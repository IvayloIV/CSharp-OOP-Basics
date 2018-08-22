using System;
using System.Collections.Generic;
using System.Text;


public class PriceCalculator
{
    private decimal pricePerDay;
    private int days;
    private Season season;
    private Discount discount;

    public decimal PricePerDay
    {
        get { return pricePerDay; }
        set { pricePerDay = value; }
    }

    public int Days
    {
        get { return days; }
        set { days = value; }
    }

    public Season Season
    {
        get { return season; }
        set { season = value; }
    }

    public Discount Discount
    {
        get { return discount; }
        set { discount = value; }
    }

    public PriceCalculator(string[] info)
    {
        this.PricePerDay = decimal.Parse(info[0]);
        this.Days = int.Parse(info[1]);
        this.Season = Enum.Parse<Season>(info[2]);
        this.Discount = Discount.None;
        if (info.Length > 3)
        {
            this.Discount = Enum.Parse<Discount>(info[3]);
        }
    }

    public decimal CalculatePrice()
    { 
        var price = this.PricePerDay * this.Days * (decimal)this.Season;
        var currentDiscount = (decimal)(100 - this.Discount) / 100;
        return price * currentDiscount;
    }
}