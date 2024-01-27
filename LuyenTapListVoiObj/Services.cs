using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LuyenTapListVoiObj
{
    internal class Services
    {
        List<Nguoi> nguois = new List<Nguoi>();
        // Khởi tạo thuộc tính List<Nguoi> cho lớp services
        public Services()
        {
            // nguois = new List<Nguoi>(); Nếu ở trên chưa khởi tạo khi thêm dòng này
            //nguois = new List<Nguoi> { 
            //    new Nguoi() {SoCCCD = "123", Ten ="Khanh", 
            //        DoB = DateTime.Now, DiaChi = "Gầm cầu Long Biên" } 
            //}; // đoạn khỏi tạo List với 1 phàn tử cho sẵn với anonymous type
        }
        // Constructor là hàm tạo có vai trò khởi tạo đối tượng và thuộc tính của đối
        // tượng đó. Nếu Constructor có tham số và gán giá trị của các thuộc tính
        // bằng giá trị của các tham số được truyền vào thì với những thuộc tính
        // không được gán hay khởi tạo sẵn sẽ mang giá trị mặc định
        // Viết Các phương thức thao tác trên List
        // Nhập và thêm phần tử 
        public void AddNguoi()
        {
            Console.WriteLine("Nhập số lượng người muốn thêm");
            int count = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                Nguoi n = new Nguoi();
                Console.WriteLine("Nhập Số CCCD");
                n.SoCCCD = Console.ReadLine();
                Console.WriteLine("Nhập Tên");
                n.Ten = Console.ReadLine();
                n.DoB = DateTime.Now;
                Console.WriteLine("Nhập Địa chỉ");
                n.DiaChi = Console.ReadLine();
                nguois.Add(n);
            }
            Console.WriteLine("bạn có muốn nhập tiếp không?");
            string choose = Console.ReadLine();
            if (choose == "Y" || choose == "y") AddNguoi(); // Gọi là chính hàm này
        }
        // Xuất danh sachs
        public void XuatDS()
        {
            if (nguois.Count == 0)
            {
                Console.WriteLine("Danh sách rỗng, hãy nhập phần tử đi đã");
                AddNguoi();
            }
            else
            {
                foreach (var item in nguois)
                {
                    item.InThongTin();
                }
            }
        }
        // Tìm kiếm những người mà tên có chứa chữ a hoặc n
        public void TimKiem1()
        {
            foreach (var item in nguois)
            {
                if (item.Ten.Contains("a") || item.Ten.Contains("n"))
                {
                    item.InThongTin();
                }
            }
        }
        // Với Where
        public void TimKiem2()
        {
            // Linq VỚI Lambda Expression
            var listKQ = nguois.Where(p => p.Ten.Contains("a") || p.Ten.Contains("n")).ToList();
            // LinQ thuần
            var listKQ2 = from Nguoi in nguois
                          where Nguoi.Ten.Contains("a") || Nguoi.Ten.Contains("n")
                          select Nguoi;
            foreach (var item in listKQ)
            {
                item.InThongTin();
            }
        }
        // Xóa phần tử Người mà CCCD không đúng (có độ dài khác 12 số hoặc 9 số
        public void XoaViPham()
        {
            // LinQ
            // nguois.RemoveAll(p => p.SoCCCD.Length != 9 && p.SoCCCD.Length != 12);
            // Vòng lặp for
            //for (int i = 0; i < nguois.Count; i++)
            //{
            //    if (nguois[i].SoCCCD.Length != 9 && nguois[i].SoCCCD.Length != 12)
            //    {
            //        nguois.RemoveAt(i); 
            //        i--; // Reset lại vi trí khi xáo phần tử
            //    }
            //}
            // Vòng lặp foreach
            foreach (var item in nguois.ToList()) // nguois và nguois.ToList() là 2 List khác nhau
            {
                // Không xóa trực tiếp ở List được kiểm tra sẽ không gay thay đổi List => Không gây lỗi
                if(item.SoCCCD.Length != 9 && item.SoCCCD.Length != 12)
                {
                    nguois.Remove(item);
                }
            }
            Console.WriteLine("Danh sách sau khi xóa");
            XuatDS();
        }
    }
}
