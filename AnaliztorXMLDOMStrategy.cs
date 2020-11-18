using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Lab2OOP
{
    class AnaliztorXMLDOMStrategy : IAnalizatorXML
    {
        public List<Coffee> Search(Coffee coffee)
        {
            List<Coffee> result = new List<Coffee>();
            XmlDocument doc = new XmlDocument();
            doc.Load(@"C:\Users\HP\source\repos\Lab2OOP\Lab2OOP\Info.xml");
            XmlNode node = doc.DocumentElement;
            foreach(XmlNode nod in node.ChildNodes)
            {
                string Name = "";
                string Kind = "";
                string Price = "";
                string Country = "";
                string Caffeine = "";
                string Roasting = "";
                string Grind = "";

                foreach (XmlAttribute attribute in nod.Attributes)
                {
                    if (attribute.Name.Equals("Name") && (attribute.Value.Equals(coffee.Name) || coffee.Name.Equals(String.Empty)))
                    {
                        Name = attribute.Value;
                    }
                    if (attribute.Name.Equals("Kind") && (attribute.Value.Equals(coffee.Kind)|| coffee.Kind.Equals(String.Empty)))
                    {
                        Kind = attribute.Value;
                    }

                    if (attribute.Name.Equals("Price") && (attribute.Value.Equals(coffee.Price) || coffee.Price.Equals(String.Empty)))
                    {
                        Price = attribute.Value;
                    }

                    if (attribute.Name.Equals("Country") && (attribute.Value.Equals(coffee.Country) || coffee.Country.Equals(String.Empty)))
                    {
                        Country = attribute.Value;
                    }

                    if (attribute.Name.Equals("Caffeine") && (attribute.Value.Equals(coffee.Caffeine) || coffee.Caffeine.Equals(String.Empty)))
                    {
                        Caffeine = attribute.Value;
                    }

                    if (attribute.Name.Equals("Roasting") && (attribute.Value.Equals(coffee.Roasting) || coffee.Roasting.Equals(String.Empty)))
                    {
                        Roasting = attribute.Value;
                    }

                    if (attribute.Name.Equals("Grind") && (attribute.Value.Equals(coffee.Grind) || coffee.Grind.Equals(String.Empty)))
                    {
                        Grind = attribute.Value;
                    }
                }

                if (Kind != "" && Price !=""&&Country!=""&&Caffeine!=""&&Roasting!=""&&Grind != "")
                {
                    Coffee myCoffee = new Coffee();
                    myCoffee.Name = Name;
                    myCoffee.Kind = Kind;
                    myCoffee.Price = Price;
                    myCoffee.Country = Country;
                    myCoffee.Caffeine = Caffeine;
                    myCoffee.Roasting = Roasting;
                    myCoffee.Grind = Grind;

                    result.Add(myCoffee);
                }
            }
            return result;
        }
    }
}
