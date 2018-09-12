using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Clinic
{
    public Clinic(string name, int roomsCount)
    {
        this.name = name;
        this.rooms = new List<Pet>(roomsCount);
        this.rooms.AddRange(Enumerable.Repeat(default(Pet), roomsCount));
    }

    private string name;

    public string Name
    {
        get { return name; }
        protected set { name = value; }
    }

    private List<Pet> rooms;

    public IReadOnlyCollection<Pet> Rooms
    {
        get { return rooms; }
    }

    private int CenterRoom => this.Rooms.Count / 2;

    public bool AddPet(Pet currentPet)
    {
        if (!this.HasEmptyRooms())
        {
            return false; 
        }
        for (int i = 0; i <= this.CenterRoom; i++)
        {
            var leftRoom = this.rooms[this.CenterRoom - i];
            var rigthRoom = this.rooms[this.CenterRoom + i];

            if (leftRoom == null) 
            {
                this.rooms[this.CenterRoom - i] = currentPet;
                break;
            } 
            else if (rigthRoom == null)
            {
                this.rooms[this.CenterRoom + i] = currentPet;
                break;
            }
        }

        return true;
    }
    
    public bool Release()
    {
        for (int i = 0; i < this.rooms.Count; i++)
        {
            var index = (this.CenterRoom + i) % this.rooms.Count;

            if (this.rooms[index] != null)
            {
                this.rooms[index] = null;
                return true;
            }
        }

        return false;
    }

    public bool HasEmptyRooms()
    {
        return this.rooms.Any(a => a == null);
    }

    public string GetPetPrintByRoom(int roomNumber)
    {
        var currentRoom = this.rooms[roomNumber];
        return currentRoom == null ? "Room empty" : currentRoom.ToString();
    }

    public override string ToString()
    {
        var builder = new StringBuilder();
        for (int i = 0; i < this.rooms.Count; i++)
        {
            builder.AppendLine(this.GetPetPrintByRoom(i));
        }
        return builder.ToString().TrimEnd();
    }
}