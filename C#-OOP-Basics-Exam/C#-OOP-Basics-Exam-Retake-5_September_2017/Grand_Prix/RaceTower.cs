using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RaceTower
{
    public RaceTower()
    {
        this.sesuccessDrivers = new List<Driver>();
        this.failedDrivers = new Stack<Driver>();
        this.currentLab = 0;
        this.weather = "Sunny";
    }

    public int lapsNumber;
    private int trackLength;
    private List<Driver> sesuccessDrivers;
    private Stack<Driver> failedDrivers;
    public int currentLab;
    private string weather;

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.lapsNumber = lapsNumber;
        this.trackLength = trackLength;
    }

    public void RegisterDriver(List<string> commandArgs)
    {
        try
        {
            sesuccessDrivers.Add(DriverFactory.CreateDriver(commandArgs));
        }
        catch (ArgumentException) { }
    }

    public void DriverBoxes(List<string> commandArgs)
    {
        var reasonToBox = commandArgs[0];
        var driverName = commandArgs[1];
        var currentDriver = sesuccessDrivers.FirstOrDefault(a => a.Name == driverName);
        currentDriver.IncreaseTotalTime(20);
        if (reasonToBox == "Refuel")
        {
            var fuelAmount = double.Parse(commandArgs[2]);
            currentDriver.Car.IncreaseFuelAmount(fuelAmount);
        }
        else
        {
            commandArgs.Insert(0, string.Empty);
            commandArgs.Insert(0, string.Empty);
            currentDriver.Car.ChangeTyre(TyreFactory.CreateTyre(commandArgs));
        }
    }

    public string CompleteLaps(List<string> commandArgs)
    {
        var numberOfLaps = int.Parse(commandArgs[0]);
        var builder = new StringBuilder();
        if (numberOfLaps + currentLab > lapsNumber)
        {
            return $"There is no time! On lap {currentLab}.";
        }
        for (int lab = 0; lab < numberOfLaps; lab++)
        {
            for (var index = 0; index < sesuccessDrivers.Count; index++)
            {
                var driver = sesuccessDrivers[index];
                try
                {
                    var time = 60 / (trackLength / driver.Speed);
                    driver.IncreaseTotalTime(time);
                    driver.Car.ReduceFuelAmount(trackLength * driver.FuelConsumptionPerKm);
                    driver.Car.Tyre.MakeALap();
                }
                catch (ArgumentException err)
                {
                    driver.Fail(err.Message);
                    failedDrivers.Push(driver);
                    sesuccessDrivers.Remove(driver);
                    index--;
                }
            }

            this.currentLab++;

            var orderedDrivers = sesuccessDrivers.OrderByDescending(a => a.TotalTime).ToList();
            for (int i = 0; i < orderedDrivers.Count - 1; i++)
            {
                var overtakeDriver = orderedDrivers[i];
                var behindDriver = orderedDrivers[i + 1];
                var success = this.TryOverTake(overtakeDriver, behindDriver);

                if (success)
                {
                    i++;
                    builder.AppendLine($"{overtakeDriver.Name} has overtaken " +
                     $"{behindDriver.Name} on lap {this.currentLab}.");
                }
                else
                {
                    if (!overtakeDriver.IsDrive)
                    {
                        this.failedDrivers.Push(overtakeDriver);
                        this.sesuccessDrivers.Remove(overtakeDriver);
                    }
                }
            }

        }
        return builder.ToString().TrimEnd();
    }

    internal string GetWinner()
    {
        var winner = this.sesuccessDrivers.OrderBy(a => a.TotalTime).First();
        return $"{winner.Name} wins the race for {winner.TotalTime.ToString("f3")} seconds.";
    }

    private bool TryOverTake(Driver overtakingDriver, Driver targetDriver)
    {
        double timeDiff = overtakingDriver.TotalTime - targetDriver.TotalTime;

        bool aggressiveDriver = overtakingDriver is AggressiveDriver &&
            overtakingDriver.Car.Tyre is UltrasoftTyre;

        bool enduranceDriver = overtakingDriver is EnduranceDriver &&
            overtakingDriver.Car.Tyre is HardTyre;

        bool crash = (aggressiveDriver && this.weather == "Foggy") ||
            (enduranceDriver && this.weather == "Rainy");

        if ((aggressiveDriver || enduranceDriver) && timeDiff <= 3)
        {
            if (crash)
            {
                overtakingDriver.Crash();
                return false;
            }

            overtakingDriver.DecreaseTotalTime(3);
            targetDriver.IncreaseTotalTime(3);
            return true;
        }
        else if (timeDiff <= 2)
        {
            overtakingDriver.DecreaseTotalTime(2);
            targetDriver.IncreaseTotalTime(2);
            return true;
        }

        return false;
    }

    public string GetLeaderboard()
    {
        var builder = new StringBuilder();
        builder.AppendLine($"Lap {currentLab}/{lapsNumber}");
        var counter = 1;
        var totalDrivers = sesuccessDrivers
            .OrderBy(a => a.TotalTime)
            .Concat(failedDrivers);

        foreach (var driver in totalDrivers)
        {
            builder.AppendLine($"{counter++} {driver.ToString()}");
        }
        return builder.ToString().TrimEnd();
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        var weather = commandArgs[0];
        this.weather = weather;
    }
}