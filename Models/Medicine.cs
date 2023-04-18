using ConsoleApp16.DAL;
using ConsoleApp16.Models.Exceptions;
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
        public int Count { get; set; }
        private static int _id;
        public int Id { get; set; }
        public Medicine(string name, double cost,int count,int categoryId)
        {
            _id++;
            Id= _id;
            Name= name;
            Cost= cost;
            Count= count;
            CategoryId= categoryId;
        }
        public static void Create()
        {
            Console.Write("Dermanin adini daxil edin: ");
            string medicineName = Console.ReadLine();
            Console.Write("Dermanin qiymetini daxil edin: ");
            double medicineCost = Convert.ToDouble(Console.ReadLine());
            Console.Write("Dermanin sayini daxil edin: ");
            int medicineCount = int.Parse(Console.ReadLine());
            Console.WriteLine("---Kateqoriyalar---");
            foreach (var item in Context.Categories)
            {
                Console.WriteLine($"{item.CategoryName} id: {item.Id}");
            }
            Console.Write("Dermanin aid oldugu kateqoriyanin idsini daxil edin: ");
            int categoryId = int.Parse(Console.ReadLine());
            Medicine medicine = new Medicine(medicineName, medicineCost, medicineCount,categoryId);
            foreach (var item in Context.Categories)
            {
                if (categoryId == item.Id)
                {
                    item.CategorizedMedicines.Add(medicine);
                }
            }
            Context.Medicines.Add(medicine);
        }
        public static void Delete(int id)
        {
            Context.Medicines.Remove(Search(id));
            Search(id).Count--;
        }
        public static void Update(int id)
        {
            Medicine updatedMedicine = Search(id);
            Console.WriteLine($"Deyisiklik etmek istediyiniz derman: {updatedMedicine.Name}");
            Console.Write("Yeni adi daxil edin: ");
            string newName = Console.ReadLine();
            Console.Write("Yeni qiymeti daxil edin: ");
            double newCost = Convert.ToDouble(Console.ReadLine());
            Console.Write("Yeni sayi daxil edin: ");
            int newCount = int.Parse(Console.ReadLine());
            updatedMedicine.Name = newName;
            updatedMedicine.Cost = newCost;
            updatedMedicine.Count = newCount;
        }
        public static Medicine Search(int id)
        {
            foreach (var item in Context.Medicines)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            throw new NotFoundException("Bele bir derman yoxdur");
        }
        public static void Sale(int id)
        {
            Medicine saledMedicine = Search(id);
            if (saledMedicine.Count > 0)
            {
                saledMedicine.Count--;
                Console.WriteLine("Satis heyata kecirildi");
            }
            else
            {
                Console.WriteLine("Stockda bu dermandan yoxdur!");
            }
        }
    }
}
