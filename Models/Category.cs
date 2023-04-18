using ConsoleApp16.DAL;
using ConsoleApp16.Models.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp16.Models
{
    internal class Category
    {
        public static int _id;
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public List<Medicine> CategorizedMedicines = new List<Medicine>();
        public Category(string categoryName)
        {
            _id++;
            Id = _id;
            CategoryName = categoryName;
        }
        public static void Delete(int id)
        {
            Context.Categories.Remove(Search(id));
        }
        public static void Update(int id)
        {
            Console.WriteLine($"Deyisiklik etmek istediyiniz category: {Search(id).CategoryName}");
            Console.Write("Yeni adi daxil edin: ");
            string newName = Console.ReadLine();
            Search(id).CategoryName = newName;
        }
        public static Category Search(int id)
        {
            foreach (var item in Context.Categories)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            throw new NotFoundException("Bele bir category yoxdur");
        }
    }
}
