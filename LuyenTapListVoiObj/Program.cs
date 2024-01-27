namespace LuyenTapListVoiObj
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Services s = new Services();
            s.AddNguoi();
            s.XuatDS();
            s.XoaViPham();
        }
    }
}