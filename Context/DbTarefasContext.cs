using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using desafioDIO.Models;

namespace desafioDIO.Context{
    public class DbTarefasContext : DbContext{
        public DbSet<Tarefa> Tarefas {get; set;}
        public DbTarefasContext(DbContextOptions<DbTarefasContext> options):base(options){
            
        }
    }
}