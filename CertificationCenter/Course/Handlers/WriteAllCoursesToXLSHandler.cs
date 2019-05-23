using Course.Data;
using Course.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.IO;
using OfficeOpenXml;

namespace Course.Handlers
{
    public class WriteAllCoursesToXLSHandler
    {
        private readonly CourseContext _context;

        public WriteAllCoursesToXLSHandler(CourseContext context)
        {
            _context = context;
        }

        public bool Handle()
        {
            List<MedicalCourse> list = new List<MedicalCourse>();

            using (MySqlConnection conn = _context.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from Courses", conn);

                try
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new MedicalCourse()
                            {
                                Id = Convert.ToInt32(reader["course_id"]),
                                Name = reader["course_name"].ToString(),
                                Qualification = Convert.ToInt32(reader["qualification"])
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

                return WriteToXLS(list) ? true : false;
            }
        }

        private static bool WriteToXLS(List<MedicalCourse> courses)
        {
            ExcelPackage excel = new ExcelPackage();
            excel.Workbook.Worksheets.Add("Courses");

            var headerRow = new List<string[]>()
            {
                new string[] { "ID", "Course Name", "Qualification" }
            };

            var worksheet = excel.Workbook.Worksheets["Courses"];
            worksheet.Cells[1, 1].LoadFromArrays(headerRow);
            worksheet.Cells[2, 1].LoadFromCollection(courses);

            FileInfo excelFile = new FileInfo(@"courses.xlsx");
            excel.SaveAs(excelFile);
            return true;
        }

        private static System.Data.DataTable ConvertToDataTable(List<MedicalCourse> courses)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(MedicalCourse));
            System.Data.DataTable table = new System.Data.DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);

            foreach (var course in courses)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                {
                    row[prop.Name] = prop.GetValue(course) ?? DBNull.Value;
                }
                table.Rows.Add(row);
            }
            return table;
        }

    }
}

