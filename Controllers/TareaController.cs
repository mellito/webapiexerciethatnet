using Microsoft.AspNetCore.Mvc;
using webapiexercise.Services;
using webapiexercise.Models;
namespace webapiexercise.Controllers;


[ApiController]
[Route("api/[controller]")]

public class TareaCOntroller:ControllerBase{
    private readonly ITareasService _tarea;

    public TareaCOntroller(ITareasService tarea){
        _tarea=tarea;
    }
    [HttpGet]
    public IActionResult Get(){
        List<Tarea> allTarea=_tarea.Get().ToList();
        return Ok(allTarea);
    }
    [HttpPost]
    public IActionResult Post([FromBody] Tarea tarea){
        _tarea.Save(tarea);
        return Ok();
    }
    [HttpPut("{id}")]   
    public IActionResult Update([FromBody] Tarea tarea,[FromRoute] Guid id){
        _tarea.Update(id,tarea);
        return Ok();
    }
    [HttpDelete("{id}")]  
    public IActionResult Delete([FromRoute] Guid id){
        _tarea.Delete(id);
        return Ok();
    }
}