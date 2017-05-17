using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;

namespace LogMicroService.Controllers
{
   
    public class LogSystemController : Controller
    {
       
        
        [HttpPost]
        public void NewMessage([FromBody]LogMessage message)
        {
            String strJson = JsonConvert.SerializeObject(message);
            Console.WriteLine(strJson);
            var address = Request.HttpContext.Connection.RemoteIpAddress;
        
        }



    }
}
