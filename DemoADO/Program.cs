namespace DemoADO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            ADOServices services = new ADOServices();
            var svData = services.GetAllSinhvien();
            foreach (var item in svData)
            {
                item.InThongTin();
            }
        }
    }
}