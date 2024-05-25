using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _CellPhoneService_.Entity
{
    public class Devices
    {
        public Devices() { }

        public Devices(int id, string deviceName, string deviceModel, int userId, string deviceIssue, DateTime? dateOfStartOfService)
        {
            Id = id;
            DeviceName = deviceName;
            DeviceModel = deviceModel;
            UserId = userId;
            DeviceIssue = deviceIssue;
            DateOfStartOfService = dateOfStartOfService;
        }
        public int Id { get; set; }
        public string? DeviceName { get; set; }
        public string? DeviceModel { get; set; }
        public int UserId { get; set; }
        public string? DeviceIssue { get; set; }
        public DateTime? DateOfStartOfService { get; set; }


    }
}
