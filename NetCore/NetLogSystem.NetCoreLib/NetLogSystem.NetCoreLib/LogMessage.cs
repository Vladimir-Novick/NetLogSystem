using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace NetLogSystem.NetCoreLib
{
    [DataContract(Namespace = ""), Serializable]
    public class LogMessage
    {

        public LogMessage()
        {
            Time = DateTime.Now;
        }

        public LogMessage(String _ComputerID, String _Status, String _Message)
        {
            ComputerID = _ComputerID;
            Status = _Status;
            Message = _Message;
        }

        [DataMember]
        public String ComputerID { get; set; }

        [DataMember]
        public String Status { get; set; }

        [DataMember]
        public String Message { get; set; }

        public DateTime Time { get; set; } 
    }
}
