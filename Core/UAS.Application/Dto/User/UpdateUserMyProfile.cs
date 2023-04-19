using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Application.Dto.User
{
    public class UpdateUserMyProfile
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string PersonelDogumYili { get; set; }
        public string PersonelImageUrl { get; set; }
        public IFormFile PersonelImage { get; set; }
        public string PhoneNumber { get; set; }
        public string TcKimlikNo { get; set; }

    }
}
