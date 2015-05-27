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

        DataContext _db = new DataContext();

        DataContext DB {
            get { return _db; }
        }

        public IEnumerable<object> Get() {
            ClientFilter filter = GetFilter();

            var result = DB.Client.Where(c =>
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

        public void Post([FromBody]Client client) {
            DB.Client.Add(client);
            DB.SaveChanges();
        }


        public void Put(int id, [FromBody]Client editedClient) {
            Client client = DB.Client.Find(id);

            if(client == null)
                return;

            client.Name = editedClient.Name;
            client.Age = editedClient.Age;
            client.Country = editedClient.Country;
            client.Address = editedClient.Address;
            client.Married = editedClient.Married;

            DB.Entry(client).State = System.Data.Entity.EntityState.Modified;
            DB.SaveChanges();
        }

        public void Delete(int id) {
            Client client = DB.Client.Find(id);

            if(client == null)
                return;

            DB.Client.Remove(client);
            DB.SaveChanges();
        }

        protected override void Dispose(bool disposing) {
            if(disposing) {
                DB.Dispose();
            }
            base.Dispose(disposing);
        }

    }

}