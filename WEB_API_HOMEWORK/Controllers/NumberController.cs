using Microsoft.AspNetCore.Mvc;
using WEB_API_HOMEWORK.Models;
using System;
using WEB_API_HOMEWORK.Interfaces;


namespace WEB_API_HOMEWORK.Controllers
{
    [ApiController]
    public class NumberController : ControllerBase
    {
        private readonly IDataService _numberData;
        public NumberController(IDataService numberData)
        {
            _numberData = numberData;
        }

        [HttpGet]
        [Route("api/getdata")]
        public ActionResult GetRecentData()
        {   // To fetch sorted numbers from the recently posted text file
            try
            {

                _numberData.GetRecentData();
            }
            catch (Exception e)
            {
                return BadRequest("Error while fetching the latest data: " + e.Message);
            }
            return Ok(_numberData.GetRecentData());
        }

        [HttpPost]
        [Route("api/postdata")]
        public IActionResult PostData(Number num)
        {

            try
            {
                // To post data to text file
                _numberData.PostData(num);
               
            }
            catch (Exception e)
            {
                return BadRequest("Error while fetching the latest data: " + e.Message);
            }

            return Accepted("Data's posted to the text file: "+ num);
        }

       
    }
}

