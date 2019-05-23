using HealthFacility.Model;
using HealthFacility.Commands;
using HealthFacility.Data;
using HealthFacility.Handlers;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CertificationCenter.Tests
{
    class FacilityTests
    {
        public string connString = "server=localhost;port=3306;database=certification_database;uid=liza;password=12345admin;";
        public MySqlConnection conn;

        [Test]
        public void CreateFacilityTest()
        {
            // arrange
            List<MedicalHealthFacility> list = new List<MedicalHealthFacility>();

            MedicalHealthFacility expected = new MedicalHealthFacility
            {
                Address = new Address { Street = "s", City = "c", Country = "c", House = 1 },
                Name = "Facility#3"
            };

            CreateHealthFacitityCommand command = new CreateHealthFacitityCommand
            {
                Address = new Address { Street = "s", City = "c", Country = "c", House = 1 },
                Name = "Facility#3"
            };

            //act
            HealthFacilityContext context = new HealthFacilityContext(connString);
            CreateHealthFacilityHandler handler = new CreateHealthFacilityHandler(context);
            handler.Handle(command);
            
            using (conn = new MySqlConnection(connString))
            {
                conn.Open();
                string query = string.Format("select * from health_facilities where address='улица s, дом 1, город c, страна c' and name='Facility#3'");

                MySqlCommand cmd = new MySqlCommand(query, conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string addressString = reader["address"].ToString();
                        Address address = Converter.ConvertToAddress(addressString);
                        list.Add(new MedicalHealthFacility()
                        {
                            Id = Convert.ToInt32(reader["faculty_id"]),
                            Name = reader["name"].ToString(),
                            Address = address,
                        });
                    }
                }
            }

            if (list[0].Name == expected.Name && list[0].Address == expected.Address)
                Assert.IsTrue(true);
        }

        [Test]
        public void UpdateFacilityTest()
        {
            // arrange
            List<MedicalHealthFacility> list = new List<MedicalHealthFacility>();
            int id = 2;

            MedicalHealthFacility expected = new MedicalHealthFacility
            {
                Name = "Facility#3",
                Address = new Address { Street = "s", City = "c", Country = "c", House = 1 },
            };

            CreateHealthFacitityCommand command = new CreateHealthFacitityCommand
            {
                Name = "Facility#3",
                Address = new Address { Street = "street", City = "city", Country = "country", House = 11 },
            };

            //act
            HealthFacilityContext context = new HealthFacilityContext(connString);
            UpdateHealthFacilityHandler handler = new UpdateHealthFacilityHandler(context);
            handler.Handle(2, command);


            using (conn = new MySqlConnection(connString))
            {
                conn.Open();
                string query = string.Format("select * from health_facilities where address='улица street, дом 11, город city, страна country' and name='Facility#3'");

                MySqlCommand cmd = new MySqlCommand(query, conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string addressString = reader["address"].ToString();
                        Address address = Converter.ConvertToAddress(addressString);
                        list.Add(new MedicalHealthFacility()
                        {
                            Id = Convert.ToInt32(reader["faculty_id"]),
                            Name = reader["name"].ToString(),
                            Address = address,
                        });
                    }
                }
            }

            if (list[0].Name == expected.Name && list[0].Address == expected.Address && list[0].Id == id)
                Assert.IsTrue(true);
        }

        [Test]
        public void GetTestByIdTest()
        {
            // arrange
            List<MedicalHealthFacility> list = new List<MedicalHealthFacility>();

            int id = 2;

            MedicalHealthFacility expected = new MedicalHealthFacility
            {
                Name = "Facility#3",
                Address = new Address { Street = "street", City = "city", Country = "country", House = 11 }
            };

            //act
            HealthFacilityContext context = new HealthFacilityContext(connString);
            GetHealthFacilityByIdHandler handler = new GetHealthFacilityByIdHandler(context);
            handler.Handle(id);


            using (conn = new MySqlConnection(connString))
            {
                conn.Open();
                string query = string.Format("select * from health_facilities where faculty_id=2");

                MySqlCommand cmd = new MySqlCommand(query, conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string addressString = reader["address"].ToString();
                        Address address = Converter.ConvertToAddress(addressString);
                        list.Add(new MedicalHealthFacility()
                        {
                            Id = Convert.ToInt32(reader["faculty_id"]),
                            Name = reader["name"].ToString(),
                            Address = address,
                        });
                    }
                }
            }

            if (list[0].Name == expected.Name && list[0].Address == expected.Address)
                Assert.IsTrue(true);
        }

        [Test]
        public void GetAllTests()
        {
            // arrange
            List<MedicalHealthFacility> list = new List<MedicalHealthFacility>();
            List<MedicalHealthFacility> expected = new List<MedicalHealthFacility>(2);

            expected.Add(new MedicalHealthFacility
            {
                Name = "string",
                Address = new Address { Street = "string", City = "string", Country = "string", House = 0 }
            });
            
            expected.Add(new MedicalHealthFacility
            {
                Name = "Facility#3",
                Address = new Address { Street = "street", City = "city", Country = "country", House = 11 }
            });

            //act
            HealthFacilityContext context = new HealthFacilityContext(connString);
            GetAllHealthFacilitiesHandler handler = new GetAllHealthFacilitiesHandler(context);
            handler.Handle();


            using (conn = new MySqlConnection(connString))
            {
                conn.Open();
                string query = string.Format("select * from health_facilities");

                MySqlCommand cmd = new MySqlCommand(query, conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string addressString = reader["address"].ToString();
                        Address address = Converter.ConvertToAddress(addressString);
                        list.Add(new MedicalHealthFacility()
                        {
                            Id = Convert.ToInt32(reader["faculty_id"]),
                            Name = reader["name"].ToString(),
                            Address = address,
                        });
                    }
                }
            }

            if (list[0].Name == expected[0].Name && list[0].Address == expected[0].Address &&
                list[1].Name == expected[1].Name && list[1].Address == expected[1].Address)
                Assert.IsTrue(true);
        }

    }

}
