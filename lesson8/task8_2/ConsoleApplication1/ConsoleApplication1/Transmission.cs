using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    enum TransmissionTypes
    {
        Transmission1,
        Transmission2,
    }

    class Transmission
    {
        public Transmission(TransmissionTypes transmissionType)
        {
            TransmissionType = transmissionType;
        }

        public TransmissionTypes TransmissionType { get; set; }
    }
}
