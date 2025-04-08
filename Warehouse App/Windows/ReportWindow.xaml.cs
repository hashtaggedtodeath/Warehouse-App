using Microsoft.Reporting.WinForms;
using System;
using System.IO;
using System.Windows;
using System.Windows.Forms.Integration;
using Warehouse_App.Data;

namespace Warehouse_App.Windows
{
    public partial class ReportWindow : Window
    {
        private DatabaseService _dbService;

        public ReportWindow()
        {
            InitializeComponent();
            _dbService = new DatabaseService();
            LoadReport();
        }

        private void LoadReport()
        {
            var reportViewer = new ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;

            // Указываем путь к .rdlc
            string reportPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports", "SuppliersReport.rdlc");
            reportViewer.LocalReport.ReportPath = reportPath;

            // Загружаем данные
            var suppliers = _dbService.GetSuppliers();
            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", suppliers));

            reportViewer.RefreshReport();

            reportHost.Child = reportViewer;

            // Экспорт в Excel
            ExportReportToExcel(reportViewer);
        }

        private void ExportReportToExcel(ReportViewer reportViewer)
        {
            byte[] bytes = reportViewer.LocalReport.Render("Excel", null, out string mimeType, out _, out _, out _, out _);

            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "SuppliersReport.xls");
            File.WriteAllBytes(filePath, bytes);

            MessageBox.Show($"Отчет сохранен на рабочем столе как:\n{filePath}", "Сохранено", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
