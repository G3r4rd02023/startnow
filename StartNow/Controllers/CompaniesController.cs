using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StartNow.Data;
using StartNow.Data.Entities;
using StartNow.Helpers;
using StartNow.Models;

namespace StartNow.Controllers
{
    public class CompaniesController : Controller
    {

        private readonly DataContext _context;
        private readonly IBlobHelper _blobHelper;
        private readonly IConverterHelper _converterHelper;
        private readonly ICombosHelper _combosHelper;

        public CompaniesController(DataContext context, IBlobHelper blobHelper,
            IConverterHelper converterHelper, ICombosHelper combosHelper)
        {
            _context = context;
            _blobHelper = blobHelper;
            _converterHelper = converterHelper;
            _combosHelper = combosHelper;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _context.Companies.ToListAsync());
        }

        public IActionResult Create()
        {
            CompanyViewModel model = new CompanyViewModel()
            {
                Countries = _combosHelper.GetComboCountries(),
                Cities = _combosHelper.GetComboCities(0),
            };
            
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CompanyViewModel model)
        {
            if (ModelState.IsValid)
            {
                Guid imageId = Guid.Empty;

                if (model.ImageFile != null)
                {
                    imageId = await _blobHelper.UploadBlobAsync(model.ImageFile, "categorias");
                }

                try
                {
                    Company company = await _converterHelper.ToCompanyAsync(model, imageId, true);
                    _context.Add(company);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe una empresa con ese nombre.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }
            model.Countries = _combosHelper.GetComboCountries();
            model.Cities = _combosHelper.GetComboCities(model.CountryId);
            return View(model);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Company company = await _context.Companies.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }

            CompanyViewModel model = _converterHelper.ToCompanyViewModel(company);
            model.Countries = _combosHelper.GetComboCountries();
            model.Cities = _combosHelper.GetComboCities(model.CountryId);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CompanyViewModel model)
        {
            if (ModelState.IsValid)
            {
                Guid imageId = model.ImageId;

                if (model.ImageFile != null)
                {
                    imageId = await _blobHelper.UploadBlobAsync(model.ImageFile, "categorias");
                }

                try
                {
                    Company company = await _converterHelper.ToCompanyAsync(model, imageId, false);
                    _context.Update(company);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));

                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "There are a record with the same name.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }
            model.Countries = _combosHelper.GetComboCountries();
            model.Cities = _combosHelper.GetComboCities(model.CountryId);
            return View(model);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Company company = await _context.Companies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (company == null)
            {
                return NotFound();
            }

            try
            {
                _context.Companies.Remove(company);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return RedirectToAction(nameof(Index));
        }

        public JsonResult GetCities(int countryId)
        {
            Country country = _context.Countries
                .Include(d => d.Cities)
                .FirstOrDefault(d => d.Id == countryId);
            if (country == null)
            {
                return null;
            }

            return Json(country.Cities.OrderBy(c => c.Name));
        }
    }
}
