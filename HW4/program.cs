
using System;

// Lớp CongNhan
public class CongNhan
{
    private string hoTen;   
    private int soSanPham; 
    private double gia;     

    public CongNhan()
    {
        this.hoTen = "";
        this.soSanPham = 0;
        this.gia = 0.0;
    }
    public CongNhan(string hoTen, int soSanPham, double gia)
    {
        this.hoTen = hoTen;
        this.soSanPham = soSanPham;
        this.gia = gia;
    }




    public string HoTen
    {
        get { return hoTen; }
        set { hoTen = value; }
    }

    public int SoSanPham
    {
        get { return soSanPham; }
        set { soSanPham = value; }
    }

    public double Gia
    {
        get { return gia; }
        set { gia = value; }
    }



    public double TinhLuong()
    {
        return soSanPham * gia;
    }

    public void HienThi()
    {
        Console.WriteLine($"Họ tên: {hoTen,-20} | Số sản phẩm: {soSanPham,5} | Lương: {TinhLuong(),10:F2}");
    }

   
}

public class DSCongNhan
{
    private double tongLuong;
    private CongNhan[] dscn;
    private int soLuongCongNhan;

    public DSCongNhan(int kichThuoc)
    {
        this.dscn = new CongNhan[kichThuoc];
        this.tongLuong = 0.0;
        this.soLuongCongNhan = 0;
    }

    public CongNhan this[int index]
    {
        get
        {
            if (index >= 0 && index < soLuongCongNhan)
            {
                return dscn[index];
            }
            throw new IndexOutOfRangeException($"Chỉ số không hợp lệ: {index}");
        }
        set
        {
            if (index >= 0 && index < dscn.Length)
            {
                dscn[index] = value;
                if (index >= soLuongCongNhan)
                {
                    soLuongCongNhan = index + 1;
                }
            }
            else
            {
                throw new IndexOutOfRangeException($"Chỉ số không hợp lệ: {index}");
            }
        }
    }

    public int SoLuongCongNhan
    {
        get { return soLuongCongNhan; }
    }



    public void HienThi()
    {
        Console.WriteLine("STT | Họ tên              | Số SP | Lương");


        for (int i = 0; i < soLuongCongNhan; i++)
        {
            dscn[i].HienThi();
        }

        Console.WriteLine($"Tổng lương: {Tongluong()}");
    }

    public double Tongluong()
    {
        tongLuong = 0.0;
        for (int i = 0; i < soLuongCongNhan; i++)
        {
            tongLuong += dscn[i].TinhLuong();
        }
        return tongLuong;
    }

    public bool ThemCongNhan(CongNhan congNhan)
    {
        if (soLuongCongNhan < dscn.Length)
        {
            dscn[soLuongCongNhan] = congNhan;
            soLuongCongNhan++;
            return true;
        }
        return false;
    }
}

public class CongNhanTest
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
    
        CongNhan cn1 = new CongNhan("Nguyen Van A", 100, 15000);
        CongNhan cn2 = new CongNhan("Le Thi B", 80, 12000);
        CongNhan cn3 = new CongNhan("Tran Van C", 120, 18000);

      
        cn1.HienThi();
        cn2.HienThi();
        cn3.HienThi();

        Console.WriteLine("\nKiểm tra Properties:");
        Console.WriteLine($"Tên CN1: {cn1.HoTen}, SP: {cn1.SoSanPham}, Giá: {cn1.Gia:F2}");

        // Thay đổi 
        cn1.HoTen = "Nguyen Van A (Updated)";
        cn1.SoSanPham = 150;
        cn1.Gia = 20000;
        Console.WriteLine($"Sau khi cập nhật: {cn1.HoTen}, SP: {cn1.SoSanPham}, Giá: {cn1.Gia:F2}");

     

        // Tạo danh sách công nhân với kích thước 5
        DSCongNhan ds = new DSCongNhan(5);

        // Thêm công nhân vào danh sách
        ds.ThemCongNhan(new CongNhan("Hoang Van D", 90, 14000));
        ds.ThemCongNhan(new CongNhan("Pham Thi E", 110, 16000));
        ds.ThemCongNhan(new CongNhan("Vo Van F", 95, 13500));

        Console.WriteLine("Hiển thị danh sách công nhân:");
        ds.HienThi();

        // Test Indexer
        Console.WriteLine("\n3. KIỂM TRA INDEXER:");
        Console.WriteLine($"Công nhân tại vị trí [0]: {ds[0].HoTen} - Lương: {ds[0].TinhLuong()}");
        Console.WriteLine($"Công nhân tại vị trí [1]: {ds[1].HoTen} - Lương: {ds[1].TinhLuong()}");

        // Cập nhật c
        ds[1] = new CongNhan("Le Thi G (New)", 130, 17000);
        Console.WriteLine($"Sau khi cập nhật [1]: {ds[1].HoTen} - Lương: {ds[1].TinhLuong():F2}");

        Console.WriteLine($"\nTổng lương tất cả công nhân: {ds.Tongluong():F2}");

       
        Console.WriteLine($"- Họ tên: {ds[0].HoTen}");
        Console.WriteLine($"- Số sản phẩm: {ds[0].SoSanPham}");
        Console.WriteLine($"- Giá: {ds[0].Gia:F2}");
        Console.WriteLine($"- Lương: {ds[0].TinhLuong():F2}");

       
        ds[0].HoTen += " (fdsds)";
        ds[0].SoSanPham += 20;
        ds[0].Gia += 2000;

        Console.WriteLine("\nSau khi thay đổi qua Properties:");
        Console.WriteLine($"- Họ tên: {ds[0].HoTen}");
        Console.WriteLine($"- Số sản phẩm: {ds[0].SoSanPham}");
        Console.WriteLine($"- Giá: {ds[0].Gia:F2}");
        Console.WriteLine($"- Lương: {ds[0].TinhLuong():F2}");

        Console.WriteLine("\nHiển thị lại toàn bộ danh sách:");
        ds.HienThi();

        Console.ReadLine();
    }
}
