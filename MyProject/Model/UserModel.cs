﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyProject.Model
{
    public class UserModel
    {

        Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}