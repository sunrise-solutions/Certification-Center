using MySql.Data.MySqlClient;
using Specialist.Data;
using Specialist.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Specialists.Handlers
{
    public class WriteAllSpecialistsToXMLHandler
    {
        private readonly SpecialistContext _context;

        public WriteAllSpecialistsToXMLHandler(SpecialistContext context)
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

                return WriteToXML(list) ? true : false;
            }
        }

        private static bool WriteToXML(List<MedicalSpecialist> specialists)
        {
            //путь
            string path = @"specialists.xml";

            //создание главного объекта документа
            XmlDocument XmlDoc = new XmlDocument();

            /*<?xml version="1.0" encoding="utf-8" ?> */
            //создание объявления (декларации) документа
            XmlDeclaration XmlDec = XmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
            //добавляем в документ
            XmlDoc.AppendChild(XmlDec);

            /*<!--база данных-->*/
            //комментарий уровня root
            XmlComment Comment0 = XmlDoc.CreateComment("Certification Center database");
            //добавляем в документ
            XmlDoc.AppendChild(Comment0);

            /*<database name="abc"></database>*/
            //создание корневого элемента 
            XmlElement ElementDatabase = XmlDoc.CreateElement("database");
            //создание атрибута
            ElementDatabase.SetAttribute("name", "certification-center");
            //добавляем в документ
            XmlDoc.AppendChild(ElementDatabase);

            /*<!--описание структуры таблицы-->*/
            //комментарий уровня вложенности root/child
            XmlComment Comment1 = XmlDoc.CreateComment("Описание структуры таблицы");
            //добавляем в ElementDatabase
            ElementDatabase.AppendChild(Comment1);

            /*<table_structure name="specialists"></table_structure>*/
            //создание дочернего элемента уровня вложенности root/child
            XmlElement ElementTable_Structure = XmlDoc.CreateElement("table_structure");
            //создание атрибута
            ElementTable_Structure.SetAttribute("name", "specialists");
            //добавляем в ElementDatabase
            ElementDatabase.AppendChild(ElementTable_Structure);

            /*<field Field="specialist_id" type="int"></field>*/
            //создание дочернего элемента уровня вложенности root/child/child
            XmlElement ElementField0 = XmlDoc.CreateElement("field");
            //создание атрибута
            ElementField0.SetAttribute("Field", "specialis_id");
            ElementField0.SetAttribute("type", "int");
            //добавляем в ElementTable_Structure
            ElementTable_Structure.AppendChild(ElementField0);

            /*<field Field="last_name" type="string"></field>*/
            //создание дочернего элемента уровня вложенности root/child/child
            XmlElement ElementField1 = XmlDoc.CreateElement("field");
            //создание атрибута
            ElementField1.SetAttribute("Field", "last_name");
            ElementField1.SetAttribute("type", "string");
            //добавляем в ElementTable_Structure
            ElementTable_Structure.AppendChild(ElementField1);

            /*<field Field="first_name" type="string"></field>*/
            //создание дочернего элемента уровня вложенности root/child/child
            XmlElement ElementField2 = XmlDoc.CreateElement("field");
            //создание атрибута
            ElementField2.SetAttribute("Field", "first_name");
            ElementField2.SetAttribute("type", "string");
            //добавляем в ElementTable_Structure
            ElementTable_Structure.AppendChild(ElementField2);

            /*<field Field="middle_name" type="string"></field>*/
            //создание дочернего элемента уровня вложенности root/child/child
            XmlElement ElementField3 = XmlDoc.CreateElement("field");
            //создание атрибута
            ElementField3.SetAttribute("Field", "middle_name");
            ElementField3.SetAttribute("type", "string");
            //добавляем в ElementTable_Structure
            ElementTable_Structure.AppendChild(ElementField3);

            /*<field Field="email" type="string"></field>*/
            //создание дочернего элемента уровня вложенности root/child/child
            XmlElement ElementField4 = XmlDoc.CreateElement("field");
            //создание атрибута
            ElementField4.SetAttribute("Field", "email");
            ElementField4.SetAttribute("type", "string");
            //добавляем в ElementTable_Structure
            ElementTable_Structure.AppendChild(ElementField4);

            /*<field Field="faculty_id" type="int"></field>*/
            //создание дочернего элемента уровня вложенности root/child/child
            XmlElement ElementField5 = XmlDoc.CreateElement("field");
            //создание атрибута
            ElementField5.SetAttribute("Field", "faculty_id");
            ElementField5.SetAttribute("type", "int");
            //добавляем в ElementTable_Structure
            ElementTable_Structure.AppendChild(ElementField5);

            /*<!--данные таблицы-->*/
            //комментарий уровня вложенности root/child
            XmlComment Comment2 = XmlDoc.CreateComment("Данные таблицы");
            //добавляем в ElementDatabase
            ElementDatabase.AppendChild(Comment2);

            /*<table_data name="specialists"></table_data>*/
            //создание дочернего элемента уровня вложенности root/child
            XmlElement ElementTable_Data = XmlDoc.CreateElement("table_data");
            //создание атрибута
            ElementTable_Data.SetAttribute("name", "specialists");
            //добавляем в ElementDatabase
            ElementDatabase.AppendChild(ElementTable_Data);

            for (int i = 0; i < specialists.Count; i++)
            {
                /*<row><row>*/
                //создание дочернего элемента уровня вложенности root/child/child
                XmlElement ElementRow = XmlDoc.CreateElement("row");
                //добавляем в ElementTable_Data
                ElementTable_Data.AppendChild(ElementRow);

                /*<field name="specialist_id"></field>*/
                //создание дочернего элемента уровня вложенности root/child/child/child
                XmlElement ElementFieldId = XmlDoc.CreateElement("field");
                //создание атрибута
                ElementFieldId.SetAttribute("name", "specialist_id");
                //создание контента
                ElementFieldId.InnerText = specialists[i].Id.ToString();
                //добавляем в ElementRow
                ElementRow.AppendChild(ElementFieldId);

                /*<field name="last_name"></field>*/
                //создание дочернего элемента уровня вложенности root/child/child/child
                XmlElement ElementFieldLast = XmlDoc.CreateElement("field");
                //создание атрибута
                ElementFieldLast.SetAttribute("name", "last_name");
                //создание контента
                ElementFieldLast.InnerText = specialists[i].LastName.ToString();
                //добавляем в ElementRow
                ElementRow.AppendChild(ElementFieldLast);

                /*<field name="first_name"></field>*/
                //создание дочернего элемента уровня вложенности root/child/child/child
                XmlElement ElementFieldName = XmlDoc.CreateElement("field");
                //создание атрибута
                ElementFieldName.SetAttribute("name", "first_name");
                //создание контента
                ElementFieldName.InnerText = specialists[i].FirstName.ToString();
                //добавляем в ElementRow
                ElementRow.AppendChild(ElementFieldName);

                /*<field name="middle_name"></field>*/
                //создание дочернего элемента уровня вложенности root/child/child/child
                XmlElement ElementFieldMiddle = XmlDoc.CreateElement("field");
                //создание атрибута
                ElementFieldMiddle.SetAttribute("name", "middle_name");
                //создание контента
                ElementFieldMiddle.InnerText = specialists[i].MiddleName;
                //добавляем в ElementRow
                ElementRow.AppendChild(ElementFieldMiddle);

                /*<field name="email"></field>*/
                //создание дочернего элемента уровня вложенности root/child/child/child
                XmlElement ElementFieldEmail = XmlDoc.CreateElement("field");
                //создание атрибута
                ElementFieldEmail.SetAttribute("name", "email");
                //создание контента
                ElementFieldEmail.InnerText = specialists[i].Email;
                //добавляем в ElementRow
                ElementRow.AppendChild(ElementFieldEmail);

                /*<field name="first_name"></field>*/
                //создание дочернего элемента уровня вложенности root/child/child/child
                XmlElement ElementFieldFaculty = XmlDoc.CreateElement("field");
                //создание атрибута
                ElementFieldFaculty.SetAttribute("name", "faculty");
                //создание контента
                ElementFieldFaculty.InnerText = specialists[i].HealthFacilitiesFacultyId.ToString();
                //добавляем в ElementRow
                ElementRow.AppendChild(ElementFieldFaculty);
            }

            XmlDoc.Save(path);
            return true;
        }
    }
}
