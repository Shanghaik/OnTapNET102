using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocGhiFile
{
    internal static class TextServices
    {
        // Lớp static sẽ chứa các phương thức static, phương thức static là 
        // phương thức có thể gọi trực tiếp thông qua tên class mà không cần tạo
        // ra đối tượng cự thể
        public static string ObjToString(DongVat dv)
        {
            return $"{dv.Ten}|{dv.MoTa}|{dv.SoChan}";
        }// trả về 1 chuỗi chứa đủ thông tin chua đối tượng, mỗi thuộc tính sẽ được
         // phân tách với thuộc tính tiếp theo bởi 1 dấu |

        public static DongVat StringToObj(string data)
        {
            // Kiểm tra xem string có chứa 2 dấu | hay không?
            if (data.Length - data.Replace("|", "").Length != 2)
            {
                return null;
            }
            else
            {
                // cắt chuỗi ra thành các phần chứa thông tin của đối tượng
                string[] dataObj = data.Split('|'); // Cắt thành 1 mảng chứa dữ liệu của các
                // thuộc tính
                DongVat dv = new DongVat();
                dv.Ten = dataObj[0]; // Tên chính là phần tử đầu tiên của mảng dataObj
                dv.MoTa = dataObj[1];
                dv.SoChan = Convert.ToInt32(dataObj[2]);
                return dv;
            }
        }
        // Đọc dữ liệu từ file dựa vào đường dẫn, trả về danh sách đối tượng DongVat
        public static List<DongVat> ReadFromFile(string path)
        {
            if (File.Exists(path))
            {
                List<DongVat> dvs = new List<DongVat>();
                string[] files = File.ReadAllLines(path); // đọc tất cả các dòng từ file
                foreach (var item in files)
                {
                    if (StringToObj(item) != null) // Nếu đọc được dữ liệu từ 1 dòng bất kì của file
                    {
                        dvs.Add(StringToObj(item));
                    }
                }
                return dvs;
            }
            else { Console.WriteLine("File không tồn tại"); return null; }
        }
        public static void WriteDataToFile(string path, List<DongVat> dvs)
        {
            if(!File.Exists(path))
            {
                Console.WriteLine("File không tòn tại");
            }
            else
            {
                File.WriteAllText(path, ""); // Ghi đè một chuỗi rỗng vào file => Dữ liệu mất trắng
                foreach (var item in dvs)
                {
                    string data = ObjToString(item);
                    File.AppendAllText(path,("\n"+data)); // \n để xuống dòng cho mỗi bản ghi
                }
                Console.WriteLine("Ghi file thành công");
            }
        }
    }
}
