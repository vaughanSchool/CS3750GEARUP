using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace GearUp.Models
{
    public class ContactLog
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "First Name Required")]
        [StringLength(50)]
        public string stFirstName { get; set; }
        [Required(ErrorMessage = "Last Name Required")]
        [StringLength(50)]
        public string stLastName { get; set; }
        public DateTime serviceDate { get; set; }
        public string serviceDescription { get; set; }
        public int serviceMinutes { get; set; }
        public string serviceCode { get; set; }
        public bool parentOnly { get; set; }
        public bool compass { get; set; }
        public string serviceDetails { get; set; }
    }
    public class ContactLogGet
    {

        readonly string uri = "http://icarus.cs.weber.edu:8080/student/1";

        public async Task<Student> GetContactLogAsync()
        {

            using (HttpClient httpClient = new HttpClient())
            {

                var test = JsonConvert.DeserializeObject<Student>(
                    await httpClient.GetStringAsync(uri)
                );
                return test;

                return JsonConvert.DeserializeObject<Student>(
                        await httpClient.GetStringAsync(uri)
                    );
            }
        }
    }
}