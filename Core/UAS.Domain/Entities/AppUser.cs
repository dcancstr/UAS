using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Domain.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string TcKimlikNo { get; set; }
        public string PersonelKad { get; set; }
        public string PersonelPw { get; set; }
        public string PersonelImageUrl { get; set; }
        public string PersonelDogumYili { get; set; }
        public bool PersonelSMI { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }



        //Relational Properties
        //public ICollection<Notification>? Notifications { get; set; }
        public ICollection<PersonelRol> PersonelRols { get; set; }
    }
}
