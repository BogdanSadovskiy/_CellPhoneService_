using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _CellPhoneService_.Entity
{
    public class Services
    {
        public Services() { }
        public int Id { get; set; }
        public int DeviceID {  get; set; }
        public decimal ServicePrice { get; set; }
        public bool IsServiceDone { get; set; }
        public bool IsServicePaid { get; set; }

        public Services(int id, int deviceID, decimal servicePrice, bool isServiceDone, bool isServicePaid)
        {
            Id = id;
            DeviceID = deviceID;
            ServicePrice = servicePrice;
            IsServiceDone = isServiceDone;
            IsServicePaid = isServicePaid;
        }
    }
}
