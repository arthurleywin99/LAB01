using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LAB01_01;
using LAB01_02;

namespace LAB01
{
    public class StudentList
    {
        private List<Student> students;

        /// <summary>
        /// Phương thức xử lý chính
        /// </summary>
        public void Solve()
        {
            students = new List<Student>();
            byte select;
            do
            {
                Menu();
                Console.Write("\t\t>>");
                select = byte.Parse(Console.ReadLine());

                switch (select)
                {
                    case 0:
                        {
                            Console.WriteLine("\tBạn đã nhập 0. Chương trình sẽ quay về menu trước...");
                            Notification();
                            break;
                        }
                    case 1:
                        {
                            InputList(students);
                            Notification();
                            break;
                        }
                    case 2:
                        {
                            ITFalcuty(students);
                            Notification();
                            break;
                        }
                    case 3:
                        {
                            GreaterThan5(students);
                            Notification();
                            break;
                        }
                    case 4:
                        {
                            SortAverageScore(students);
                            Notification();
                            break;
                        }
                    case 5:
                        {
                            ITFalcutyGreaterThan5(students);
                            Notification();
                            break;
                        }
                    case 6:
                        {
                            BestITStudent(students);
                            Notification();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("\t\tKhông có lựa chọn này");
                            Notification();
                            break;
                        }
                }
            } while (select != 0);
        }

        /// <summary>
        /// Menu
        /// </summary>
        private void Menu()
        {
            Console.WriteLine("\t ------------------------------------------------------------------------------------------------");
            Console.WriteLine("\t| Chọn chức năng:");
            Console.WriteLine("\t| 1. Nhập danh sách sinh viên");
            Console.WriteLine("\t| 2. Xuất ra thông tin của các SV đều thuộc khoa CNTT (nếu có)");
            Console.WriteLine("\t| 3. Xuất ra thông tin sinh viên có điểm TB lớn hơn bằng 5 (nếu có)");
            Console.WriteLine("\t| 4. Xuất ra danh sách sinh viên được sắp xếp theo điểm trung bình tăng dần");
            Console.WriteLine("\t| 5. Xuất ra danh sách sinh viên có điểm TB lớn hơn bằng 5 và thuộc khoa CNTT (nếu có)");
            Console.WriteLine("\t| 6. Xuất ra danh sách sinh viên có điểm TB cao nhất và thuộc khoa CNTT (nếu có)");
            Console.WriteLine("\t| 0. Trở về menu trước");
            Console.WriteLine("\t ------------------------------------------------------------------------------------------------");
        }

        private void Notification()
        {
            Console.Write("\t\tPress any key to continue");
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// Nhập danh sách
        /// </summary>
        /// <param name="list"></param>
        private void InputList(List<Student> list)
        {
            Console.Write("\t\tNhập số lượng sinh viên: ");
            int range = int.Parse(Console.ReadLine());
            for (var i = 0; i < range; ++i)
            {
                Console.WriteLine("\t\tNhập sinh viên thứ {0}:", i + 1);
                Student student = new Student();
                student.Input();
                list.Add(student);
            }
        }

        /// <summary>
        /// Xuất danh sách
        /// </summary>
        /// <param name="list"></param>
        internal void OutputList(dynamic list)
        {
            foreach (var item in list)
            {
                item.Output();
            }
        }

        /// <summary>
        /// Xuất ra thông tin của các SV đều thuộc khoa CNTT (nếu có)
        /// </summary>
        internal void ITFalcuty(dynamic list)
        {
            var students = new List<Student>();
            foreach (var item in list)
            {
                if (item is Student)
                {
                    var student = item as Student;
                    if (student == null)
                    {
                        Console.Write("\t\tCasting Error");
                    }
                    else
                    {
                        if (student.Falcuty.Equals("CNTT"))
                        {
                            students.Add(student);
                        }
                    }
                }
            }
            if (students.Count == 0)
            {
                Console.WriteLine("\t\tKhông có sinh viên nào thuộc khoa CNTT");
            }
            else
            {
                Console.WriteLine("\t\tDanh sách sinh viên thuộc khoa CNTT:");
                Console.WriteLine("\t{0,-10}{1,-20}{2,-15}{3,-10}", "ID", "FullName", "AverageScore", "Falcuty");
                OutputList(students);
            }
        }

        /// <summary>
        /// Xuất ra thông tin sinh viên có điểm TB lớn hơn bằng 5 (nếu có)
        /// </summary>
        /// <param name="list"></param>
        private void GreaterThan5(List<Student> list)
        {
            var students = list.Where(p => p.AverageScore >= 5).ToList();
            if (students.Count == 0)
            {
                Console.WriteLine("\t\tKhông có sinh viên nào với điểm TB >= 5");
            }
            else
            {
                Console.WriteLine("\t\tDanh sách sinh viên với điểm TB >= 5");
                Console.WriteLine("\t{0,-10}{1,-20}{2,-15}{3,-10}", "ID", "FullName", "AverageScore", "Falcuty");
                OutputList(students);
            }
        }

        /// <summary>
        /// Xuất ra danh sách sinh viên được sắp xếp theo điểm trung bình tăng dần
        /// </summary>
        /// <param name="list"></param>
        private void SortAverageScore(List<Student> list)
        {
            Console.WriteLine("\t\tDanh sách sau khi sắp xếp: ");
            Console.WriteLine("\t{0,-10}{1,-20}{2,-15}{3,-10}", "ID", "FullName", "AverageScore", "Falcuty");
            OutputList(list.OrderBy(p => p.AverageScore).ToList());
        }

        /// <summary>
        /// Xuất ra thông tin sinh viên có điểm TB lớn hơn bằng 5 (nếu có)
        /// </summary>
        /// <param name="list"></param>
        private void ITFalcutyGreaterThan5(List<Student> list)
        {
            var students = list.Where(p => p.AverageScore >= 5 && p.Falcuty.Equals("CNTT")).ToList();
            if (students.Count == 0)
            {
                Console.WriteLine("\t\tKhông có sinh viên khoa CNTT nào với điểm TB >= 5");
            }
            else
            {
                Console.WriteLine("\t\tDanh sách sinh viên khoa CNTT với điểm TB >= 5");
                Console.WriteLine("\t{0,-10}{1,-20}{2,-15}{3,-10}", "ID", "FullName", "AverageScore", "Falcuty");
                OutputList(students);
            }
        }

        /// <summary>
        /// Xuất ra danh sách sinh viên có điểm TB cao nhất và thuộc khoa CNTT (nếu có)
        /// </summary>
        /// <param name="list"></param>
        internal void BestITStudent(dynamic list)
        {
            /**
             *Điểm trung bình cao nhất nằm trong tất cả sinh viên 
             */
            var max = ((IEnumerable<dynamic>)((IEnumerable<dynamic>)list).Where(p => p is Student).ToList()).Max(p => p.AverageScore);
            var students = ((IEnumerable<dynamic>)list).Where(p => p is Student && (p as Student).AverageScore == max).ToList();
            
            if (students.Count == 0)
            {
                Console.WriteLine("\t\tKhông có sinh viên khoa CNTT nào có điểm TB cao nhất");
            }
            else
            {
                Console.WriteLine("\t\tDanh sách sinh viên có điểm TB cao nhất thuộc khoa CNTT: ");
                Console.WriteLine("\t{0,-10}{1,-20}{2,-15}{3,-10}", "ID", "FullName", "AverageScore", "Falcuty");
                OutputList(students);
            }
        }
    }
}
