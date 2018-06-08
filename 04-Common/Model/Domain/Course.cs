using Common;
using Common.CustomFilters;
using Model.Auth;
using Model.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class Course : AuditEntity, ISoftDeleted
    {
        //Atributos
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; } //Identificador de pagina
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image1 { get; set; }// Imagen en tamaño original
        public string Image2 { get; set; }// Imagen en formato reducido
        public Enums.Status Status { get; set; } // Estados del curso segun politica
        public decimal Vote { get; set; }
        public bool Deleted { get; set; }
        //Relaciones
        public Category Category { get; set; }
        public int CategoryId { get; set; }

        public ICollection<LessonPerCourse> Lessons { get; set; }

        [ForeignKey("AuthorId")]
        public ApplicationUser Author { get; set; }
        public string AuthorId { get; set; }
    }
}
