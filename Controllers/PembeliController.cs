using Microsoft.AspNetCore.Mvc;
using PALUGADA.API.Datas;
using PALUGADA.API.Datas.Entities;

namespace PALUGADA.API.Controllers;

[ApiController]
[Route("[controller]")]

public class PembeliController : Controller
{
    private readonly IRepository<Pembeli> _repoPembeli;
    public PembeliController(IRepository<Pembeli> rep) {
        _repoPembeli = rep;
    }
    [HttpGet]
    public IActionResult Product() {
        var datas = _repoPembeli.GetList();
        return Json(datas);
    }
    [HttpPost]
    public IActionResult Create(RequestPembeli beli) {
        var pembeli=_repoPembeli.GetList().LastOrDefault();
        var pen = new Pembeli() {
            NamaPembeli = beli.NamaPembeli,
            AlamatPembeli = beli.AlamatPembeli,
            NotelpPembeli = beli.NotelpPembeli,
            NegaraPembeli =  beli.NegaraPembeli,
            IdUser = beli.IdUser,
            IdPembeli= (pembeli?.IdPembeli??0)+1
        };
        _repoPembeli.Add(pen);
        return Created("",pen);
    }

    [HttpGet("{Id}")]
    public IActionResult Detail(int Id) {
        var detail = _repoPembeli.Get(Id);
        return Json(detail);
    }
    [HttpPut("{Id}")]
    public IActionResult Update(int Id, RequestPembeli jual) {
        var pen = _repoPembeli.Get(Id);
            if (pen == null)
            {
                return NotFound();
            }
            pen.NamaPembeli = jual.NamaPembeli;
            pen.AlamatPembeli = jual.AlamatPembeli;
            pen.NotelpPembeli = jual.NotelpPembeli;
            pen.NegaraPembeli = jual.NegaraPembeli;
            pen.IdUser = jual.IdUser;

            _repoPembeli.Update(pen);
            return Ok(pen);
    }
    [HttpDelete("{Id}")]
    public IActionResult Delete(int Id) {
        _repoPembeli.Remove(Id);
        return Ok();
    }
}