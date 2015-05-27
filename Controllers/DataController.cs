using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using JSGridWebAPISample.DAL;
using JSGridWebAPISample.Models;

namespace JSGridWebAPISample.Controllers {

    public class DataController: ApiController {

        public IEnumerable<object> Get() {
            DataContext db = new DataContext();

            ClientFilter filter = GetFilter();

            var result = db.Client.Where(c =>
                (String.IsNullOrEmpty(filter.Name) || c.Name.Contains(filter.Name)) &&
                (String.IsNullOrEmpty(filter.Address) || c.Address.Contains(filter.Address)) &&
                (!filter.Married.HasValue || c.Married == filter.Married) &&
                (!filter.Country.HasValue || c.Country == filter.Country)
            );

            return result.ToArray();
        }

        private ClientFilter GetFilter() {
            NameValueCollection filter = HttpUtility.ParseQueryString(Request.RequestUri.Query);

            return new ClientFilter {
                Name = filter["Name"],
                Address = filter["Address"],
                Country =  (filter["Country"] == "0") ? (Country?)null : (Country)int.Parse(filter["Country"]),
                Married = String.IsNullOrEmpty(filter["Married"]) ? (bool?)null : bool.Parse(filter["Married"])
            };
        }

        // GET api/values/5
        public object Get(int id) {
            DataContext db = new DataContext();
            return db.Client.FirstOrDefault(c => c.ID == id);
        }

        // POST api/values
        public void Post([FromBody]string value) {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value) {
        }

        // DELETE api/values/5
        public void Delete(int id) {
        }

    }

}