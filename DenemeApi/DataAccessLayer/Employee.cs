﻿using System.ComponentModel.DataAnnotations;

namespace DenemeApi.DataAccessLayer
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
