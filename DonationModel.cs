using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
        public class DonationModel
        {
            public int Id { get; set; }

            [Required]
            public int DonorId { get; set; }

            [Required]
            public DateTime DonationDate { get; set; }

            public int? VolumeML { get; set; }

            public int? StaffId { get; set; }

            public string? Remarks { get; set; }
        }
    }

