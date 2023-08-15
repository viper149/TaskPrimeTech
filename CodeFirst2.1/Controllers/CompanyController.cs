using System;
using System.Threading.Tasks;
using CodeFirst.Interfaces;
using CodeFirst.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirst.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompany _company;

        public CompanyController(ICompany company)
        {
            _company = company;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            try
            {
                var result = await _company.GetAll();
                return View(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Company company)
        {
            try
            {
                return (await _company.InsertByAsync(company)) ? RedirectToAction(nameof(Index)) : RedirectToAction(nameof(Create));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var result = await _company.FindByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Company company)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var exCom = await _company.FindByIdAsync(company.ID);
                    if (exCom != null)
                    {
                        exCom.CID = company.CID;
                        exCom.CNAME = company.CNAME;
                        exCom.CADDRESS = company.CADDRESS;

                        if (await _company.UpdateByAsync(exCom))
                        {
                            return RedirectToAction(nameof(Index));
                        }
                    }

                    return View(company);
                }

                return View(company);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var exCom = await _company.FindByIdAsync(id);
            await _company.DeleteByAsync(exCom);
            return RedirectToAction(nameof(Index));
        }

        //[AcceptVerbs("Get", "Post")]
        //[Route("Company/AlreadyInUse")]
        //public async Task<IActionResult> IsCIDInUse(Company company)
        //{
        //    var cid = company.CID;
        //    return await _company.FindByCIDAsync(cid) ? Json(true) : Json($"CID {cid} already exists");
        //}

        [HttpGet]
        public async Task<ActionResult> AddExtra()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<ActionResult> AddExtra(string field)
        //{
        //    try
        //    {
        //        var newCom = new Company
        //        {
        //            ExtraField = field
        //            // Set other properties as needed
        //        };

        //        await _company.AddField(newCom);

        //        return Json(new { success = true, message = "Data added successfully." });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { success = false, message = "An error occurred." });
        //    }
        //}
    }
}
