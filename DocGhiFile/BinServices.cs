using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;


namespace DocGhiFile
{
    internal class BinServices<T> where T : class
    {
        public static List<T> ReadFromBinFile(string path)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("File không tồn tại"); return null;
            }
            else
            {
                using (FileStream fileStream = new FileStream(path, FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    List<T> list = (List<T>)bf.Deserialize(fileStream);
                    return list;    
                }
            }
        }
        public static void WriteToBinFile(string path, List<T> data)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("File không tồn tại");
            }
            else
            {
                using (FileStream fileStream = new FileStream(path, FileMode.Create))
                {
                    // Tạo 1 XmlSerializer để có thể dọc ghi file xml
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fileStream, data);
                    Console.WriteLine("Thêm dữ liệu vào file thành công");
                }
            }
        }
    }
}
