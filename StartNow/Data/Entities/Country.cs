using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StartNow.Data.Entities
{
    public class Country
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Image")]
        public Guid ImageId { get; set; }

        //TODO: Pending to put the correct paths
        [Display(Name = "Image")]
        public string ImageFullPath => ImageId == Guid.Empty
            ? $"https://localhost:44367/images/noimage.png"
            : $"https://tecnologershn.blob.core.windows.net/categorias/{ImageId}";


        public ICollection<City> Cities { get; set; }

        [DisplayName("No Ciudades")]
        public int CitiesNumber => Cities == null ? 0 : Cities.Count;
    }
}
