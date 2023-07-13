using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP_DB_ELECCIONES.Models;

namespace TP_DB_ELECCIONES.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewBag.ListaPartidos = BD.ListarPartidos();
        return View();
    }

    public IActionResult VerDetallePartido(int idPartido)
    {
        ViewBag.DatosPartido = BD.VerInfoPartido(idPartido);
        ViewBag.ListaCandidatos = BD.ListarCandidatos(idPartido);
        return View("VerDetallePartido");
    }
    public IActionResult VerDetalleCandidato(int idCandidato)
    {
        ViewBag.DatosCandidato = BD.VerInfoCandidatos(idCandidato);
        return View("DetalleCandidato");
    }
    //falta esto
    public IActionResult AgregarCandidato(int idPartido)
    {
        ViewBag.idPartido = idPartido;
        return View();
    }

    [HttpPost]
    public IActionResult GuardarCandidato(int idPartido, string Nombre, string Apellido, string FechaNacimiento, string Foto, string Postulacion)
    {
        DateTime FechaNacimientoConv = DateTime.Parse(FechaNacimiento);
        Candidato Can = new Candidato(0, idPartido, Apellido, Nombre, FechaNacimientoConv, Foto, Postulacion);
        BD.AgregarCandidato(Can);
        ViewBag.DatosPartido = BD.VerInfoPartido(idPartido);
        ViewBag.ListaCandidatos = BD.ListarCandidatos(idPartido);
        return View("VerDetallePartido");
    }
    public IActionResult EliminarCandidato(int idCandidato, int idPartido)
    {
        BD.EliminarCandidato(idCandidato);
        ViewBag.DatosPartido = BD.VerInfoPartido(idPartido);
        ViewBag.ListaCandidatos = BD.ListarCandidatos(idPartido);
        return View("VerDetallePartido");
    }
    public IActionResult Elecciones()
    {
        return View();
    }
    public IActionResult Creditos()  
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
