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
            decimal expectededResult = 0;
            //Act
            decimal overallPeople = GetOverallPeople(locs);
            //Assert
            Assert.Equal(expectededResult, overallPeople);
        }
        
        
        [Fact]
        public void GetOverallPeopleEmptyList()
        {
            //Arrange
            List<Locality> locs = new List<Locality>();
            decimal expectededResult = 0;
            //Act
            decimal overallPeople = GetOverallPeople(locs);
            //Assert
            Assert.Equal(expectededResult, overallPeople);
        }
        
        
        [Fact]
        public void GetOverallPeopleOneLocInList()
        {
            //Arrange
            List<Locality> locs = new List<Locality>();
            Locality loc = new Locality();
            loc.PeopleCount = 100;
            locs.Add(loc);
            decimal expectededResult = 100;
            //Act
            decimal overallPeople = GetOverallPeople(locs);
            //Assert
            Assert.Equal(expectededResult, overallPeople);
        }
        
        
        [Fact]
        public void GetOverallPeopleMultipleLocsInList()
        {
            //Arrange
            List<Locality> locs = new List<Locality>();
            decimal expectededResult = 0;
            for (int i = 10; i <= 100; i+=10)
            {
                Locality loc = new Locality();
                decimal rand = new decimal( new Random().NextDouble() * i );
                expectededResult += rand;
                loc.PeopleCount = rand;
                locs.Add(loc);
            }
            //Act
            decimal overallPeople = GetOverallPeople(locs);
            //Assert
            Assert.Equal(expectededResult, overallPeople);
        }
        
        
        //GetAveragePeople tests
        
        [Fact]
        public void GetAveragePeopleNullList()
        {
            //Arrange
            List<Locality> locs = null;
            decimal expectededResult = 0;
            //Act
            decimal averagePeople = GetAveragePeople(locs);
            //Assert
            Assert.Equal(expectededResult, averagePeople);
        }
        
        
        [Fact]
        public void GetAveragePeopleEmptyList()
        {
            //Arrange
            List<Locality> locs = new List<Locality>();
            decimal expectededResult = 0;
            //Act
            decimal averagePeople = GetAveragePeople(locs);
            //Assert
            Assert.Equal(expectededResult, averagePeople);
        }
        
        
        [Fact]
        public void GetAveragePeopleOneLocInList()
        {
            //Arrange
            List<Locality> locs = new List<Locality>();
            Locality loc = new Locality();
            loc.PeopleCount = 100;
            locs.Add(loc);
            decimal expectededResult = 100;
            //Act
            decimal averagePeople = GetAveragePeople(locs);
            //Assert
            Assert.Equal(expectededResult, averagePeople);
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
            decimal expectededResult = decimal.Round( decimal.Divide(sum, count), 3 );
            //Act
            decimal averagePeople = GetAveragePeople(locs);
            //Assert
            Assert.Equal(expectededResult, averagePeople);
        }
        
        
        //GetOverallBudget tests
        
        [Fact]
        public void GetOverallBudgetNullList()
        {
            //Arrange
            List<Locality> locs = null;
            decimal expectededResult = 0;
            //Act
            decimal overallPeople = GetOverallBudget(locs);
            //Assert
            Assert.Equal(expectededResult, overallPeople);
        }
        
        
        [Fact]
        public void GetOverallBudgetEmptyList()
        {
            //Arrange
            List<Locality> locs = new List<Locality>();
            decimal expectededResult = 0;
            //Act
            decimal overallPeople = GetOverallBudget(locs);
            //Assert
            Assert.Equal(expectededResult, overallPeople);
        }
        
        
        [Fact]
        public void GetOverallBudgetOneLocInList()
        {
            //Arrange
            List<Locality> locs = new List<Locality>();
            Locality loc = new Locality();
            loc.Budget = 100;
            locs.Add(loc);
            decimal expectededResult = 100;
            //Act
            decimal overallPeople = GetOverallBudget(locs);
            //Assert
            Assert.Equal(expectededResult, overallPeople);
        }
        
        
        [Fact]
        public void GetOverallBudgetMultipleLocsInList()
        {
            //Arrange
            List<Locality> locs = new List<Locality>();
            decimal expectededResult = 0;
            for (int i = 10; i <= 100; i+=10)
            {
                Locality loc = new Locality();
                decimal rand = new decimal( new Random().NextDouble() * i );
                expectededResult += rand;
                loc.Budget = rand;
                locs.Add(loc);
            }
            //Act
            decimal overallPeople = GetOverallBudget(locs);
            //Assert
            Assert.Equal(expectededResult, overallPeople);
        }
        
        
        //GetAverageBudget tests
        
        [Fact]
        public void GetAverageBudgetNullList()
        {
            //Arrange
            List<Locality> locs = null;
            decimal expectededResult = 0;
            //Act
            decimal averagePeople = GetAverageBudget(locs);
            //Assert
            Assert.Equal(expectededResult, averagePeople);
        }
        
        
        [Fact]
        public void GetAverageBudgetEmptyList()
        {
            //Arrange
            List<Locality> locs = new List<Locality>();
            decimal expectededResult = 0;
            //Act
            decimal averagePeople = GetAverageBudget(locs);
            //Assert
            Assert.Equal(expectededResult, averagePeople);
        }
        
        
        [Fact]
        public void GetAverageBudgetOneLocInList()
        {
            //Arrange
            List<Locality> locs = new List<Locality>();
            Locality loc = new Locality();
            loc.Budget = 100;
            locs.Add(loc);
            decimal expectededResult = 100;
            //Act
            decimal averageBudget = GetAverageBudget(locs);
            //Assert
            Assert.Equal(expectededResult, averageBudget);
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
            decimal expectededResult = decimal.Round( decimal.Divide(sum, count), 3 );
            //Act
            decimal averageBudget = GetAverageBudget(locs);
            //Assert
            Assert.Equal(expectededResult, averageBudget);
        }
        
        
        //GetFormattedDecimal tests
        
        [Fact]
        public void GetFormattedDecimalZero()
        {
            //Arrange
            decimal input = 0;
            string expectedResult = "0";
            //Act
            string formattedDecimal = GetFormattedDecimal(input);
            //Assert
            Assert.Equal(expectedResult, formattedDecimal);
        }

        [Fact]
        public void GetFormattedDecimalIntOneDigitNotZero()
        {
            //Arrange
            decimal input = 5;
            string expectedResult = "5";
            //Act
            string formattedDecimal = GetFormattedDecimal(input);
            //Assert
            Assert.Equal(expectedResult, formattedDecimal);
        }

        [Fact]
        public void GetFormattedDecimalIntMultipleDigitEndsZero()
        {
            //Arrange
            decimal input = 150;
            string expectedResult = "150";
            //Act
            string formattedDecimal = GetFormattedDecimal(input);
            //Assert
            Assert.Equal(expectedResult, formattedDecimal);
        }

        [Fact]
        public void GetFormattedDecimalIntMultipleDigitEndsOnlyZero()
        {
            //Arrange
            decimal input = 200;
            string expectedResult = "200";
            //Act
            string formattedDecimal = GetFormattedDecimal(input);
            //Assert
            Assert.Equal(expectedResult, formattedDecimal);
        }

        [Fact]
        public void GetFormattedDecimalIntMultipleDigitEndsNotZero()
        {
            //Arrange
            decimal input = 3946;
            string expectedResult = "3946";
            //Act
            string formattedDecimal = GetFormattedDecimal(input);
            //Assert
            Assert.Equal(expectedResult, formattedDecimal);
        }

        [Fact]
        public void GetFormattedDecimalDoubleOneDigitInMantissa()
        {
            //Arrange
            decimal input = new decimal(1.5);
            string expectedResult = "1.5";
            //Act
            string formattedDecimal = GetFormattedDecimal(input);
            //Assert
            Assert.Equal(expectedResult, formattedDecimal);
        }

        [Fact]
        public void GetFormattedDecimalDoubleTwoDigitsInMantissa()
        {
            //Arrange
            decimal input = new decimal(3.46);
            string expectedResult = "3.46";
            //Act
            string formattedDecimal = GetFormattedDecimal(input);
            //Assert
            Assert.Equal(expectedResult, formattedDecimal);
        }

        [Fact]
        public void GetFormattedDecimalDoubleMultipleDigitsInMantissa()
        {
            //Arrange
            decimal input = new decimal(15.67843);
            string expectedResult = "15.67843";
            //Act
            string formattedDecimal = GetFormattedDecimal(input);
            //Assert
            Assert.Equal(expectedResult, formattedDecimal);
        }
    }
}