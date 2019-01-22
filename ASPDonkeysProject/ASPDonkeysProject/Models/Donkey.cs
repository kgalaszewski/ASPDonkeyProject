using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPDonkeysProject.Models
{
    public class Donkey
    {
        public int Id { get; set; }

        public int Value { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Sex { get; set; }

        public bool IsPregnant { get; set; }

        public bool IsWypozyczony { get; set; }
    }
}
