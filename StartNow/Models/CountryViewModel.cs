using Microsoft.AspNetCore.Http;
using StartNow.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace StartNow.Models
{
    public class CountryViewModel : Country
    {
        [Display(Name = "Bandera")]
        public IFormFile ImageFile { get; set; }
    }
}
