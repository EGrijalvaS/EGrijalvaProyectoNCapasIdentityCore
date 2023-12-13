using DL;
using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Empresa
    {
        // EmpresaGetAll
        public static ML.Result EmpresaGetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EgrijalvaProyectoNcapasIdentityCoreContext context = new DL.EgrijalvaProyectoNcapasIdentityCoreContext())
                {
                    var query = (from empresaLINQ in context.Empresas
                                 select new
                                 {
                                     IdEmpresa = empresaLINQ.IdEmpresa,
                                     Nombre = empresaLINQ.Nombre,
                                     Telefono = empresaLINQ.Telefono,
                                     Email = empresaLINQ.Email,
                                     DireccionWeb = empresaLINQ.DireccionWeb,
                                     Logo = empresaLINQ.Logo
                                 });

                    result.Objects = new List<object>();

                    if (query != null && query.ToList().Count > 0)
                    {
                        foreach (var obj in query)
                        {
                            ML.Empresa empresa = new ML.Empresa();
                            empresa.IdEmpresa= obj.IdEmpresa;
                            empresa.Nombre = obj.Nombre;
                            empresa.Telefono = obj.Telefono;
                            empresa.Email = obj.Email;
                            empresa.DireccionWeb = obj.DireccionWeb;
                            empresa.Logo = obj.Logo;
                            result.Objects.Add(empresa);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se encontraron Registros de la Empresa";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
            }
            return result;
        }

        // EmpresaAdd
        public static ML.Result EmpresaAdd(ML.Empresa empresa)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EgrijalvaProyectoNcapasIdentityCoreContext context = new DL.EgrijalvaProyectoNcapasIdentityCoreContext())
                {
                    DL.Empresa empresaLINQ = new DL.Empresa();

                    empresaLINQ.IdEmpresa = empresa.IdEmpresa;
                    empresaLINQ.Nombre = empresa.Nombre;
                    empresaLINQ.Telefono = empresa.Telefono;
                    empresaLINQ.Email = empresa.Email;
                    empresaLINQ.DireccionWeb = empresa.DireccionWeb;
                    empresaLINQ.Logo = empresa.Logo;

                    context.Empresas.Add(empresaLINQ);

                    context.SaveChanges();
                }

                result.Correct = true;
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
            }

            return result;
        }

        // EmpresaUpdate
        public static ML.Result EmpresaUpdate(ML.Empresa empresa)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EgrijalvaProyectoNcapasIdentityCoreContext context = new DL.EgrijalvaProyectoNcapasIdentityCoreContext())
                {
                    var query = (from Empresa in context.Empresas
                                 where empresa.IdEmpresa == empresa.IdEmpresa
                                 select empresa).SingleOrDefault();

                    if (query != null)
                    {
                        query.Nombre = empresa.Nombre;
                        query.Telefono = empresa.Telefono;
                        query.Email = empresa.Email;
                        query.DireccionWeb = empresa.DireccionWeb;
                        query.Logo = empresa.Logo;

                        context.SaveChanges();

                        result.Correct = true;
                    }

                    else
                    {
                        result.Correct = false;
                        result.Message = "No se encontró el grupo" + empresa.IdEmpresa;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
            }

            return result;
        }

        // EmpresaDelete
        public static ML.Result EmpresaDelete(ML.Empresa empresa)
        {
            ML.Result result = new ML.Result();

            try
            {
                using(DL.EgrijalvaProyectoNcapasIdentityCoreContext context = new DL.EgrijalvaProyectoNcapasIdentityCoreContext())
                {
                    var query = (from Empresa in context.Empresas
                                 where Empresa.IdEmpresa == empresa.IdEmpresa
                                 select empresa).First();

                    DL.Empleado empresaLINQ = new DL.Empleado();

                    context.Empleados.Remove(empresaLINQ);
                    context.SaveChanges();
                }
            } 
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;

            }
            return result;
        }

        // EmpresaGetById
        public static ML.Result EmpresaGetById(ML.Empresa empresa)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EgrijalvaProyectoNcapasIdentityCoreContext context = new DL.EgrijalvaProyectoNcapasIdentityCoreContext())
                {
                    var query = (from empresaLINQ in context.Empresas
                                 where empresaLINQ.IdEmpresa == empresaLINQ.IdEmpresa
                                 select new
                                 {
                                     IdEmpresa = empresaLINQ.IdEmpresa,
                                     Nombre = empresaLINQ.Nombre,
                                     Telefono = empresaLINQ.Telefono,
                                     Email = empresaLINQ.Email,
                                     DireccionWeb = empresaLINQ.DireccionWeb,
                                     Logo = empresaLINQ.Logo
                                 });

                    result.Objects = new List<object>();
                  
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
            }
            return result;
        }
    }
}
