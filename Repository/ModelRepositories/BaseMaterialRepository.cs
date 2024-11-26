using ExcelDataReader;
using Models.Models;
using Repository.Interfaces;
using Repository.ModelRepositories.GenericRepository;

namespace Repository.ModelRepositories
{
    public class BaseMaterialRepository : CRUDRepository<BaseMaterial>, IBaseMaterialRepository
    {

        public BaseMaterialRepository(DataBaseContext dbContext) : base(dbContext)
        {
        }

        public async Task<BaseMaterial> GetAllExtended()
        {
            return null;
        }
        public void LoadData()
        {
            string filePath = "C:\\Users\\palid\\Downloads\\2021-2023 FNDDS At A Glance - FNDDS Nutrient Values.xlsx";
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = _ => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true // Assumes that the first row contains headers
                        }
                    });

                    // Load the relevant sheet
                    var table = result.Tables["FNDDS Nutrient Values"];


                    for (int i = 1; i < table.Rows.Count; i++) // Skip header row
                    {
                        var row = table.Rows[i];

                        var baseMaterial = new BaseMaterial
                        {
                            MaterialName = row.ItemArray[1].ToString(),
                            MaterialCode = row.ItemArray[0].ToString(),
                            Protein = Convert.ToDecimal(row.ItemArray[5]),
                            Quantity = 100,
                            Fat = Convert.ToDecimal(row.ItemArray[9]),
                            Carbohydrate = Convert.ToDecimal(row.ItemArray[6]),
                            Cholesterol = 0, // Add logic if cholesterol data is present
                            Fiber = Convert.ToDecimal(row.ItemArray[8]),
                            Kalium = 0, // Add mapping for Potassium if available
                            MaterialGroupId = 22, // Fixed value as per your requirement
                            Measure = "g", // Default value, change if needed
                            IsAllergen = false, // Default or map if needed
                            Kilojule = Convert.ToDecimal(row.ItemArray[4]) * Convert.ToDecimal(4.184),
                            Sugar = Convert.ToDecimal(row.ItemArray[7]),

                        };

                        _dbContext.BaseMaterials.Add(baseMaterial);
                    }

                    _dbContext.SaveChanges(); // Save changes to the database

                }
            }
        }
    }
}
