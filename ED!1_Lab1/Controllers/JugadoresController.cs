using ED_1_Lab1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ED_1_Lab1.Controllers
{
    public class JugadoresController : Controller
    {
        public static List<Jugador> GuardandoJugador = new List<Jugador>();
        public static bool Ordenamiento = false;


        // GET: Jugadores
        public ActionResult Index()
        {
            return View(GuardandoJugador);
        }

        // GET: Jugadores/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Jugadores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jugadores/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                var NuevoJugador = new Jugador
                {
                    Nombre = collection["Nombre"],
                    Apellido = collection["Apellido"],
                    Posicion = collection["Posicion"],
                    Salario = collection["Salario"]


                };

                GuardandoJugador.Add(NuevoJugador);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: Usuario/Create
        public ActionResult Lista()
        {
            if (Ordenamiento)
            {
                //ordenar por nombre
                GuardandoJugador.Sort((x, y) => x.Nombre.CompareTo(y.Nombre));

            }
            else
            {
                //ordenar por apellido
                GuardandoJugador.Sort((x, y) => x.Apellido.CompareTo(y.Apellido));

            }
            return View(GuardandoJugador);
        }

        // GET: Jugadores/Edit/5
        public ActionResult Edit(string id)
        {
            return View();
        }

        // POST: Jugadores/Edit/5
        [HttpPost]
        public ActionResult Edit(string  id, FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                var editado = new Jugador()
                {
                    Nombre = collection["Nombre"],
                    Apellido = collection["Apellido"],
                    Club = collection["Club"],
                    Salario = collection["Salario"],
                    Posicion = collection["Posicion"]

                };
                var contador = 0;
                foreach (var item in GuardandoJugador)
                {
                    if (item.Nombre == id)
                    {
                        GuardandoJugador[contador] = editado;
                       // GuardandoJugador.Remove(GuardandoJugador[contador]);
                    }
                    else
                    {
                        contador++;
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Jugadores/Delete/5
        public ActionResult Delete(string id)
        {
            return View();
        }

        // POST: Jugadores/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var eliminado = new Jugador()
                {
                    Nombre = collection["Nombre"],
                    Apellido = collection["Apellido"],
                    Club = collection["Club"],
                    Salario = collection["Salario"],
                    Posicion = collection["Posicion"]

                };
                var contador = 0;
                foreach (var item in GuardandoJugador)
                {
                    if (item.Nombre == id)
                    {
                        GuardandoJugador.Remove(GuardandoJugador[contador]);
                    }
                    else
                    {
                        contador++;
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
