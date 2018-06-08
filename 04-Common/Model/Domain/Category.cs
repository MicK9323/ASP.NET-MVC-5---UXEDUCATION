using Common.CustomFilters;
using Model.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class Category : AuditEntity, ISoftDeleted
    {
        //Atributos
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; } // Identificador de pagina
        public string Icon { get; set; }
        public bool Deleted { get; set; }
    }
}
