using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAS.Application.Enums;

namespace UAS.Application.CustomAttributes
{
    /// <summary>
    /// Ilgili metod uzerindeki islem tiplerini, ilgilendigi menu bilgisini ve aciklamasina ait text degerini tanimlayarak ilgili endpointin rol bazinda yetkilendirilecegi bilgisini elde etmek icin kullanilir.
    /// </summary>
    public class AuthorizeDefinitionAttribute : Attribute
    {
        public string Menu { get; set; }
        public string Definition { get; set; }
        public ActionType ActionType { get; set; } //Role bagli requestin islem sinifini tanimlamak icin kullanilir.
    }
}
