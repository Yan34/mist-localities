using System;
using System.Collections.Generic;
using LocalityBaseNetCore;
using LocalityBaseNetCore.Models;
using Xunit;
using static LocalityBaseNetCore.LocalitiesStats;


namespace LocalityBaseTest
{
    public class LocalitiesStatsTests
    {
        //GetOverallPeople tests
        
        [Fact]
        public void GetOverallPeopleNullList()
        {
            //Arrange
            List<Locality> locs = null;
            decimal ExpectededResult = 0;
            //Act
            decimal OverallPeople = GetOverallPeople(locs);
            //Assert
            Assert.Equal(ExpectededResult, OverallPeople);
        }
        
        
        [Fact]
        public void GetOverallPeopleEmptyList()
        {
            //Arrange
            List<Locality> locs = new List<Locality>();
            decimal ExpectededResult = 0;
            //Act
            decimal OverallPeople = GetOverallPeople(locs);
            //Assert
            Assert.Equal(ExpectededResult, OverallPeople);
        }
        
        
        [Fact]
        public void GetOverallPeopleOneLocInList()
        {
            //Arrange
            List<Locality> locs = new List<Locality>();
            Locality loc = new Locality();
            loc.PeopleCount = 100;
            locs.Add(loc);
            decimal ExpectededResult = 100;
            //Act
            decimal OverallPeople = GetOverallPeople(locs);
            //Assert
            Assert.Equal(ExpectededResult, OverallPeople);
        }
        
        
        [Fact]
        public void GetOverallPeopleMultipleLocsInList()
        {
            //Arrange
            List<Locality> locs = new List<Locality>();
            decimal ExpectededResult = 0;
            for (int i = 10; i <= 100; i+=10)
            {
                Locality loc = new Locality();
                decimal rand = new decimal( new Random().NextDouble() * i );
                ExpectededResult += rand;
                loc.PeopleCount = rand;
                locs.Add(loc);
            }
            //Act
            decimal OverallPeople = GetOverallPeople(locs);
            //Assert
            Assert.Equal(ExpectededResult, OverallPeople);
        }
        
        
        //GetAveragePeople tests
        
        [Fact]
        public void GetAveragePeopleNullList()
        {
            //Arrange
            List<Locality> locs = null;
            decimal ExpectededResult = 0;
            //Act
            decimal AveragePeople = GetAveragePeople(locs);
            //Assert
            Assert.Equal(ExpectededResult, AveragePeople);
        }
        
        
        [Fact]
        public void GetAveragePeopleEmptyList()
        {
            //Arrange
            List<Locality> locs = new List<Locality>();
            decimal ExpectededResult = 0;
            //Act
            decimal AveragePeople = GetAveragePeople(locs);
            //Assert
            Assert.Equal(ExpectededResult, AveragePeople);
        }
        
        
        [Fact]
        public void GetAveragePeopleOneLocInList()
        {
            //Arrange
            List<Locality> locs = new List<Locality>();
            Locality loc = new Locality();
            loc.PeopleCount = 100;
            locs.Add(loc);
            decimal ExpectededResult = 100;
            //Act
            decimal AveragePeople = GetAveragePeople(locs);
            //Assert
            Assert.Equal(ExpectededResult, AveragePeople);
        }
        
        
        [Fact]
        public void GetAveragePeopleMultipleLocsInList()
        {
            //Arrange
            List<Locality> locs = new List<Locality>();
            decimal sum = 0;
            int count = 10;
            for (int i = 10; i <= 100; i+=10)
            {
                Locality loc = new Locality();
                decimal rand = new decimal( new Random().NextDouble() * i );
                sum += rand;
                loc.PeopleCount = rand;
                locs.Add(loc);
            }
            decimal ExpectededResult = decimal.Round( decimal.Divide(sum, count), 3 );
            //Act
            decimal AveragePeople = GetAveragePeople(locs);
            //Assert
            Assert.Equal(ExpectededResult, AveragePeople);
        }
        
        
        //GetOverallBudget tests
        
        [Fact]
        public void GetOverallBudgetNullList()
        {
            //Arrange
            List<Locality> locs = null;
            decimal ExpectededResult = 0;
            //Act
            decimal OverallPeople = GetOverallBudget(locs);
            //Assert
            Assert.Equal(ExpectededResult, OverallPeople);
        }
        
        
        [Fact]
        public void GetOverallBudgetEmptyList()
        {
            //Arrange
            List<Locality> locs = new List<Locality>();
            decimal ExpectededResult = 0;
            //Act
            decimal OverallPeople = GetOverallBudget(locs);
            //Assert
            Assert.Equal(ExpectededResult, OverallPeople);
        }
        
        
        [Fact]
        public void GetOverallBudgetOneLocInList()
        {
            //Arrange
            List<Locality> locs = new List<Locality>();
            Locality loc = new Locality();
            loc.Budget = 100;
            locs.Add(loc);
            decimal ExpectededResult = 100;
            //Act
            decimal OverallPeople = GetOverallBudget(locs);
            //Assert
            Assert.Equal(ExpectededResult, OverallPeople);
        }
        
        
        [Fact]
        public void GetOverallBudgetMultipleLocsInList()
        {
            //Arrange
            List<Locality> locs = new List<Locality>();
            decimal ExpectededResult = 0;
            for (int i = 10; i <= 100; i+=10)
            {
                Locality loc = new Locality();
                decimal rand = new decimal( new Random().NextDouble() * i );
                ExpectededResult += rand;
                loc.Budget = rand;
                locs.Add(loc);
            }
            //Act
            decimal OverallPeople = GetOverallBudget(locs);
            //Assert
            Assert.Equal(ExpectededResult, OverallPeople);
        }
    }
}