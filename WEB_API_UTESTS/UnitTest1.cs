using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WEB_API_HOMEWORK.Controllers;
using WEB_API_HOMEWORK.Interfaces;
using WEB_API_HOMEWORK.Models;
using WEB_API_HOMEWORK.Services;
using Xunit;
using FluentAssertions;
using FluentAssertions.Common;
using FluentAssertions.Execution;
using System.IO;

namespace WEB_API_UTESTS
{
    public class NumberSortingTest
    {
      
        public static Number num = new Number()
        {
            IntList = new List<int> { 21, 44, 66, -3 }
        };

        NumberController _controller;
        IDataService _numberData;
        PerformanceService _performanceService;
        ISortingService _sortingService;

        public NumberSortingTest()
        {
           
            _controller = new NumberController(_numberData);
            _performanceService = new PerformanceService(_sortingService);
            _sortingService = new SortingService();

        }
        [Fact]
        public void CreateRandList()
        {
            var unsortedList = _performanceService.CreateRandomList(500);
         
            Assert.NotEqual(unsortedList, null);
            unsortedList.Should().BeOfType<List<int>>();

 
        }
        [Fact]
        public void BubbleSort_Sort()
        {
            var unsortedList = _performanceService.CreateRandomList(500);
            var sortedList = _sortingService.BubbleSort(unsortedList);
            var sortedListInsert = _sortingService.InsertSort(unsortedList);



            Assert.NotEqual(sortedList, null);
            sortedList.Should().BeOfType<List<int>>();
            sortedList.Should().BeInAscendingOrder();
            Assert.NotEqual(sortedListInsert, null);
            sortedListInsert.Should().BeOfType<List<int>>();
            sortedListInsert.Should().BeInAscendingOrder();
        }

        [Fact]
        public  void GetPerformanceMeasures()
        {
            var count = 999;
            var newPerformance = new PerformanceService(_sortingService);
            newPerformance.ReturnPerformanceResults(count);
        }
        [Fact]
        public void Get_Sorted_Number_Test()
        {
            var okResult = new NumberController(_numberData);
            okResult.GetRecentData();

            okResult.Should().NotBeNull();
        }
        [Fact]
        public string GetRecentData()
        {
            return num.ToString();
        }
        [Fact]
        public void Post_Sorted_Number_Test()
        {
            
            var createdResponse = new NumberController(_numberData);
            createdResponse.PostData(num);

            createdResponse.Should().NotBeNull();
        }
    }
}
