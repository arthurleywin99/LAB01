using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LAB01_03;
using LAB01_04;

namespace LAB01
{
    internal class RealEstateList
    {
        private Dictionary<int, Tuple<Ground, TownHouse, Apartment>> realEstates;

        /// <summary>
        /// Empty Constructor
        /// </summary>
        public RealEstateList()
        {
            realEstates = new Dictionary<int, Tuple<Ground, TownHouse, Apartment>>();
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
                            InputList(realEstates);
                            Notification();
                            break;
                        }
                    case 2:
                        {
                            SumPrice(realEstates);
                            Notification();
                            break;
                        }
                    case 3:
                        {
                            Ground100Townhouse60And2020(realEstates);
                            Notification();
                            break;
                        }
                    case 4:
                        {
                            Search(realEstates);
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
            Console.WriteLine("\t ----------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("\t| Chọn chức năng:");
            Console.WriteLine("\t| 1. Nhập danh sách các thông tin (Khu đất, Nhà phố, Chung cư) cần quản lý");
            Console.WriteLine("\t| 2. Xuất tổng giá bán cho 3 loại (Khu đất, Nhà phố, Chung cư) của công ty");
            Console.WriteLine("\t| 3. Xuất danh sách các khu đất có diện tích > 100m2 hoặc là nhà phố có diện tích > 60m2 và năm xây dựng >= 2020 (nếu có)");
            Console.WriteLine("\t| 4. Nhập vào thông tin cần tìm kiếm (Địa điểm, giá diện tích).");
            Console.WriteLine("\t|\tXuất thông tin danh sách tất cả các nhà phố hoặc chung cư phù hợp yêu cầu.");
            Console.WriteLine("\t| 0. Trở về menu trước");
            Console.WriteLine("\t ----------------------------------------------------------------------------------------------------------------------------------");
        }

        private void Notification()
        {
            Console.Write("\t\tPress any key to continue");
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// Nhập danh sách các thông tin (Khu đất, Nhà phố, Chung cư) cần quản lý
        /// </summary>
        /// <param name="realEstates"></param>
        private void InputList(Dictionary<int, Tuple<Ground, TownHouse, Apartment>> realEstates)
        {
            Console.Write("\t\tNhập số lượng muốn thêm: ");
            int range = int.Parse(Console.ReadLine());
            for (int i = 0; i < range; ++i)
            {
                Console.WriteLine($"\t\tNhập dữ liệu cho khu thứ {realEstates.Count + 1}:");
                /**
                 * Chọn Y/N hoặc y/n hoặc YES/NO hoặc yes/no
                 **/
                string check = "";

                /**
                 * Nhập khu đất
                 **/
                Ground ground = null;
                do
                {
                    Console.Write("\t\tKhu vực này có \"Khu đất\" không? (Y/N): ");
                    check = Console.ReadLine();
                    if (check.Equals("Y") || check.Equals("y") || check.Equals("YES") || check.Equals("yes"))
                    {
                        ground = new Ground();
                        ground.Input();
                        break;
                    }
                    else if (check.Equals("N") || check.Equals("n") || check.Equals("NO") || check.Equals("no"))
                    {
                        break;
                    }
                    Console.WriteLine("\t\tKhông có lựa chọn này...");
                } while (true);

                /**
                 * Nhập nhà phố
                 **/
                TownHouse townHouse = null;
                do
                {
                    Console.Write("\t\tKhu vực này có \"Nhà phố\" không? (Y/N): ");
                    check = Console.ReadLine();
                    if (check.Equals("Y") || check.Equals("y") || check.Equals("YES") || check.Equals("yes"))
                    {
                        townHouse = new TownHouse();
                        townHouse.Input();
                        break;
                    }
                    else if (check.Equals("N") || check.Equals("n") || check.Equals("NO") || check.Equals("no"))
                    {
                        break;
                    }
                    Console.WriteLine("\t\tKhông có lựa chọn này...");
                } while (true);

                /**
                 * Nhập chung cư
                 **/
                Apartment apartment = null;
                do
                {
                    Console.Write("\t\tKhu vực này có \"Chung cư\" không? (Y/N): ");
                    check = Console.ReadLine();
                    if (check.Equals("Y") || check.Equals("y") || check.Equals("YES") || check.Equals("yes"))
                    {
                        apartment = new Apartment();
                        apartment.Input();
                        break;
                    }
                    else if (check.Equals("N") || check.Equals("n") || check.Equals("NO") || check.Equals("no"))
                    {
                        break;
                    }
                    Console.WriteLine("\t\tKhông có lựa chọn này...");
                } while (true);

                var tuple = Tuple.Create(ground, townHouse, apartment);

                realEstates.Add(i, tuple);

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Xuất tổng giá bán cho 3 loại (Khu đất, Nhà phố, Chung cư) của công ty
        /// </summary>
        /// <param name="realEstates"></param>
        /// <returns></returns>
        private void SumPrice(Dictionary<int, Tuple<Ground, TownHouse, Apartment>> realEstates)
        {
            Console.WriteLine("\t\t{0,-10}{1,-15}", "Khu vực", "Tổng giá bán");
            //Tuple không dùng trong KeyValuePair vì nó là loại dữ liệu static
            foreach (var item in realEstates)
            {
                float price = 0f;
                if (item.Value.Item1 != null)
                {
                    price += item.Value.Item1.Price;
                }
                if (item.Value.Item2 != null)
                {
                    price += item.Value.Item2.Price;
                }
                if (item.Value.Item3 != null)
                {
                    price += item.Value.Item3.Price;
                }
                Console.WriteLine($"\t\t{item.Key,-10}{price,-15}");
            }
        }

        /// <summary>
        /// Xuất danh sách các khu đất có diện tích > 100m2 hoặc là nhà phố có diện tích > 60m2 và năm xây dựng > 2020 (nếu có)
        /// </summary>
        /// <param name="realEstates"></param>
        private void Ground100Townhouse60And2020(Dictionary<int, Tuple<Ground, TownHouse, Apartment>> realEstates)
        {
            List<Ground> grounds = new List<Ground>();
            List<TownHouse> townHouses = new List<TownHouse>();
            foreach (var item in realEstates.Values)
            {
                if (item.Item1 != null && item.Item1.Area > 100)
                {
                    grounds.Add(item.Item1);
                }
                if (item.Item2 != null && item.Item2.Area > 60 && item.Item2.Groundbreaking >= 2020)
                {
                    townHouses.Add(item.Item2);
                }
            }

            if (grounds.Count == 0)
            {
                Console.WriteLine("\t\tKhông có khu đất có diện tích > 100m2");
            }
            else
            {
                Console.WriteLine("\t\tDanh sách khu dất có diện tích > 100m2:");
                Console.WriteLine("\t{0,-20}{1,-10}{2,-10}", "Location", "Price", "Area");
                foreach (var item in grounds)
                {
                    item.Output();
                    Console.WriteLine();
                }

            }

            if (townHouses.Count == 0)
            {
                Console.WriteLine("\t\tKhông có nhà phố có diện tích > 60m2 và năm xây dựng >= 2020");
            }
            else
            {
                Console.WriteLine("\t\tDanh sách nhà phố có diện tích > 60m2 và năm xây dựng >= 2020");
                Console.WriteLine("\t{0,-20}{1,-10}{2,-10}{3,-20}{4,-20}", "Location", "Price", "Area", "Groundbreaking", "FloorCount");
                foreach (var item in townHouses)
                {
                    item.Output();
                }
            }
        }

        /// <summary>
        /// Nhập vào thông tin cần tìm kiếm (Địa điểm, giá, diện tích). Xuất thông tin danh sách tất cả các nhà phố hoặc chung cư phù hợp yêu cầu
        /// </summary>
        /// <param name="realEstates"></param>
        private void Search(Dictionary<int, Tuple<Ground, TownHouse, Apartment>> realEstates)
        {
            Console.Write("\t\tNhập địa điểm: ");
            string location = Console.ReadLine();
            Console.Write("\t\tNhập giá: ");
            float price = float.Parse(Console.ReadLine());
            Console.Write("\t\tNhập diện tích: ");
            int area = int.Parse(Console.ReadLine());

            List<TownHouse> townHouses = new List<TownHouse>();
            List<Apartment> apartments = new List<Apartment>();
            
            foreach (var item in realEstates.Values)
            {
                if (item.Item2.Location.Contains(location) && item.Item2.Price <= price && item.Item2.Area > area)
                {
                    townHouses.Add(item.Item2);
                }

                if (item.Item3.Location.Contains(location) && item.Item3.Price <= price && item.Item3.Area > area)
                {
                    apartments.Add(item.Item3);
                }
            }

            Console.WriteLine("\t\tĐã tìm thấy {0} nhà phố và {1} chung cư\n", townHouses.Count, apartments.Count);

            if (townHouses.Count != 0)
            {
                Console.WriteLine("\t{0,-20}{1,-10}{2,-10}{3,-20}{4,-20}", "Location", "Price", "Area", "Groundbreaking", "FloorCount");
                foreach (var item in townHouses)
                {
                    item.Output();
                }
            }

            if (apartments.Count != 0)
            {
                Console.WriteLine("\t{0,-20}{1,-10}{2,-10}{3,-20}", "Location", "Price", "Area", "FloorCount");
                foreach (var item in apartments)
                {
                    item.Output();
                }
            }
        }
    }
}
