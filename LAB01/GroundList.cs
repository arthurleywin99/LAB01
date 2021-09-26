using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LAB01_03;

namespace LAB01
{
    internal class GroundList
    {
        private List<Ground> grounds;

        /// <summary>
        /// Empty Constructor
        /// </summary>
        public GroundList()
        {
            grounds = new List<Ground>();
        }

        /// <summary>
        /// Phương thức xử lý chính
        /// </summary>
        public void Solve()
        {
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
                            InputList(grounds);
                            Notification();
                            break;
                        }
                    case 2:
                        {
                            OutputList(grounds);
                            Notification();
                            break;
                        }
                    case 3:
                        {
                            SortList(grounds);
                            Notification();
                            break;
                        }
                    case 4:
                        {
                            LessThanAMiliionAndGreaterThan60m2(grounds);
                            Notification();
                            break;
                        }
                    case 5:
                        {
                            Price1m2(grounds);
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
            Console.WriteLine("\t| 1. Nhập danh sách khu đất của công ty");
            Console.WriteLine("\t| 2. Xuất danh sách khu đất của công ty");
            Console.WriteLine("\t| 3. Xuất danh sách thông tin các khu đất có diện tích được sắp xếp tăng dần");
            Console.WriteLine("\t| 4. Xuất danh sách thông tin các khu đất có giá bán < 1 tỷ và diện tích >= 60m2 (nếu có)");
            Console.WriteLine("\t| 5. Tính đơn giá trung bình 1m2 của tất cả các khu đất có diện tích > 1000m2 (nếu có)");
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
        /// Nhập danh sách khu đất của công ty
        /// </summary>
        /// <param name="list"></param>
        private void InputList(List<Ground> list)
        {
            Console.Write("\t\tNhập số lượng khu đất muốn thêm: ");
            int range = int.Parse(Console.ReadLine());
            for (var i = 0; i < range; ++i)
            {
                Console.WriteLine($"\t\tNhập khu đất thứ {list.Count + 1}:");
                Ground student = new Ground();
                student.Input();
                list.Add(student);
            }
        }

        /// <summary>
        /// Xuất danh sách khu đất của công ty
        /// </summary>
        /// <param name="list"></param>
        private void OutputList(List<Ground> list)
        {
            Console.WriteLine("\t{0,-20}{1,-10}{2,-10}", "Location", "Price", "Area");
            foreach (var item in list)
            {
                item.Output();
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Xuất danh sách thông tin các khu đất có diện tích được sắp xếp tăng dần
        /// </summary>
        /// <param name="list"></param>
        private void SortList(List<Ground> list)
        {
            Console.WriteLine("\t\tDanh sách sau khi được sắp xếp tăng dần:");
            OutputList(list.OrderBy(p => p.Area).ToList());
        }

        /// <summary>
        /// Xuất danh sách thông tin các khu đất có giá bán < 1 tỷ và diện tích >= 60m2 (nếu có)
        /// </summary>
        /// <param name="list"></param>
        private void LessThanAMiliionAndGreaterThan60m2(List<Ground> list)
        {
            var groundList = list.Where(p => p.Price < 1000000000 && p.Area >= 60).ToList();
            if (groundList.Count == 0)
            {
                Console.WriteLine("\t\tKhông có khu đất cần tìm");
            }
            else
            {
                OutputList(groundList);
            }
        }

        /// <summary>
        /// Tính đơn giá trung bình 1m2 của tất cả các khu đất có diện tích > 1000m2 (nếu có)
        /// </summary>
        /// <param name="list"></param>
        private void Price1m2(List<Ground> list)
        {
            var groundList = list.Where(p => p.Area >= 1000).ToList();
            if (groundList.Count == 0)
            {
                Console.WriteLine("\t\tKhông có khu đất có diện tích lớn hơn 1000");
            }
            else
            {
                Console.WriteLine("\t{0,-20}{1,-20}", "Location", "AveragePrice");
                foreach (var item in groundList)
                {
                    Console.WriteLine($"\t{item.Location,-20}{item.Price / item.Area,-20}");
                }
            }
        }
    }
}
