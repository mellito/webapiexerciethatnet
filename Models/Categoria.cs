namespace webapiexercise.Models;
using System.Text.Json.Serialization;
public class Categoria
{
   // [Key]
    public Guid CategoriaId { get; set; }
   // [Required]
   // [MaxLength(150)]
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public int peso {get;set;}
    [JsonIgnore]
    public virtual ICollection<Tarea> Tareas { get; set; }
}