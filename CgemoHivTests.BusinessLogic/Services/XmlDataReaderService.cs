using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;
//using CgemoHivTests.DataAccess;
using CgemoHivTests.BusinessLogic.Infrastructure;
using CgemoHivTests.BusinessLogic.DTO;

namespace CgemoHivTests.BusinessLogic.Services
{
    public static class XmlDataReaderService
    {
        private static XDocument xdoc;
        public static IList<PersonAnalysisDTO> ReadFile(System.IO.Stream fileStream,
            string filePathForValidation)
        {
            if (fileStream == null) return null;
            xdoc = XDocument.Load(fileStream);
            if (!String.IsNullOrEmpty(filePathForValidation))
            {
                string error;
                if (!IsValidXML(xdoc, filePathForValidation, out error)) throw new XmlSchemaValidationException(error);
            }
            IList<PersonAnalysisDTO> persons = new List<PersonAnalysisDTO>();
            foreach(XElement personElement in xdoc.Element("Persons").Elements("Person"))
            {
                PersonAnalysisDTO pa = new PersonAnalysisDTO();
                pa.FullName = personElement.Element("FullName").Value;
                if (personElement.Element("DateOfBirth") != null) pa.DateOfBirth = Convert.ToDateTime(personElement.Element("DateOfBirth").Value);
                pa.PassportNumber = personElement.Element("PassportNumber").Value;
                if (personElement.Element("PassportDateOfIssue") != null) pa.PassportDateOfIssue = Convert.ToDateTime(personElement.Element("PassportDateOfIssue").Value);
                if (personElement.Element("Country") != null) pa.Country = personElement.Element("Country").Value;
                pa.CertNumber = personElement.Element("CertNumber").Value;
                pa.CertDateOfIssue = Convert.ToDateTime(personElement.Element("CertDateOfIssue").Value);
                pa.AnalysisDate = Convert.ToDateTime(personElement.Element("AnalysisDate").Value);
                pa.AnalysisResult = bool.Parse(personElement.Element("AnalysisResult").Value);

                persons.Add(pa);
            }
            if (int.Parse(xdoc.Element("Persons").Element("Header").Element("Total").Value) != persons.Count)
                throw new XmlDataIncorrectNumberException("Ошибка XML файла. Количество загруженных объектов не соответствует указанному в заголовке");
            return persons;
        }
        public static async Task<ICollection<PersonAnalysisDTO>> ReadFileAsync(System.IO.Stream fileStream, 
            string filePathForValidation)
        {
            return await Task.Run<ICollection<PersonAnalysisDTO>>(() =>
                {
                    if (fileStream == null) return null;

                    //try
                    //{
                        xdoc = XDocument.Load(fileStream);

                        if (!String.IsNullOrEmpty(filePathForValidation))
                        {
                            string error;
                            if (!IsValidXML(xdoc, filePathForValidation, out error)) throw new XmlSchemaValidationException(error);
                        }

                        //IDictionary<string, PersonAnalysisDTO> persons = new Dictionary<string, PersonAnalysisDTO>();
                        IList<PersonAnalysisDTO> persons = new List<PersonAnalysisDTO>();
                        
                        foreach (XElement personElement in xdoc.Element("Persons").Elements("Person"))
                        {
                            PersonAnalysisDTO person = new PersonAnalysisDTO();
                            person.FullName = personElement.Element("FullName").Value;
                            if (personElement.Element("DateOfBirth") != null) person.DateOfBirth = Convert.ToDateTime(personElement.Element("DateOfBirth").Value);
                            person.PassportNumber = personElement.Element("PassportNumber").Value;
                            if (personElement.Element("PassportDateOfIssue") != null) person.PassportDateOfIssue = Convert.ToDateTime(personElement.Element("PassportDateOfIssue").Value);
                            if (personElement.Element("Country") != null) person.Country = personElement.Element("Country").Value;
                            person.CertNumber = personElement.Element("CertNumber").Value;
                            person.CertDateOfIssue = Convert.ToDateTime(personElement.Element("CertDate").Value);
                            person.AnalysisDate = Convert.ToDateTime(personElement.Element("AnalysisDate").Value);
                            person.AnalysisResult = bool.Parse(personElement.Element("AnalysisResult").Value);
                            //person.IsDublicate = (personElement.Attribute("dublicate") != null) ? true : false;

                            persons.Add(person);
                            //if (!persons.ContainsKey(person.CertNumber)) persons.Add(person.CertNumber, person);
                            //if (personElement.Element("DateOfBirth") == null || personElement.Element("PassportDateOfIssue") == null ||
                            //    personElement.Element("Country") == null) persons.Add(person.CertNumber, person);
                            
                            //else
                            //{
                            //    dublicatePersons.Add(persons[person.CertNumber]);
                            //    dublicatePersons.Add(person);
                            //}
                            //if (persons.ContainsKey(person.CertNumber)) persons.Add(person.CertNumber, person);
                        }
                        if (int.Parse(xdoc.Element("Persons").Element("Header").Element("Total").Value) != persons.Count)
                            throw new XmlDataIncorrectNumberException("Ошибка XML файла. Количество загруженных объектов не соответствует указанному в заголовке");
                        
                        //foreach (PersonAnalysisDTO pa in dublicatePersons)
                        //{
                        //    PersonAnalysisDTO pa2 = new PersonAnalysisDTO();
                        //    if (persons.TryGetValue(pa.CertNumber, out pa2)) dublicatePersons.Add(pa2);
                        //}

                        return persons;
                    //}
                    //catch (XmlSchemaValidationException ex) { throw new Exception(ex.Message); }
                    //catch (Exception ex) { throw ex; }
                });
        }
        public static bool IsValidXML(XDocument xDocToValidate, string xsdFilePath, out string errorMsg)
        {
            XmlSchemaSet schemas = new XmlSchemaSet();
            
            schemas.Add("", xsdFilePath);
            //schemas.Add("", System.Xml.XmlReader.Create(new System.IO.StringReader(xsdMarkup)));

            bool errors = false;
            string message = null;
            xDocToValidate.Validate(schemas, (o, e) =>
            {
                message = e.Message;
                errors = true;
            }, true);
            errorMsg = message;
            return !errors;       
        }
    }
}
