using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using CgemoHivTests.BusinessLogic.Interfaces;
using CgemoHivTests.BusinessLogic.DTO;
using System.Web.Security;
using CgemoHivTests.BusinessLogic.Providers;

namespace CgemoHivTests.WebUI.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        IDbServiceAsync<PersonAnalysisDTO> personAnalysisService;
        public HomeController(IDbServiceAsync<PersonAnalysisDTO> serv)
        {
            ViewBag.SelectedPage = "List";
            personAnalysisService = serv;
        }
        public async Task<ActionResult> Index()
        {
            //ViewBag.SelectedPage = "List";
            //IEnumerable<PersonAnalysisDTO> list = await personAnalysisService.GetEntitiesAsync();
            //using (PersonAnalysisRepository repository = new PersonAnalysisRepository())
            //{
            //    //PersonAnalysis data = await Task<PersonAnalysis>.Factory.StartNew(() =>
            //    //{
            //    //    return repository.Get(5);
            //    //});
            //    //PersonAnalysis pa = await repository.GetAsync(4);
            //    //PersonAnalysis pa2 = repository.Get(5);
            //    //IList<PersonAnalysis> list = await XmlDataReader.ReadFileAsync(@"C:\Проекты\CgemoHivTests\CgemoHivTests.WebUI\App_Data\Запрос на эмигрантов.xml",
            //    //    @"C:\Проекты\CgemoHivTests\CgemoHivTests.WebUI\App_Data\PersonsReport.xsd");               
            //}
            return View();
        }
        public async Task<ActionResult> Details(int id)
        {
            return View(await personAnalysisService.GetEntityAsync(id));
        }

        public async Task<ActionResult> LoadFromXML()
        {           
            //string result = null;
            //IList<PersonAnalysisDTO> list = null;
            //try
            //{
            //    list = await CgemoHivTests.BusinessLogic.Services.XmlDataReaderService.ReadFileAsync(@"C:\Проекты\CgemoHivTests\CgemoHivTests.WebUI\App_Data\20160101_20160425.xml",
            //        @"C:\Проекты\CgemoHivTests\CgemoHivTests.WebUI\App_Data\PersonsReport.xsd");
            //    if (list != null) await personAnalysisService.SaveEntitiesAsync(list);
            //    result = String.Format("В базу данных выгружено записей: {0}", list.Count.ToString());
            //}
            //catch(Exception ex)
            //{
            //    result = ex.GetBaseException().Message;
            //}
            //TempData["Result"] = result;
           
            return View();
        }
        //public ActionResult Index()
        //{
        //    using (PersonAnalysisRepository repository = new PersonAnalysisRepository())
        //    {
        //        PersonAnalysis pa;// = new PersonAnalysis();
        //        pa = repository.Get(4);

        //        return View(pa);
        //    }

        //}    
            //pa.PersonId = 4;
            //pa.FullName = "Петров2 Петр2 Петрович2";
            //pa.DateOfBirth = Convert.ToDateTime("07.07.1977");
            //pa.PassportNumber = "TM06724";
            //pa.PassportDateOfIssue = Convert.ToDateTime("05.04.2004");
            //pa.Country = "Казахстан";
            //pa.CertNumber = "22222";
            //pa.AnalysisDate = Convert.ToDateTime("15.07.2015");
            //pa.AnalysisResult = false;
            //pa.CertDateOfIssue = DateTime.Now;

            //repository.Add(pa);
            //repository.Save();

            //IQueryable<PersonAnalysis> persons = repository.GetAll();
            //pa = persons.ToList<PersonAnalysis>()[1];  //repository.Get(4);

            //using (CgemoHivTestsContext context = new CgemoHivTestsContext())
            //{
                //Declarant d = new Declarant();
                //d.Title = "ФМС по МО";
                //d.Address = "МО г. Мытищи";
                //context.Declarants.Add(d);
                //context.SaveChanges();
                //Declarant dec;
                //dec = context.Declarants.FirstOrDefault();
                //return View(dec);

                //PersonAnalysis pa = new PersonAnalysis();
                //pa.FullName = "Иванов Иван Иванович";
                //pa.DateOfBirth = Convert.ToDateTime("08.08.1971");
                //pa.PassportNumber = "TM06723";
                //pa.PassportDateOfIssue = Convert.ToDateTime("05.04.2005");
                //pa.Country = "Узбекистан";
                //pa.CertNumber = "12345";
                //pa.AnalysisDate = Convert.ToDateTime("15.06.2015");
                //pa.AnalysisResult = false;
                //pa.CertDateOfIssue = DateTime.Now;

                //PersonAnalysis pa = new PersonAnalysis();
                //pa.CertNumber = "12345";
                //pa.AnalysisDate = Convert.ToDateTime("15.06.2015");
                //pa.AnalysisResult = false;
                //pa.CertDateOfIssue = DateTime.Now;
                //pa.Person = p;

                //context.Persons.Add(p);
                //context.PersonAnalyses.Add(pa);
                //context.SaveChanges();

                //Person p;
                //p = context.Persons.FirstOrDefault();

                //pa = XmlDataReader.ReadFile(@"C:\Проекты\CgemoHivTests\CgemoHivTests.WebUI\App_Data\Запрос на эмигрантов.xml")[0];
                //return View(pa);
            //}
        //}
        //public ActionResult IndexCompleted()
        //{
        //    return View();
        //}
    }
}
