using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DocGhiFile
{
    // Đọc ghi file XML kết hợp với Generic
    internal static class XMLServices<T> where T : class // Giới hạn T chỉ là class
    {
        public static List<T> ReadFromXMLFile(string path)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("File không tồn tại"); return null;
            }
            else
            {
                using(FileStream fileStream = new FileStream(path, FileMode.Open))
                {
                    // Tạo 1 XmlSerializer để có thể dọc ghi file xml
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<T>)); 
                    List<T> list = (List<T>)xmlSerializer.Deserialize(fileStream); // Thực hiện đọc file  
                    return list;
                }
            }
        }
        public static void WriteToXMLFile(string path, List<T> data) {
            if (!File.Exists(path))
            {
                Console.WriteLine("File không tồn tại"); 
            }
            else
            {
                using (FileStream fileStream = new FileStream(path, FileMode.Create))
                {
                    // Tạo 1 XmlSerializer để có thể dọc ghi file xml
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<T>));
                    xmlSerializer.Serialize(fileStream, data);
                    Console.WriteLine("Thêm dữ liệu vào file thành công");
                }
            }
        }
    }
}
