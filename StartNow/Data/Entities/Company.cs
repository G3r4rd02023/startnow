using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StartNow.Data.Entities
{
    public class Company
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        [DisplayName("Empresa")]
        public string Name { get; set; }

        [MaxLength(20)]
        [Required]
        [DisplayName("Telefono")]
        public string Phone { get; set; }

        [MaxLength(100)]
        [Required]
        [DisplayName("Dirección")]
        public string Address { get; set; }

        [Display(Name = "Logo")]
        public Guid ImageId { get; set; }

        //TODO: Pending to put the correct paths
        [Display(Name = "Logo")]
        public string ImageFullPath => ImageId == Guid.Empty
            ? $"https://localhost:44367/images/noimage.png"
            : $"https://tecnologershn.blob.core.windows.net/categorias/{ImageId}";

        [Display(Name = "País")]
        public Country Country { get; set; }

        [Display(Name = "Ciudad")]
        public City City { get; set; }

        public ICollection<Category> Categories { get; set; }

        public ICollection<Product> Products { get; set; }

        public ICollection<CompanyCustomer> CompanyCustomers { get; set; }
    }
}
