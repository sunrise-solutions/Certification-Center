using Course.Data;
using Course.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Course.Handlers
{
    public class WriteAllCoursesToXMLHandler
    {
        private readonly CourseContext _context;

        public WriteAllCoursesToXMLHandler(CourseContext context)
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

                return WriteToXML(list) ? true : false;
            }
        }

        private static bool WriteToXML(List<MedicalCourse> courses)
        {
            //путь
            string path = @"courses.xml";

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

            /*<table_structure name="courses"></table_structure>*/
            //создание дочернего элемента уровня вложенности root/child
            XmlElement ElementTable_Structure = XmlDoc.CreateElement("table_structure");
            //создание атрибута
            ElementTable_Structure.SetAttribute("name", "courses");
            //добавляем в ElementDatabase
            ElementDatabase.AppendChild(ElementTable_Structure);

            /*<field Field="course_id" type="int"></field>*/
            //создание дочернего элемента уровня вложенности root/child/child
            XmlElement ElementField0 = XmlDoc.CreateElement("field");
            //создание атрибута
            ElementField0.SetAttribute("Field", "course_id");
            ElementField0.SetAttribute("type", "int");
            //добавляем в ElementTable_Structure
            ElementTable_Structure.AppendChild(ElementField0);

            /*<field Field="course_name" type="string"></field>*/
            //создание дочернего элемента уровня вложенности root/child/child
            XmlElement ElementField1 = XmlDoc.CreateElement("field");
            //создание атрибута
            ElementField1.SetAttribute("Field", "course_name");
            ElementField1.SetAttribute("type", "string");
            //добавляем в ElementTable_Structure
            ElementTable_Structure.AppendChild(ElementField1);

            /*<field Field="qualification" type="int"></field>*/
            //создание дочернего элемента уровня вложенности root/child/child
            XmlElement ElementField2 = XmlDoc.CreateElement("field");
            //создание атрибута
            ElementField2.SetAttribute("Field", "qualification");
            ElementField2.SetAttribute("type", "int");
            //добавляем в ElementTable_Structure
            ElementTable_Structure.AppendChild(ElementField2);

            /*<!--данные таблицы-->*/
            //комментарий уровня вложенности root/child
            XmlComment Comment2 = XmlDoc.CreateComment("Данные таблицы");
            //добавляем в ElementDatabase
            ElementDatabase.AppendChild(Comment2);

            /*<table_data name="courses"></table_data>*/
            //создание дочернего элемента уровня вложенности root/child
            XmlElement ElementTable_Data = XmlDoc.CreateElement("table_data");
            //создание атрибута
            ElementTable_Data.SetAttribute("name", "courses");
            //добавляем в ElementDatabase
            ElementDatabase.AppendChild(ElementTable_Data);

            for (int i = 0; i < courses.Count; i++)
            {
                /*<row><row>*/
                //создание дочернего элемента уровня вложенности root/child/child
                XmlElement ElementRow = XmlDoc.CreateElement("row");
                //добавляем в ElementTable_Data
                ElementTable_Data.AppendChild(ElementRow);

                /*<field name="id"></field>*/
                //создание дочернего элемента уровня вложенности root/child/child/child
                XmlElement ElementFieldId = XmlDoc.CreateElement("field");
                //создание атрибута
                ElementFieldId.SetAttribute("name", "course_id");
                //создание контента
                ElementFieldId.InnerText = courses[i].Id.ToString();
                //добавляем в ElementRow
                ElementRow.AppendChild(ElementFieldId);

                /*<field name="name"></field>*/
                //создание дочернего элемента уровня вложенности root/child/child/child
                XmlElement ElementFieldName = XmlDoc.CreateElement("field");
                //создание атрибута
                ElementFieldName.SetAttribute("name", "course_name");
                //создание контента
                ElementFieldName.InnerText = courses[i].Name;
                //добавляем в ElementRow
                ElementRow.AppendChild(ElementFieldName);

                /*<field name="amount"></field>*/
                //создание дочернего элемента уровня вложенности root/child/child/child
                XmlElement ElementFieldAmount = XmlDoc.CreateElement("field");
                //создание атрибута
                ElementFieldAmount.SetAttribute("name", "qualification");
                //создание контента
                ElementFieldAmount.InnerText = courses[i].Qualification.ToString();
                //добавляем в ElementRow
                ElementRow.AppendChild(ElementFieldAmount);
            }

            XmlDoc.Save(path);
            return true;
        }
    }
}
