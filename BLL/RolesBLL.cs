
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;


using Tarea_2.DAL;
using Tarea_2.Entidades;

namespace Tarea_2.BLL
{
    public class RolesBLL
    {

        public static bool Guardar(Roles roles)
        {
            if(!Existe(roles.RolId))
                return Insertar(roles);
            return false;
        }
        public static bool Insertar(Roles roles)
        {
            bool paso = false;
            using (var contexto = new Contexto())
            {
                contexto.Roles.Add(roles);
                paso = contexto.SaveChanges() > 0;
            }

            return paso;
        }

        public static bool Modificar(Roles roles)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(roles).State = EntityState.Modified;
                paso = contexto.SaveChanges () > 0;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var roles = contexto.Roles.Find(id);

                if(roles != null)
                {
                    contexto.Roles.Remove(roles);
                    paso = contexto.SaveChanges() > 0;

                }
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static List<Roles> GetLista()
        {
            using (var contexto = new Contexto())
            {
                return contexto.Roles.ToList();
            }
        }

        public static List<Roles> GetLista(Expression<Func<Roles, bool>> criterio)
        {
            List<Roles> lista = new List<Roles>();

            Contexto contexto = new Contexto();

            try
            {

                lista = contexto.Roles.Where(criterio).ToList();
                
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }

        public static Roles Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Roles roles;

            try
            {
                roles = contexto.Roles.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return roles;
        }
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Roles.Any(e => e.RolId == id);
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;

        }

        public static bool ExisteRolDescripcion(string roldescripcion)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Roles.Any(e => e.Descripcion == roldescripcion);
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;

        }

    }
}