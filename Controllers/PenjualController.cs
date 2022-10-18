using Microsoft.AspNetCore.Mvc;
using PALUGADA.API.Datas;
using PALUGADA.API.Datas.Entities;

namespace PALUGADA.API.Controllers;

[ApiController]
[Route("[controller]")]

public class PenjualController : Controller
{
    private readonly IRepository<Penjual> _repoPenjual;
    public PenjualController(IRepository<Penjual> rep) {
        _repoPenjual = rep;
    }
    [HttpGet]
    public IActionResult Product() {
        var jual = _repoPenjual.GetList();
        return Json(jual);
    }
    [HttpPost]
    public IActionResult Create(RequestPenjual jual) {
        var pen = new Penjual() {
            KodeToko = jual.KodeToko,
            NamaToko = jual.NamaToko,
            AlamatToko = jual.AlamatToko,
            IdUser = jual.IdUser,
        };
        _repoPenjual.Add(pen);
        return Created("",pen);
    }

    [HttpGet("{Id}")]
    public IActionResult Detail(int Id) {
        var jual = _repoPenjual.Get(Id);
        return Json(jual);
    }
    [HttpPut("{Id}")]
    public IActionResult Update(int Id, RequestPenjual jual) {
        var pen = _repoPenjual.Get(Id);
            if (pen == null)
            {
                return NotFound();
            }
            pen.KodeToko = jual.KodeToko;
            pen.NamaToko = jual.NamaToko;
            pen.AlamatToko = jual.AlamatToko;
            pen.IdUser = jual.IdUser;
            _repoPenjual.Update(pen);
            return Ok(pen);
    }

    [HttpDelete("{Id}")]
    public IActionResult Delete(int Id) {
        _repoPenjual.Remove(Id);
        return Ok();

    }
}