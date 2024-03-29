﻿using ASPdotNetDesign.Models;
using ASPdotNetDesign.Models.Account;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace ASPdotNetDesign.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<StudentInfo> StudentInfoes { get; set; }
        public DbSet<NewImage> NewImages { get; set; }
        public DbSet<User> Users { get; set; }


    }
}
