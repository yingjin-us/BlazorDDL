using System;
using System.Collections.Generic;

namespace BlazorDDL.Shared.Models
{
    public partial class ServerTypes
    {
        public ServerTypes()
        {
            Servers = new HashSet<Servers>();
        }

        public int ServerTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Show { get; set; }
        public int SortOrder { get; set; }

        public ICollection<Servers> Servers { get; set; }
    }
}
