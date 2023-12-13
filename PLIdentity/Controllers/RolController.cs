using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PLIdentity.Controllers
{

    public class RolController : Controller
    {
        private RoleManager<IdentityRole> roleManager;
        public RolController(RoleManager<IdentityRole> roleMgr)
        {
            roleManager = roleMgr;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var Roles = roleManager.Roles.ToList();
            return View(Roles);
        }

        //[Authorize(Roles = "Administrador, Usuario")]
        [HttpGet]
        public IActionResult Asignar(Guid IdRole, string Name)
        {
            ML.Result result = BL.UserIdentity.GetAll();
            ML.UserIdentity user = new ML.UserIdentity();
            if (result.Correct)
            {
                user.IdentityUsers = result.Objects;
            }
            user.Rol = new ML.Rol();
            user.Rol.Name = Name;
            user.Rol.RoleId = IdRole;

            return View(user);
        }

        // [Authorize(Roles = "Administrador, Usuario")]
        [HttpPost]
        public IActionResult Asignar(ML.UserIdentity user)
        {
            ML.Result result = BL.UserIdentity.Asignar(user);
            if (result.Correct)
            {
                ViewBag.Message = "Todo bien";

            }
            else
            {
                ViewBag.Message = result.Message;
            }

            return PartialView("Modal");
        }

        // [Authorize(Roles = "Administrador, Usuario")]
        [HttpPost]
        public async Task<IActionResult> Form([Required] Microsoft.AspNetCore.Identity.IdentityRole rol)
        {

            if (ModelState.IsValid)
            {
                IdentityRole role = await roleManager.FindByIdAsync(rol.Id.ToString());
                //Add o Insert
                if (role == null)
                {
                    IdentityResult result = await roleManager.CreateAsync(new IdentityRole(rol.Name));
                    if (result.Succeeded)
                    {
                        return RedirectToAction("GetAll");
                    }
                    else
                    {

                    }
                }
                else //Update
                {
                    role.Id = await roleManager.GetRoleIdAsync(rol);
                    role.Name = await roleManager.GetRoleNameAsync(rol);

                    IdentityResult result = await roleManager.UpdateAsync(role);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("GetAll");
                    }
                }
            }
            return View(rol);
        }

        // [Authorize(Roles = "Administrador, Usuario")]
        [HttpGet]
        public IActionResult Form(Guid IdRole, string Name)
        {
            IdentityRole role = new IdentityRole();
            if (Name != null)
            {
                role.Name = Name;
                role.Id = IdRole.ToString();
                return View(role);
            }
            else
            {
                return View(role);
            }

        }

        //[Authorize(Roles = "Administrador, Usuario")]
        public async Task<IActionResult> Delete(Guid IdRole)
        {
            IdentityRole role = await roleManager.FindByIdAsync(IdRole.ToString());
            if (role != null)
            {
                IdentityResult result = await roleManager.DeleteAsync(role);
                if (result.Succeeded)
                    return RedirectToAction("GetAll");
                //else
                //    Errors(result);
            }
            else
                ModelState.AddModelError("", "No role found");
            return View("GetAll", roleManager.Roles);
        }


    }
}
