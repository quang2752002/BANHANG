﻿using System;
using System.Collections.Generic;

namespace BANHANG.Models.EF
{
    public partial class Admin
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
