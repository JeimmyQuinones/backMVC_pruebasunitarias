using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Negocioservice
    {
        #region Proceso
        public static List<Proceso> GetProcesos()
        {
            ServiceData data = new ServiceData();
            return data.GetProcesos();
        }
      
        public static Proceso GetProceso(int id)
        {
            ServiceData data = new ServiceData();
            return data.GetProceso(id);
        }
        public static List<Proceso> GetProcesosbynombreusuario(string nombreusuario)
        {
            ServiceData data = new ServiceData();
            return data.GetProcesosbynombreusuario(nombreusuario);
        }
        public static string AddProceso(Proceso model)
        {
            ServiceData data = new ServiceData();
            return data.AddProceso(model);

        }
        public static string SaveProceso(Proceso model)
        {
            ServiceData data = new ServiceData();
            return data.SaveProceso(model);
        }
        public static string DeleteProceso(int id)
        {
            ServiceData data = new ServiceData();
            return data.DeleteProceso(id);
        }
        #endregion

        #region Usuarios
        public static List<Usuario> GetUsuarios()
        {
            ServiceData data = new ServiceData();
            return data.GetUsuarios();
        }
        public static List<Usuario> GetUsuariobyApellido(string Apellido)
        {
            ServiceData data = new ServiceData();
            return data.GetUsuariobyApellido(Apellido);
        }
        public static Usuario GetUsuario(int id)
        {
            ServiceData data = new ServiceData();
            return data.GetUsuario(id);
        }
        public static string AddUsuario(Usuario user)
        {
            ServiceData data = new ServiceData();
            return data.AddUsuario(user);

        }
        public static string SaveUsuario(Usuario user)
        {
            ServiceData data = new ServiceData();
            return data.SaveUsuario(user);
        }
        public static string DeleteUsuario(int id)
        {
            ServiceData data = new ServiceData();
            return data.DeleteUsuario(id);
        }
        #endregion
    }
}
