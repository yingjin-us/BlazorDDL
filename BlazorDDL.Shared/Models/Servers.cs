using System;
using System.Collections.Generic;

namespace BlazorDDL.Shared.Models
{
    public partial class Servers
    {
        public int ServerId { get; set; }
        public string Name { get; set; }
        public string ComputerName { get; set; }
        public string Domain { get; set; }
        public int ServerTypeId { get; set; }
        public int OperatingSystemId { get; set; }
        public int LocationTypeId { get; set; }
        public string Ipaddress { get; set; }
        public string Description { get; set; }
        public bool Show { get; set; }

        public ServerTypes ServerType { get; set; }
    }
}
