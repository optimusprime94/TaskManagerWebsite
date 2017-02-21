﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Http;

namespace TaskManagerWebsite.Model
{
    public class TaskDto
    {
        
        public int TaskId { get; set; }

        public string BeginDateTime { get; set; }

        public string DeadlineDateTime { get; set; }

        public string Title { get; set; }

        public string Requirements { get; set; }

    }

}
