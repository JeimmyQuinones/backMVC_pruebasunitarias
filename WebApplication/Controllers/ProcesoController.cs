using AutoMapper;
using Entity;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class ProcesoController : Controller
    {
        // GET: Proceso
        public ActionResult Index(string Nombre_Usuario)
        {
            if (!String.IsNullOrEmpty(Nombre_Usuario))
            {
                List<Proceso> modellist = Negocioservice.GetProcesosbynombreusuario(Nombre_Usuario);
                var Model = new List<ProcesoListViewModel>();
                foreach (var il in modellist)
                {
                    var Mol = new ProcesoListViewModel();
                    var usuario = Negocioservice.GetUsuario(il.IdUsuario);
                    if (il.procesopadre != null)
                    {
                        var proceso = Negocioservice.GetProceso(il.procesopadre.GetValueOrDefault(0));
                        Mol.Nombreproyectopadre = proceso.nombre;

                    }
                    Mol.procesopadre = il.procesopadre;
                    Mol.IdUsuario = il.IdUsuario;
                    Mol.Idporceso = il.Idporceso;
                    Mol.nombre = il.nombre;
                    Mol.NombreUsuario = usuario.Nombre + " " + usuario.Apellido;
                    Mol.Identificacion = usuario.Cedula;
                    Model.Add(Mol);



                }
                return View(Model);
            }
            else
            {
                List<Proceso> modellist = Negocioservice.GetProcesos();
                var Model = new List<ProcesoListViewModel>();
                foreach (var il in modellist)
                {
                    var Mol = new ProcesoListViewModel();
                    var usuario = Negocioservice.GetUsuario(il.IdUsuario);
                    if (il.procesopadre != null)
                    {
                        var proceso = Negocioservice.GetProceso(il.procesopadre.GetValueOrDefault(0));
                        Mol.Nombreproyectopadre = proceso.nombre;

                    }
                    Mol.procesopadre = il.procesopadre;
                    Mol.IdUsuario = il.IdUsuario;
                    Mol.Idporceso = il.Idporceso;
                    Mol.nombre = il.nombre;
                    Mol.NombreUsuario = usuario.Nombre + " " + usuario.Apellido;
                    Mol.Identificacion = usuario.Cedula;
                    Model.Add(Mol);



                }
                return View(Model);
            }

              
        }

        public ActionResult Edit(int id)
        {
            if (id == -1)
            {
                var mol = new ProcesoAddViewModel();
                var proces = Negocioservice.GetProcesos();
                var usuarios = Negocioservice.GetUsuarios();
                mol.IdUsuario = -1;
                mol.nombre = string.Empty;
                mol.Idporceso = -1;
                mol.procesopadre = -1;
                var ProcesoList = new List<SelectListItem>();
                var UsuarioList = new List<SelectListItem>();
                ProcesoList.Add(new SelectListItem { Value = "-1", Text = "--Seleccione un proceso--", Selected = true });
                UsuarioList.Add(new SelectListItem { Value = "-1", Text = "--Seleccione un Usuario--", Selected = true });
                foreach (var il in proces)
                {
                    ProcesoList.Add(new SelectListItem { Value = il.Idporceso.ToString() , Text = il.nombre });
                }
                foreach (var il in usuarios)
                {
                    var name = il.Nombre + " " + il.Apellido + "-" + il.Cedula;
                    UsuarioList.Add(new SelectListItem { Value = il.IdUsuario.ToString() , Text = name });
                }
                mol.procesos = ProcesoList;
                mol.usuarios = UsuarioList;
                return View(mol);
            }
            else
            {

                Proceso model = Negocioservice.GetProceso(id);
                var mol = new ProcesoAddViewModel();
                var proces = Negocioservice.GetProcesos();
                var usuarios = Negocioservice.GetUsuarios();
                mol.IdUsuario = model.IdUsuario;
                mol.nombre = model.nombre;
                mol.Idporceso = model.Idporceso;
                mol.procesopadre = model.procesopadre;
                var ProcesoList = new List<SelectListItem>();
                var UsuarioList = new List<SelectListItem>();
                ProcesoList.Add(new SelectListItem { Value = "-1", Text = "--Seleccione un proceso--", Selected = true });
                UsuarioList.Add(new SelectListItem { Value = "-1", Text = "--Seleccione un Usuario--", Selected = true });
                foreach (var il in proces)
                {
                    if (il.Idporceso == mol.procesopadre)
                    {
                        ProcesoList.Add(new SelectListItem { Value = il.Idporceso.ToString(), Text = il.nombre  ,Selected = true });
                    }
                    else if(il.Idporceso != mol.Idporceso)
                    {

                        ProcesoList.Add(new SelectListItem { Value = il.Idporceso.ToString(), Text = il.nombre });
                    }
                }
                foreach (var il in usuarios)
                {
                    var name = il.Nombre + " " + il.Apellido + "-" + il.Cedula;
                    if (il.IdUsuario == mol.IdUsuario)
                    {
                        UsuarioList.Add(new SelectListItem { Value = il.IdUsuario.ToString(), Text = name, Selected = true });

                    }
                    else
                    {
                        UsuarioList.Add(new SelectListItem { Value = il.IdUsuario.ToString(), Text = name });

                    }
                }
                mol.procesos = ProcesoList;
                mol.usuarios = UsuarioList;
                return View(mol);
            }
        }

        // POST: Proceso/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "IdUsuario,Idporceso,nombre,procesopadre,usuarios,procesos")] ProcesoAddViewModel Model)
        {
            try
            {
                if (Model.IdUsuario!=-1)
                {
                    if (Model.Idporceso != -1)
                    {
                        var mol = new Proceso();
                        mol.IdUsuario = Model.IdUsuario;
                        mol.Idporceso = Model.Idporceso;
                        mol.nombre = Model.nombre;
                        if(Model.procesopadre==-1)
                        {
                            mol.procesopadre = null;
                        }
                        else
                        {

                            mol.procesopadre = Model.procesopadre;
                        }
                        var resul = Negocioservice.SaveProceso(mol);
                    }
                    else
                    {
                        var mol = new Proceso();
                        mol.IdUsuario = Model.IdUsuario;
                        mol.Idporceso = Model.Idporceso;
                        mol.nombre = Model.nombre;
                        if (Model.procesopadre == -1)
                        {
                            mol.procesopadre = null;
                        }
                        else
                        {

                            mol.procesopadre = Model.procesopadre;
                        }
                        var resul = Negocioservice.AddProceso(mol);
                    }

                    return RedirectToAction("Index");
                }
                return View(Model);
            }
            catch
            {
                return View(Model);
            }
        }

        // GET: Proceso/Delete/5
        public ActionResult Delete(int id)
        {
            Proceso model = Negocioservice.GetProceso(id);
            if (model != null)
            {
                var resul = Negocioservice.DeleteProceso(id);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }

        }


    }
}
