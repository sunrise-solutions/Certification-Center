using MySql.Data.MySqlClient;
using NUnit.Framework;
using Specialist.Model;
using Specialist.Handlers;
using Specialist.Commands;
using Specialist.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace CertificationCenter.Tests
{
    //course
    public class SpecialistTests
    {
        public string connString = "server=localhost;port=3306;database=certification_database;uid=liza;password=12345admin;";
        public MySqlConnection conn;

        #region Courses tests

        [Test]
        public void CreateCourseTest()
        {
            // arrange
            List<MedicalSpecialist> list = new List<MedicalSpecialist>();

            MedicalSpecialist expected = new MedicalSpecialist
            {
                LastName = "lastname",
                FirstName = "name",
                MiddleName = "middlename",
                Email = "email@gmail.com",
                PasswordHash = "password",
                HealthFacilitiesFacultyId = 1,
            };

            CreateSpecialistCommand command = new CreateSpecialistCommand
            {
                LastName = "lastname",
                FirstName = "name",
                MiddleName = "middlename",
                Email = "email@gmail.com",
                PasswordHash = "password",
                HealthFacilitiesFacultyId = 1,
            };

            //act
            SpecialistContext context = new SpecialistContext(connString);
            CreateSpecialistHandler handler = new CreateSpecialistHandler(context);
            handler.Handle(command);


            using (conn = new MySqlConnection(connString))
            {
                conn.Open();
                string query = string.Format("select * from specialists where email='email@gmail.com' and last_name='lastname'");

                MySqlCommand cmd = new MySqlCommand(query, conn);

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
                            HealthFacilitiesFacultyId = Convert.ToInt32(reader["Health_Facilities_faculty_id"]),
                        });
                    }
                }
            }

            if (list[0].HealthFacilitiesFacultyId == expected.HealthFacilitiesFacultyId && 
                list[0].LastName == expected.LastName && list[0].Email == expected.Email)
                Assert.IsTrue(true);
        }

        [Test]
        public void UpdateCourseTest()
        {
            // arrange
            List<MedicalSpecialist> list = new List<MedicalSpecialist>();
            int id = 1;

            MedicalSpecialist expected = new MedicalSpecialist
            {
                LastName = "lastname",
                FirstName = "name",
                MiddleName = "middlename",
                Email = "email@gmail.com",
                PasswordHash = "password",
                HealthFacilitiesFacultyId = 1,
            };

            CreateSpecialistCommand command = new CreateSpecialistCommand
            {
                LastName = "newlastname",
                FirstName = "newname",
                MiddleName = "newmiddlename",
                Email = "newemail@gmail.com",
                PasswordHash = "password",
                HealthFacilitiesFacultyId = 1,
            };

            //act
            SpecialistContext courseContext = new SpecialistContext(connString);
            UpdateSpecialistHandler createCourseHandler = new UpdateSpecialistHandler(courseContext);
            createCourseHandler.Handle(id, command);


            using (conn = new MySqlConnection(connString))
            {
                conn.Open();
                string query = string.Format("select * from specialists where email='newemail@gmail.com' and last_name='newlastname'");

                MySqlCommand cmd = new MySqlCommand(query, conn);

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
                            HealthFacilitiesFacultyId = Convert.ToInt32(reader["Health_Facilities_faculty_id"]),
                        });
                    }
                }
            }

            if (list[0].HealthFacilitiesFacultyId == expected.HealthFacilitiesFacultyId &&
                list[0].LastName == expected.LastName && list[0].Email == expected.Email)
                Assert.IsTrue(true);
        }

        [Test]
        public void GetCourseByIdTest()
        {
            // arrange
            List<MedicalSpecialist> list = new List<MedicalSpecialist>();

            int id = 2;

            MedicalSpecialist expected = new MedicalSpecialist
            {
                LastName = "lastname",
                FirstName = "name",
                MiddleName = "middlename",
                Email = "email@mail.ru",
                PasswordHash = "password",
                HealthFacilitiesFacultyId = 1,
            };

            //act
            SpecialistContext context = new SpecialistContext(connString);
            GetSpecialistByIdHandler handler = new GetSpecialistByIdHandler(context);
            handler.Handle(id);

            using (conn = new MySqlConnection(connString))
            {
                conn.Open();
                string query = string.Format("select * from specialists where email='email@mail.ru' and last_name='lastname'");

                MySqlCommand cmd = new MySqlCommand(query, conn);


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
                            HealthFacilitiesFacultyId = Convert.ToInt32(reader["Health_Facilities_faculty_id"]),
                        });
                    }
                }
            }

            if (list[0].HealthFacilitiesFacultyId == expected.HealthFacilitiesFacultyId &&
                list[0].LastName == expected.LastName && list[0].Email == expected.Email)
                Assert.IsTrue(true);
        }

        [Test]
        public void GetAllCourses()
        {
            // arrange
            List<MedicalSpecialist> list = new List<MedicalSpecialist>();
            List<MedicalSpecialist> expected = new List<MedicalSpecialist>(2);

            expected.Add(new MedicalSpecialist
            {
                LastName = "newlastname",
                FirstName = "newname",
                MiddleName = "mnewiddlename",
                Email = "email@gmail.com",
                PasswordHash = "password",
                HealthFacilitiesFacultyId = 1,
            });

            expected.Add(new MedicalSpecialist
            {
                LastName = "lastname",
                FirstName = "name",
                MiddleName = "middlename",
                Email = "email@mail.ru",
                PasswordHash = "password",
                HealthFacilitiesFacultyId = 1,
            });

            //act
            SpecialistContext context = new SpecialistContext(connString);
            GetAllSpecialistsHandler handler = new GetAllSpecialistsHandler(context);
            handler.Handle();

            using (conn = new MySqlConnection(connString))
            {
                conn.Open();
                string query = string.Format("select * from specialists");

                MySqlCommand cmd = new MySqlCommand(query, conn);


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
                            HealthFacilitiesFacultyId = Convert.ToInt32(reader["Health_Facilities_faculty_id"]),
                        });
                    }
                }
            }

            if (list[0].HealthFacilitiesFacultyId == expected[0].HealthFacilitiesFacultyId &&
                list[0].LastName == expected[0].LastName && list[0].Email == expected[0].Email &&
                list[1].HealthFacilitiesFacultyId == expected[1].HealthFacilitiesFacultyId &&
                list[1].LastName == expected[1].LastName && list[1].Email == expected[1].Email)
                Assert.IsTrue(true);
        }

        #endregion
    }

}
