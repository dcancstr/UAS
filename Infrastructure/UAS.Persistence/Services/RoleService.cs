using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAS.Application.Abstractions.Services;
using UAS.Domain.Entities;
using UAS.Application.Repositories.PersonelRol;
using UAS.Application.Repositories.PersonelRolTip;
using UAS.Application.Repositories.GrupMenuPanel;
using UAS.Application.Repositories.MenuKategori;
using UAS.Application.Repositories.MenuPanel;
using UAS.Application.Dto.Rol;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using UAS.Persistence.Contexts;
using System.Security;
using System.Data.Entity;
using Newtonsoft.Json;
using UAS.Persistence.Repositories.PersonelRol;

namespace UAS.Persistence.Services
{
    public class RoleService : IRoleService
    {
        readonly RoleManager<AppRole> _roleManager;
        private readonly IPersonelRolReadRepository _personelRolReadRepository;
        private readonly IPersonelRolWriteRepository _personelRolWriteRepository;
        private readonly IPersonelRolTipReadRepository _personelRolTipReadRepository;
        private readonly IPersonelRolTipWriteRepository _personelRolTipWriteRepository;
        private readonly IGrupMenuPanelReadRepository _grupMenuPanelReadRepository;
        private readonly IGrupMenuPanelWriteRepository _grupMenuPanelWriteRepository;
        private readonly IMenuKategoriReadRepository _menuKategoriReadRepository;
        private readonly IMenuKategoriWriteRepository _menuKategoriWriteRepository;
        private readonly IMenuPanelReadRepository _menuPanelReadRepository;
        private readonly IMenuPanelWriteRepository _menuPanelWriteRepository;
        private readonly IMapper _mapper;
        private readonly UASDbContext _context;

        public RoleService(RoleManager<AppRole> roleManager, IPersonelRolReadRepository personelRolReadRepository, IPersonelRolWriteRepository personelRolWriteRepository, IPersonelRolTipReadRepository personelRolTipReadRepository, IPersonelRolTipWriteRepository personelRolTipWriteRepository, IGrupMenuPanelReadRepository grupMenuPanelReadRepository, IGrupMenuPanelWriteRepository grupMenuPanelWriteRepository, IMenuKategoriReadRepository menuKategoriReadRepository, IMenuKategoriWriteRepository menuKategoriWriteRepository, IMenuPanelReadRepository menuPanelReadRepository, IMenuPanelWriteRepository menuPanelWriteRepository, IMapper mapper, UASDbContext context)
        {
            _roleManager = roleManager;
            _personelRolReadRepository = personelRolReadRepository;
            _personelRolWriteRepository = personelRolWriteRepository;
            _personelRolTipReadRepository = personelRolTipReadRepository;
            _personelRolTipWriteRepository = personelRolTipWriteRepository;
            _grupMenuPanelReadRepository = grupMenuPanelReadRepository;
            _grupMenuPanelWriteRepository = grupMenuPanelWriteRepository;
            _menuKategoriReadRepository = menuKategoriReadRepository;
            _menuKategoriWriteRepository = menuKategoriWriteRepository;
            _menuPanelReadRepository = menuPanelReadRepository;
            _menuPanelWriteRepository = menuPanelWriteRepository;
            _mapper = mapper;
            _context = context;
        }

        public async Task<bool> CreateRole(string name)
        {
            IdentityResult result = await _roleManager.CreateAsync(new() { Name = name });

            return result.Succeeded;
        }


        public async Task<bool> DeleteRole(string id)
        {
            AppRole appRole = await _roleManager.FindByIdAsync(id);
            IdentityResult result = await _roleManager.DeleteAsync(appRole);
            return result.Succeeded;
        }


        public (object, int) GetAllRoles(int page, int size)
        {
            var query = _roleManager.Roles;

            IQueryable<AppRole> rolesQuery = null;

            if (page != -1 && size != -1)
                rolesQuery = query.Skip(page * size).Take(size);
            else
                rolesQuery = query;

            return (rolesQuery.Select(r => new { r.Id, r.Name }), query.Count());
        }



        public async Task<(int id, string name)> GetRoleById(int id)
        {
            string role = await _roleManager.GetRoleIdAsync(new() { Id = id });
            return (id, role);
        }


