using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LAB01_03;

namespace LAB01_04
{
    public class Apartment : Ground
    {
        /// <summary>
        /// Tầng
        /// </summary>
        public short FloorNumber { get; set; }

        /// <summary>
        /// Empty Constructor
        /// </summary>
        public Apartment() : base()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Location"></param>
        /// <param name="Price"></param>
        /// <param name="Area"></param>
        public Apartment(string Location, float Price, int Area, short FloorNumber) : base(Location, Price, Area)
        {
            this.FloorNumber = FloorNumber;
        }

        /// <summary>
        /// Nhập một chung cư
        /// </summary>
        public override void Input()
        {
            base.Input();
            do
            {
                Console.Write("\t\t\tNhập tầng: ");
                FloorNumber = short.Parse(Console.ReadLine());
                if (FloorNumber <= 0)
                {
                    Console.WriteLine("\t\tTầng phải là số nguyên > 0");
                }
            } while (FloorNumber <= 0);
        }

        /// <summary>
        /// Xuất một chung cư
        /// </summary>
        public override void Output()
        {
            base.Output();
            Console.WriteLine($"{FloorNumber,-20}");
        }
    }
}
