using System;
using System.Collections.Generic;

namespace QuanLyDonHangOOP
{
    public class SanPham
    {
        private string maSP;
        private string tenSP;
        private decimal donGia;
        private int soLuong;

        public SanPham()
        {
            maSP = "";
            tenSP = "";
            donGia = 0;
            soLuong = 0;
        }

        public SanPham(string maSP, string tenSP, decimal donGia, int soLuong)
        {
            this.maSP = maSP;
            this.tenSP = tenSP;
            this.donGia = donGia;
            this.soLuong = soLuong;
        }

        public string GetMaSP()
        {
            return maSP;
        }

        public void SetMaSP(string maSP)
        {
            this.maSP = maSP;
        }

        public string GetTenSP()
        {
            return tenSP;
        }

        public void SetTenSP(string tenSP)
        {
            this.tenSP = tenSP;
        }

        public decimal GetDonGia()
        {
            return donGia;
        }

        public void SetDonGia(decimal donGia)
        {
            this.donGia = donGia;
        }

        public int GetSoLuong()
        {
            return soLuong;
        }

        public void SetSoLuong(int soLuong)
        {
            this.soLuong = soLuong;
        }
        //t
        public decimal TinhThanhTien()
        {
            return donGia * soLuong;
        }

        public void HienThiThongTin()
        {
            Console.WriteLine($"Ma SP: {maSP}, Ten: {tenSP}, Don gia: {donGia:C}, So luong: {soLuong}, Thanh tien: {TinhThanhTien():C}");
        }
    }

    public class DonHang
    {
        private string maDH;
        private DateTime ngayDatHang;
        private List<SanPham> danhSachSP;

        public DonHang()
        {
            maDH = "";
            ngayDatHang = DateTime.Now;
            danhSachSP = new List<SanPham>();
        }

        public DonHang(string maDH, DateTime ngayDatHang)
        {
            this.maDH = maDH;
            this.ngayDatHang = ngayDatHang;
            danhSachSP = new List<SanPham>();
        }

        public string GetMaDH()
        {
            return maDH;
        }

        public void SetMaDH(string maDH)
        {
            this.maDH = maDH;
        }

        public DateTime GetNgayDatHang()
        {
            return ngayDatHang;
        }

        public void SetNgayDatHang(DateTime ngayDatHang)
        {
            this.ngayDatHang = ngayDatHang;
        }

        public List<SanPham> GetDanhSachSP()
        {
            return danhSachSP;
        }

        public void ThemSanPham(SanPham sp)
        {
            danhSachSP.Add(sp);
        }

        public bool XoaSanPham(string maSP)
        {
            for (int i = 0; i < danhSachSP.Count; i++)
            {
                if (danhSachSP[i].GetMaSP() == maSP)
                {
                    danhSachSP.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
        //i
        public SanPham TimSanPham(string maSP)
        {
            for (int i = 0; i < danhSachSP.Count; i++)
            {
                if (danhSachSP[i].GetMaSP() == maSP)
                {
                    return danhSachSP[i];
                }
            }
            return null;
        }

        public decimal TinhTongTien()
        {
            decimal tong = 0;
            for (int i = 0; i < danhSachSP.Count; i++)
            {
                tong += danhSachSP[i].TinhThanhTien();
            }
            return tong;
        }

        public void HienThiDonHang()
        {
            Console.WriteLine("===== DON HANG =====");
            Console.WriteLine($"Ma don hang: {maDH}");
            Console.WriteLine($"Ngay dat hang: {ngayDatHang:dd/MM/yyyy}");
            Console.WriteLine("Danh sach san pham:");

            if (danhSachSP.Count == 0)
            {
                Console.WriteLine("Khong co san pham nao!");
            }
            else
            {
                for (int i = 0; i < danhSachSP.Count; i++)
                {
                    Console.Write($"{i + 1}. ");
                    danhSachSP[i].HienThiThongTin();
                }
            }

            Console.WriteLine($"Tong tien: {TinhTongTien():C}");
            Console.WriteLine("====================");
        }
    }

    class Program
    {
        static void Main()
        {
            // Tao don hang
            DonHang dh1 = new DonHang("DH001", new DateTime(2024, 12, 1));

            // Tao san pham
            SanPham sp1 = new SanPham("SP001", "Laptop", 15000000, 1);
            SanPham sp2 = new SanPham("SP002", "Chuot", 200000, 2);
            SanPham sp3 = new SanPham("SP003", "Ban phim", 500000, 1);

            // Them san pham vao don hang
            dh1.ThemSanPham(sp1);
            dh1.ThemSanPham(sp2);
            dh1.ThemSanPham(sp3);

            // Hien thi don hang
            dh1.HienThiDonHang();

            Console.WriteLine();

            // Tim san pham
            SanPham timKiem = dh1.TimSanPham("SP002");
            if (timKiem != null)
            {
                Console.WriteLine("Tim thay san pham:");
                timKiem.HienThiThongTin();
            }

            Console.WriteLine();

            // Xoa san pham
            if (dh1.XoaSanPham("SP003"))
            {
                Console.WriteLine("Da xoa san pham SP003");
            }
             //                                                                                                                                                                                                                                              nh
            // Hien thi lai don hang sau khi xoa 
            dh1.HienThiDonHang();

            Console.ReadLine();
        }
    }
}
