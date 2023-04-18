using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp16.Models
{
    internal class Medicine
    {
        public string Name { get; set; }
        public double Cost { get; set; }
        public int CategoryId { get; set; }
        private static int Count { get; set; }
        public int Id;
        public Medicine(string name, double cost,int count)
        {
            Count++;
            Id= Count;
            Name= name;
            Cost= cost;
            Count= count;
        }
    }
}
