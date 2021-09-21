using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LAB01_02;

namespace LAB01_01
{
    public class Student : Person
    {
        /// <summary>
        /// Điểm trung bình
        /// </summary>
        public float AverageScore { get; set; }

        /// <summary>
        /// Khoa
        /// </summary>
        public string Falcuty { get; set; }

        /// <summary>
        /// Empty Constructer
        /// </summary>
        public Student() : base()
        {
        }

        /// <summary>
        /// Full properties Constructer
        /// </summary>
        /// <param name="iD"></param>
        /// <param name="name"></param>
        /// <param name="averageScore"></param>
        /// <param name="falcuty"></param>
        public Student(string ID, string Name, float AverageScore, string Falcuty) : base(ID, Name)
        {
            this.ID = ID;
            this.Name = Name;
            this.AverageScore = AverageScore;
            this.Falcuty = Falcuty;
        }

        /// <summary>
        /// Nhập một sinh viên
        /// </summary>
        public override void Input()
        {
            base.Input();

            bool flag;
            do
            {
                flag = true;
                Console.Write("\t\t\tNhập điểm trung bình: ");
                try
                {
                    AverageScore = float.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("\t\t\tĐiểm phải là một số");
                    flag = false;
                }

                if (0 < AverageScore && AverageScore > 10)
                {
                    Console.WriteLine("\t\t\tĐiểm phải >= 0 và <= 10");
                    flag = false;
                }
            } while (!flag);

            do
            {
                Console.Write("\t\t\tNhập khoa: ");
                Falcuty = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(Falcuty))
                {
                    Console.WriteLine("\t\t\tTên khoa không được để trống");
                }
            } while (string.IsNullOrWhiteSpace(Falcuty));
        }

        /// <summary>
        /// Xuất một sinh viên
        /// </summary>
        public override void Output()
        {
            base.Output();
            Console.WriteLine($"{AverageScore,-15}{Falcuty,-10}");
        }
    }
}
