using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2OOP
{
    class Coffee
    {
        public Coffee() {
            Name = "";
            Kind = "";
            Price = "";
            Country = "";
            Caffeine = "";
            Roasting = "";
            Grind = "";
        }
        public string Name { get; set; }
        public string Kind { get; set; }
        public string Price { get; set; }
        public string Country { get; set; }
        public string Caffeine { get; set; }
        public string Roasting { get; set; }
        public string Grind { get; set; }
    }
}
