
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Tarea_2
{
    public class RolesBLL
    {

        public static bool Guardar(Roles roles)
        {
            if(!Existe(roles.RolId))
                return Insertar(roles);
            else
                return Modificar(roles);

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