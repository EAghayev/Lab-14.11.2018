using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Book
    {

        private string _Name;
        public string Name
        {
            get
            {
                return _Name;
            }
        }

        public string Author { get; set; }

        private double _Price;
        public double Price
        {
            get
            {
                return this._Price;
            }
        }

        private double _SalePrice;
        public double SalePrice
        {
            get
            {
                return this._SalePrice;
            }
        }

        public Book(string name, double price)
        {
            this._Name = name;
            this._Price = price;
        }

        public void CalcSale(double percent)
        {
            if (percent < 0 || percent > 100)
            {
                Console.WriteLine("Faiz 0-100 araliginda olmalidir!");
            }
            else
            {
                this._SalePrice = this._Price - this.Price * (percent / 100);
            }
        }






    }
}

