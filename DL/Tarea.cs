using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public partial class Tarea
    {
        [Key]
        public int IdTarea { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        public int? IdStatus { get; set; }
        public DateTime CreationDate{ get; set; }

        public virtual Status? IdStatusNavigation { get; set; }
    }
}
