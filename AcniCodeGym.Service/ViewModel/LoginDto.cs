﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcniCodeGym.Service.ViewModel
{
    public class LoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Recordar { get; set; }
    }
}
