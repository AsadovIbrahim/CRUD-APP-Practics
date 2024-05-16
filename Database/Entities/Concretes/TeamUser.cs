using Database.Entities.Abstracts;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entities.Concretes
{
    public class TeamUser:Entity
    {
        public string FullName { get; set; }
        public string Position { get; set; }
        public string ?ImageUrl { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
