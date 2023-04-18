
using ConsoleApp16.DAL;
using ConsoleApp16.Models;
using ConsoleApp16.Models.Enum;
using ConsoleApp16.Models.Exceptions;
using System.ComponentModel;

namespace ConsoleApp16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = 0;
            do
            {
                Console.WriteLine("----------Menu--------------");
                Console.WriteLine("1.Category menu");
                Console.WriteLine("2.Medicine menu");
                Console.WriteLine("0.Exit");
                Console.Write("Seciminizi edin: ");
                input = int.Parse(Console.ReadLine());

                switch (input)
                {
                    case 0:
                        break;
                    case 1:
                        Console.WriteLine("1.Create Category");
                        Console.WriteLine("2.Delete Category");
                        Console.WriteLine("3.Update Category");
                        Console.WriteLine("0.Exit");
                        Console.Write("Seciminizi edin: ");
                        int input2 = int.Parse(Console.ReadLine());
                        switch (input2)
                        {
                            case 0:
                                break;
                            case 1:
                                Console.Write("Category adini daxil edin: ");
                                string categoryName = Console.ReadLine();
                                Category category = new Category(categoryName);
                                Context.Categories.Add(category);
                                break;
                            case 2:
                                Console.Write("Category Idsini daxil edin: ");
                                int categoryid = int.Parse(Console.ReadLine());
                                Category.Delete(categoryid);
                                break;
                            case 3:
                                Console.Write("Category Idsini daxil edin: ");
                                int updatedCategoryid = int.Parse(Console.ReadLine());
                                Category.Update(updatedCategoryid);
                                break;
                        }
                        break;
                    case 2:
                        Console.WriteLine("1.Create");
                        Console.WriteLine("2.Delete");
                        Console.WriteLine("3.Update");
                        Console.WriteLine("0.Exit");
                        Console.Write("Seciminizi edin: ");
                        int input3 = int.Parse(Console.ReadLine());
                        switch (input3)
                        {
                            case 0:
                                break;
                            case 1:
                                Console.Write("Medicine adini daxil edin: ");
                                string medicineName = Console.ReadLine();
                                Console.Write("Medicine adini daxil edin: ");
                                double medicineCost = Convert.ToDouble(Console.ReadLine());
                                Console.Write("Medicine adini daxil edin: ");
                                int medicineCount = int.Parse(Console.ReadLine());
                                Medicine medicine = new Medicine(medicineName,medicineCost,medicineCount);
                                Context.Medicines.Add(medicine);
                                break;
                            case 2:
                                Console.Write("Category Idsini daxil edin: ");
                                int categoryid = int.Parse(Console.ReadLine());
                                Category.Delete(categoryid);
                                break;
                            case 3:
                                Console.Write("Category Idsini daxil edin: ");
                                int updatedCategoryid = int.Parse(Console.ReadLine());
                                Category.Update(updatedCategoryid);
                                break;
                        }
                        break;
                }

            } while (input != 0);
            foreach (var item in Context.Categories)
            {
                Console.WriteLine(item.CategoryName);
            }
        }
    }
}