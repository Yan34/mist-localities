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
        
        
        //GetAverageBudget tests
        
        [Fact]
        public void GetAverageBudgetNullList()
        {
            //Arrange
            List<Locality> locs = null;
            decimal ExpectededResult = 0;
            //Act
            decimal AveragePeople = GetAverageBudget(locs);
            //Assert
            Assert.Equal(ExpectededResult, AveragePeople);
        }
        
        
        [Fact]
        public void GetAverageBudgetEmptyList()
        {
            //Arrange
            List<Locality> locs = new List<Locality>();
            decimal ExpectededResult = 0;
            //Act
            decimal AveragePeople = GetAverageBudget(locs);
            //Assert
            Assert.Equal(ExpectededResult, AveragePeople);
        }
        
        
        [Fact]
        public void GetAverageBudgetOneLocInList()
        {
            //Arrange
            List<Locality> locs = new List<Locality>();
            Locality loc = new Locality();
            loc.Budget = 100;
            locs.Add(loc);
            decimal ExpectededResult = 100;
            //Act
            decimal AverageBudget = GetAverageBudget(locs);
            //Assert
            Assert.Equal(ExpectededResult, AverageBudget);
        }
        
        
        [Fact]
        public void GetAverageBudgetMultipleLocsInList()
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
                loc.Budget = rand;
                locs.Add(loc);
            }
            decimal ExpectededResult = decimal.Round( decimal.Divide(sum, count), 3 );
            //Act
            decimal AverageBudget = GetAverageBudget(locs);
            //Assert
            Assert.Equal(ExpectededResult, AverageBudget);
        }
        
        
        //GetFormattedDecimal tests
        
        [Fact]
        public void GetFormattedDecimalZero()
        {
            //Arrange
            decimal input = 0;
            string ExpectedResult = "0";
            //Act
            string FormattedDecimal = GetFormattedDecimal(input);
            //Assert
            Assert.Equal(ExpectedResult, FormattedDecimal);
        }

        [Fact]
        public void GetFormattedDecimalIntOneDigitNotZero()
        {
            //Arrange
            decimal input = 5;
            string ExpectedResult = "5";
            //Act
            string FormattedDecimal = GetFormattedDecimal(input);
            //Assert
            Assert.Equal(ExpectedResult, FormattedDecimal);
        }

        [Fact]
        public void GetFormattedDecimalIntMultipleDigitEndsZero()
        {
            //Arrange
            decimal input = 150;
            string ExpectedResult = "150";
            //Act
            string FormattedDecimal = GetFormattedDecimal(input);
            //Assert
            Assert.Equal(ExpectedResult, FormattedDecimal);
        }

        [Fact]
        public void GetFormattedDecimalIntMultipleDigitEndsOnlyZero()
        {
            //Arrange
            decimal input = 200;
            string ExpectedResult = "200";
            //Act
            string FormattedDecimal = GetFormattedDecimal(input);
            //Assert
            Assert.Equal(ExpectedResult, FormattedDecimal);
        }

        [Fact]
        public void GetFormattedDecimalIntMultipleDigitEndsNotZero()
        {
            //Arrange
            decimal input = 3946;
            string ExpectedResult = "3946";
            //Act
            string FormattedDecimal = GetFormattedDecimal(input);
            //Assert
            Assert.Equal(ExpectedResult, FormattedDecimal);
        }

        [Fact]
        public void GetFormattedDecimalDoubleOneDigitInMantissa()
        {
            //Arrange
            decimal input = new decimal(1.5);
            string ExpectedResult = "1.5";
            //Act
            string FormattedDecimal = GetFormattedDecimal(input);
            //Assert
            Assert.Equal(ExpectedResult, FormattedDecimal);
        }

        [Fact]
        public void GetFormattedDecimalDoubleTwoDigitsInMantissa()
        {
            //Arrange
            decimal input = new decimal(3.46);
            string ExpectedResult = "3.46";
            //Act
            string FormattedDecimal = GetFormattedDecimal(input);
            //Assert
            Assert.Equal(ExpectedResult, FormattedDecimal);
        }

        [Fact]
        public void GetFormattedDecimalDoubleMultipleDigitsInMantissa()
        {
            //Arrange
            decimal input = new decimal(15.67843);
            string ExpectedResult = "15.67843";
            //Act
            string FormattedDecimal = GetFormattedDecimal(input);
            //Assert
            Assert.Equal(ExpectedResult, FormattedDecimal);
        }
    }
}