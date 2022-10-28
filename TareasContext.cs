using webapiexercise.Models;
namespace webapiexercise;

public class TareasContext : DbContext
{
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Tarea> Tareas { get; set; }

    public TareasContext(DbContextOptions<TareasContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        List<Categoria> categoriasInit=new();
        categoriasInit.Add(new Categoria{
            CategoriaId=Guid.Parse("35452ec1-73dc-4c96-aaec-bf88f27b8d1a"),
            Nombre="Actividades Pendientes",
            Descripcion="activdad 1",
            peso=20
        });
        categoriasInit.Add(new Categoria{
            CategoriaId=Guid.Parse("35452ec1-73dc-4c96-aaec-bf88f27b8d02"),
            Nombre="Actividades Personales",
              Descripcion="activdad 2",
            peso=50
        });
        modelBuilder.Entity<Categoria>(categoria=>
        {
            categoria.ToTable("Categoria");
            categoria.HasKey(p=>p.CategoriaId);
            categoria.Property(p=>p.Nombre).IsRequired().HasMaxLength(150);
            categoria.Property(p=>p.Descripcion);
            categoria.Property(p=>p.peso);
            categoria.HasData(categoriasInit);
        });

        List<Tarea> tareasInit =new();
            tareasInit.Add(new Tarea{
            TareaId=Guid.Parse("35452ec1-73dc-4c96-aaec-bf88f27b8d34"),
            CategoriaId=Guid.Parse("35452ec1-73dc-4c96-aaec-bf88f27b8d02"),
            Titulo="Banarme",
            Descripcion="Huelo feo",
            PrioridadTarea=Prioridad.media,
            FechaCreacion=DateTime.Now.ToLocalTime(),
            estado=false
        });
            tareasInit.Add(new Tarea{
            TareaId=Guid.Parse("35452ec1-73dc-4c96-aaec-bf88f27b8d35"),
            CategoriaId=Guid.Parse("35452ec1-73dc-4c96-aaec-bf88f27b8d02"),
            Titulo="Pagar servicios",
            Descripcion="pagar los servicios o me los cortan",
            PrioridadTarea=Prioridad.alta,
            FechaCreacion=DateTime.Now.ToLocalTime(),
            estado=true
        });
             modelBuilder.Entity<Tarea>(tarea=>
        {
            tarea.ToTable("Tarea");
            tarea.HasKey(p=>p.TareaId);
            tarea.HasOne(p=> p.Categoria).WithMany(p=> p.Tareas).HasForeignKey(p=>p.CategoriaId);
            tarea.Property(p=>p.Titulo).IsRequired().HasMaxLength(200);
            tarea.Property(p=>p.Descripcion);
            tarea.Property(p=>p.PrioridadTarea);
            tarea.Property(p=>p.FechaCreacion);
            tarea.Ignore(p=>p.Resumen);
            tarea.Property(p=> p.estado);
            tarea.HasData(tareasInit);
        });
        
    }
}