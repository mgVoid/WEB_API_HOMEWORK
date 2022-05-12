using System;
using System.Collections.Generic;
using System.Diagnostics;
using WEB_API_HOMEWORK.Interfaces;

namespace WEB_API_HOMEWORK.Services
{
    public class PerformanceService : IPerformanceService
    {
        private readonly ISortingService _sortingService;
    
        public PerformanceService(ISortingService sortingService)
        {
            _sortingService = sortingService;
         
        }
        //Creates a random array with desired size(count)
        public List<int> CreateRandomList(int count)
        {
            Random random = new Random();
            List<int> testList = new List<int>();


            for (int i = 0; i < count; ++i)
                testList.Add(random.Next());

            return testList;

        }
        //Records time it takes to sort the same array created ^ with bubble and quicksort algorhithms
        public string RecordTime(List<int> testList, Func<List<int>, List<int>> func)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Reset();
            stopwatch.Start();
            func(new List<int>(testList));
            stopwatch.Stop();
            return $"{stopwatch.ElapsedMilliseconds} ms";
        }
        public string BubbleTime(List<int> testList) => RecordTime(testList, _sortingService.BubbleSort);

        public string QuickTime(List<int> testList) => RecordTime(testList, _sortingService.InsertSort);


        // Returns performance measures
        public List<string> ReturnPerformanceResults(int count)
        {

            var testList = CreateRandomList(count);

            List<string> results = new List<string>()
            {
                $"BubbleSort elapsed {BubbleTime(testList)}",
                $"InsertionSort elapsed {QuickTime(testList)}"
            };

            return results;
        }
    }
}
