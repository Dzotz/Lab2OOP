using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2OOP
{
    class Search
    {
        IAnalizatorXML analiz;
        Coffee coff;
        public Search(IAnalizatorXML analizator, Coffee coffee)
        {
            analiz = analizator;
            coff = coffee;
        }

        public List<Coffee> SearchAlgorithm()
        {
            return analiz.Search(coff);
        }
    }
}
