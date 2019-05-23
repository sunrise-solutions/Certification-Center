using NUnit.Framework;
using Course.Commands;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using Course.Model;
using System;
using Microsoft.Extensions.DependencyInjection;
using Course.Handlers;
using Test.Handlers;
using Test.Commands;
using Test.Model;
using HealthFacility.Model;

namespace Tests
{
    //course
    public class CourseTests
    {
        public string connString = "server=localhost;port=3306;database=certification_database;uid=liza;password=12345admin;";
        public MySqlConnection conn;
        public IServiceCollection services;

        #region Courses tests

        [Test]
        public void CreateCourseTest()
        {
            // arrange
            List<MedicalCourse> list = new List<MedicalCourse>();

            MedicalCourse expected = new MedicalCourse
            {
                Name = "Ёндокринологи€",
                Qualification = 1
            };

            CreateCourseCommand command = new CreateCourseCommand
            {
                Name = "Ёндокринологи€",
                Qualification = 1
            };

            //act
            Course.Data.CourseContext context = new Course.Data.CourseContext(connString);
            CreateCourseHandler handler = new CreateCourseHandler(context);
            handler.Handle(command);
            

            using (conn = new MySqlConnection(connString))
            {
                conn.Open();
                string query = string.Format("select * from Courses where course_name='Ёндокринологи€' and qualification=1");

                MySqlCommand cmd = new MySqlCommand(query, conn);

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

            if (list[0].Name == expected.Name && list[0].Qualification == expected.Qualification)
                Assert.IsTrue(true);
        }

        [Test]
        public void UpdateCourseTest()
        {
            // arrange
            List<MedicalCourse> list = new List<MedicalCourse>();
            int id = 2;

            MedicalCourse expected = new MedicalCourse
            {
                Id = id,
                Name = "Ёндокринологи€",
                Qualification = 2
            };

            CreateCourseCommand command = new CreateCourseCommand
            {
                Name = "Ёндокринологи€",
                Qualification = 2
            };

            //act
            Course.Data.CourseContext courseContext = new Course.Data.CourseContext(connString);
            UpdateCourseHandler createCourseHandler = new UpdateCourseHandler(courseContext);
            createCourseHandler.Handle(2, command);


            using (conn = new MySqlConnection(connString))
            {
                conn.Open();
                string query = string.Format("select * from Courses where course_name='Ёндокринологи€' and qualification=2");

                MySqlCommand cmd = new MySqlCommand(query, conn);

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

            if (list[0].Name == expected.Name && list[0].Qualification == expected.Qualification && list[0].Id == id)
                Assert.IsTrue(true);
        }

        [Test]
        public void GetCourseByIdTest()
        {
            // arrange
            List<MedicalCourse> list = new List<MedicalCourse>();

            int id = 2;

            MedicalCourse expected = new MedicalCourse
            {
                Name = "Ёндокринологи€",
                Qualification = 2
            };

            //act
            Course.Data.CourseContext context = new Course.Data.CourseContext(connString);
            GetCourseByIdHandler handler = new GetCourseByIdHandler(context);
            handler.Handle(id);


            using (conn = new MySqlConnection(connString))
            {
                conn.Open();
                string query = string.Format("select * from Courses where course_id=2");

                MySqlCommand cmd = new MySqlCommand(query, conn);

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

            if (list[0].Name == expected.Name && list[0].Qualification == expected.Qualification)
                Assert.IsTrue(true);
        }
        
        [Test]
        public void GetAllCourses()
        {
            // arrange
            List<MedicalCourse> list = new List<MedicalCourse>();
            List<MedicalCourse> expected = new List<MedicalCourse>(2);
            
            expected.Add(new MedicalCourse()
            {
                Name = "Ёндокринологи€",
                Qualification = 2
            });

            expected.Add(new MedicalCourse()
            {
                Name = "Ёндокринологи€",
                Qualification = 1
            });

            //act
            Course.Data.CourseContext context = new Course.Data.CourseContext(connString);
            GetAllCoursesHandler handler = new GetAllCoursesHandler(context);
            handler.Handle();


            using (conn = new MySqlConnection(connString))
            {
                conn.Open();
                string query = string.Format("select * from Courses");

                MySqlCommand cmd = new MySqlCommand(query, conn);

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

            if (list[0].Name == expected[0].Name && list[0].Qualification == expected[0].Qualification &&
                list[1].Name == expected[1].Name && list[1].Qualification == expected[1].Qualification)
                Assert.IsTrue(true);
        }
        
        #endregion
    }

    
}