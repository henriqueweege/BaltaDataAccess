﻿using Blog.Models.Base;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Models
{
    [Table("[Post]")]
    public class PostModel
    {
        public PostModel()
        => Tags = new List<TagModel>();

        public int Id { get; set; }
        public string Slug { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Body { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }

        [Write(false)]
        public List<TagModel> Tags { get; set; }

    }
}
