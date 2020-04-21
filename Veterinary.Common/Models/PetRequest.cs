using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Veterinary.Common.Models
{
    public class PetRequest
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Race { get; set; }

        public int OwnerId { get; set; }

        public int PetTypeId { get; set; }

        [Required]
        public DateTime Born { get; set; }

        public string Remarks { get; set; }

        public byte[] ImageArray { get; set; }

    }
}
