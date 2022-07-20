using System;
using System.Collections.Generic;

namespace Tamagatchi.Models
{
  public class BaseTamagatchi
  {
    public string Name { get; set; }
    public int Hunger { get; set; }
    public int Happy { get; set; }
    public int Training { get; set; }
    public int Discipline { get; set; }
    public int Age { get; set; }
    public int Height { get; set; }
    public int Weight { get; set; }
    public int Id { get; set; }
    public string Status { get; set; }
    public string CheckFood { get; set; }
    public string CheckHappy { get; set; }
    private static List<BaseTamagatchi> _types = new List<BaseTamagatchi> {};

    public BaseTamagatchi(string name)
    {
      Name = name;
      //random 1=10 for Hunger, Happy, Training, and Discipline
      Hunger = this.GetStat(1, 10);
      Happy = this.GetStat(1, 10);
      Training = this.GetStat(1, 10);
      Discipline = this.GetStat(1, 10);
      Age = 0; //connect to local machine time
      //random 25-40 for height
      Height = this.GetStat(25, 40);
      //random 20-30 for weight
      Weight = this.GetStat(20, 30);

      _types.Add(this);
      Status = this.CheckAlive();
      CheckFood = this.Feed();
      CheckHappy = this.MakeHappy();
      Id = _types.Count;
    }

    public static List<BaseTamagatchi> GetAll()
    {
        return _types;
    }

    public int GetStat(int min, int max)
    {
      Random rnd = new Random();
      int stat = rnd.Next(min, max);
      return stat;
    }

    public static BaseTamagatchi Find(int searchId)
    {
      return _types[searchId - 1];
    }

    public string CheckAlive()
    { //true == alive && false == dead;
      if (Hunger + Happy == 0)
      {
        return "Dead";
      }
      else
      {
        return "Alive";
      }
    }

    public string Feed()
    {
      if (Hunger < 10 && Hunger > 0)
        {
          Hunger = Hunger + 1;
          CheckFood = "You fed " + Name;
          return CheckFood;
        }
        else if (Hunger == 10)
        {
          CheckFood = Name + " is full!";
          return CheckFood;
        }
        else
        {
          CheckFood = Name + " is " + Status + " you can't feed a corpse.";
          return CheckFood;
        }
    }

    public string MakeHappy()
    {
        if (Happy < 10 && Happy > 0)
        {
          Happy = Happy + 1;
          CheckHappy = "You fed " + Name;
          return CheckHappy;
        }
        else if (Happy == 10)
        {
          CheckHappy = Name + " is full!";
          return CheckHappy;
        }
        else
        {
          CheckHappy = Name + " is " + Status + " you can't feed a corpse.";
          return CheckHappy;
        }
    }

  }
}