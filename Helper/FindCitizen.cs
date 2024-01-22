using PodsystemaFizLicz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodsystemaFizLicz.Helper
{
    internal class FindCitizen
    {
        int id;
        public FindCitizen(int id)
        {
            this.id = id;
        }
        public bool CitizenPredicate(Citizen c)
        {
            return c.Id == id;
        }
    }
}
