using webapiexercise.Models;
namespace webapiexercise.Services;


public class TareaServices:ITareasService{
     public readonly TareasContext _context;   

     public TareaServices( TareasContext context){
        _context=context;
     } 

    public IEnumerable<Tarea> Get()
    {
        return _context.Tareas.Include(p=>p.Categoria);
    }

        public async Task Save(Tarea tarea)
    {
        _context.Add(tarea);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Guid id, Tarea tarea){
        var tareaActual= _context.Tareas.Find(id);

        if(tareaActual !=null){
            tareaActual.Titulo=tarea.Titulo;
            tareaActual.Descripcion=tarea.Descripcion;
            tareaActual.PrioridadTarea=tarea.PrioridadTarea;
            tareaActual.CategoriaId=tarea.CategoriaId;
            tareaActual.estado=tarea.estado;

            await _context.SaveChangesAsync();
        }  
    }

        public async Task Delete(Guid id){
        var tareaActual= _context.Tareas.Find(id);

        if(tareaActual !=null){
            _context.Remove(tareaActual);
            await _context.SaveChangesAsync();
        }  
    }
}

public interface ITareasService{
    IEnumerable<Tarea> Get();
    Task Save(Tarea categoria);
    Task Update(Guid id, Tarea categoria);
    Task Delete(Guid id);
}