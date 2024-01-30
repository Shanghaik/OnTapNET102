namespace DocGhiFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            List<DongVat> dvs = new List<DongVat>()
            {
                new DongVat() {Ten = "Hổ", MoTa = "Ăn thịt", SoChan = 4},
                new DongVat() {Ten = "Báo", MoTa = "Ăn thịt", SoChan = 4},
                new DongVat() {Ten = "Cáo", MoTa = "Ăn quả", SoChan = 4},
                new DongVat() {Ten = "Chồn", MoTa = "Ăn hạt dẻ", SoChan = 4},
                new DongVat() {Ten = "Gà", MoTa = "Ăn thóc", SoChan = 2}
            };
            // ghi vào file
             TextServices.WriteDataToFile(@"dongvat.txt", dvs);
            // đọc file
            List<DongVat> dvs2 = TextServices.ReadFromFile(@"dongvat.txt");
            foreach (var item in dvs2)
            {
                item.InThongTin();
            }
        }
    }
}