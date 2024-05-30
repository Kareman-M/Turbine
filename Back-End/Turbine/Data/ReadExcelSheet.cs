using OfficeOpenXml;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace Turbine.Data
{
    public class ReadExcelSheet
    {
        FactoryService factoryService;
        public ReadExcelSheet()
        {
            factoryService = ServiceHelper.GetService<FactoryService>();
        }
        public static void Read()
        {
            var obj = new  ReadExcelSheet();
            obj.Start();
        }
        private void Start()
        {
            try
            {

                var fi = new  FileInfo("Data/factory.xlsx");
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using (var package = new  ExcelPackage(fi))
                {
                    var workbook = package.Workbook;
                    var worksheet = workbook.Worksheets.First();
                    int rowCount = worksheet.Dimension.End.Row;

                    for (int row = 2; row <= rowCount; row++)
                    {
                        Factory factory = new  Factory();
                        factory.Id = row.ToString();
                        factory.Name = worksheet.Cells[row, 1].Value?.ToString().Trim();
                        factory.Phone = worksheet.Cells[row, 2].Value?.ToString().Trim();
                        factory.Description = worksheet.Cells[row, 3].Value?.ToString().Trim();
                        factory.Mail = worksheet.Cells[row, 4].Value?.ToString().Split(",")[0]?.Trim().Replace("mailto:","");
                        factory.WebSite = worksheet.Cells[row, 5].Value?.ToString().Split(",")[0]?.Trim().Replace("http://","");
                        factory.Sector = worksheet.Cells[row, 6].Value?.ToString().Trim();
                        factory.City = worksheet.Cells[row, 7].Value?.ToString().Trim();
                        factory.CityCode = worksheet.Cells[row, 8].Value?.ToString().Trim();

                        factoryService.Factories.Add(factory);
                    }
                }
            }
            catch(Exception ex)
            {
                throw new  Exception(ex.Message);
            }
        }

    }
}
