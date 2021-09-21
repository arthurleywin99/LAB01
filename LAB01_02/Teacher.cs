using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB01_02
{
    public class Teacher : Person
    {
        public string Address { get; set; }

        /// <summary>
        /// Empty Constructer
        /// </summary>
        public Teacher() : base()
        {

        }

        /// <summary>
        /// Full Properties Constructer
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Name"></param>
        /// <param name="Address"></param>
        public Teacher(string ID, string Name, string Address) : base(ID, Name)
        {
            this.ID = ID;
            this.Name = Name;
            this.Address = Address;
        }

        /// <summary>
        /// Nhập một giảng viên
        /// </summary>
        public override void Input()
        {
            base.Input();
            do
            {
                Console.Write("\t\t\tNhập địa chỉ: ");
                Address = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(Address))
                {
                    Console.WriteLine("\t\tĐịa chỉ không được để trống");
                }
            } while (string.IsNullOrWhiteSpace(Address));
        }

        /// <summary>
        /// Xuất một giảng viên
        /// </summary>
        public override void Output()
        {
            base.Output();
            Console.WriteLine($"{Address,-20}");
        }
    }
}
