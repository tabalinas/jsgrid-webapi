using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JSGridWebAPISample.Models {

    public class ClientFilter {

        public string Name { get; set; }
        public string Address { get; set; }
        public Country? Country { get; set; }
        public bool? Married { get; set; }

    }

}