using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace desafioDIO.Models{
    public class Tarefa{
        public int Id {get;set;}
        public string Titulo {get;set;}
        public string Descricao {get;set;}
        public DateTime Data {get;set;}
        public StatusTarefa Status {get; set;}
    }

    public enum StatusTarefa{
        Pendente,
        Finalizada
    };
}