using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Dependiente
    {
        // GETALL
        public static ML.Result DependienteGetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EgrijalvaProyectoNcapasIdentityCoreContext context = new DL.EgrijalvaProyectoNcapasIdentityCoreContext())
                {
                    var query = (from dependienteLINQ in context.Dependientes
                                 select new
                                 {
                                     IdDependiente = dependienteLINQ.IdDependiente,
                                     NumeroEmpleado = dependienteLINQ.NumeroEmpleado,
                                     Nombre = dependienteLINQ.Nombre,
                                     ApellidoPaterno = dependienteLINQ.ApellidoPaterno,
                                     ApellidoMaterno = dependienteLINQ.ApellidoMaterno,
                                     FechaNacimiento = dependienteLINQ.FechaNacimiento,
                                     EstadoCivil = dependienteLINQ.EstadoCivil,
                                     Genero = dependienteLINQ.Genero,
                                     Telefono = dependienteLINQ.Telefono,
                                     Rfc = dependienteLINQ.Rfc,
                                     IdDependienteTipo = dependienteLINQ.IdDependienteTipo
                                 });

                    result.Objects = new List<object>();

                    if (query != null && query.ToList().Count > 0)
                    {
                        foreach (var obj in query)
                        {
                            ML.Dependiente dependiente = new ML.Dependiente();

                            dependiente.IdDependiente = obj.IdDependiente;
                            dependiente.NumeroEmpleado = obj.NumeroEmpleado;
                            dependiente.Nombre = obj.Nombre;
                            dependiente.ApellidoPaterno = obj.ApellidoPaterno;
                            dependiente.ApellidoMaterno = obj.ApellidoMaterno;
                            dependiente.FechaNacimiento = obj.FechaNacimiento;
                            dependiente.EstadoCivil = obj.EstadoCivil;
                            dependiente.Genero = obj.Genero;
                            dependiente.Telefono = obj.Telefono;
                            dependiente.Rfc = obj.Rfc;
                            dependiente.IdDependienteTipo = obj.IdDependienteTipo;
                        }
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "NO se encontrarón Registros";
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

        // ADD
        public static ML.Result DependienteAdd(ML.Dependiente dependiente)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EgrijalvaProyectoNcapasIdentityCoreContext context = new DL.EgrijalvaProyectoNcapasIdentityCoreContext())
                {
                    DL.Dependiente dependienteLINQ = new DL.Dependiente();

                    dependienteLINQ.IdDependiente = dependiente.IdDependiente;
                    dependienteLINQ.NumeroEmpleado = dependiente.NumeroEmpleado;
                    dependienteLINQ.Nombre = dependiente.Nombre;
                    dependienteLINQ.ApellidoPaterno = dependiente.ApellidoPaterno;
                    dependienteLINQ.ApellidoMaterno = dependiente.ApellidoMaterno;
                    dependienteLINQ.FechaNacimiento = dependiente.FechaNacimiento;
                    dependienteLINQ.EstadoCivil = dependiente.EstadoCivil;
                    dependienteLINQ.Genero = dependiente.Genero;
                    dependienteLINQ.Telefono = dependiente.Telefono;
                    dependienteLINQ.Rfc = dependiente.Rfc;
                    dependienteLINQ.IdDependienteTipo= dependiente.IdDependienteTipo;

                    context.Dependientes.Add( dependienteLINQ );

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

        //UPDATE
        public static ML.Result DependienteUpdate(ML.Dependiente dependiente)
        {
            ML.Result result = new ML.Result();

            try
            {
                using(DL.EgrijalvaProyectoNcapasIdentityCoreContext context = new DL.EgrijalvaProyectoNcapasIdentityCoreContext())
                {
                    var query = (from Dependiente in context.Dependientes
                                 where dependiente.IdDependiente == dependiente.IdDependiente
                                 select dependiente).SingleOrDefault();

                    if(query != null)
                    {
                        query.Nombre = dependiente.Nombre;
                        query.ApellidoPaterno = dependiente.ApellidoPaterno;
                        query.ApellidoMaterno = dependiente.ApellidoMaterno;
                        query.FechaNacimiento = dependiente.FechaNacimiento;
                        query.EstadoCivil = dependiente.EstadoCivil;
                        query.Genero = dependiente.Genero;
                        query.Telefono = dependiente.Telefono;
                        query.Rfc = dependiente.Rfc;
                        query.IdDependienteTipo = dependiente.IdDependienteTipo;

                        context.SaveChanges();

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se encontro el Registro" + dependiente.IdDependiente;
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

        // DELETE
        public static ML.Result DependienteDelete(ML.Dependiente dependiente)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EgrijalvaProyectoNcapasIdentityCoreContext context = new DL.EgrijalvaProyectoNcapasIdentityCoreContext())
                {
                    var query = (from Dependiente in context.Dependientes
                                 where Dependiente.IdDependiente == dependiente.IdDependiente
                                 select dependiente).First();

                    DL.Dependiente dependienteLINQ = new DL.Dependiente();

                    context.Dependientes.Remove(dependienteLINQ);
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

        // GETBYID
        public static ML.Result DependienteGetById()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EgrijalvaProyectoNcapasIdentityCoreContext context = new DL.EgrijalvaProyectoNcapasIdentityCoreContext())
                {
                    var query = (from dependienteLINQ in context.Dependientes
                                 select new
                                 {
                                     IdDependiente = dependienteLINQ.IdDependiente,
                                     NumeroEmpleado = dependienteLINQ.NumeroEmpleado,
                                     Nombre = dependienteLINQ.Nombre,
                                     ApellidoPaterno = dependienteLINQ.ApellidoPaterno,
                                     ApellidoMaterno = dependienteLINQ.ApellidoMaterno,
                                     FechaNacimiento = dependienteLINQ.FechaNacimiento,
                                     EstadoCivil = dependienteLINQ.EstadoCivil,
                                     Genero = dependienteLINQ.Genero,
                                     Telefono = dependienteLINQ.Telefono,
                                     Rfc = dependienteLINQ.Rfc,
                                     IdDependienteTipo = dependienteLINQ.IdDependienteTipo
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
