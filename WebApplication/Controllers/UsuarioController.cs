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
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            List<Usuario> modellist = Negocioservice.GetUsuarios();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Usuario, UsuarioViewModel>());
            var mapper = config.CreateMapper();
            var lstVm = modellist.Select(itm => mapper.Map<UsuarioViewModel>(itm)).ToList();
            return View(lstVm);
        }
        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == -1)
            {
                var mol = new UsuarioViewModel();
                mol.IdUsuario = -1;
                mol.Nombre = string.Empty;
                mol.Apellido = string.Empty;
                mol.Email = string.Empty;
                mol.Cedula = null;
                return View(mol);
            }
            else
            {

                Usuario model = Negocioservice.GetUsuario(id);
                var mol = new UsuarioViewModel();
                mol.IdUsuario = model.IdUsuario;
                mol.Nombre = model.Nombre;
                mol.Apellido = model.Apellido;
                mol.Email = model.Email;
                mol.Cedula = model.Cedula;
                return View(mol);
            }
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdUsuario,Nombre,Apellido,Email,Cedula")]UsuarioViewModel Model)
        {
           
            try
            {
                if (ModelState.IsValid)
                {
                    if (Model.IdUsuario != -1)
                    {
                        var mol = new Usuario();
                        mol.IdUsuario = Model.IdUsuario;
                        mol.Nombre = Model.Nombre;
                        mol.Apellido = Model.Apellido;
                        mol.Email = Model.Email;
                        mol.Cedula = Model.Cedula.GetValueOrDefault();
                        var resul = Negocioservice.SaveUsuario(mol);
                    }
                    else
                    {
                        var mol = new Usuario();
                        mol.IdUsuario = Model.IdUsuario;
                        mol.Nombre = Model.Nombre;
                        mol.Apellido = Model.Apellido;
                        mol.Email = Model.Email;
                        mol.Cedula = Model.Cedula.GetValueOrDefault();
                        var resul = Negocioservice.AddUsuario(mol);
                    }

                    return RedirectToAction("Index");
                }
                return View(Model);
                // TODO: Add update logic here

            }
            catch
            {
                return View(Model);
            }
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            Usuario model = Negocioservice.GetUsuario(id);
            if (model != null)
            {
                var resul = Negocioservice.DeleteUsuario(id);
                return RedirectToAction(this.Url.Action("Index", "Usuario"));
            }
            else
            {
                return RedirectToAction(this.Url.Action("Index", "Usuario"));
            }
            
        }

    }
}
