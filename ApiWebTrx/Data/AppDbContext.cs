﻿using ApiWebTrx.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiWebTrx.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options ) : base(options)
        { }
            
        public DbSet<ProdutoModel> Produtos { get; set; }   
    }
}
