﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAS.Domain.Entities;

namespace UAS.Application.Dto.Rol
{
    public class UpdatePersonelRolGetUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int PersonelRolTipID { get; set; }
        public string PersonelRolTipAd { get; set; }

    }
}
