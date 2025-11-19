using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace QuanLyKhoDuocPham
{
    internal class Program
    {
        struct Thuoc
        {
            public string MaThuoc;
            public string TenThuoc;
            public string DonViTinh;
            public string HanSuDung;
            public int SoLuongTon;

            public Thuoc(string maThuoc, string tenThuoc, string donViTinh, string hanSuDung, int soLuongTon)
            {
                MaThuoc = maThuoc;
                TenThuoc = tenThuoc;
                DonViTinh = donViTinh;
                HanSuDung = hanSuDung;
                SoLuongTon = soLuongTon;
            }
        }

        static Dictionary<string, Thuoc> danhSachThuoc = new Dictionary<string, Thuoc>();

        static Dictionary<string, List<string>> danhSachTheoHanSuDung = new Dictionary<string, List<string>>();

        static string[] combo = new string[100];

        static void KhoiTaoDuLieu()
        {
            ThemThuoc("T001", "Paracetamol", "Vien", "12/2026", 200);
            ThemThuoc("T002", "Amoxicillin", "Vien", "06/2025", 150);
            ThemThuoc("T003", "Cephalexin", "Vien", "08/2025", 180);
            ThemThuoc("T004", "Azithromycin", "Goi", "03/2026", 120);
            ThemThuoc("T005", "Cefuroxime", "Lo", "09/2025", 90);
            ThemThuoc("T006", "Ibuprofen", "Vien", "07/2026", 250);
            ThemThuoc("T007", "Loratadine", "Vien", "05/2027", 300);
            ThemThuoc("T008", "Vitamin C", "Vien", "10/2026", 400);
            ThemThuoc("T009", "Omeprazole", "Vien", "02/2027", 220);
            ThemThuoc("T010", "Metformin", "Vien", "01/2026", 350);
            ThemThuoc("T011", "Aspirin", "Vien", "11/2026", 280);
            ThemThuoc("T012", "Doxycycline", "Vien", "04/2026", 160);
            ThemThuoc("T013", "Ciprofloxacin", "Ong", "08/2026", 140);
            ThemThuoc("T014", "Amlodipine", "Vien", "09/2026", 190);
            ThemThuoc("T015", "Atorvastatin", "Vien", "12/2026", 210);
            ThemThuoc("T016", "Losartan", "Vien", "07/2026", 170);
            ThemThuoc("T017", "Levothyroxine", "Vien", "06/2026", 130);
            ThemThuoc("T018", "Gabapentin", "Vien", "05/2027", 240);
            ThemThuoc("T019", "Sertraline", "Vien", "03/2027", 200);
            ThemThuoc("T020", "Tramadol", "Ong", "10/2026", 150);
            ThemThuoc("T021", "Furosemide", "Ong", "11/2026", 180);
            ThemThuoc("T022", "Warfarin", "Vien", "09/2026", 120);
            ThemThuoc("T023", "Prednisone", "Vien", "08/2026", 160);
            ThemThuoc("T024", "Albuterol", "Ong", "07/2026", 200);
            ThemThuoc("T025", "Insulin", "Lo", "12/2026", 100);
            ThemThuoc("T026", "Morphine", "Ong", "06/2027", 80);
            ThemThuoc("T027", "Diazepam", "Ong", "05/2027", 140);
            ThemThuoc("T028", "Phenytoin", "Lo", "04/2027", 110);
            ThemThuoc("T029", "Digoxin", "Vien", "11/2026", 90);
            ThemThuoc("T030", "Heparin", "Ong", "10/2026", 130);
        }

        static void ThemThuoc(string maThuoc, string tenThuoc, string donViTinh, string hanSuDung, int soLuongTon)
        {

            Thuoc thuocMoi = new Thuoc(maThuoc, tenThuoc, donViTinh, hanSuDung, soLuongTon);

            danhSachThuoc.Add(maThuoc, thuocMoi);

            if (!danhSachTheoHanSuDung.ContainsKey(hanSuDung))
            {
                danhSachTheoHanSuDung[hanSuDung] = new List<string>();
            }
            danhSachTheoHanSuDung[hanSuDung].Add(maThuoc);
        }

        static void ThemThuocTuNguoiDung()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("═══════════════════════════════════════");
            Console.WriteLine("         THÊM THUỐC MỚI");
            Console.WriteLine("═══════════════════════════════════════");
            Console.ResetColor();

            Console.Write("Nhập mã thuốc (ví dụ: T001): ");
            string maThuoc = Console.ReadLine();

            if (danhSachThuoc.ContainsKey(maThuoc))
            {
                Console.WriteLine("Mã thuốc đã tồn tại! Vui lòng nhập mã khác.");
                NhanPhimBatKy();
                return;
            }

            Console.Write("Nhập tên thuốc: ");
            string tenThuoc = Console.ReadLine();

            Console.Write("Nhập đơn vị tính: ");
            string donViTinh = Console.ReadLine();

            Console.Write("Nhập hạn sử dụng (mm/yyyy): ");
            string hanSuDung = Console.ReadLine();

            Console.Write("Nhập số lượng tồn: ");
            int soLuongTon = int.Parse(Console.ReadLine());

            if (soLuongTon < 0)
            {
                Console.WriteLine("Số lượng tồn không hợp lệ!");
                NhanPhimBatKy();
                return;
            }

            ThemThuoc(maThuoc, tenThuoc, donViTinh, hanSuDung, soLuongTon);
            Console.WriteLine();
            Console.WriteLine("Thuốc mới đã được thêm thành công!");
            NhanPhimBatKy();
        }

        static void TimKiemTheoMa()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("═══════════════════════════════════════");
            Console.WriteLine("      TÌM KIẾM THUỐC THEO MÃ");
            Console.WriteLine("═══════════════════════════════════════");
            Console.ResetColor();

            Console.Write("Nhập mã thuốc cần tìm (ví dụ: T001): ");
            string maThuoc = Console.ReadLine();

            if (danhSachThuoc.ContainsKey(maThuoc))
            {
                Thuoc thuoc = danhSachThuoc[maThuoc];
                HienThiThongTinThuoc(thuoc);
            }
            else
            {
                Console.WriteLine("Không tìm thấy thuốc có mã {0}!", maThuoc);
            }

            NhanPhimBatKy();
        }

        static void TimKiemTheoHanSuDung()
        {
            Console.Clear();
            Console.WriteLine("═══════════════════════════════════════");
            Console.WriteLine("   TÌM KIẾM THUỐC THEO HẠN SỬ DỤNG");
            Console.WriteLine("═══════════════════════════════════════");

            Console.Write("Nhập hạn sử dụng cần tìm (mm/yyyy): ");
            string hanSuDung = Console.ReadLine();

            if (danhSachTheoHanSuDung.ContainsKey(hanSuDung))
            {
                Console.WriteLine("\nCác thuốc có hạn sử dụng {0}:", hanSuDung);
                Console.WriteLine("───────────────────────────────────────────");

                List<string> danhSachMa = danhSachTheoHanSuDung[hanSuDung];
                foreach (string maThuoc in danhSachMa)
                {
                    Thuoc thuoc = danhSachThuoc[maThuoc];
                    HienThiThongTinThuoc(thuoc);
                    Console.WriteLine("───────────────────────────────────────────");
                }

                Console.WriteLine("\nTổng cộng: {0} thuốc", danhSachMa.Count);
            }
            else
            {
                Console.WriteLine("Không tìm thấy thuốc nào có hạn sử dụng {0}!", hanSuDung);
            }

            NhanPhimBatKy();
        }

        static void HienThiThongTinThuoc(Thuoc thuoc)
        {
            Console.WriteLine("Mã thuốc: {0}", thuoc.MaThuoc);
            Console.WriteLine("Tên thuốc: {0}", thuoc.TenThuoc);
            Console.WriteLine("Đơn vị tính: {0}", thuoc.DonViTinh);
            Console.WriteLine("Hạn sử dụng: {0}", thuoc.HanSuDung);
            Console.WriteLine("Số lượng tồn: {0}", thuoc.SoLuongTon);
        }

        static void XemDanhSachThuoc()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════════════════");
            Console.WriteLine("                              DANH SÁCH TẤT CẢ THUỐC");
            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════════════════");
            Console.ResetColor();

            if (danhSachThuoc.Count == 0)
            {
                Console.WriteLine("Kho thuốc đang trống!");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("┌──────┬──────────┬──────────────────────────────┬──────────────┬────────────┬──────────┐");
                Console.WriteLine("│ STT  │   Mã     │            Tên thuốc         │ Đơn vị tính  │    HSD     │   SL     │");
                Console.WriteLine("├──────┼──────────┼──────────────────────────────┼──────────────┼────────────┼──────────┤");

                int stt = 1;
                foreach (var thuoc in danhSachThuoc.Values)
                {
                    string tenThuoc = thuoc.TenThuoc;
                    if (tenThuoc.Length > 28)
                    {
                        tenThuoc = tenThuoc.Substring(0, 25) + "...";
                    }

                    string donViTinh = thuoc.DonViTinh;
                    if (donViTinh.Length > 12)
                    {
                        donViTinh = donViTinh.Substring(0, 9) + "...";
                    }

                    Console.WriteLine("│ {0,-4} │ {1,-8} │ {2,-28} │ {3,-12} │ {4,-10} │ {5,-8} │",
                        stt++, thuoc.MaThuoc, tenThuoc, donViTinh, thuoc.HanSuDung, thuoc.SoLuongTon);
                }

                Console.WriteLine("└──────┴──────────┴──────────────────────────────┴──────────────┴────────────┴──────────┘");
                Console.WriteLine("\n───────────────────────────────────────────────────────────────────────────────────────");
                Console.WriteLine("Tổng cộng: {0} loại thuốc", danhSachThuoc.Count);
            }

            NhanPhimBatKy();
        }

        static void CapNhatThuoc()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("═══════════════════════════════════════");
            Console.WriteLine("        CẬP NHẬT THÔNG TIN THUỐC");
            Console.WriteLine("═══════════════════════════════════════");
            Console.ResetColor();

            Console.Write("Nhập mã thuốc cần cập nhật (ví dụ: T001): ");
            string maThuoc = Console.ReadLine();

            if (!danhSachThuoc.ContainsKey(maThuoc))
            {
                Console.WriteLine("Không tìm thấy thuốc có mã {0}!", maThuoc);
                NhanPhimBatKy();
                return;
            }

            Thuoc thuocCu = danhSachThuoc[maThuoc];
            Console.WriteLine("\nThông tin hiện tại:");
            HienThiThongTinThuoc(thuocCu);
            Console.WriteLine("\n───────────────────────────────────────────");
            Console.WriteLine("Nhập thông tin mới (nhấn Enter để giữ nguyên):");

            Console.Write("Tên thuốc mới: ");
            string tenMoi = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(tenMoi))
                tenMoi = thuocCu.TenThuoc;

            Console.Write("Đơn vị tính mới: ");
            string donViMoi = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(donViMoi))
                donViMoi = thuocCu.DonViTinh;

            Console.Write("Hạn sử dụng mới: ");
            string hanSuDungMoi = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(hanSuDungMoi))
                hanSuDungMoi = thuocCu.HanSuDung;

            Console.Write("Số lượng tồn mới: ");
            string soLuongMoi = Console.ReadLine();
            int soLuongTonMoi = string.IsNullOrWhiteSpace(soLuongMoi) ? thuocCu.SoLuongTon : int.Parse(soLuongMoi);

            if (danhSachTheoHanSuDung.ContainsKey(thuocCu.HanSuDung))
            {
                danhSachTheoHanSuDung[thuocCu.HanSuDung].Remove(maThuoc);
                if (danhSachTheoHanSuDung[thuocCu.HanSuDung].Count == 0)
                {
                    danhSachTheoHanSuDung.Remove(thuocCu.HanSuDung);
                }
            }

            Thuoc thuocMoi = new Thuoc(maThuoc, tenMoi, donViMoi, hanSuDungMoi, soLuongTonMoi);
            danhSachThuoc[maThuoc] = thuocMoi;

            if (!danhSachTheoHanSuDung.ContainsKey(hanSuDungMoi))
            {
                danhSachTheoHanSuDung[hanSuDungMoi] = new List<string>();
            }
            danhSachTheoHanSuDung[hanSuDungMoi].Add(maThuoc);

            Console.WriteLine("\nĐã cập nhật thông tin thuốc thành công!");
            NhanPhimBatKy();
        }

        static void XoaThuoc()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("═══════════════════════════════════════");
            Console.WriteLine("            XÓA THUỐC");
            Console.WriteLine("═══════════════════════════════════════");
            Console.ResetColor();

            Console.Write("Nhập mã thuốc cần xóa (ví dụ: T001): ");
            string maThuoc = Console.ReadLine();

            if (!danhSachThuoc.ContainsKey(maThuoc))
            {
                Console.WriteLine("Không tìm thấy thuốc có mã {0}!", maThuoc);
                NhanPhimBatKy();
                return;
            }

            Thuoc thuoc = danhSachThuoc[maThuoc];
            Console.WriteLine("\nThông tin thuốc sẽ bị xóa:");
            HienThiThongTinThuoc(thuoc);

            Console.Write("\nBạn có chắc chắn muốn xóa? (y/n): ");
            string xacNhan = Console.ReadLine().ToLower();

            if (xacNhan == "y" || xacNhan == "yes")
            {
                danhSachThuoc.Remove(maThuoc);

                if (danhSachTheoHanSuDung.ContainsKey(thuoc.HanSuDung))
                {
                    danhSachTheoHanSuDung[thuoc.HanSuDung].Remove(maThuoc);
                    if (danhSachTheoHanSuDung[thuoc.HanSuDung].Count == 0)
                    {
                        danhSachTheoHanSuDung.Remove(thuoc.HanSuDung);
                    }
                }

                Console.WriteLine("Đã xóa thuốc thành công!");
            }
            else
            {
                Console.WriteLine("Đã hủy thao tác xóa.");
            }

            NhanPhimBatKy();
        }

        static void LietKeComboThuoc()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("═══════════════════════════════════════");
            Console.WriteLine("    LIỆT KÊ COMBO THUỐC ĐIỀU TRỊ");
            Console.WriteLine("═══════════════════════════════════════");
            Console.ResetColor();

            int tongSoLoaiThuoc = danhSachThuoc.Count;
            Console.WriteLine("Có tổng cộng {0} loại thuốc trong kho.", tongSoLoaiThuoc);

            if (tongSoLoaiThuoc == 0)
            {
                Console.WriteLine("Kho thuốc đang trống!");
                NhanPhimBatKy();
                return;
            }

            Console.WriteLine("\nDanh sách thuốc trong kho:");
            Console.WriteLine("───────────────────────────────────────────");
            foreach (var thuoc in danhSachThuoc.Values)
            {
                Console.WriteLine("Mã: {0} - Tên: {1} - Số lượng: {2}", thuoc.MaThuoc, thuoc.TenThuoc, thuoc.SoLuongTon);
            }
            Console.WriteLine("───────────────────────────────────────────");

            Console.Write("\nNhập số lượng thuốc có trong 1 combo (m): ");
            int m = int.Parse(Console.ReadLine());

            if (m <= 0)
            {
                Console.WriteLine("Số lượng không hợp lệ! Vui lòng nhập lại.");
                NhanPhimBatKy();
                return;
            }

            Console.Write("Nhập số lượng thuốc sẽ được lấy để tạo combo (n): ");
            int n = int.Parse(Console.ReadLine());

            if (n <= 0)
            {
                Console.WriteLine("Số lượng không hợp lệ! Vui lòng nhập lại.");
                NhanPhimBatKy();
                return;
            }

            if (n < m)
            {
                Console.WriteLine("Số lượng thuốc chọn (n) phải lớn hơn hoặc bằng số lượng thuốc trong combo (m)!");
                NhanPhimBatKy();
                return;
            }

            if (n > tongSoLoaiThuoc)
            {
                Console.WriteLine("Số lượng thuốc chọn không được vượt quá số thuốc trong kho ({0})!", tongSoLoaiThuoc);
                NhanPhimBatKy();
                return;
            }

            List<string> danhSachMaChon = new List<string>();
            Console.WriteLine("\nNhập mã thuốc của {0} thuốc (ví dụ: T001, T002...):", n);
            for (int i = 0; i < n; i++)
            {
                Console.Write("Nhập mã thuốc thứ {0}: ", i + 1);
                string maThuoc = Console.ReadLine();

                if (!danhSachThuoc.ContainsKey(maThuoc))
                {
                    Console.WriteLine("Mã thuốc {0} không tồn tại trong kho! Vui lòng nhập lại.", maThuoc);
                    i--;
                    continue;
                }

                if (danhSachMaChon.Contains(maThuoc))
                {
                    Console.WriteLine("Mã thuốc {0} đã được chọn! Vui lòng nhập mã khác.", maThuoc);
                    i--;
                    continue;
                }

                danhSachMaChon.Add(maThuoc);
                Console.WriteLine("   Đã thêm: {0} (Số lượng: {1})", danhSachThuoc[maThuoc].TenThuoc, danhSachThuoc[maThuoc].SoLuongTon);
            }

            danhSachMaChon.Sort();

            Console.WriteLine("\n═══════════════════════════════════════");
            Console.WriteLine("Các combo thuốc (mỗi combo có {0} loại thuốc):", m);
            Console.WriteLine("Từ {0} thuốc đã chọn:", n);
            foreach (string ma in danhSachMaChon)
            {
                Console.WriteLine("  - {0} (Mã: {1}, SL: {2})", danhSachThuoc[ma].TenThuoc, ma, danhSachThuoc[ma].SoLuongTon);
            }
            Console.WriteLine("═══════════════════════════════════════\n");

            int demCombo = 0;
            TimCombo(1, 0, danhSachMaChon, m, n, ref demCombo);

            Console.WriteLine("\n═══════════════════════════════════════");
            Console.WriteLine("Tổng cộng tìm thấy {0} combo.", demCombo);
            Console.WriteLine("═══════════════════════════════════════");

            NhanPhimBatKy();
        }
        static void TimCombo(int i, int start, List<string> danhSachMa, int m, int n, ref int demCombo)
        {
            for (int j = start; j < n; j++)
            {
                combo[i] = danhSachMa[j];

                if (i == m)
                {
                    demCombo++;
                    Console.Write("Combo {0}: ", demCombo);
                    for (int k = 1; k <= m; k++)
                    {
                        string maThuoc = combo[k];
                        Console.Write("[{0}] ", danhSachThuoc[maThuoc].TenThuoc);
                    }
                    Console.WriteLine();
                }
                else
                {
                    TimCombo(i + 1, j + 1, danhSachMa, m, n, ref demCombo);
                }
            }
        }

        static void HienThiMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔══════════════════════════════════════════╗");
            Console.WriteLine("║   QUẢN LÝ KHO DƯỢC PHẨM TRONG BỆNH VIỆN  ║");
            Console.WriteLine("╚══════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("1. Xem danh sách tất cả thuốc");
            Console.WriteLine("2. Thêm thuốc mới");
            Console.WriteLine("3. Tìm kiếm thuốc theo mã");
            Console.WriteLine("4. Tìm kiếm thuốc theo hạn sử dụng");
            Console.WriteLine("5. Cập nhật thông tin thuốc");
            Console.WriteLine("6. Xóa thuốc");
            Console.WriteLine("7. Liệt kê combo thuốc điều trị");
            Console.WriteLine("8. Thực nghiệm hiệu năng (>10.000 thuốc)");
            Console.WriteLine("9. Thoát chương trình");
            Console.WriteLine();
            Console.Write("Chọn chức năng (1-9): ");
        }

        static void NhanPhimBatKy()
        {
            Console.WriteLine("\nNhấn phím bất kỳ để tiếp tục...");
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            KhoiTaoDuLieu();

            while (true)
            {
                HienThiMenu();
                string luaChon = Console.ReadLine();

                switch (luaChon)
                {
                    case "1":
                        XemDanhSachThuoc();
                        break;
                    case "2":
                        ThemThuocTuNguoiDung();
                        break;
                    case "3":
                        TimKiemTheoMa();
                        break;
                    case "4":
                        TimKiemTheoHanSuDung();
                        break;
                    case "5":
                        CapNhatThuoc();
                        break;
                    case "6":
                        XoaThuoc();
                        break;
                    case "7":
                        LietKeComboThuoc();
                        break;
                    case "8":
                        ThucNghiemHieuNang();
                        break;
                    case "9":
                        Console.Clear();
                        Console.WriteLine("Cảm ơn bạn đã sử dụng chương trình!");
                        Console.WriteLine("Nhấn phím bất kỳ để thoát...");
                        Console.ReadKey();
                        return;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ! Vui lòng chọn từ 1-8.");
                        NhanPhimBatKy();
                        break;
                }
                Console.ReadLine();
            }
        }
        static void ThucNghiemHieuNang()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("═══════════════════════════════════════");
            Console.WriteLine(" THỰC NGHIỆM HIỆU NĂNG HỆ THỐNG KHO THUỐC");
            Console.WriteLine("═══════════════════════════════════════");
            Console.ResetColor();

            const int soLuongThuocCanSinh = 20000;
            Console.WriteLine("Đang sinh dữ liệu mô phỏng {0:N0} thuốc...", soLuongThuocCanSinh);

            Dictionary<string, Thuoc> boNhoThuoc = new Dictionary<string, Thuoc>(soLuongThuocCanSinh);
            Dictionary<string, List<string>> boNhoHanSuDung = new Dictionary<string, List<string>>();

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            Stopwatch swThem = Stopwatch.StartNew();
            for (int i = 1; i <= soLuongThuocCanSinh; i++)
            {
                string maThuoc = $"TN{i:D5}";
                string tenThuoc = $"Thuoc Mo Phong {i:D5}";
                string donViTinh = "Vien";
                string hanSuDung = $"{(i % 12) + 1:00}/20{25 + (i % 5)}";
                int soLuongTon = 50 + (i % 250);

                Thuoc thuoc = new Thuoc(maThuoc, tenThuoc, donViTinh, hanSuDung, soLuongTon);
                boNhoThuoc[maThuoc] = thuoc;

                if (!boNhoHanSuDung.ContainsKey(hanSuDung))
                {
                    boNhoHanSuDung[hanSuDung] = new List<string>();
                }
                boNhoHanSuDung[hanSuDung].Add(maThuoc);
            }
            swThem.Stop();

            GC.Collect();
            long boNhoSauKhiThem = GC.GetTotalMemory(true);

            Console.WriteLine("\nHoàn tất sinh dữ liệu.");
            Console.WriteLine("- Thời gian thêm dữ liệu: {0} ms", swThem.ElapsedMilliseconds);
            Console.WriteLine("- Bộ nhớ sử dụng ước tính: {0:N0} bytes (~{1:F2} MB)", boNhoSauKhiThem, boNhoSauKhiThem / (1024.0 * 1024.0));
            Console.WriteLine("- Mật độ dữ liệu: {0:N2} bytes/thuốc", boNhoSauKhiThem / (double)soLuongThuocCanSinh);

            string maThuocCanTim = $"TN{(soLuongThuocCanSinh / 2):D5}";
            Stopwatch swTimKiem = Stopwatch.StartNew();
            bool timThay = boNhoThuoc.TryGetValue(maThuocCanTim, out Thuoc thuocTimThay);
            swTimKiem.Stop();

            Console.WriteLine("\nKiểm tra truy xuất dữ liệu:");
            Console.WriteLine("- Mã cần tìm: {0}", maThuocCanTim);
            Console.WriteLine("- Kết quả: {0}", timThay ? "Tìm thấy" : "Không tìm thấy");
            Console.WriteLine("- Thời gian truy xuất: {0} ticks (~{1:F6} ms)", swTimKiem.ElapsedTicks, swTimKiem.Elapsed.TotalMilliseconds);

            string hanSuDungCanTim = boNhoHanSuDung.Keys.ElementAt(0);
            Stopwatch swThongKe = Stopwatch.StartNew();
            int soLuongTheoHan = boNhoHanSuDung.TryGetValue(hanSuDungCanTim, out List<string> danhSachTheoHan) ? danhSachTheoHan.Count : 0;
            swThongKe.Stop();

            Console.WriteLine("\nThống kê theo hạn sử dụng:");
            Console.WriteLine("- HSD chọn mẫu: {0}", hanSuDungCanTim);
            Console.WriteLine("- Số thuốc có HSD này: {0}", soLuongTheoHan);
            Console.WriteLine("- Thời gian thống kê: {0} ticks (~{1:F6} ms)", swThongKe.ElapsedTicks, swThongKe.Elapsed.TotalMilliseconds);

            Console.WriteLine("\nKẾT LUẬN:");
            Console.WriteLine("- Cấu trúc Dictionary đảm bảo thêm/truy xuất O(1) giúp xử lý nhanh ngay cả với dữ liệu >10.000 thuốc.");
            Console.WriteLine("- Bộ nhớ tiêu thụ vẫn trong ngưỡng thấp nhờ lưu trường dữ liệu tối giản và tái sử dụng object str.");
            Console.WriteLine("- Hệ thống đủ khả năng mở rộng cho các kho thuốc lớn hơn chỉ với việc tăng cấu hình phần cứng.");

            NhanPhimBatKy();
        }
    }
}
