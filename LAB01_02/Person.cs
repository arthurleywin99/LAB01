using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB01_02
{
    public class Person
    {
        /// <summary>
        /// ID
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Họ và tên
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Empty Constructer
        /// </summary>
        public Person()
        {

        }

        /// <summary>
        /// Full Properties Constructer
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Name"></param>
        public Person(string ID, string Name)
        {
            this.ID = ID;
            this.Name = Name;
        }

        /// <summary>
        /// Nhập dữ liệu
        /// </summary>
        public virtual void Input()
        {
            do
            {
                Console.Write("\t\t\tNhập ID: ");
                ID = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(ID))
                {
                    Console.WriteLine("\t\t\tID không được để trống");
                }
            } while (string.IsNullOrWhiteSpace(ID));

            do
            {
                Console.Write("\t\t\tNhập họ tên: ");
                Name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(Name))
                {
                    Console.WriteLine("\t\t\tHọ tên không được để trống");
                }
            } while (string.IsNullOrWhiteSpace(Name));
        }

        /// <summary>
        /// Xuất dữ liệu
        /// </summary>
        public virtual void Output()
        {
            Console.Write($"\t{ID,-10}{Name,-20}");
        }
    }
}
