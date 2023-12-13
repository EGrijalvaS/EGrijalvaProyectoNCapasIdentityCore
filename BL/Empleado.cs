
using DL;
using ML;

namespace BL
{
    public class Empleado
    {

        // EmpleadoGetAll LINQ 
        public static ML.Result EmpleadoGetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EgrijalvaProyectoNcapasIdentityCoreContext context = new DL.EgrijalvaProyectoNcapasIdentityCoreContext())
                {
                    var query = (from empleadoLINQ in context.Empleados
                                 select new
                                 {
                                     NumeroEmpleado = empleadoLINQ.NumeroEmpleado,
                                     RFC = empleadoLINQ.Rfc,
                                     Nombre = empleadoLINQ.Nombre,
                                     ApellidoPaterno = empleadoLINQ.ApellidoPaterno,
                                     ApellidoMaterno = empleadoLINQ.ApellidoMaterno,
                                     Email = empleadoLINQ.Email,
                                     Telefono = empleadoLINQ.Telefono,
                                     FechaNacimiento = empleadoLINQ.FechaNacimiento,
                                     NSS = empleadoLINQ.Nss,
                                     FechaIngreso = empleadoLINQ.FechaIngreso,
                                     Foto = empleadoLINQ.Foto,
                                     IdEmpresa = empleadoLINQ.IdEmpresa
                                 });

                    result.Objects = new List<object>();

                    if (query != null && query.ToList().Count > 0)
                    {
                        foreach (var obj in query)
                        {
                            ML.Empleado empleado = new ML.Empleado();
                            empleado.NumeroEmpleado = obj.NumeroEmpleado;
                            empleado.Rfc = obj.RFC;
                            empleado.Nombre = obj.Nombre;
                            empleado.ApellidoPaterno = obj.ApellidoPaterno;
                            empleado.ApellidoMaterno = obj.ApellidoMaterno;
                            empleado.Email = obj.Email;
                            empleado.Telefono = obj.Telefono;
                            empleado.FechaNacimiento = obj.FechaNacimiento;
                            empleado.Nss = obj.NSS;
                            empleado.FechaIngreso = obj.FechaIngreso;
                            empleado.Foto = obj.Foto;
                            empleado.IdEmpresa = obj.IdEmpresa;
                            result.Objects.Add(empleado);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se encontraron registros";
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

        // EmpleadoAdd LINQ
        public static ML.Result EmpleadoAdd(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EgrijalvaProyectoNcapasIdentityCoreContext context = new DL.EgrijalvaProyectoNcapasIdentityCoreContext())
                {
                    DL.Empleado empleadoLINQ = new DL.Empleado();

                    empleadoLINQ.NumeroEmpleado = empleado.NumeroEmpleado;
                    empleadoLINQ.Rfc = empleado.Rfc;
                    empleadoLINQ.Nombre = empleado.Nombre;
                    empleadoLINQ.ApellidoPaterno = empleado.ApellidoPaterno;
                    empleadoLINQ.ApellidoMaterno = empleado.ApellidoMaterno;
                    empleadoLINQ.Email = empleado.Email;
                    empleadoLINQ.Telefono = empleado.Telefono;
                    empleadoLINQ.FechaNacimiento = empleado.FechaNacimiento;
                    empleadoLINQ.Nss = empleado.Nss;
                    empleadoLINQ.FechaIngreso = empleado.FechaIngreso;
                    empleadoLINQ.Foto = empleado.Foto;
                    empleadoLINQ.IdEmpresa = empleado.IdEmpresa;

                    context.Empleados.Add(empleadoLINQ);

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

        // EmpleadoUpdate LINQ
        public static ML.Result EmpleadoUpdate(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EgrijalvaProyectoNcapasIdentityCoreContext context = new DL.EgrijalvaProyectoNcapasIdentityCoreContext())
                {
                    var query = (from Empleado in context.Empleados
                                 where empleado.NumeroEmpleado == empleado.NumeroEmpleado
                                 select empleado).SingleOrDefault();

                    if (query != null)
                    {
                        query.Rfc = empleado.Rfc;
                        query.Nombre = empleado.Nombre;
                        query.ApellidoPaterno = empleado.ApellidoPaterno;
                        query.ApellidoMaterno = empleado.ApellidoMaterno;
                        query.Email = empleado.Email;
                        query.Telefono = empleado.Telefono;
                        query.FechaNacimiento = empleado.FechaNacimiento;
                        query.Nss = empleado.Nss;
                        query.FechaIngreso = empleado.FechaIngreso;
                        query.Foto = empleado.Foto;
                        query.IdEmpresa = empleado.IdEmpresa;

                        context.SaveChanges();

                        result.Correct = true;
                    }

                    else
                    {
                        result.Correct = false;
                        result.Message = "No se encontró el grupo" + empleado.NumeroEmpleado;
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

        // EmpleadoDelete LINQ
        public static Result EmpleadoDelete(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EgrijalvaProyectoNcapasIdentityCoreContext context = new DL.EgrijalvaProyectoNcapasIdentityCoreContext())
                {
                    var query = (from Empleado in context.Empleados
                                 where Empleado.NumeroEmpleado == empleado.NumeroEmpleado
                                 select empleado).First();

                    DL.Empleado empleadoLINQ = new DL.Empleado();

                    context.Empleados.Remove(empleadoLINQ);
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

        // EmpleadoGetById
        public static ML.Result EmpleadoGetById(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EgrijalvaProyectoNcapasIdentityCoreContext context = new DL.EgrijalvaProyectoNcapasIdentityCoreContext())
                {
                    var query = (from empleadoLINQ in context.Empleados
                                 where empleadoLINQ.NumeroEmpleado == empleadoLINQ.NumeroEmpleado
                                 select new
                                 {
                                     NumeroEmpleado = empleadoLINQ.NumeroEmpleado,
                                     RFC = empleadoLINQ.Rfc,
                                     Nombre = empleadoLINQ.Nombre,
                                     ApellidoPaterno = empleadoLINQ.ApellidoPaterno,
                                     ApellidoMaterno = empleadoLINQ.ApellidoMaterno,
                                     Email = empleadoLINQ.Email,
                                     Telefono = empleadoLINQ.Telefono,
                                     FechaNacimiento = empleadoLINQ.FechaNacimiento,
                                     NSS = empleadoLINQ.Nss,
                                     FechaIngreso = empleadoLINQ.FechaIngreso,
                                     Foto = empleadoLINQ.Foto,
                                     IdEmpresa = empleadoLINQ.IdEmpresa
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





