using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Lab2OOP
{
    class AnalizatorXMLSAXStrategy : IAnalizatorXML
    {
        public List<Coffee> Search (Coffee coffee)
        {
            List<Coffee> AllResult = new List<Coffee>();
            var xmlReader = new XmlTextReader(@"C:\Users\HP\source\repos\Lab2OOP\Lab2OOP\Info.xml");

            while (xmlReader.Read())
            {
                if (xmlReader.HasAttributes)
                {
                    while (xmlReader.MoveToNextAttribute())
                    {
                        string Name = "";
                        string Kind = "";
                        string Price = "";
                        string Country = "";
                        string Caffeine = "";
                        string Roasting = "";
                        string Grind = "";
                        if (xmlReader.Name.Equals("Name") && (xmlReader.Value.Equals(coffee.Name) || coffee.Name.Equals(String.Empty)))
                        {
                            Name = xmlReader.Value;
                            xmlReader.MoveToNextAttribute();
                            if (xmlReader.Name.Equals("Kind") && (xmlReader.Value.Equals(coffee.Kind) || coffee.Kind.Equals(String.Empty)))
                            {
                                Kind = xmlReader.Value;
                                xmlReader.MoveToNextAttribute();

                                if (xmlReader.Name.Equals("Price") && (xmlReader.Value.Equals(coffee.Price) || coffee.Price.Equals(String.Empty)))
                                {
                                    Price = xmlReader.Value;
                                    xmlReader.MoveToNextAttribute();
                                    if (xmlReader.Name.Equals("Country") && (xmlReader.Value.Equals(coffee.Country) || coffee.Country.Equals(String.Empty)))
                                    {
                                        Country = xmlReader.Value;
                                        xmlReader.MoveToNextAttribute();
                                        if (xmlReader.Name.Equals("Caffeine") && (xmlReader.Value.Equals(coffee.Caffeine) || coffee.Caffeine.Equals(String.Empty)))
                                        {
                                            Caffeine = xmlReader.Value;
                                            xmlReader.MoveToNextAttribute();
                                            if (xmlReader.Name.Equals("Roasting") && (xmlReader.Value.Equals(coffee.Roasting) || coffee.Roasting.Equals(String.Empty)))
                                            {
                                                Roasting = xmlReader.Value;
                                                xmlReader.MoveToNextAttribute();
                                                if (xmlReader.Name.Equals("Grind") && (xmlReader.Value.Equals(coffee.Grind) || coffee.Grind.Equals(String.Empty)))
                                                {
                                                    Grind = xmlReader.Value;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        if (Kind != "" && Price != "" && Country != "" && Caffeine != "" && Roasting != "" && Grind != "")
                        {
                            Coffee myCoffee = new Coffee();
                            myCoffee.Name = Name;
                            myCoffee.Kind = Kind;
                            myCoffee.Price = Price;
                            myCoffee.Country = Country;
                            myCoffee.Caffeine = Caffeine;
                            myCoffee.Roasting = Roasting;
                            myCoffee.Grind = Grind;

                            AllResult.Add(myCoffee);
                        }

                    }
                }
            }

            xmlReader.Close();
            return AllResult;
        }
    }
}
