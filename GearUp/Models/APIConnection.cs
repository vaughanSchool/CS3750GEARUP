using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace GearUp.Models
{
    public class APIConnection
    {
        readonly string uri = "http://localhost:5000/api/v1/";

        public async Task<IEnumerable<AspNetRole>> GetUsers()
        {

            using (HttpClient httpClient = new HttpClient())
            {

                var test = JsonConvert.DeserializeObject<IEnumerable<AspNetRole>>(
                    await httpClient.GetStringAsync(uri + "accounts")
                );
                if (test != null)
                {
                    return null;
                }


                return test;
            }
        }
    }
}