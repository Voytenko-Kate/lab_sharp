using PodsystemaFizLicz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodsystemaFizLicz.Helper
{
    internal class FindDocument
    {
        int id;
        public FindDocument(int id)
        {
            this.id = id;
        }
        public bool DocumentPredicate(Document doc)
        {
            return doc.Id == id;
        }
    }
}
