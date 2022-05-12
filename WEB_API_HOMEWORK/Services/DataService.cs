using WEB_API_HOMEWORK.Models;
using System.IO;
using System.Linq;
using System;
using WEB_API_HOMEWORK.Interfaces;


namespace WEB_API_HOMEWORK.Services
{
    public class DataService : IDataService
    {

        //Default storage for generated text files
        public static readonly string folder = @"C:\AppData\";
        public readonly string path = folder + $@"{DateTime.Now.Ticks}.txt";
        private readonly ISortingService _sortingService;
        public DataService(ISortingService sortingService)
        {
            _sortingService = sortingService;
        }
        //Fetching the latest saved file
        public string GetRecentData()
        {
            Directory.CreateDirectory(folder);

           

            var files = new DirectoryInfo(folder);
            var myFile = files.GetFiles()
                .OrderByDescending(f => f.LastWriteTime)
                .FirstOrDefault();

            string txt = " ";
            try
            {
                if (myFile == null)
                {
                    return "Folder is empty. Please POST data first";
                }
                else
                {
                    txt = System.IO.File.ReadAllText(myFile.FullName);
                }
            }
            catch (Exception e)
            {
                return e.Message + "Folder is empty. Please POST data first";
            }

            return txt;
        }

        //Posting to a file with a generated name
        public Number PostData(Number num)
        {
            System.IO.Directory.CreateDirectory(folder);
            int length = num.IntList.Count;

            num.IntList = _sortingService.BubbleSort(num.IntList);


            var files = new DirectoryInfo(folder);
            var myFile = files.GetFiles()
                .OrderByDescending(f => f.LastWriteTime)
                .FirstOrDefault();
            string path = files + $@"{DateTime.Now.Ticks}.txt";
            if (myFile == null)
            {

                using (StreamWriter sw = System.IO.File.CreateText(path))
                {
                    for (int i = 0; i < length; i++)
                    {
                        sw.Write(num.IntList[i] + " ");

                    }
                }
            }
            else
            {

                path = files + $@"{DateTime.Now.Ticks}.txt";

                using (StreamWriter sw = System.IO.File.CreateText(path))
                {
                    for (int i = 0; i < length; i++)
                    {
                        sw.Write(num.IntList[i] + " ");

                    }

                }
            }
            return num;
        }

    }



}

