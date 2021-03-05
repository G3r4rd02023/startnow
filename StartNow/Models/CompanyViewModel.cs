using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using StartNow.Data.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StartNow.Models
{
    public class CompanyViewModel : Company
    {
        [Display(Name = "Imagen")]
        public IFormFile ImageFile { get; set; }

        [Required]
        [Display(Name = "País")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione un país.")]
        public int CountryId { get; set; }

        public IEnumerable<SelectListItem> Countries { get; set; }


        [Required]
        [Display(Name = "Ciudad")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione una ciudad.")]
        public int CityId { get; set; }

        public IEnumerable<SelectListItem> Cities { get; set; }
    }
}
