using System;
using System.Collections.Generic;
namespace WEB_API_HOMEWORK.Interfaces
{
    public interface IPerformanceService
    {
        public string RecordTime(List<int> testList, Func<List<int>, List<int>> Func);
        public string BubbleTime(List<int> testList);
        public string QuickTime(List<int> testList);
        public List<int> CreateRandomList(int count);

        public List<string> ReturnPerformanceResults(int count);
    }
}
