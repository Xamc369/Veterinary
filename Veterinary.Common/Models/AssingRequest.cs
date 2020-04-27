using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Veterinary.Common.Models
{
    public class AssingRequest
    {
        [Required]
        public int AgendaId { get; set; }

        [Required]
        public int OwnerId { get; set; }

        [Required]
        public int PetId { get; set; }

        public string Remarks { get; set; }

    }
}
