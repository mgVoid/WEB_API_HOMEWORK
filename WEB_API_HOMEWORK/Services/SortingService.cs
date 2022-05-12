using System.Collections.Generic;
using WEB_API_HOMEWORK.Interfaces;

namespace WEB_API_HOMEWORK.Services
{
    public class SortingService : ISortingService
    {

       

        public List<int> BubbleSort(List<int> arr)
        {
            int temp;
            for (int j = 0; j <= arr.Count - 2; j++)
            {
                for (int i = 0; i <= arr.Count - 2; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        temp = arr[i + 1];
                        arr[i + 1] = arr[i];
                        arr[i] = temp;
                    }
                }
            }
            return arr;
        }

        public List<int> InsertSort(List<int> arr)
        {
            for (var i = 0; i < arr.Count; i++)
            {
                var key = arr[i];
                var j = i;
                while (j > 0 && arr[j - 1] > key)
                {
                    var swapValue = arr[j - 1];
                    arr[j - 1] = arr[j];
                    arr[j] = swapValue;
                    j--;
                }

                arr[j] = key;
            }

            return arr;
        }

    }


}

