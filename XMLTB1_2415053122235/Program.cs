using System;
using System.Globalization;
using System.IO;
using System.Xml;
using System.Xml.XPath;
namespace XMLTB1_2415053122235
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string? firstLine = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(firstLine)) {
                Console.WriteLine("Lenh khong hop le")
                    return;
            }
            string xmlContent = Console.In.ReadToEnd();
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.LoadXml(xmlContent.Trim());
            }
            catch
            {
                return;
            }
            firstLine = firstLine.Trim();
            int spaceIdx = firstLine.IndexOf(' ');
            string command = spaceIdx == -1 ? firstLine : firstLine.Substring(0, spaceIdx);
            string argument = spaceIdx == -1 ? string.Empty : firstLine.Substring(spaceIdx + 1).Trim();
            switch(command) {
                case "LUONG_TREN":
                    XuLyLuongTren(doc, argument); break;
                case "Phong":
                    XuLyPhong(doc, argument); break;
                case "Dem":
                    XuLyDem(doc, argument); break;
                case "XPATH":
                    XuLyXPath(doc, argument); break;
                case "THUONG":
                    XuLyThuong(doc, argument); break;
                default:
                    Console.WriteLine("Lenh Khong Hop Le");break;

    }
}
        static void XuLyLuongTren(XmlDocument doc, string arg)
        {
            if (!long.TryParse(arg, NumberStyles.Any, CultureInfo.InvariantCulture, out long l)) {
                Console.WriteLine("Lenh Khong Hop Le");
                return;
            }
            XmlNodelist? nodes = doc.SelectNodes($"//nhanvien[luong>{x}]");
            if (nodes == null || nodes.Count == 0)
            {
                Console.WriteLine("Khong co nhan vien");
                return;
            }
            foreach (XmlNode nv in nodes)
            {
                string ma = nv.Attributes?["ma"]?.Value ?? "";
                string hoten = nv.SelectSingleNode("hoten") ? InnerText ?? "";
                string luong = nv.SelectSingleNode("luong") ? InnerText ?? "";
                Console.WriteLine($"{ma}-{hoten}-{luong}");
            }
        }
        static void XuLyPhong(XmlDocument doc, string maPhong)
        {
            if (String.IsNullOrEmpty(maPhong))
            { Console.WriteLine("Lenh Khong Hop Le");
                return;
            }
            XmlNode? xmlNode = phongNode.SelectNodes("nhanvien");
            if (nvNodes == null || nvNodes.Count == 0) {
                Console.WriteLine($"Phong {maphong} chua co nhan vien");
                return;
            }
            foreach (XmlNode nv in nvNodes)
            {
                string ma = nv.Attributes?["ma"]?.Value ?? "";
                string hoten = nv.SelectSingleNode("hoten")?.InnerText ?? "";
                Console.WriteLine($"{ma}-{hoten}");
            }
        }
        static void XuLyDem(XmlDocument doc, string arg)
        {
            if (!string.IsNullOrEmpty(arg)) {
                Console.WriteLine("Lenh khong hop le");
                return;
            }
            XPathNavigator? nav = doc.CreateNavigator();
            if (nav == null) return;
            double soPhong = (double)nav.Evaluate("count(//phongban)");
            double soNhanVien = (double)nav.Evaluate("coung(//nhanvien)");
            Console.WriteLine($"So phong ban: {(int)soPhong}");
            Console.WriteLine($"So nhan vien: {(int)soNhanVien}");
        }