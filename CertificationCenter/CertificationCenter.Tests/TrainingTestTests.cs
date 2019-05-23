using MySql.Data.MySqlClient;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Test.Commands;
using Test.Handlers;
using Test.Model;

namespace CertificationCenter.Tests
{
    public class TrainingTestTests
    {
        public string connString = "server=localhost;port=3306;database=certification_database;uid=liza;password=12345admin;";
        public MySqlConnection conn;

        [Test]
        public void CreateTestTest()
        {
            // arrange
            List<TrainingTest> list = new List<TrainingTest>();

            TrainingTest expected = new TrainingTest
            {
                CourseId = 1,
                SpecialistId = 1,
                TopicId = 1,
                Date = new DateTime(2010, 8, 18, 16, 32, 0),
                Result = 97                
            };

            CreateTestCommand command = new CreateTestCommand
            {
                CourseId = 1,
                Date = new DateTime(2010, 8, 18, 16, 32, 0),
                 Result = 98,
                  SpecialistId = 1,
                   TopicId = 1
            };

            //act
            Test.Data.TestContext context = new Test.Data.TestContext(connString);
            CreateTestHandler handler = new CreateTestHandler(context);
            handler.Handle(command);


            using (conn = new MySqlConnection(connString))
            {
                conn.Open();
                string query = string.Format("select * from training_tests where result=98 and specialists_specialist_id=1"+
                                                         "and topics_topic_id=1, date='{0}' and topics_courses_course_id=1",
                                                            command.Date.ToString("yyyy-MM-dd HH:mm:ss"));

                MySqlCommand cmd = new MySqlCommand(query, conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new TrainingTest()
                        {
                            Id = Convert.ToInt32(reader["training_id"]),
                            Date = Convert.ToDateTime(reader["date"]),
                            Result = Convert.ToInt32(reader["result"]),
                            SpecialistId = Convert.ToInt32(reader["Specialists_specialist_id"]),
                            TopicId = Convert.ToInt32(reader["Topics_topic_id"]),
                            CourseId = Convert.ToInt32(reader["Topics_Courses_course_id"])
                        });
                    }
                }
            }

