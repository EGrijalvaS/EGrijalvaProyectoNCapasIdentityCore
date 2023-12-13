using Microsoft.EntityFrameworkCore;
using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class UserIdentity
    {                                         // GetAll de Users
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EgrijalvaProyectoNcapasIdentityCoreContext context = new DL.EgrijalvaProyectoNcapasIdentityCoreContext())
                {
                    var  query = ( from user in context.AspNetUsers   // Referencia a la tabla de Identity AspNetUsers
                                   select new
                                   {
                                      IdUser = user.Id,
                                      UserName = user.UserName
                                   }).ToList();

                    if (query.Count > 0)
                    {
                        result.Objects = new List<object>(); // Lista de objetos

                        foreach (var item in query )
                        {
                            ML.UserIdentity usuario = new ML.UserIdentity();

                            usuario.IdUsuario = item.IdUser;
                            usuario.UserName = item.UserName;
                            result.Objects.Add(usuario);
                        }
                        result.Correct = true;
                    }

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

        public static ML.Result Asignar(ML.UserIdentity user)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EgrijalvaProyectoNcapasIdentityCoreContext context = new DL.EgrijalvaProyectoNcapasIdentityCoreContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"AddAspNetUserRoles '{user.IdUsuario}','{user.Rol.RoleId}'"); // Interpolación: Para no estar concatenando

                    if (query != null)
                    {
                        result.Correct = true;
                    }
                }
            } 
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = "No se pudo Asignar";
                result.Ex = ex;
            }
            return result;
        }

    }
}
