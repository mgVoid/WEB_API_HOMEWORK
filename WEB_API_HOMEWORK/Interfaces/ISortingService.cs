using System.Collections.Generic;

namespace WEB_API_HOMEWORK.Interfaces
{
    public interface ISortingService
    {
        public List<int> BubbleSort(List<int> arr);
        public List<int> InsertSort(List<int> arr);
    }
}
