using BlazorDDL.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDDL.Server.DataAcces
{
    public class DataAccessLayer
    {
        ApplicationInventoryContext db = new ApplicationInventoryContext();

        public IEnumerable<ServerTypes> GetAllServerTypes()
        {
            try
            {
                return db.ServerTypes.ToList();
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<Servers> GetServersData(string id)
        {
            try
            {
                List<Servers> lstCity = new List<Servers>();
                lstCity = (from ServerName in db.Servers where ServerName.ServerTypeId == Int64.Parse(id) select ServerName).ToList();

                return lstCity;
            }
            catch
            {
                throw;
            }
        }
    }
}