        public async Task<bool> UpdateRole(string id, string name)
        {
            AppRole role = await _roleManager.FindByIdAsync(id);
            role.Name = name;
            IdentityResult result = await _roleManager.UpdateAsync(role);
            return result.Succeeded;
        }

        public async Task<GetRoleMenuByUserNameResponse> GetMenuPanelsAndMenukategoriWithUserName(GetRoleMenuByUserName getRoleMenuByUserName)
        {
            var response = await _grupMenuPanelReadRepository.GetMenuPanelsAndMenukategoriWithUserName(getRoleMenuByUserName.UserName);
            List<MenuKategori> liste = new List<MenuKategori>();
            foreach (var kategori in response.Item2)
            {
                foreach (var roleMenu in response.Item1)
                {
                    if (roleMenu.menuKategoriID == kategori.Id)
                    {
                        liste.Add(kategori);
                        break;
                    }
                }
            }
            return new GetRoleMenuByUserNameResponse
            {
                MenuPanels = response.Item1,
                MenuKategories = liste
            };
        }
        public List<GetPersonelRolTip> GetPersonelRolTips()
        {
            var personelRolTips = _personelRolTipReadRepository.GetAll(false);
            var getPersonelRoltips = personelRolTips.Select(
                x => new GetPersonelRolTip
                {
                    Id = x.Id,
                    personelRolTipAd = x.personelRolTipAd
                });
            return getPersonelRoltips.ToList();
        }
        public async Task<CreateRoleAssignMenuListe> GetMenuPanels()
        {
            return new CreateRoleAssignMenuListe
            {
                CreateRoleAssignMenus = _mapper.Map<List<MenuPanel>, List<CreateRoleAssignMenu>>(_menuPanelReadRepository.GetAll(false).ToList()),
                RoleName = string.Empty,
            };
        }

