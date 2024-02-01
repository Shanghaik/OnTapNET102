using Microsoft.Data.SqlClient;
using System;
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
            List<Sinhvien> list = new List<Sinhvien>(); // tạo 1 list để hứng data
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
            finally { con.Close(); } // Bất kì trường hợp nào xả ra đều đóng liên kết - lệnh này luôn được chạy
            return list;    
        }
    }
}
