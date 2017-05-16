using System;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace NetLogSystem.NetCoreLib
{

    public class NetLogSystem
    {

        private static Task taskLogSystem = null;
        private static MyMessageBag messageBag = null;

        private static Object _Lock = new object();

        public static  void Send(LogMessage newMessage)
        {
            lock (_Lock)
            {
                if (taskLogSystem == null)
                {
                    ewh = new EventWaitHandle(false, EventResetMode.AutoReset);
                    messageBag = new MyMessageBag();
                    taskLogSystem = new Task(() => SendMessages());
                    taskLogSystem.Start();
                }
            }
            messageBag.AddMessage(newMessage);
            ewh.Set();
        }


        private static EventWaitHandle ewh;


        private static void SendMessages()
        {
           while ( true )
            {
                if (messageBag.Count > 0)
                {
                    LogMessage message = null;
                    messageBag.TryTake(out message);
                    if (message != null)
                    {
                        SendMessageToServer(message);
                    }
                } else
                {
                    ewh.WaitOne();
                }
               
            }
        }

         


        public static String NetAdderss { get; set;  }
        public static String NetUserName { get; set;  }
        public static String NetPassword { get; set; }


        private static void SendMessageToServer(LogMessage message)
        {
            try
            {


                String strJson =  JsonConvert.SerializeObject(message);

                HttpClient httpClient = new HttpClient();
               
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage responce =  httpClient.PostAsync(NetAdderss, new StringContent(strJson, Encoding.UTF8, "application/json")).Result;



            }
            catch (Exception ex)
            {
                Console.WriteLine($@" Don't send to log server: {ex.Message}");
            }
        }
    }
}
