﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
	public class DonorModel
	{
		public int Id { get; set; }
		[Required]
		public string? Name { get; set; }
		[Required]
		public string? Email { get; set; }
		[Required]
		public string? Phone { get; set; }
		[Required]
		public string? BloodGroup { get; set; }
		[Required]
		public string? City { get; set; }
	}
}
