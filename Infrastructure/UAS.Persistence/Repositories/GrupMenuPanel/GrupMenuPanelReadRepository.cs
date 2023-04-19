using Microsoft.EntityFrameworkCore;
using UAS.Application.Repositories.GrupMenuPanel;
using UAS.Domain.Entities;
using UAS.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Persistence.Repositories.GrupMenuPanel
{
    public class GrupMenuPanelReadRepository : ReadRepository<UAS.Domain.Entities.GrupMenuPanel, int>, IGrupMenuPanelReadRepository
    {
        public GrupMenuPanelReadRepository(UASDbContext context) : base(context)
        {
        }



        public async Task<(List<Domain.Entities.MenuPanel>, List<Domain.Entities.MenuKategori>)> GetMenuPanelsAndMenukategoriWithUserName(string userName)
        {
            var menuPanels = (from gmp in _context.GrupMenuPanels
                                    join mp in _context.MenuPanels on gmp.menuID equals mp.Id
                                    where gmp.personelRolTipID == (from u in _context.Users
                                                                   join pr in _context.PersonelRols on u.Id equals pr.AppUserId
                                                                   join prt in _context.PersonelRolTips on pr.personelRolTipID equals prt.Id
                                                                   where u.UserName == userName
                                                                   select prt.Id).Single<int>()
                                    select new Domain.Entities.MenuPanel
                                    {
                                        Id = mp.Id,
                                        CDate = mp.CDate,
                                        Deleted = mp.Deleted,
                                        menuAd = mp.menuAd,
                                        menuIcon = mp.menuIcon,
                                        menuVisible = mp.menuVisible,
                                        menuUstID = mp.menuUstID,
                                        menuSMI = mp.menuSMI,
                                        menuSira = mp.menuSira,
                                        menuLink = mp.menuLink,
                                        menuKategoriID = mp.menuKategoriID,
                                        EDate = mp.EDate,
                                        Action= mp.Action,
                                        Controller= mp.Controller                                        
                                    }).ToList();
            var menuGrups = (from mk in _context.MenuKategories
                                   select new Domain.Entities.MenuKategori
                                   {
                                       Id = mk.Id,
                                       EDate = mk.EDate,
                                       CDate = mk.CDate,
                                       Deleted = mk.Deleted,
                                       menuKategoriAd = mk.menuKategoriAd,
                                       menuKategoriSira = mk.menuKategoriSira
                                   }).ToList();
            return (menuPanels, menuGrups);
        }
    }
}
