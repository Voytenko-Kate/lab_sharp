using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodsystemaFizLicz.Model
{
    internal class Document
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Seriy { get; set; }
        public string Organ { get; set; }
        public DateTime Data { get; set; }

        public Document() { }

        public Document(int id, string name, string seriy, string organ, DateTime data)
        {
            Id = id;
            Name = name;
            Seriy = seriy;
            Organ = organ;
            Data = data;
        }
        public Document ShallowCopy()
        {
            return (Document)this.MemberwiseClone();
        }
    }
}
