﻿using Almacen.Clases.Administracion;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema
{
    public class AlmacenContext: DbContext
    {
        public AlmacenContext() 
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=HWNOTE163490\SQLEXPRESS;Initial Catalog=Almacen;Integrated Security=True;Connect Timeout=30;Encrypt=False");
        }
    }
}