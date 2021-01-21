using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ServiceData
    {
        #region Procesos
        public List<Proceso> GetProcesos()
        {
            AplicactionDbContext db = new AplicactionDbContext();
            return db.Proceso.ToList();
        }
        public Proceso GetProceso(int id)
        {
            AplicactionDbContext db = new AplicactionDbContext();
            return db.Proceso.FirstOrDefault(x => x.Idporceso == id);
        }
        public string AddProceso(Proceso model)
        {
            AplicactionDbContext db = new AplicactionDbContext();
            try
            {
                db.Proceso.Add(model);
                db.SaveChanges();
                return "OK";
            }
            catch (Exception e)
            {
                return "Error al agregar el Proceso";
            }

        }
        public string SaveProceso(Proceso proces)
        {
            AplicactionDbContext db = new AplicactionDbContext();
            var model = db.Proceso.FirstOrDefault(x => x.IdUsuario == proces.IdUsuario);
            if (model != null)
            {
                try
                {
                    model.IdUsuario = proces.IdUsuario;
                    model.nombre = proces.nombre;
                    model.procesopadre = proces.procesopadre;
                    db.SaveChanges();
                    return "OK";
                }
                catch (Exception e)
                {
                    return "Error al guardar los cambios";
                }
            }
            else
            {
                return "Proceso no encontrado";
            }
        }
        public string DeleteProceso(int id)
        {
            AplicactionDbContext db = new AplicactionDbContext();
            var model = db.Proceso.FirstOrDefault(x => x.Idporceso == id);
            if (model != null)
            {
                try
                {
                    db.Proceso.Remove(model);
                    db.SaveChanges();
                    return "OK";
                }
                catch (Exception e)
                {
                    return "Error al eliminar el Proceso";
                }
            }
            else
            {
                return "Proceso no encontrado";
            }


        }
        #endregion

        #region Usuarios

        public List<Usuario> GetUsuarios()
        {
            AplicactionDbContext db = new AplicactionDbContext();
            return db.Usuario.ToList();
        }
        public Usuario GetUsuario(int id)
        {
            AplicactionDbContext db = new AplicactionDbContext();
            return db.Usuario.FirstOrDefault(x => x.IdUsuario == id);
        }
        public string AddUsuario(Usuario user)
        {
            AplicactionDbContext db = new AplicactionDbContext();
            try
            {
                db.Usuario.Add(user);
                db.SaveChanges();
                return "OK";
            }
            catch (Exception e)
            {
                return "Error al agregar el usuario";
            }

        }
        public string SaveUsuario(Usuario user)
        {
            AplicactionDbContext db = new AplicactionDbContext();
            var model = db.Usuario.FirstOrDefault(x => x.IdUsuario == user.IdUsuario);
            if (model != null)
            {
                try
                {
                    model.Nombre = user.Nombre;
                    model.Email = user.Email;
                    model.Apellido = user.Apellido;
                    model.Cedula = user.Cedula;
                    db.SaveChanges();
                    return "OK";
                }
                catch (Exception e)
                {
                    return "Error al guardar los cambios";
                }
            }
            else
            {
                return "Usuario no encontrado";
            }
        }
        public string DeleteUsuario(int id)
        {
            AplicactionDbContext db = new AplicactionDbContext();
            var model = db.Usuario.FirstOrDefault(x => x.IdUsuario == id);
            if (model != null)
            {
                try
                {
                    db.Usuario.Remove(model);
                    db.SaveChanges();
                    return "OK";
                }
                catch (Exception e)
                {
                    return "Error al eliminar el usuario";
                }
            }
            else
            {
                return "Usuario no encontrado";
            }


        }
        #endregion
    }
}
