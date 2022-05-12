using WEB_API_HOMEWORK.Models;
namespace WEB_API_HOMEWORK.Interfaces
{
    public interface IDataService
    {
        public Number PostData(Number num);

        public string GetRecentData();

    }

}
