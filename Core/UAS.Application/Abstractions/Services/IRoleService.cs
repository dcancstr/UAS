using UAS.Application.Dto.Rol;
using UAS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Application.Abstractions.Services
{
    public interface IRoleService
    {
        /// <summary>
        /// Tum rolleri getirir.
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        (object, int) GetAllRoles(int page, int size);


        /// <summary>
        /// Gelen id parametresine gore rol kaydini getirir.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<(int id, string name)> GetRoleById(int id);


        /// <summary>
        /// Gelen parametre degerlerine ait bir kayit olusturur.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<bool> CreateRole(string name);

        /// <summary>
        /// Gelen id parametresine ait kaydi siler.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteRole(string id);


        /// <summary>
        /// Gelen id parametresi uzerinden rol kaydini bulur ve gerekli parametreleri gunceller.
        /// </summary>
        /// <param name="id">Role Id</param>
        /// <param name="name">Role Name</param>
        /// <returns></returns>
        Task<bool> UpdateRole(string id, string name);

        Task<GetRoleMenuByUserNameResponse> GetMenuPanelsAndMenukategoriWithUserName(GetRoleMenuByUserName getRoleMenuByUserName);
        Task<UpdateRoleAssignMenuListe> UpdateRolGetRoles();
        Task<CreateRoleAssignMenuListe> GetMenuPanels();
        Task<bool> CreateRoleAndAssignMenuPanel(CreateRoleAssignMenuListe createRoleAssignMenuListe);
        Task<UpdateRoleAssignMenuListe> UpdateRoleAndGetPersonelTipAndMenuPanel(UpdateRoleAssignMenuListe UpdateRoleAssignMenuListe);
        Task<UpdateRoleAssignMenuListe> UpdateRoleAndGetPersonelTip(UpdateRol updateRol);
        List<GetMenuKategories> GetMenuCategories();
        List<GetPersonelRolTip> GetPersonelRolTips();
        Task<bool> AddMenuPanels(string model);
        Task<bool> AddOrUpdatePersonelRol(AddPersonelRol model);
        List<UpdatePersonelRolGetUser> UpdatePersonelRolGetUsers();
    }
}
