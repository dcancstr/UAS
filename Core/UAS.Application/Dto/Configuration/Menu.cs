using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Application.Dto.Configuration
{
    /// <summary>
    /// Rol bazli kontrol yapilacak menu adini ve bu menuye ait islemleri tanimlar.
    /// </summary>
    public class Menu
    {
        public string Name { get; set; }
        public List<Action> Actions { get; set; } = new();
    }
}
