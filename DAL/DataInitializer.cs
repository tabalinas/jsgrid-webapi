using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JSGridWebAPISample.Models;

namespace JSGridWebAPISample.DAL {

    public class DataInitializer: System.Data.Entity.DropCreateDatabaseAlways<DataContext> {

        protected override void Seed(DataContext context) {

            var clients = new List<Client> {
                new Client { 
                    Name = "Otto Clay", 
                    Age = 61, 
                    Country = Country.Canada, 
                    Address = "Ap #897-1459 Quam Avenue", 
                    Married = false 
                },
                new Client {
	                Name = "Lacey Hess",
	                Age = 29,
	                Country = Country.Russia,
	                Address = "Ap #365-8835 Integer St.",
	                Married = false
                },
                new Client {
	                Name = "Timothy Henson",
	                Age = 78,
	                Country = Country.UnitedStates,
	                Address = "911-5143 Luctus Ave",
	                Married = false
                },
                new Client {
	                Name = "Ramona Benton",
	                Age = 43,
	                Country = Country.Brazil,
	                Address = "Ap #614-689 Vehicula Street",
	                Married = true
                },
                new Client {
	                Name = "Ezra Tillman",
	                Age = 51,
	                Country = Country.UnitedStates,
	                Address = "P.O. Box 738, 7583 Quisque St.",
	                Married = true
                },
                new Client {
	                Name = "Dante Carter",
	                Age = 59,
	                Country = Country.UnitedStates,
	                Address = "P.O. Box 976, 6316 Lorem, St.",
	                Married = false
                },
                new Client {
	                Name = "Christopher Mcclure",
	                Age = 58,
	                Country = Country.UnitedStates,
	                Address = "847-4303 Dictum Av.",
	                Married = true
                },
                new Client {
	                Name = "Ruby Rocha",
	                Age = 62,
	                Country = Country.Canada,
	                Address = "5212 Sagittis Ave",
	                Married = false
                },
                new Client {
	                Name = "Imelda Hardin",
	                Age = 39,
	                Country = Country.Brazil,
	                Address = "719-7009 Auctor Av.",
	                Married = false
                },
                new Client {
	                Name = "Jonah Johns",
	                Age = 28,
	                Country = Country.Brazil,
	                Address = "P.O. Box 939, 9310 A Ave",
	                Married = false
                },
                new Client {
	                Name = "Herman Rosa",
	                Age = 49,
	                Country = Country.Russia,
	                Address = "718-7162 Molestie Av.",
	                Married = true
                },
                new Client {
	                Name = "Arthur Gay",
	                Age = 20,
	                Country = Country.Russia,
	                Address = "5497 Neque Street",
	                Married = false
                },
                new Client {
	                Name = "Xena Wilkerson",
	                Age = 63,
	                Country = Country.UnitedStates,
	                Address = "Ap #303-6974 Proin Street",
	                Married = true
                },
                new Client {
	                Name = "Lilah Atkins",
	                Age = 33,
	                Country = Country.Brazil,
	                Address = "622-8602 Gravida Ave",
	                Married = true
                }
            };

            foreach (var client in clients) {
                context.Client.Add(client);
	        }

            context.SaveChanges();
        }

    }

}