﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodsystemaFizLicz.Model
{
    enum PersonType
    {
        /// <summary>
        /// физ. лицо
        /// </summary>
        NaturalPerson,
        /// <summary>
        /// юр. лицо
        /// </summary>
        LegalPerson
    }

    internal class Person
    {
        public int Id { get; set; }
        public string Shifer { get; set; }
        public string Inn { get; set; }
        public PersonType Type { get; set; }
        public DateTime Data { get; set; }

        public Person() { }

        public Person(int id, string shifer, string inn, PersonType type, DateTime data)
        {
            Id = id;
            Shifer = shifer;
            Inn = inn;
            Type = type;
            Data = data;
        }
    }
}
