using CgemoHivTests.BusinessLogic.DTO;
using CgemoHivTests.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CgemoHivTests.WebUI.Controllers
{
    public class ImportFileController : Controller
    {
        IDbServiceAsync<PersonAnalysisDTO> personAnalysisService;
        public ImportFileController(IDbServiceAsync<PersonAnalysisDTO> serv)
        {
            ViewBag.SelectedPage = "Import";
            personAnalysisService = serv;
        }
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Upload(HttpPostedFileBase upload)
        {
            string result;
            ICollection<PersonAnalysisDTO> persons = null;
            if (upload != null)
            {
                // получаем имя файла
                //string fileName = System.IO.Path.GetFileName(upload.FileName);
                //// сохраняем файл в папку Files в проекте
                //upload.SaveAs(Server.MapPath("~/ImportFiles/" + fileName));
               
                try
                {
                    persons = await CgemoHivTests.BusinessLogic.Services.XmlDataReaderService.ReadFileAsync(upload.InputStream,
                        Server.MapPath("~/App_Data/" + "PersonsXMLSchema.xsd"));
                    if (persons != null) await personAnalysisService.SaveEntitiesAsync(persons);
                    result = String.Format("Загружено записей: {0}", persons.Count.ToString());
                }
                catch (Exception ex)
                {
                    result = ex.Message;//"ex.GetBaseException().Message";
                }

            }
            else result = "Не выбран файл";
            TempData["Result"] = result;
            //return RedirectToAction("Index");
            return View("Index");
        }
    }
}