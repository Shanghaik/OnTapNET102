using System.Collections;

namespace OnTapNET102
{
    internal class Program
    {
        // Collection: là các lớp được tạo ra với mục đích lưu trữ và quản lý dữ liệu
        // một cách linh hoạt và đa dạng. Có 2 loại là Collection cơ bản và Generic 
        // Collection
        // Collection<T>: generic collection bao gồm List, Dictionary, Hashmap,...
        // Collection: ArrayList, Hashtable,...
        // Các Collection đều có các phương thức để thao tác với dữ liệu
        // Collection là còn là 1 references type
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            // Cú pháp khia báo List
            List<string> listStr = new List<string>(); // Khởi tạo 1 List string
            // <string> là kiểu dữ liệu bắt buộc mà List này phải chứa
            // ArrayList arrayList= new ArrayList(); // Chứa được mọi kiểu dữ liệu
            // Them dữ liệu vào List với Add(), khi add thì các phần tử sẽ được thêm
            // tuần tự vào trong List
            listStr.Add("A");
            listStr.Add("B");
            for (int i = 67; i <= 70; i++)
            {
                listStr.Add(Convert.ToChar(i) + ""); // + "" để dữ liệu tự ép sang string
                // Convert.ToChar() cho phép lấy ra kí tự từ bảng mã ASCII
            }
            // Thêm 1 phần tử vào 1 vị trí nào đó trong List với Insert
            listStr.Insert(4, "KhanhPG"); // insert vào vị trí số 5 chuỗi KhanhPG
            // Cú phảp in ra toàn bộ List dạng values type với string.Join
            // Ngoài add và insert chúng ta có thể dùng AddRange và InSertRange để thêm
            // vào nhiều phần tử cùng 1 lúc
            List<string> listStr2 = new List<string>() { "x", "y", "x" };// thêm nhanh phần tử
            listStr.AddRange(listStr2); // Thêm cả List listStr2 vào cuối listStr
            Console.WriteLine(string.Join('-', listStr));
            // Kiểm tra tồn tại với phương thức Contains
            if (listStr.Contains("H"))
            {
                Console.WriteLine("Có chứa H");
            }
            else Console.WriteLine("Không chứa H");
            // Kiểm tra vị trí với IndexOf/LastIndexOf
            Console.WriteLine("Vị trí đầu tiên của x: " + listStr.IndexOf("x")); // Vị trí đầu tiên
            Console.WriteLine("Vị trí cuối cùng của x: " + listStr.LastIndexOf("x")); // vị trí cuối cùng
            // Nếu phần tử không tồn tại trong List thì sẽ trả về giá trị -1
            // Làm sao để biết 1 phần tử trong List có phải phần tử duy nhất hay không
            // nếu phần tử là duy nhất => vị trí cuối cùng và đầu tiên của nó trong List bằng nhau
            // Nhưng phần tử cũng phải nằm trong List đã
            if (listStr.IndexOf("x") == listStr.LastIndexOf("x") && listStr.IndexOf("x") != -1)
            {
                Console.WriteLine("Phần tử là duy nhất");
            }
            else Console.WriteLine("Phần tử không tồn tại hoặc không phải duy nhất");
            // Xóa các phần tử trong List
            // Xóa 1 phần tử Remove-xóa theo giá trị/RemoveAt: xóa theo vị trí
            // listStr.Remove("A"); // Xóa phần tử có giá trị là A
            // listStr.RemoveAt(5); // Xóa ở vị trí số 5
            // Phương thức RemoveRange để xóa từ vị trí 2 và xóa 4 phần tử sau đó
            listStr.RemoveRange(2, 4);
            Console.WriteLine(string.Join('-', listStr));
            // listStr.Clear() - Xóa toàn bộ các phần tử
        }
    }
}