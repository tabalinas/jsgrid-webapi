using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JSGridWebAPISample.Models {

    public class Client {

        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Country? Country { get; set; }
        public string Address { get; set; }
        public bool Married { get; set; }

    }

}