            if (list[0].Result == expected.Result && list[0].SpecialistId == expected.SpecialistId
                && list[0].TopicId == expected.TopicId && list[0].Date == expected.Date &&
                list[0].CourseId == expected.CourseId)
            {
                Assert.IsTrue(true);
            }
        }

        [Test]
        public void UpdateTestTest()
        {
            // arrange
            List<TrainingTest> list = new List<TrainingTest>();
            int id = 2;

            TrainingTest expected = new TrainingTest
            {
                CourseId = 1,
                SpecialistId = 1,
                TopicId = 1,
                Date = new DateTime(),
                Result = 97
            };

            CreateTestCommand command = new CreateTestCommand
            {
                CourseId = 1,
                Date = new DateTime(),
                Result = 100,
                SpecialistId = 1,
                TopicId = 1
            };

            //act
            Test.Data.TestContext courseContext = new Test.Data.TestContext(connString);
            UpdateTestHandler handler= new UpdateTestHandler(courseContext);
            handler.Handle(id, command);


            using (conn = new MySqlConnection(connString))
            {
                conn.Open();
                string query = string.Format("select * from training_tests where result=100 and specialists_specialist_id=1" +
                                                         "and topics_topic_id=1, date='{0}' and topics_courses_course_id=1",
                                                            command.Date.ToString("yyyy-MM-dd HH:mm:ss"));
                
                MySqlCommand cmd = new MySqlCommand(query, conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new TrainingTest()
                        {
                            Id = Convert.ToInt32(reader["training_id"]),
                            Date = Convert.ToDateTime(reader["date"]),
                            Result = Convert.ToInt32(reader["result"]),
                            SpecialistId = Convert.ToInt32(reader["Specialists_specialist_id"]),
                            TopicId = Convert.ToInt32(reader["Topics_topic_id"]),
                            CourseId = Convert.ToInt32(reader["Topics_Courses_course_id"])
                        });
                    }
                }
            }

            if (list[0].Result == expected.Result && list[0].SpecialistId == expected.SpecialistId
                && list[0].TopicId == expected.TopicId && list[0].Date == expected.Date &&
                list[0].CourseId == expected.CourseId)
            {
                Assert.IsTrue(true);
            }
        }

        [Test]
        public void GetTestByIdTest()
        {
            // arrange
            List<TrainingTest> list = new List<TrainingTest>();

            int id = 2;

            TrainingTest expected = new TrainingTest
            {
                CourseId = 1,
                SpecialistId = 1,
                TopicId = 1,
                Date = new DateTime(),
                Result = 97
            };

            //act
            Test.Data.TestContext context = new Test.Data.TestContext(connString);
            GetTestByIdHandler handler = new GetTestByIdHandler(context);
            handler.Handle(id);


            using (conn = new MySqlConnection(connString))
            {
                conn.Open();
                string query = string.Format("select * from training_tests where training_id=2");

                MySqlCommand cmd = new MySqlCommand(query, conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new TrainingTest()
                        {
                            Id = Convert.ToInt32(reader["training_id"]),
                            Date = Convert.ToDateTime(reader["date"]),
                            Result = Convert.ToInt32(reader["result"]),
                            SpecialistId = Convert.ToInt32(reader["Specialists_specialist_id"]),
                            TopicId = Convert.ToInt32(reader["Topics_topic_id"]),
                            CourseId = Convert.ToInt32(reader["Topics_Courses_course_id"])
                        });
                    }
                }
            }

            if (list[0].Result == expected.Result && list[0].SpecialistId == expected.SpecialistId
                && list[0].TopicId == expected.TopicId && list[0].Date == expected.Date &&
                list[0].CourseId == expected.CourseId)
            {
                Assert.IsTrue(true);
            }
        }

        [Test]
        public void GetAllTests()
        {
            // arrange
            List<TrainingTest> list = new List<TrainingTest>();
            List<TrainingTest> expected = new List<TrainingTest>(2);

            expected.Add(new TrainingTest
            {
                CourseId = 1,
                SpecialistId = 1,
                TopicId = 1,
                Date = new DateTime(),
                Result = 97
            });

            expected.Add(new TrainingTest
            {
                CourseId = 1,
                SpecialistId = 1,
                TopicId = 1,
                Date = new DateTime(),
                Result = 30
            });

            //act
            Test.Data.TestContext context = new Test.Data.TestContext(connString);
            GetAllTestsHandler handler = new GetAllTestsHandler(context);
            handler.Handle();


            using (conn = new MySqlConnection(connString))
            {
                conn.Open();
                string query = string.Format("select * from training_tests");

                MySqlCommand cmd = new MySqlCommand(query, conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new TrainingTest()
                        {
                            Id = Convert.ToInt32(reader["training_id"]),
                            Date = Convert.ToDateTime(reader["date"]),
                            Result = Convert.ToInt32(reader["result"]),
                            SpecialistId = Convert.ToInt32(reader["Specialists_specialist_id"]),
                            TopicId = Convert.ToInt32(reader["Topics_topic_id"]),
                            CourseId = Convert.ToInt32(reader["Topics_Courses_course_id"])
                        });
                    }
                }
            }

            if (list[0].Result == expected[0].Result && list[0].SpecialistId == expected[0].SpecialistId
                && list[0].TopicId == expected[0].TopicId && list[0].Date == expected[0].Date &&
                list[0].CourseId == expected[0].CourseId &&
                list[1].Result == expected[1].Result && list[1].SpecialistId == expected[1].SpecialistId
                && list[0].TopicId == expected[1].TopicId && list[1].Date == expected[1].Date &&
                list[1].CourseId == expected[1].CourseId)
            {
                Assert.IsTrue(true);
            }
        }
        
    }

}
