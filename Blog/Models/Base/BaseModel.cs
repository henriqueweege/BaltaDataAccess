﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Models.Base
{
    public abstract class BaseModel
    {
        public int Id { get; set; }
        public string Slug { get; set; }
        public string Name { get; set; }
    }
}
