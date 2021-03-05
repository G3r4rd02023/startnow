using Microsoft.AspNetCore.Identity;
using StartNow.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StartNow.Data.Entities
{
    public class Customer : IdentityUser
    {
        public int Id { get; set; }

        [MaxLength(256)]
        [Required]
        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }

        [MaxLength(50)]
        [Required]
        [DisplayName("Nombre")]
        public string FirstName { get; set; }

        [MaxLength(50)]
        [Required]
        [DisplayName("Apellidos")]
        public string LastName { get; set; }

        [MaxLength(20)]
        [Required]
        [DisplayName("Telefono")]
        public string Phone { get; set; }

        [MaxLength(100)]
        [Required]
        [DisplayName("Dirección")]
        public string Address { get; set; }

        [Display(Name = "Rol")]
        public UserType UserType { get; set; }

        [Display(Name = "Foto")]
        public Guid ImageId { get; set; }

        //TODO: Pending to put the correct paths
        [Display(Name = "Foto")]
        public string ImageFullPath => ImageId == Guid.Empty
            ? $"https://localhost:44367/images/noimage.png"
            : $"https://tecnologershn.blob.core.windows.net/usuarios/{ImageId}";

        [Display(Name = "País")]
        public Country Country { get; set; }

        [Display(Name = "Ciudad")]
        public City City { get; set; }

        [Display(Name = "Cliente")]
        public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }

        public ICollection<CompanyCustomer> CompanyCustomers { get; set; }

    }
}
