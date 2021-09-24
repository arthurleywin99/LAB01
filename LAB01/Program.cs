using System;
using System.Text;

namespace LAB01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            byte select;
            do
            {
                Console.WriteLine("********************************************************************************************");
                Console.WriteLine("* Chọn chức năng:");
                Console.WriteLine("* 1. BÀI TẬP 1");
                Console.WriteLine("* 2. BÀI TẬP 2");
                Console.WriteLine("* 3. BÀI TẬP 3");
                Console.WriteLine("* 4. BÀI TẬP 4");
                Console.WriteLine("* 0. THOÁT");
                Console.WriteLine("********************************************************************************************");

                Console.Write("\t>>");
                select = byte.Parse(Console.ReadLine());

                switch (select)
                {
                    case 0:
                        {
                            Console.WriteLine("\tBạn đã nhập 0. Chương trình sẽ thoát");
                            return;
                        }
                    case 1:
                        {
                            Console.Clear();
                            var studentList = new StudentList();
                            studentList.Solve();
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            var personList = new PersonList();
                            personList.Solve();
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            var groundList = new GroundList();
                            groundList.Solve();
                            break;
                        }
                    case 4:
                        {
                            Console.Clear();
                            var realEstateList = new RealEstateList();
                            realEstateList.Solve();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("\tKhông có lựa chọn này");
                            break;
                        }
                }
            } while (select != 0);
        }
    }
}
