using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LAB01_03;

namespace LAB01_04
{
    public class TownHouse : Ground
    {
        /// <summary>
        /// Năm xây dựng
        /// </summary>
        public short Groundbreaking { get; set; }

        /// <summary>
        /// Số tầng
        /// </summary>
        public short FloorCount { get; set; }
        
        /// <summary>
        /// Empty Constructor
        /// </summary>
        public TownHouse() : base()
        {

        }

        /// <summary>
        /// Full Properties Constructor
        /// </summary>
        public TownHouse(string Location, float Price, int Area, short Groundbreaking, short FloorCount) : base(Location, Price, Area)
        {
            this.Groundbreaking = Groundbreaking;
            this.FloorCount = FloorCount;
        }

        /// <summary>
        /// Nhập một nhà phố
        /// </summary>
        public override void Input()
        {
            base.Input();

            do
            {
                Console.Write("\t\t\tNhập năm xây dựng: ");
                Groundbreaking = short.Parse(Console.ReadLine());
                if (Groundbreaking <= 0)
                {
                    Console.WriteLine("\t\tNăm xây dựng phải là số nguyên > 0");
                }
            } while (Groundbreaking <= 0);

            do
            {
                Console.Write("\t\t\tNhập số tầng: ");
                FloorCount = short.Parse(Console.ReadLine());

                if (Groundbreaking <= 0)
                {
                    Console.WriteLine("\t\tSố tầng phải là số nguyên > 0");
                }
            } while (FloorCount <= 0);
        }

        /// <summary>
        /// Xuất một nhà phố
        /// </summary>
        public override void Output()
        {
            base.Output();
            Console.WriteLine($"{Groundbreaking,-20}{FloorCount,-20}");
        }
    }
}
