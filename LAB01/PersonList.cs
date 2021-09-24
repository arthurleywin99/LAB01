using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LAB01_01;
using LAB01_02;

namespace LAB01
{
    internal class PersonList
    {
        private List<Person> people; 

        /// <summary>
        /// Phương thức xử lý chính
        /// </summary>
        public void Solve()
        {
            people = new List<Person>();
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
                            InputList(people);   
                            Notification();
                            break;
                        }
                    case 2:
                        {
                            StudentList.ITFalcuty(people);
                            Notification();
                            break;
                        }
                    case 3:
                        {
                            ITFalcutyLessThan5(people);
                            Notification();
                            break;
                        }
                    case 4:
                        {
                            TeacherDistric9(people);
                            Notification();
                            break;
                        }
                    case 5:
                        {
                            if (TeacherCHN060286(people) == null)
                            {
                                Console.WriteLine("\t\tKhông có giảng viên nào với mã này");
                            }
                            else
                            {
                                Console.WriteLine("\t{0,-10}{1,-20}{2,-20}", "ID", "FullName", "Address");
                                TeacherCHN060286(people).Output();
                            }
                            Notification();
                            break;
                        }
                    case 6:
                        {
                            StudentList.BestITStudent(people);
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
            Console.WriteLine("\t ---------------------------------------------------------------------------------------------------");
            Console.WriteLine("\t| Chọn chức năng:");
            Console.WriteLine("\t| 1. Nhập danh sách");
            Console.WriteLine("\t| 2. Tìm kiếm danh sách SV đều thuộc khoa CNTT (nếu có)");
            Console.WriteLine("\t| 3. Xuất ra danh sách sinh viên có điểm trung bình nhỏ hơn 5 và thuộc khoa \"CNTT\"");
            Console.WriteLine("\t| 4. Xuất ra danh sách giáo viên có địa chỉ chứa thông tin \"Quận 9\" (nếu có)");
            Console.WriteLine("\t| 5. Tìm kiếm giáo viên có mã giảng viên là CHN060286. Xuất ra thông tin giáo viên tìm được (nếu có)");
            Console.WriteLine("\t| 6. Tìm danh sách sinh viên có điểm trung bình cao nhất và thuộc khoa \"CNTT\"");
            Console.WriteLine("\t| 0. Trở về menu trước");
            Console.WriteLine("\t ---------------------------------------------------------------------------------------------------");
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
        private void InputList(List<Person> list)
        {
            Person person = null;
            Console.Write("\t\tNhập số lượng: ");
            int range = int.Parse(Console.ReadLine());
            for (int i = 0; i < range; ++i)
            {
                Console.WriteLine("\t\tNhập người thứ {0}:", i + 1);
                do
                {
                    Console.WriteLine("\t\t\tChọn loại dữ liệu muốn nhập:");
                    Console.WriteLine("\t\t\t1. Sinh viên");
                    Console.WriteLine("\t\t\t2. Giảng viên");
                    Console.Write("\t\t\t\t>>");
                    byte select = byte.Parse(Console.ReadLine());
                    if (select == 1)
                    {
                        person = new Student();
                        person.Input();
                        list.Add(person);
                        break;
                    }
                    else if (select == 2)
                    {
                        person = new Teacher();
                        person.Input();
                        list.Add(person);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\t\t\tKhông có lựa chọn này");
                    }
                } while (true);
            }
        }

        /// <summary>
        /// Xuất ra danh sách sinh viên có điểm trung bình nhỏ hơn 5 và thuộc khoa CNTT
        /// </summary>
        /// <param name="list"></param>
        private void ITFalcutyLessThan5(List<Person> list)
        {
            var students = list.Where(p => p is Student && (p as Student).Falcuty.Equals("CNTT") && (p as Student).AverageScore < 5).ToList();
            if (students.Count == 0)
            {
                Console.WriteLine("\t\tKhông có sinh viên khoa CNTT có ĐTB nhỏ hơn 5");
            }
            else
            {
                Console.WriteLine("\t{0,-10}{1,-20}{2,-15}{3,-10}", "ID", "FullName", "AverageScore", "Falcuty");
                StudentList.OutputList(students);
            }
        }

        /// <summary>
        /// Xuất ra danh sách giáo viên có địa chỉ chứa thông tin "Quận 9" (nếu có)
        /// </summary>
        private void TeacherDistric9(List<Person> list)
        {
            var teachers = list.Where(p => p is Teacher && (p as Teacher).Address.Equals("Quan 9")).ToList();
            if (teachers.Count == 0)
            {
                Console.WriteLine("\t\tKhông có giảng viên ở Quận 9");
            }
            else
            {
                Console.WriteLine("\t{0,-10}{1,-20}{2,-20}", "ID", "FullName", "Address");
                StudentList.OutputList(teachers);
            }
        }

        /// <summary>
        /// Tìm kiếm giáo viên có mã giảng viên là CHN060286. Xuất ra thông tin giáo viên tìm được (nếu có)
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private Teacher TeacherCHN060286(List<Person> list)
        {
            var index = list.FindIndex(p => p.ID.Equals("CHN060286"));
            if (index != -1)
            {
                return list[index] as Teacher;
            }
            return null;
        }
    }
}
