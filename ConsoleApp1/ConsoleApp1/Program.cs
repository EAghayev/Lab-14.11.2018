using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //book obyektini costructorda teleb olunan deyerleri(adi,qiymeti) daxil ederek yaradiriq
            Book book = new Book("kitab", 100);
            byte secim;
            string author;
            do
            {
                Console.WriteLine("1.Kitabin adi nedir?");
                Console.WriteLine("2.Kitabin yazari kimdir?");
                Console.WriteLine("3.Kitabin yazarini qeyd et");
                Console.WriteLine("4.Kitabin qiymetini goster");
                Console.WriteLine("5.Kitabin endirimli qiyetini goster");
                Console.WriteLine("6.Kitabin endirim faizini daxil et");
                Console.WriteLine("7.Kitabin endirim faizini goster");

                Console.WriteLine("0.Cix");
                string secimStr = Console.ReadLine();
                while (!byte.TryParse(secimStr, out secim))
                {
                    secimStr = Console.ReadLine();
                }
                switch (secim)
                {
                    case 1:
                        Console.WriteLine("Kitabin adi: " + book.Name);
                        Console.WriteLine("==========================");
                        break;
                    case 2:
                        Console.WriteLine("Kitabin yazari: " + (book.Author ?? "Kitabin muellifi qeyd edilmeyib"));
                        Console.WriteLine("==========================");
                        break;
                    case 3:
                        if (book.Author != null)
                        {
                            Console.WriteLine("Kitabin muellifi {0} olaraq qeyd edilib.Deyisdirmek isteyirsinizmi?(y/n)", book.Author);
                            string yn = Console.ReadLine();

                            while (yn != "y" && yn != "n")
                            {
                                Console.Write("Seciminiz yalnizca y ve ya n ola biler!");
                                yn = Console.ReadLine();
                            }

                            if (yn.ToLower() == "y")
                            {
                                Console.Write("Kitabin muellifi: ");
                                author = Console.ReadLine();
                                book.Author = author;
                            }
                            Console.WriteLine("==========================");
                        }
                        else
                        {
                            Console.Write("Kitabin yazari: ");
                            author = Console.ReadLine();
                            book.Author = author;
                            Console.WriteLine("==========================");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Kitabin qiymeti: " + book.Price + " AZN");
                        Console.WriteLine("==========================");
                        break;
                    case 5:
                        if (book?.SalePrice == null || book.SalePrice == 0)
                        {
                            Console.WriteLine("Kitab endirimde deyil!");
                        }
                        else
                        {
                            Console.WriteLine("Kitabin endirim qiymeti: " + book.SalePrice + " AZN");
                        }
                        Console.WriteLine("==========================");
                        break;
                    case 6:
                        if (book?.SalePrice == null || book.SalePrice == 0)
                        {
                            Console.Write("Endirim faizini daxil edin: ");
                            string percentStr = Console.ReadLine();
                            double percent;
                            while (!double.TryParse(percentStr, out percent))
                            {
                                Console.Write("Endirim faizini duzgun daxil edin: ");
                                percentStr = Console.ReadLine();
                            }
                            book.CalcSale(percent);
                        }
                        else
                        {
                            double oldSalePercent = 100 - (book.SalePrice * 100 / book.Price);
                            Console.WriteLine("Kitab " + oldSalePercent + "%  endirimdedir.Endirim faziini yenilemek isteyirsinizmi?(y/n)");
                            string yn = Console.ReadLine();
                            while (yn != "y" && yn != "n")
                            {
                                Console.Write("Seciminiz yalnizca y ve ya n ola biler!");
                                yn = Console.ReadLine();
                            }
                            if (yn.ToLower() == "y")
                            {
                                Console.WriteLine("==========================");
                                string percentStr = Console.ReadLine();
                                double percent;
                                while (!double.TryParse(percentStr, out percent))
                                {
                                    Console.Write("Endirim faizini duzgun daxil edin: ");
                                    percentStr = Console.ReadLine();
                                }
                                book.CalcSale(percent);
                            }

                        }
                        break;
                    case 7:
                        if (book.SalePrice == null)
                        {
                            Console.WriteLine("Kitab endrimde deyil!");
                        }
                        else
                        {
                            double SalePercent = 100 - (book.SalePrice * 100 / book.Price);
                            Console.WriteLine("Kitab " + SalePercent + "%  endirimdedir");
                        }
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("==========================");
                        Console.WriteLine("Seciminiz duz etmediniz");
                        Console.WriteLine("==========================");
                        break;
                }
            }
            while (secim != 0);
        }
    }
}
