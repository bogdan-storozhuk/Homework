using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace ConsoleApplication19_1
{
    [DataContract]
    [Serializable]
    [ProtoContract]
    public class CallLog
    {
        [DataMember]
        [ProtoMember(1)]
        public int CallCount { get; set; }
        [DataMember]
        [ProtoMember(2)]
        public double CoefficientActivity { get; set; }
    }
}
