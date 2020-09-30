using ProyectoProgramacion.ETL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoProgramacion.Models
{
    public class ListaUsuarioModelo
    {
        public List<etlUsuario> ConsultarTodos()
        {
            using (var contextoBD = new ARMEntities())
            {
                var respuesta = contextoBD.Usuarios.Select(x =>
                new etlUsuario
                {
                    Empleado = new etlEmpleado
                    {
                        Cedula=x.Empleados.empleadoCedula.Trim()
                    },
                    Password = x.usuarioContraseña.Trim(),
                    Rol = new etlRol
                    {
                        ID_Rol = x.Roles.rolId,
                        Rol = x.Roles.rolNombre.Trim()
                    }

                }).ToList();
                return respuesta;
            }

        }
        public void GuardarConsulta(etlUsuario usr)
        {
            try
            {
                using (var contextoBD = new ARMEntities())
                {
                    Usuarios item = new Usuarios();

                    item.Empleados.empleadoCedula = usr.Empleado.Cedula.Trim();
                    item.usuarioContraseña = usr.Password.Trim();
                    item.rolId = usr.Rol.ID_Rol;


                    contextoBD.Usuarios.Add(item);
                    contextoBD.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new System.Exception("Cedula ya existe");
            }

        }
        public void Eliminar(string id)
        {
            try
            {
                using (var contextoBD = new ARMEntities())
                {
                    Usuarios usr = (from d in contextoBD.Usuarios
                                   where d.Empleados.empleadoCedula == id
                                   select d).FirstOrDefault();
                    contextoBD.Usuarios.Remove(usr);
                    contextoBD.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new System.Exception("Error al eliminar");
            }

        }

        public etlUsuario Consultar(string id)
        {
            try
            {
                using (var contextoBD = new ARMEntities())
                {
                    //Usuarios user = contextoBD.Usuarios.Find(user.Empleados.empleadoCedula)
                    //                usr => usr.Empleados.empleadoCedula, emp => emp.
                    //                 (emp,usr) => usr).Where(a => a.Cedula.Equals(id)).FirstOrDefault();

                    Usuarios user = contextoBD.Usuarios.Find(id);

                    etlUsuario usuario = new etlUsuario
                    {
                        Empleado = new etlEmpleado
                        {
                            Cedula = user.Empleados.empleadoCedula.Trim(),
                        },
                        Password = user.usuarioContraseña.Trim(),
                        Rol = new etlRol 
                        {
                            ID_Rol = user.Roles.rolId,
                            Rol = user.Roles.rolNombre.Trim(),
                        },

                    };
                    return usuario;
                }
            }
            catch (Exception e)
            {
                throw new System.Exception("Error al consultar");
            }

        }
        public void Actualizar(etlUsuario usuario)
        {
            try
            {
                using (var contextoBD = new ARMEntities())
                {
                    //Usuarios item = contextoBD.Empleado.Join(contextoBD.Usuario,
                    //                 emp => emp.Cedula, usr => usr.Cedula,
                    //                 (emp, usr) => usr).Where(a => a.Cedula.Equals(usuario.Empleado.Cedula)).FirstOrDefault();

                    Usuarios item = contextoBD.Usuarios.Find(usuario.Empleado.Cedula);

                    item.usuarioContraseña = usuario.Password;
                    item.rolId = usuario.Rol.ID_Rol;
                    contextoBD.SaveChanges();

                }
            }
            catch (Exception e)
            {
                throw new System.Exception("Error al actualizar");
            }

        }
    }
}