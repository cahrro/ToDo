using Microsoft.AspNetCore.Mvc;
using ToDo.Context;
using ToDo.Models;

namespace ToDo.Controllers
{
    public class TodoController : Controller
    {
        private readonly TodoContexts _context;

        public TodoController(TodoContexts context) //serve para gerenciamento de dados o que permite operações 
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewData["title"] = "Lista de Tarefas";
            //var todo = _context.Todos.First(); //pega a primeira tarefa do banco dedados
            var todos = _context.Todos.ToList(); //transforma em lista os itens no banco de dados
            return View(todos);
        }

        public IActionResult Create() //exibe
        {
            ViewData["Title"] = "Nova Tarefa";
            return View("Form");
        }

        [HttpPost] //Avisa que o que vai ser enviado com o metodo post. o padrao é get
        public IActionResult Create(Todo todo) //recebe os dados e salva no banco
        {
            if (ModelState.IsValid)
            {
                todo.CriadoEm = DateTime.Now;
                _context.Todos.Add(todo); //Adiciona na tabela a variavel todo
                _context.SaveChanges(); //salva 
                return RedirectToAction(nameof(Index)); //redireciona para o index
            }
            ViewData["Title"] = "Nova Tarefa";
            return View("Form",todo);
           
        }

        public IActionResult Edit(int id) {
            var todo = _context.Todos.Find(id); // busca o id no banco
            if (todo == null)
            {
                return NotFound();
            }
            ViewData["Title"] = "Editar Tarefa";
            return View("Form", todo);
        }

        [HttpPost]
        public IActionResult Edit(Todo todo)
        {
            if (ModelState.IsValid)
            {
                _context.Todos.Attach(todo);

                _context.Todos.Update(todo);
                _context.Entry(todo).Property(X => X.CriadoEm).IsModified = false;
                _context.Entry(todo).Property(X => X.FinalizadoEm).IsModified = false;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Title"] = "Editar Tarefa";
            return View("Form", todo);
            
        }

        public IActionResult Delete(int id)
        {
            var todo = _context.Todos.Find(id);
            if (todo == null)
            {
                return NotFound();
            }
            ViewData["Title"] = "Excluir Tarefa";
            return View(todo);
        }

        [HttpPost]
        public IActionResult Delete(Todo todo)
        {
            _context.Todos.Remove(todo);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Finish(int id)
        {
   
            var todo = _context.Todos.Find(id);
            if (todo == null)
            {
                return NotFound();
            }
            todo.Finish();
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
