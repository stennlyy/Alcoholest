using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Alcoholest.Areas.Administration.Models.InputModels
{
    public class RoleInputModel
    {
        [Required]
        public string Name { get; set; }

        public string NormalizedName => Name.ToUpperInvariant();
    }
}
