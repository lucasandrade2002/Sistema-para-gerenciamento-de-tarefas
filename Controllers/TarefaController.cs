using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using desafioDIO.Models;
using desafioDIO.Context;

namespace desafioDIO.Controllers{

    [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase{
        private readonly DbTarefasContext _instanceDb;
        public TarefaController(DbTarefasContext instaceDb){
            _instanceDb = instaceDb;
        }

        [HttpGet("ObterTodos")]
        public IActionResult getAll(){

            var tarefas = _instanceDb.Tarefas.ToList();
            return Ok(tarefas);
        }

        [HttpGet("{id}")]
        public IActionResult getById(int id){

            var tarefa = _instanceDb.Tarefas.Find(id);
            
            if(tarefa == null)
                return NotFound();
            else
                return Ok(tarefa);
        }

        [HttpGet("ObterPorTitulo")]
        public IActionResult getByTitle(string titulo){

            var tarefaDb = _instanceDb.Tarefas.Where(t => t.Titulo.Contains(titulo));

            if(tarefaDb == null){
                throw new NullReferenceException("Contato não existe!");
            }

            return Ok(tarefaDb);
        }

        [HttpGet("ObterPorData")]
        public IActionResult getByData(DateTime data){

            var tarefaDb = _instanceDb.Tarefas.Where(t => t.Data.Equals(data));

            if(tarefaDb == null)
                return NotFound();
            else
                return Ok(tarefaDb);
        }

        [HttpGet("ObterPorStatus")]
        public IActionResult getByStatus(StatusTarefa statusCode){

            var tarefaDb = _instanceDb.Tarefas.Where(t => t.Status == statusCode);

            if(tarefaDb == null)
                return NotFound();
            else
                return Ok(tarefaDb);
        }

        [HttpPost]
        public IActionResult AddTarefa(Tarefa newTarefa){

            _instanceDb.Tarefas.Add(newTarefa);
            _instanceDb.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult updateTarefa(int id, Tarefa newTarefa){

            var tarefaDb = _instanceDb.Tarefas.Find(id);

            if(tarefaDb == null)
                return NotFound();
            else
                tarefaDb.Titulo = newTarefa.Titulo;
                tarefaDb.Descricao = newTarefa.Descricao;
                tarefaDb.Data = newTarefa.Data;
                tarefaDb.Status = newTarefa.Status;

                _instanceDb.Tarefas.Update(tarefaDb);
                _instanceDb.SaveChanges();

                return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult deleteTarefa(int id){

            var tarefaDb = _instanceDb.Tarefas.Find(id);

            if(tarefaDb == null)
                return NotFound();
            else
                _instanceDb.Tarefas.Remove(tarefaDb);
                _instanceDb.SaveChanges();

            return Ok(new {
                Mensagem = "Tarefa deletada com sucesso!"
            });
        }
    }
}