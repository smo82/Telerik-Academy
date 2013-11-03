﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models
{
    public class ApplicationUser : User
    {
        private int points;

        public ApplicationUser()
        {
            this.points = 10;
        }
        public virtual int Points
        {
            get
            {
                return this.points;
            }
            set
            {
                this.points = value;
            }
        }
    }
}
