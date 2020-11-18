using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab2OOP
{
    class AnalizatorXMLLINQStrategy:IAnalizatorXML
    {
        public List<Coffee> Search(Coffee coffee)
        {
            List<Coffee> allResult = new List<Coffee>();
            var doc = XDocument.Load(@"C:\Users\HP\source\repos\Lab2OOP\Lab2OOP\Info.xml");
            var result = from obj in doc.Descendants("Coffee")
                         where (
                         (obj.Attribute("Name").Value.Equals(coffee.Name) || coffee.Name.Equals(String.Empty)) &&
                         (obj.Attribute("Kind").Value.Equals(coffee.Kind) || coffee.Kind.Equals(String.Empty)) &&
                         (obj.Attribute("Price").Value.Equals(coffee.Price) || coffee.Price.Equals(String.Empty)) &&
                         (obj.Attribute("Country").Value.Contains(coffee.Country) || coffee.Country.Equals(String.Empty)) &&
                         (obj.Attribute("Caffeine").Value.Contains(coffee.Caffeine) || coffee.Caffeine.Equals(String.Empty)) &&
                         (obj.Attribute("Roasting").Value.Contains(coffee.Roasting) || coffee.Roasting.Equals(String.Empty)) &&
                         (obj.Attribute("Grind").Value.Contains(coffee.Grind) || coffee.Grind.Equals(String.Empty))
                         )
                         select new
                         {
                             name = (string)obj.Attribute("Name"),
                             kind = (string)obj.Attribute("Kind"),
                             price = (string)obj.Attribute("Price"),
                             country = (string)obj.Attribute("Country"),
                             caffeine = (string)obj.Attribute("Caffeine"),
                             roasting = (string)obj.Attribute("Roasting"),
                             grind = (string)obj.Attribute("Grind")
                         };
            foreach (var n in result)
            {
                Coffee myCoffee = new Coffee();
                myCoffee.Name = n.name;
                myCoffee.Kind = n.kind;
                myCoffee.Price = n.price;
                myCoffee.Country = n.country;
                myCoffee.Caffeine = n.caffeine;
                myCoffee.Roasting = n.roasting;
                myCoffee.Grind = n.grind;

                allResult.Add(myCoffee);
            }

            return allResult;
        }
    }
}
