using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using OfficeOpenXml;

using Microsoft.Win32;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;



namespace Warehouse_App.Windows
{
    public static class Exporter
    {
        public static void ExportSalesToExcel(List<Sales> salesList)
        {
            var excelApp = new Excel.Application();
            excelApp.Visible = false;
            var workbook = excelApp.Workbooks.Add();

            // Группировка по товарам
            var groupedSales = salesList.GroupBy(s => s.Products.Name);

            foreach (var group in groupedSales)
            {
                var worksheet = workbook.Sheets.Add();
                worksheet.Name = group.Key.Length > 31 ? group.Key.Substring(0, 31) : group.Key;

                worksheet.Cells[1, 1] = "Покупатель";
                worksheet.Cells[1, 2] = "Поставщик";
                worksheet.Cells[1, 3] = "Количество";
                worksheet.Cells[1, 4] = "Сумма";

                int row = 2;
                foreach (var sale in group)
                {
                    worksheet.Cells[row, 1] = sale.Customers?.Name;
                    worksheet.Cells[row, 2] = sale.Suppliers?.Name;
                    worksheet.Cells[row, 3] = sale.QuantitySold;
                    worksheet.Cells[row, 4] = sale.TotalAmount;
                    row++;
                }

                worksheet.Columns.AutoFit();
            }

            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Продажи.xlsx");
            workbook.SaveAs(filePath);
            workbook.Close();
            excelApp.Quit();
        }
        public static void ExportSalesToWord(List<Sales> salesList)
        {
            var wordApp = new Word.Application();
            var doc = wordApp.Documents.Add();

            var groupedSales = salesList.GroupBy(s => s.Products.Name);
            foreach (var group in groupedSales)
            {
                // Заголовок
                var heading = doc.Content.Paragraphs.Add();
                heading.Range.Text = $"Продажи по товару: {group.Key}";
                heading.Range.set_Style(Word.WdBuiltinStyle.wdStyleHeading1);
                heading.Range.InsertParagraphAfter();

                // Таблица
                int rows = group.Count() + 1;
                int cols = 4;
                var range = doc.Bookmarks.get_Item("\\endofdoc").Range;
                var table = doc.Tables.Add(range, rows, cols);
                table.Borders.Enable = 1;

                table.Cell(1, 1).Range.Text = "Покупатель";
                table.Cell(1, 2).Range.Text = "Поставщик";
                table.Cell(1, 3).Range.Text = "Количество";
                table.Cell(1, 4).Range.Text = "Сумма";

                int row = 2;
                foreach (var sale in group)
                {
                    table.Cell(row, 1).Range.Text = sale.Customers?.Name;
                    table.Cell(row, 2).Range.Text = sale.Suppliers?.Name;
                    table.Cell(row, 3).Range.Text = sale.QuantitySold.ToString();
                    table.Cell(row, 4).Range.Text = sale.TotalAmount.ToString("C");
                    row++;
                }

                // Разрыв страницы после таблицы (если это не последняя)
                if (group != groupedSales.Last())
                {
                    var breakParagraph = doc.Content.Paragraphs.Add();
                    breakParagraph.Range.InsertBreak(Word.WdBreakType.wdPageBreak);
                }
            }

            wordApp.Visible = true;
        }

    }
}
