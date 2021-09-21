using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB01_03
{
    public class Ground
    {
        /// <summary>
        /// Địa điểm
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// Giá bán
        /// </summary>
        public float Price { get; set; }
        /// <summary>
        /// Diện tích
        /// </summary>
        public int Area { get; set; }

        /// <summary>
        /// Empty Constructer
        /// </summary>
        public Ground()
        {

        }

        /// <summary>
        /// Full Properties Constructer
        /// </summary>
        /// <param name="Location"></param>
        /// <param name="Price"></param>
        /// <param name="Area"></param>
        public Ground(string Location, float Price, int Area)
        {
            this.Location = Location;
            this.Price = Price;
            this.Area = Area;
        }

        /// <summary>
        /// Nhập một khu đất
        /// </summary>
        public virtual void Input()
        {
            do
            {
                Console.Write("\t\t\tNhập địa điểm: ");
                Location = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(Location))
                {
                    Console.WriteLine("\t\tĐịa điểm không được để trống");
                }
            } while (string.IsNullOrWhiteSpace(Location));

            do
            {
                Console.Write("\t\t\tNhập giá tiền: ");
                Price = float.Parse(Console.ReadLine());
                if (Price <= 0)
                {
                    Console.WriteLine("\t\tGiá tiền phải là một số thực > 0");
                }
                else if (string.IsNullOrWhiteSpace(Price.ToString()))
                {
                    Console.WriteLine("\t\tGiá tiền không được để trống");
                }
            } while (Price <= 0 || string.IsNullOrWhiteSpace(Price.ToString()));

            do
            {
                Console.Write("\t\t\tNhập diện tích: ");
                Area = int.Parse(Console.ReadLine());
                if (Area <= 0)
                {
                    Console.WriteLine("\t\tDiện tích phải là một số nguyên > 0");
                }
                else if (string.IsNullOrWhiteSpace(Area.ToString()))
                {
                    Console.WriteLine("\t\tDiện tích không được để trống");
                }
            } while (Area <= 0 || string.IsNullOrWhiteSpace(Area.ToString()));
        }

        /// <summary>
        /// Xuất một khu đất
        /// </summary>
        public virtual void Output()
        {
            Console.Write($"\t{Location,-20}{Price,-10}{Area,-10}");
        }
    }
}
