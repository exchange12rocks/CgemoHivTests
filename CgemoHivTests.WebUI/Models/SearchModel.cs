using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CgemoHivTests.WebUI.Models
{
    public class SearchModel
    {
        [DisplayName("Полное имя")]
        public string FullName { get; set; }

        [DisplayName("Дата рождения")]
        public string DateOfBirth { get; set; }
        [DisplayName("Номер паспорта")]
        public string PassportNumber { get; set; }
        [DisplayName("Дата выдачи")]
        public string PassportDate { get; set; }
        [DisplayName("Страна проживания")]
        public string Country { get; set; }
        [DisplayName("Номер сертификата")]
        public string CertNumber { get; set; }
        [DisplayName("Дата выдачи")]
        public string CertDate { get; set; }
        [DisplayName("Дата анализа")]
        public string AnalysisDate { get; set; }
    }
}