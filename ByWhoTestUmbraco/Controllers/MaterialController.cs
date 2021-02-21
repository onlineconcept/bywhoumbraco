using DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Umbraco.Web.Mvc;

namespace ByWhoTestUmbraco.Controllers
{
    public class MaterialController : SurfaceController
    {

        [HttpPost]
        public async Task<object> GetAll()
        {
            try
            {
                using (bywhoEntities db = new bywhoEntities())
                {
                    return Newtonsoft.Json.JsonConvert.SerializeObject(await db.Materials.ToListAsync());
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
