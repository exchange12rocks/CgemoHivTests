using CgemoHivTests.BusinessLogic.DTO;
using CgemoHivTests.BusinessLogic.Interfaces;
using CgemoHivTests.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CgemoHivTests.WebUI.Controllers
{
    public class SearchController : Controller
    {
        IDbServiceAsync<PersonAnalysisDTO> personAnalysisService;
        public SearchController(IDbServiceAsync<PersonAnalysisDTO> serv)
        {
            ViewBag.SelectedPage = "Search";
            personAnalysisService = serv;
        }
        public ActionResult Index()
        {
            //IEnumerable<PersonAnalysisDTO> list = await personAnalysisService.GetEntitiesAsync();
            return View();
        }
        public ActionResult Search(SearchModel model)
        {
            string search = "model.FullName";
            IEnumerable<PersonAnalysisDTO> entities =
                personAnalysisService.FindBy(p => p.FullName.StartsWith(search));
            return PartialView("_PersonList", entities);
        }
    }
}