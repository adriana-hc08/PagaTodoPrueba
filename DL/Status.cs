using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class Status
    {
        [Key]
        public int IdStatus { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Nombre { get; set; }
        public virtual ICollection<Tarea>? Tareas { get; set; } = new List<Tarea>();
    }
}
