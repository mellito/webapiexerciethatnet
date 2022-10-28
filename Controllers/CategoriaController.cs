using Microsoft.AspNetCore.Mvc;
using webapiexercise.Services;
using webapiexercise.Models;
namespace webapiexercise.Controllers;

[ApiController]
[Route("api/[controller]")]

public class CategoriaController: ControllerBase{
    private readonly ICategoriaServices _Categoria;

    public CategoriaController(ICategoriaServices categoria){
        _Categoria=categoria;
    }

    [HttpGet]
    public IActionResult Get(){
        List<Categoria> allCategoria=_Categoria.Get().ToList();
        return Ok(allCategoria);
    }
    [HttpPost]
    public IActionResult Post([FromBody] Categoria categoria){
        _Categoria.Save(categoria);
        return Ok();
    }
    [HttpPut("{id}")]   
    public IActionResult Update([FromBody] Categoria categoria,[FromRoute] Guid id){
        _Categoria.Update(id,categoria);
        return Ok();
    }
    [HttpDelete("{id}")]  
    public IActionResult Delete([FromRoute] Guid id){
        _Categoria.Delete(id);
        return Ok();
    }
}