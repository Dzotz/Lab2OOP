using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;
using System.IO;
using System.Xml.Xsl;

namespace Lab2OOP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GetCoffeeKinds();
        }

        public void GetCoffeeKinds()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"C:\Users\HP\source\repos\Lab2OOP\Lab2OOP\Info.xml");

            XmlElement xRoot = doc.DocumentElement;
            XmlNodeList childNodes = xRoot.SelectNodes("Coffee");

            for (int i = 0; i< childNodes.Count; i++)
            {
                XmlNode n = childNodes.Item(i);
                addItems(n);
            }

            comboBox1.Text = comboBox1.Items[0].ToString();
            comboBox2.Text = comboBox2.Items[0].ToString();
            comboBox3.Text = comboBox3.Items[0].ToString();
            comboBox4.Text = comboBox4.Items[0].ToString();
            comboBox5.Text = comboBox5.Items[0].ToString();
            comboBox6.Text = comboBox6.Items[0].ToString();

        }

        void addItems (XmlNode n)
        {
            if (!comboBox1.Items.Contains(n.SelectSingleNode("@Kind").Value))
            {
                comboBox1.Items.Add(n.SelectSingleNode("@Kind").Value);
            }
            if (!comboBox2.Items.Contains(n.SelectSingleNode("@Price").Value))
            {
                comboBox2.Items.Add(n.SelectSingleNode("@Price").Value);
            }
            if (!comboBox3.Items.Contains(n.SelectSingleNode("@Country").Value))
            {
                comboBox3.Items.Add(n.SelectSingleNode("@Country").Value);
            }
            if (!comboBox4.Items.Contains(n.SelectSingleNode("@Caffeine").Value))
            {
                comboBox4.Items.Add(n.SelectSingleNode("@Caffeine").Value);
            }
            if (!comboBox5.Items.Contains(n.SelectSingleNode("@Roasting").Value))
            {
                comboBox5.Items.Add(n.SelectSingleNode("@Roasting").Value);
            }
            if (!comboBox6.Items.Contains(n.SelectSingleNode("@Grind").Value))
            {
                comboBox6.Items.Add(n.SelectSingleNode("@Grind").Value);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            richTextBox1.Text = "";
            ClearXML();
            Coffee coffee = new Coffee();

            if (checkBox1.Checked)
            {
                coffee.Kind = comboBox1.SelectedItem.ToString();
            }

            if (checkBox2.Checked)
            {
                coffee.Price = comboBox2.SelectedItem.ToString();
            }

            if (checkBox3.Checked)
            {
                coffee.Country = comboBox3.SelectedItem.ToString();
            }

            if (checkBox4.Checked)
            {
                coffee.Caffeine = comboBox4.SelectedItem.ToString();
            }

            if (checkBox5.Checked)
            {
                coffee.Roasting = comboBox5.SelectedItem.ToString();
            }

            if (checkBox6.Checked)
            {
                coffee.Grind = comboBox6.SelectedItem.ToString();
            }

            IAnalizatorXML analizator = new AnaliztorXMLDOMStrategy();

            if (radioButton1.Checked)
            {
                analizator = new AnaliztorXMLDOMStrategy();
            }

            if (radioButton2.Checked)
            {
                analizator = new AnalizatorXMLSAXStrategy();
            }

            if (radioButton3.Checked)
            {
                analizator = new AnalizatorXMLLINQStrategy();
            }

            Search search = new Search(analizator, coffee);
            List<Coffee> results = search.SearchAlgorithm();

            foreach (Coffee coff in results)
            {
                AddToXML(coff);
                richTextBox1.Text += "Назва: " + coff.Name + "\n";
                richTextBox1.Text += "Вид: " + coff.Kind + "\n";
                richTextBox1.Text += "Ціна за кілограм: " + coff.Price + "\n";
                richTextBox1.Text += "Країна походження: " + coff.Country + "\n";
                richTextBox1.Text += "Вміст кофеїну: " + coff.Caffeine + "\n";
                richTextBox1.Text += "Обжарка: " + coff.Roasting + "\n";
                richTextBox1.Text += "Помол: " + coff.Grind + "\n";

                richTextBox1.Text += "\n\n\n";
            }
            EndXML();
            if (richTextBox1.Text == "")
            {
                richTextBox1.Text = "Нічого не знайдено";
            }

        }

        void AddToXML(Coffee coffee)
        {
            StreamWriter resultsFile = new StreamWriter(@"C:\Users\HP\source\repos\Lab2OOP\Lab2OOP\results.xml", true);
            resultsFile.WriteLine("<Coffee");
            resultsFile.WriteLine("Name = \"" + coffee.Name + "\"");
            resultsFile.WriteLine("Kind = \"" + coffee.Kind + "\"");
            resultsFile.WriteLine("Price = \"" + coffee.Price + "\"");
            resultsFile.WriteLine("Country = \"" + coffee.Country + "\"");
            resultsFile.WriteLine("Caffeine = \"" + coffee.Caffeine + "\"");
            resultsFile.WriteLine("Roasting = \"" + coffee.Roasting + "\"");
            resultsFile.WriteLine("Grind = \"" + coffee.Grind + "\">");
            resultsFile.WriteLine("</Coffee>");
            resultsFile.Close();
        }

        void ClearXML()
        {
            StreamWriter resultsFile = new StreamWriter(@"C:\Users\HP\source\repos\Lab2OOP\Lab2OOP\results.xml");
            resultsFile.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
            resultsFile.WriteLine("<CoffeeKinds>");
            resultsFile.Close();
        }

        void EndXML()
        {
            StreamWriter resultsFile = new StreamWriter(@"C:\Users\HP\source\repos\Lab2OOP\Lab2OOP\results.xml", true);
            resultsFile.WriteLine("</CoffeeKinds>");
            resultsFile.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            transform();
        }

        private void transform()
        {
            XslCompiledTransform xct = new XslCompiledTransform();
            xct.Load(@"C:\Users\HP\source\repos\Lab2OOP\Lab2OOP\file.xsl");
            string XMLpath = @"C:\Users\HP\source\repos\Lab2OOP\Lab2OOP\results.xml";
            string HTMLpath = @"C:\Users\HP\source\repos\Lab2OOP\Lab2OOP\res.html";
            xct.Transform(XMLpath, HTMLpath);
        }
    }
}
