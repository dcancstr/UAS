using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Application.Dto.Rol
{
    public class AddMenuPanelRequest
    {
        public string anaController { get; set; }
        public string anaAction { get; set; }
        public string anaMenuAdi { get; set; }
        public string menuKategorisi { get; set; }
        public List<AddMenuPanelRequestInner> altMenuler { get; set; }
    }
}
