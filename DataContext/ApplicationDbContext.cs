﻿using Microsoft.EntityFrameworkCore;
using WebApiFuncionarios.Model;

namespace WebApiFuncionarios.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

        public DbSet<FuncionarioModel> Funcionarios { get; set; }
    }

   
}
