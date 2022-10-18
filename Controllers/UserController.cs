using Microsoft.AspNetCore.Mvc;
using PALUGADA.API.Datas;
using PALUGADA.API.Datas.Entities;

namespace PALUGADA.API.Controllers;

[ApiController]
[Route("[controller]")]

public class UserController : Controller
{
    private readonly IRepository<User> _repoUser;
    public UserController(IRepository<User> repo) {
        _repoUser = repo;
    }
    [HttpGet]
    public IActionResult Product() {
        var jual = _repoUser.GetList();
        return Json(jual);
    }
    [HttpPost]
    public IActionResult Create(RequestUser jual) {
        var pen = new User() {
            Username = jual.Username,
            Password = jual.Password,
            NohpUser = jual.NohpUser,
            TipeUser = jual.TipeUser,
            EmailUser = jual.EmailUser,
        };
        _repoUser.Add(pen);
        return Created("",pen);
    }

    [HttpGet("{Id}")]
    public IActionResult Detail(int Id) {
        var jual = _repoUser.Get(Id);
        return Json(jual);
    }
    [HttpPut("{Id}")]
    public IActionResult Update(int Id, RequestUser jual) {
        var pen = _repoUser.Get(Id);
            if (pen == null)
            {
                return NotFound();
            }
            pen.Username = jual.Username;
            pen.Password = jual.Password;
            pen.NohpUser = jual.NohpUser;
            pen.TipeUser = jual.TipeUser;
            pen.EmailUser = jual.EmailUser;
            _repoUser.Update(pen);
            return Ok(pen); 
    }

    [HttpDelete("{Id}")]
    public IActionResult Delete(int Id) {
        _repoUser.Remove(Id);
        return Ok();

    }
}