using System;
using System.Timers;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using MySql.Data.MySqlClient;

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
    public int StartTime { get; set; }
    public int CurrentTime { get; set; }

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

      Status = this.CheckAlive();
      CheckFood = this.Feed();
      CheckHappy = this.MakeHappy();
      // Id = _types.Count;

      DateTime start = DateTime.Now;
      
      StartTime = (start.Hour * 100) + start.Minute;
    }

    public BaseTamagatchi(string name, int id)
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

      Status = this.CheckAlive();
      CheckFood = this.Feed();
      CheckHappy = this.MakeHappy();
      Id = id;

      DateTime start = DateTime.Now;
      
      StartTime = (start.Hour * 100) + start.Minute;
    }

    public override bool Equals(System.Object otherTama)
      {
        if (!(otherTama is BaseTamagatchi))
        {
          return false;
        }
        else
        {
          BaseTamagatchi newTama = (BaseTamagatchi) otherTama;
          bool idEquality = (this.Id == newTama.Id);
          bool nameEquality = (this.Name == newTama.Name);
          return (nameEquality && idEquality);
        }
      }


    public static List<BaseTamagatchi> GetAll()
    {
      List<BaseTamagatchi> allMinions = new List<BaseTamagatchi> { };
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = "SELECT * FROM minion;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
          int minionId = rdr.GetInt32(0);
          string minionName = rdr.GetString(1);
          
          BaseTamagatchi newTama = new BaseTamagatchi(minionName, minionId);
          // string minionHunger = newTama.Hunger;
          //int minionHunger = rdr.GetInt32(2);
          allMinions.Add(newTama);
      }
      conn.Close();
      if (conn != null)
      {
          conn.Dispose();
      }
      return allMinions;
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;

      cmd.CommandText = "INSERT INTO minion (minionName) VALUES (@BaseTamagatchi.Name);";
      MySqlParameter param = new MySqlParameter();
      param.ParameterName = "@BaseTamagatchi.Name";
      param.Value = this.Name;
      cmd.Parameters.Add(param);    
      cmd.ExecuteNonQuery();
      Id = (int) cmd.LastInsertedId;

      // End new code

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public int GetStat(int min, int max)
    {
      Random rnd = new Random();
      int stat = rnd.Next(min, max);
      return stat;
    }

    public static BaseTamagatchi Find(int searchId)
    {
      BaseTamagatchi placeholder = new BaseTamagatchi("minion");
      return placeholder;
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
      Status = this.CheckAlive();
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
      Status = this.CheckAlive();
      if (Happy < 10 && Happy > 0)
      {
        Happy = Happy + 1;
        CheckHappy = "You played with " + Name;
        return CheckHappy;
      }
      else if (Happy == 10)
      {
        CheckHappy = Name + " is happy!";
        return CheckHappy;
      }
      else
      {
        CheckHappy = Name + " is " + Status + "! Please don't touch a dead body.";
        return CheckHappy;
      }
    }

    public int GetTime()
    {
      DateTime start = DateTime.Now;
      int current = (start.Hour * 100) + start.Minute;
      return current;
    }

    public int GetAge()
    {
        CurrentTime = this.GetTime();

          //  57  = 1604    - 1547;
        int _age = CurrentTime - StartTime;
        Age = _age;
        return Age;
    }

    public void Timer()
    {
      System.Timers.Timer newTimer = new System.Timers.Timer();
      newTimer.Interval = 60000;
      newTimer.Elapsed += new ElapsedEventHandler(Kill);
      newTimer.AutoReset = true;
      newTimer.Enabled = true;
    }

    private void Kill(object source, ElapsedEventArgs e)
    {
      if( Hunger > 0 && Happy > 0)
      {
        Hunger = Hunger - 1;
        Happy = Happy - 1;
      }
      else
      {
        Hunger = 0;
        Happy = 0;
      }
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = "DELETE FROM minion;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
    

  }
}