using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.IO;
using Specialist.Data;
using Specialist.Model;
using OfficeOpenXml;

namespace Specialist.Handlers
{
    public class WriteAllSpecialistsToXLSHandler
    {
        private readonly SpecialistContext _context;

        public WriteAllSpecialistsToXLSHandler(SpecialistContext context)
        {
            _context = context;
        }

        public bool Handle()
        {
            List<MedicalSpecialist> list = new List<MedicalSpecialist>();

            using (MySqlConnection conn = _context.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from Specialists", conn);

                try
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new MedicalSpecialist()
                            {
                                Id = Convert.ToInt32(reader["specialist_id"]),
                                LastName = reader["last_name"].ToString(),
                                FirstName = reader["first_name"].ToString(),
                                MiddleName = reader["middle_name"].ToString(),
                                Email = reader["email"].ToString(),
                                PasswordHash = reader["password_hash"].ToString(),
                                HealthFacilitiesFacultyId = Convert.ToInt32(reader["Health_Facilities_faculty_id"]),
                            });
                        }
                    }
                }
                catch
                {
                    return false;
                }
                finally
                {
                    conn.CloseAsync();
                }
            }

            return WriteToXLS(list) ? true : false;
        }

        private static bool WriteToXLS(List<MedicalSpecialist> specialists)
        {
            ExcelPackage excel = new ExcelPackage();
            excel.Workbook.Worksheets.Add("Specialists");

            var headerRow = new List<string[]>()
            {
                new string[] { "ID", "Last Name", "First Name", "Middle Name", "Email", "Password Hash", "Faculty Id" }
            };

            var worksheet = excel.Workbook.Worksheets["Specialists"];
            worksheet.Cells[1, 1].LoadFromArrays(headerRow);
            worksheet.Cells[2, 1].LoadFromCollection(specialists);

            FileInfo excelFile = new FileInfo(@"specialists.xlsx");
            excel.SaveAs(excelFile);
            return true;
        }
    }
}

