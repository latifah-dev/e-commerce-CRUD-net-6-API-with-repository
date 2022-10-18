using Microsoft.AspNetCore.Mvc;
using PALUGADA.API.Datas;
using PALUGADA.API.Datas.Entities;

namespace PALUGADA.API.Controllers;

[ApiController]
[Route("[controller]")]

public class BarangController : Controller
{
    private readonly IRepository<Barang> _repoBarang;
    public BarangController(IRepository<Barang> rep) {
        _repoBarang = rep;
    }
    [HttpGet]
    public IActionResult Product() {
        var Bar = _repoBarang.GetList();
        return Json(Bar);
    }
    [HttpPost]
    public IActionResult Create(RequestBarang bar) {
        var barang = new Barang() {
            KodeBarang = bar.KodeBarang,
            NamaBarang = bar.NamaBarang,
            JenisBarang = bar.JenisBarang,
            HargaBarang = bar.HargaBarang,
            StokBarang = bar.StokBarang,
            DeskripsiBarang = bar.DeskripsiBarang,
            GambarBarang = bar.GambarBarang,
            IdPenjual = bar.IdPenjual,
        };
        _repoBarang.Add(barang);
        return Created("",barang);
    }

    [HttpGet("{Id}")]
    public IActionResult Detail(int Id) {
        var Bar = _repoBarang.Get(Id);
        return Json(Bar);
    }
    [HttpPut("{Id}")]
    public IActionResult Update(int Id, RequestBarang bar) {
        var Barangs = _repoBarang.Get(Id);
            if (Barangs == null)
            {
                return NotFound();
            }
            Barangs.KodeBarang = bar.KodeBarang;
            Barangs.NamaBarang = bar.NamaBarang;
            Barangs.JenisBarang = bar.JenisBarang;
            Barangs.HargaBarang = bar.HargaBarang;
            Barangs.StokBarang = bar.StokBarang;
            Barangs.DeskripsiBarang = bar.DeskripsiBarang;
            Barangs.GambarBarang = bar.GambarBarang;
            Barangs.IdPenjual = bar.IdPenjual;
            _repoBarang.Update(Barangs);
            return Ok(Barangs);
    }

    [HttpDelete("{Id}")]
    public IActionResult Delete(int Id) {
        _repoBarang.Remove(Id);
        return Ok();

    }
}