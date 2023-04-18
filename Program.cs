
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
                                if(Context.Categories.Count > 0)
                                {
                                Console.Write("Category Idsini daxil edin: ");
                                int categoryid = int.Parse(Console.ReadLine());
                                Category.Delete(categoryid);
                                }
                                else
                                {
                                    Console.WriteLine("Silinecek category yoxdur!");
                                }
                                break;
                            case 3:
                                if (Context.Categories.Count > 0)
                                {
                                    Console.Write("Category Idsini daxil edin: ");
                                    int updatedCategoryid = int.Parse(Console.ReadLine());
                                    Category.Update(updatedCategoryid);
                                }
                                else
                                {
                                    Console.WriteLine("Deyisiklik etmek ucun category yoxdur!");
                                }
                                
                                break;
                        }
                        break;
                    case 2:
                        if (Context.Categories.Count == 0)
                        {
                            Console.WriteLine("Category yaradilmadan derman yardila bilmez!");
                        }
                        else
                        {
                            Console.WriteLine("1.Create Medicine");
                            Console.WriteLine("2.Delete Medicine");
                            Console.WriteLine("3.Update Medicine");
                            Console.WriteLine("4.Sale Medicine");
                            Console.WriteLine("0.Exit");
                            Console.Write("Seciminizi edin: ");
                            int input3 = int.Parse(Console.ReadLine());
                            switch (input3)
                            {
                                case 0:
                                    break;
                                case 1:
                                    Medicine.Create();
                                    break;
                                case 2:
                                    if(Context.Medicines.Count > 0)
                                    {
                                        Console.Write("Medicine Idsini daxil edin: ");
                                        int medicineId = int.Parse(Console.ReadLine());
                                        Category.Delete(medicineId);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Silinecek derman yoxdur!");
                                    }
                                    break;
                                case 3:
                                    if (Context.Medicines.Count > 0)
                                    {
                                        Console.Write("Deyisiklik edeceyiniz dermanin Idsini daxil edin: ");
                                        int updatedMedicineId = int.Parse(Console.ReadLine());
                                        Medicine.Update(updatedMedicineId);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Deyisiklik edilecek derman yoxdur!");
                                    }
                                    
                                    break;
                                case 4:
                                    if (Context.Medicines.Count > 0)
                                    {
                                        foreach (var item in Context.Medicines)
                                        {
                                            Console.WriteLine($"{item.Name} id: {item.Id} sayi: {item.Count}");
                                        }
                                        Console.Write("Satilan dermanin idsini daxil edin: ");
                                        int saledId = int.Parse(Console.ReadLine());
                                        Medicine.Sale(saledId);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Satis ucun kifayet qeder derman yoxdur");
                                    }
                                   
                                    break;
                            }
                        }
                        break;
                }
            } while (input != 0);
        }
    }
}