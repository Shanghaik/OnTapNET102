using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoADO
{
    /*
     * Khi muốn thực hiện liên kết với CSDL SQL thì chúng ta cần cài đặt
     * nuget pakage cần thiết
     * Bước 2: Xây dựng connection string chứa những thông tin liên quan
     * tới cấu hình của database mà chúng ta cần trỏ tới
     * Bước 3: thực hiện kết nối
     */
    internal class ADOServices
    {
        string connectionString = @"Data Source=Shanghaik;Initial Catalog=ADODEMO;Integrated Security=True;TrustServerCertificate=True";
        public List<Sinhvien> GetAllSinhvien()
        {
            SqlConnection con = new SqlConnection(connectionString); // Tạo 1 sql connection
            // Tạo câu truy vấn cần thiết
            string query = "select * from SINHVIEN";
            SqlCommand cmd = new SqlCommand(query, con);
            List<Sinhvien> list = new List<Sinhvien>(); // tạo 1 list để hứng data và trả về
            try
            {
                con.Open(); // Mở kết nối
                SqlDataReader reader = cmd.ExecuteReader(); // Bình chứa dữ liệu lấy ra từ DB
                while (reader.Read()) // Đọc từng dòng để lấy ra từng đối tượng Student
                {
                    Sinhvien sv = new Sinhvien();
                    sv.ID = Convert.ToInt32(reader["ID"]);
                    sv.IDLop = Convert.ToInt32(reader["IdLop"]);
                    sv.Mark = Convert.ToSingle(reader["Mark"]);
                    sv.Name = reader["Ten"].ToString();
                    sv.Username = reader["Username"].ToString();
                    sv.Pass = reader["Pass"].ToString();
                    list.Add(sv);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally { con.Close(); } // Bất kì trường hợp nào xảy ra đều đóng liên kết - lệnh này luôn được chạy
            return list;
        }
        public void AddNewSinhVien()
        {
            // Nhập thông tin của sinh viên cần add vào CSDL
            // Không cần tạo đối tượng mà chỉ cần nhập để cho vào truy vấn
            Console.WriteLine("Nhập mã lớp"); // 1 2 3 4 5
            string idLop = Console.ReadLine();
            Console.WriteLine("Nhập Tên"); // Tên sinh viên
            string ten = Console.ReadLine();
            Console.WriteLine("Nhập điểm"); // Điểm
            string diem = Console.ReadLine();
            Console.WriteLine("Nhập username"); // Tên username
            string username = Console.ReadLine();
            Console.WriteLine("Nhập Pass"); // Tên mật khẩu
            string pass = Console.ReadLine();
            string query = $"insert into Sinhvien values ({idLop}, N'{ten}', {diem}, '{username}','{pass}')";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                int x = cmd.ExecuteNonQuery(); // thực hiện chạy truy vấn đơn thuần trả về số lượng row được tác động
                Console.WriteLine($"Đã thêm thành công {x} bản ghi"); // in ra số lượng bản ghi được thêm
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally { con.Close(); }
        }
        public void SuaSinhVien() // Sửa điểm của sinh viên theo tên
        {
            Console.WriteLine("Nhập Tên sinh viên bạn cần sửa điểm"); // Tên sinh viên
            string ten = Console.ReadLine();
            SqlConnection con = new SqlConnection(connectionString);
            // Kiểm tra xem sinh viên có nằm trong hệ thống hay không?
            string query = $"Select * from Sinhvien where ten ='{ten}'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader x = cmd.ExecuteReader(); // trả về các bản ghi hứng bởi datareader 
            int count = 0; // đếm số bản ghi trả về
            while (x.Read()) { 
                count++; // Nếu có nhiều SV thì tăng count lên 
            }
            con.Close();
            if (count == 0) Console.WriteLine($"Sinh viên có tên {ten} không tồn tại");
            else
            {
                Console.WriteLine("Điểm mới của sinh viên là: ");
                string diemmoi = Console.ReadLine();
                query = $"update Sinhvien set Mark = {diemmoi} where ten = '{ten}'";
                con.Open();
                SqlCommand cmd2 = new SqlCommand(query, con);
                int y = cmd2.ExecuteNonQuery(); // y là số lượng bản ghi được thay đổi
                Console.WriteLine($"bạn đã đổi điểm của {y} bản ghi thành {diemmoi}");
                con.Close();
            }
        }
        public void XoaSinhVien() // Xóa sinh viên theo tên
        {
            Console.WriteLine("Nhập Tên sinh viên bạn cần sửa xóa"); // Tên sinh viên
            string ten = Console.ReadLine();
            string query = $"delete from Sinhvien where ten ='{ten}'";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);    
            int x = cmd.ExecuteNonQuery();
            con.Close();    
            if (x == 0) Console.WriteLine($"Không có sinh viên nào có thể xóa có tên là {ten}");
            else Console.WriteLine($"Bạn đã xóa {x} bản ghi");
        }
    }
}
