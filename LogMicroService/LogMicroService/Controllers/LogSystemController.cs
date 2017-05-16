using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace LogMicroService.Controllers
{
   
    public class LogSystemController : Controller
    {
       
        
        [HttpPost]
        public void NewMessage([FromBody]JObject value)
        {
            Console.WriteLine(value);
        }


    }
}
