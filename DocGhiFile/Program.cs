﻿namespace DocGhiFile
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
            //// ghi vào file
            // TextServices.WriteDataToFile(@"C:\Users\Acer\source\repos\OnTapNET102\DocGhiFile\data.txt", dvs);
            //// đọc file
            //List<DongVat> dvs2 = TextServices.ReadFromFile(@"C:\Users\Acer\source\repos\OnTapNET102\DocGhiFile\data.txt");
            //foreach (var item in dvs2)
            //{
            //    item.InThongTin();
            //}
            // Ghi file xml
            //XMLServices<DongVat>.WriteToXMLFile("data.xml", dvs);
            //// đọc và in ra
            //var listXML = XMLServices<DongVat>.ReadFromXMLFile("data.xml");
            //foreach (var item in listXML)
            //{
            //    item.InThongTin();
            //}
            BinServices<DongVat>.WriteToBinFile("data.bin", dvs);
            var listBin = BinServices<DongVat>.ReadFromBinFile("data.bin");
            foreach (var item in listBin)
            {
                item.InThongTin();
            }
        }
    }
}