using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using MySql.Data.MySqlClient;
using Tamagatchi.Models;
using Tamagatchi;

namespace Tamagatchi.Tests
{
  [TestClass]
  public class BaseTamagatchiTests : IDisposable
  {
    public void Dispose()
    {
      BaseTamagatchi.ClearAll();
    }
    
    public BaseTamagatchiTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=Epicodus!;port=3306;database=minion_test;";
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyListFromDatabase_TamagatchiList()
    {
      List<BaseTamagatchi> newTama = new List<BaseTamagatchi> {};
      List<BaseTamagatchi> result = BaseTamagatchi.GetAll();
      CollectionAssert.AreEqual(newTama, result);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfNamesAreTheSame_BaseTamagatchi()
    {
      BaseTamagatchi oneTama = new BaseTamagatchi("Name");
      BaseTamagatchi twoTama = new BaseTamagatchi("Name");
      
      Assert.AreEqual(oneTama, twoTama);
    }

    [TestMethod]
    public void Save_SavesToDatabase_BaseTamagatchiList()
    {
      BaseTamagatchi oneTama = new BaseTamagatchi("Name");
      oneTama.Save();
      List<BaseTamagatchi> result = BaseTamagatchi.GetAll();
      List<BaseTamagatchi> testList = new List<BaseTamagatchi>{oneTama};
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsItems_BaseTamagatchiList()
    {
      BaseTamagatchi oneTama = new BaseTamagatchi("Name");
      oneTama.Save();
      BaseTamagatchi twoTama = new BaseTamagatchi("Name2");
      twoTama.Save();
      List<BaseTamagatchi> result = BaseTamagatchi.GetAll();
      Console.WriteLine(result[1].Id);
      List<BaseTamagatchi> testList = new List<BaseTamagatchi>{oneTama, twoTama};
      Assert.AreEqual(testList, twoTama);
    }
  }
}