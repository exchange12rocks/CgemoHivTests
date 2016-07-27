using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CgemoHivTests.BusinessLogic.DTO
{
    public class PersonAnalysisDTO
    {
        [HiddenInput(DisplayValue = false)]
        public int PersonId { get; set; }
        [DisplayName("Полное имя")]
        public string FullName { get; set; }
        [DisplayName("Дата рождения")]
        public System.DateTime? DateOfBirth { get; set; }
        [DisplayName("Номер паспорта")]
        public string PassportNumber { get; set; }
        [DisplayName("Дата выдачи паспорта")]
        public System.DateTime? PassportDateOfIssue { get; set; }
        [DisplayName("Страна проживания")]
        public string Country { get; set; }
        [DisplayName("Номер сертификата")]
        public string CertNumber { get; set; }
        [DisplayName("Дата выдачи сертификата")]
        public System.DateTime CertDateOfIssue { get; set; }
        [DisplayName("Дата анализа")]
        public System.DateTime AnalysisDate { get; set; }
        [DisplayName("Результат анализа")]
        public bool AnalysisResult { get; set; }
    }
}
