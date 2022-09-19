﻿using System;
using System.Collections.Generic;

namespace API_M3_V5.Models
{
    public partial class Administrator
    {
        public int AdminId { get; set; }
        public int PersonId { get; set; }
        public string Username { get; set; } = null!;

        public virtual Person Person { get; set; } = null!;
    }
}