        public async Task<bool> CreateRoleAndAssignMenuPanel(CreateRoleAssignMenuListe createRoleAssignMenuListe)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var personelRoltip = new PersonelRolTip { personelRolTipAd = createRoleAssignMenuListe.RoleName, personelRolTipSMI = false, personelRolTipIndexUrl = 1, CDate = DateTime.UtcNow, EDate = DateTime.UtcNow, Deleted = false };
                    var rolTipResponse = await _personelRolTipWriteRepository.AddAsync(personelRoltip);
                    await _personelRolTipWriteRepository.SaveAsync();
                    if (!rolTipResponse) return false;
                    foreach (var i in createRoleAssignMenuListe.CreateRoleAssignMenus)
                    {
                        if (i.IsChecked)
                        {
                            var grupMenuPanelResponse = await _grupMenuPanelWriteRepository.AddAsync(new GrupMenuPanel
                            {
                                menuID = i.Id,
                                personelRolTipID = personelRoltip.Id,
                                grupMenuSMI = false,
                                CDate = DateTime.UtcNow,
                                EDate = DateTime.UtcNow,
                                Deleted = false
                            });
                            if (!grupMenuPanelResponse) return false;
                        }
                    }
                    await _grupMenuPanelWriteRepository.SaveAsync();
                    await transaction.CommitAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return false;
                }
            }
        }

        public async Task<UpdateRoleAssignMenuListe> UpdateRolGetRoles()
        {
            var personelRolTips = _mapper.Map<List<PersonelRolTip>, List<UpdateRoleAssignMenuGetRoles>>(_personelRolTipReadRepository.GetAll().ToList());
            return new UpdateRoleAssignMenuListe
            {
                UpdateRoleAssignMenuGetRoles = personelRolTips,
                UpdateRoleAssignMenus = new List<UpdateRoleAssignMenu>()
            };
        }

        public async Task<UpdateRoleAssignMenuListe> UpdateRoleAndGetPersonelTipAndMenuPanel(UpdateRoleAssignMenuListe UpdateRoleAssignMenuListe)
        {
            var personelRolTip = await _personelRolTipReadRepository.GetSingleAsync(prt => prt.personelRolTipAd == UpdateRoleAssignMenuListe.RoleName);
            var menuPanels = _menuPanelReadRepository.GetAll().ToList();
            var grupMenuPanels = _grupMenuPanelReadRepository.GetWhere(gmp => gmp.personelRolTipID == personelRolTip.Id).ToList();
            UpdateRoleAssignMenuListe list = await UpdateRolGetRoles();
            menuPanels.ForEach(menuPanel =>
            {
                var data = new UpdateRoleAssignMenu
                {
                    Id = menuPanel.Id,
                    menuAd = menuPanel.menuAd,
                    menuUstID = menuPanel.menuUstID
                };
                grupMenuPanels.ForEach(grupMenuPanel =>
                {
                    if (menuPanel.Id == grupMenuPanel.menuID) data.IsChecked = true;
                });
                list.UpdateRoleAssignMenus.Add(data);
            });
            list.IsChecked = personelRolTip.personelRolTipSMI;
            list.RoleName = personelRolTip.personelRolTipAd;
            list.RoleId = personelRolTip.Id;
            list.IsSuccess = true;
            return list;
        }

        public async Task<UpdateRoleAssignMenuListe> UpdateRoleAndGetPersonelTip(UpdateRol updateRol)
        {
            var personelRolTip = await _personelRolTipReadRepository.GetSingleAsync(prt => prt.Id == updateRol.roleId);
            var response = await UpdateRoleAndGetPersonelTipAndMenuPanel(new UpdateRoleAssignMenuListe { RoleName = personelRolTip.personelRolTipAd });
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    if (string.IsNullOrEmpty(updateRol.roleName)) throw new Exception();
                    personelRolTip.personelRolTipSMI = updateRol.isRoledeleted;
                    personelRolTip.personelRolTipAd = updateRol.roleName;
                    personelRolTip.Deleted = updateRol.isRoledeleted;
                    _personelRolTipWriteRepository.Update(personelRolTip);
                    await _personelRolTipWriteRepository.SaveAsync();
                    var grupMenuPanels = _grupMenuPanelReadRepository.GetWhere(gmp => gmp.personelRolTipID == personelRolTip.Id).ToList();
                    foreach (var menuPanel in updateRol.permissionList)
                    {
                        if (!menuPanel.isChecked)
                        {
                            foreach (var grupMenuPanel in grupMenuPanels)
                            {
                                if (grupMenuPanel.menuID == menuPanel.permissionId)
                                {
                                    _context.Set<GrupMenuPanel>().Remove(grupMenuPanel);
                                    await _grupMenuPanelWriteRepository.SaveAsync();
                                }
                            }
                        }
                        else
                        {
                            bool databaseHave = false;
                            foreach (var grupMenuPanel in grupMenuPanels)
                            {
                                if (grupMenuPanel.menuID == menuPanel.permissionId)
                                {
                                    databaseHave = true;
                                }
                            }
                            if (!databaseHave)
                            {
                                await _grupMenuPanelWriteRepository.AddAsync(new GrupMenuPanel
                                {
                                    CDate = DateTime.Now,
                                    Deleted = false,
                                    EDate = DateTime.Now,
                                    grupMenuSMI = false,
                                    menuID = menuPanel.permissionId,
                                    personelRolTipID = personelRolTip.Id
                                });
                                await _grupMenuPanelWriteRepository.SaveAsync();
                            }
                        }
                    }
                    await transaction.CommitAsync();
                    response.IsSuccess = true;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    response.IsSuccess = false;
                }
            }
            return response;
        }

        public List<GetMenuKategories> GetMenuCategories()
        {
            return _mapper.Map<List<MenuKategori>, List<GetMenuKategories>>(_menuKategoriReadRepository.GetAll(false).ToList()); ;
        }

        public async Task<bool> AddMenuPanels(string model)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var addMenuPanelRequest = JsonConvert.DeserializeObject<AddMenuPanelRequest>(model);
                    MenuPanel anaPanel = new()
                    {
                        menuUstID = 0,
                        menuSira = 1,
                        menuIcon = "default",
                        menuAd = addMenuPanelRequest.anaMenuAdi,
                        menuLink = "default",
                        menuVisible = true,
                        menuSMI = false,
                        Controller = addMenuPanelRequest.anaController,
                        Action = addMenuPanelRequest.anaAction,
                        menuKategoriID = Convert.ToInt32(addMenuPanelRequest.menuKategorisi),
                        CDate = DateTime.Now,
                        EDate = DateTime.Now,
                        Deleted = false,
                        ChangeUserIdentityId = 0,
                        CreateUserIdentityId = 0,
                        IfTransferredToSecondary = false,
                        RecordStatusId = 0
                    };
                    _context.MenuPanels.Add(anaPanel);
                    await _context.SaveChangesAsync();
                    foreach (var item in addMenuPanelRequest.altMenuler)
                    {
                        MenuPanel icPanel = new()
                        {
                            menuUstID = anaPanel.Id,
                            menuSira = 1,
                            menuIcon = "default",
                            menuAd = item.altMenuAdi,
                            menuLink = "default",
                            menuVisible = true,
                            menuSMI = false,
                            Controller = item.altController,
                            Action = item.altAction,
                            menuKategoriID = Convert.ToInt32(addMenuPanelRequest.menuKategorisi),
                            CDate = DateTime.Now,
                            EDate = DateTime.Now,
                            Deleted = false,
                            ChangeUserIdentityId = 0,
                            CreateUserIdentityId = 0,
                            IfTransferredToSecondary = false,
                            RecordStatusId = 0
                        };
                        await _menuPanelWriteRepository.AddAsync(icPanel);
                    }
                    await _menuPanelWriteRepository.SaveAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return false;
                }
            }
            return true;
        }

        public async Task<bool> AddOrUpdatePersonelRol(AddPersonelRol model)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    bool personelHasRole = false;
                    var result = _personelRolReadRepository.GetWhere(o => o.AppUserId == model.appUserId);
                    if (result.Count() > 0) personelHasRole = true;
                    if (personelHasRole)
                    {

                        var personelRol = result.First();
                        if (personelRol.personelRolTipID != model.personelRolTipId)
                        {
                            // foreign keyden dolayı personelRolTipID updatelenmiyor ef core'da
                            // raw sql ile de yapılabilir - denenmedi
                            // var rowsModified = _context.Database.ExecuteSqlRaw($"UPDATE [PersonelRols] SET [personelRolTipID] = {model.personelRolTipId} WHERE [appUserId] = {model.appUserId}");

                            // update yerine remove - add işlemi 
                            // _personelRolWriteRepository.Remove(personelRol);
                            // await _personelRolWriteRepository.SaveAsync();
                            // personelRol.personelRolTipID = model.personelRolTipId;
                            // personelRol.EDate = DateTime.Now;
                            // await _personelRolWriteRepository.AddAsync(personelRol);

                            // personelRolTip'in PersonelRols listesini değiştirerek işlem
                            var personelRolTip = await _personelRolTipReadRepository.GetByIdAsync(personelRol.personelRolTipID);
                            personelRolTip.PersonelRols.Remove(personelRol);
                            _personelRolTipWriteRepository.Update(personelRolTip);
                            await _personelRolTipWriteRepository.SaveAsync();
                            personelRolTip = await _personelRolTipReadRepository.GetByIdAsync(model.personelRolTipId);
                            personelRol.personelRolTipID = model.personelRolTipId;
                            personelRolTip.PersonelRols = new List<PersonelRol> { personelRol };
                            await _personelRolWriteRepository.SaveAsync();
                        }
                    }
                    else
                    {
                        var personelRol = new PersonelRol()
                        {
                            CDate = DateTime.Now,
                            EDate = DateTime.Now,
                            Deleted = false,
                            personelRolSMI = false,
                            personelRolTipID = model.personelRolTipId,
                            AppUserId = model.appUserId
                        };
                        await _personelRolWriteRepository.AddAsync(personelRol);
                        await _personelRolWriteRepository.SaveAsync();
                    }
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                }
            }
            return true;
        }
        public List<UpdatePersonelRolGetUser> UpdatePersonelRolGetUsers()
        {
            var response = new List<UpdatePersonelRolGetUser>();
            var users = EntityFrameworkQueryableExtensions.Include(_context.Users, u => u.PersonelRols).ThenInclude(p=>p.PersonelRolTip);
            foreach (var user in users)
            {
                var updatePersonelRolGetUser = new UpdatePersonelRolGetUser()
                {
                    Id = user.Id,
                    Name = user.Name,
                    Surname = user.Surname,
                    UserName = user.UserName
                };
                if (user.PersonelRols != null && user.PersonelRols.Count != 0)
                {
                    var personelRolTip = user.PersonelRols.First().PersonelRolTip;
                    updatePersonelRolGetUser.PersonelRolTipID = personelRolTip.Id;
                    updatePersonelRolGetUser.PersonelRolTipAd = personelRolTip.personelRolTipAd;
                }
                response.Add(updatePersonelRolGetUser);
            }
            return response;

        }
    }
}
