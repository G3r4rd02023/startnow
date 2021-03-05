using Microsoft.AspNetCore.Identity;
using StartNow.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace StartNow.Data.Entities
{
    public class User : IdentityUser
    {

        [Display(Name = "Nombre")]
        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Apellidos")]
        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Dirección")]
        [MaxLength(100)]
        public string Address { get; set; }

        [Display(Name = "Foto")]
        public Guid ImageId { get; set; }

        //TODO: Pending to put the correct paths
        [Display(Name = "Foto")]
        public string ImageFullPath => ImageId == Guid.Empty
            ? $"https://localhost:44390/images/noimage.png"
            : $"https://tecnologershn.blob.core.windows.net/usuarios/{ImageId}";

        [Display(Name = "Rol")]
        public UserType UserType { get; set; }

        public City City { get; set; }

        public Company Company { get; set; }


        [Display(Name = "Usuario")]
        public string FullName => $"{FirstName} {LastName}";


    }
}
