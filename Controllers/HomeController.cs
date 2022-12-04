using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using ToDoList.Models;
using ToDoList.Models.Repo;
using ToDoList.Models.ViewModels;


namespace ToDoList.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IToDoMenu _menu;
        private readonly ITaskRepository _taskRepository;
        private readonly string MyMsg = "dafault message";
        public HomeController(ILogger<HomeController> logger,  IToDoMenu menu, ITaskRepository taskRepository)
        {
            _logger = logger;
            _menu = menu;
            _taskRepository = taskRepository;
        }
        public IActionResult Index()
        {
            ViewBag.CurrentRoute = 0;
            ViewData["Title"] = "MY Title";
            ViewBag.MyMessage = "My Menu index ";
            ViewBag.AllButton = "list-group-item list-group-item-action py-2 ripple active";
            ViewBag.SideBarItems = _menu.itemsSideBars;
            var taskObject = new TaskListViewModel() { Tasks = _taskRepository.Tasks.OrderByDescending(p => p.MakingDate), Categories = _taskRepository.Categories };
            return View(taskObject);
        }

        [Route("Home/TaskByCategory/{id?}")]
        public IActionResult TaskByCategory(int? id)
        {
            if (id == 0)
            {
                return Redirect("/");
            }
            ViewBag.CurrentRoute = id;
            ViewBag.message = MyMsg;
            ViewBag.SideBarItems = _menu.itemsSideBars;
            ViewBag.AllButton = "list-group-item list-group-item-action py-2 ripple";
            var Category = _taskRepository.Categories.Where(c => c.Id == id).FirstOrDefault();
            var taskObject = new TaskListViewModel() { Tasks = _taskRepository.Tasks.Where(p => p.TaskCategory == Category.Category).OrderByDescending(p=>p.MakingDate), Categories = _taskRepository.Categories };
            ViewBag.CurrentCategory = Category.Category;
            ViewBag.CurrentCategoryId = id;
            return View(taskObject);
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Title,")] UserTask userTask, int categoryId, string category)
        {
            string route = "TaskByCategory/" + categoryId;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            userTask.MakingDate = DateTime.Now;
            ViewBag.CurrentRoute = categoryId;
            userTask.TaskCategory=category;
            await _taskRepository.AddUserTask(userTask);
            return Redirect(route);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id, int routeId)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            string route = "/Home/TaskByCategory/" + routeId;
            ViewBag.CurrentRoute = routeId;
            await _taskRepository.DeleteUserTask((int)id);
            return Redirect(route);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeTaskStatus(int? id, int routeId)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.CurrentRoute = routeId;
            string route = "/Home/TaskByCategory/" + routeId;

            var result = await _taskRepository.ChangeStatusUserTask((int)id);
            if (result==0)
            {
                ModelState.AddModelError("UserTask.Id", "Incorrect id UserTask");
                return BadRequest(ModelState);
            }
            return Redirect(route);
        }

        [HttpGet,ActionName("Edit")]
        public async Task<IActionResult> EditUserTask(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewBag.SideBarItems = _menu.itemsSideBars;
            UserTask userTask =await _taskRepository.GetUserTask((int)id);

            int routeId = (from n in _menu.itemsSideBars
                           where n.Name == userTask.TaskCategory
                           select n.Id).FirstOrDefault();

            ViewBag.CurrentRoute = routeId;
            if (userTask == null)
            {
                ModelState.AddModelError("UserTask.Id", "Incorrect id UserTask");
                return BadRequest(ModelState);
            }

            var taskObject = new TaskListViewModel() { Tasks = _taskRepository.Tasks, Categories = _taskRepository.Categories,UserTask=userTask };
            return View(taskObject);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUserTaskConfirm(UserTask userTask)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "User task isn't correct.");
                return BadRequest(ModelState);
            }
            int routeId = (from n in _menu.itemsSideBars
                          where n.Name==userTask.TaskCategory
                          select n.Id).FirstOrDefault();
            ViewBag.SideBarItems = _menu.itemsSideBars;
            ViewBag.CurrentRoute = routeId;
            string route = "/Home/TaskByCategory/" + routeId;
            var result = await _taskRepository.EditUserTask(userTask);
            if (result == 0)
            {
                return NotFound();
            }

            return Redirect(route);
        }

        public IActionResult Privacy()
        {
            ViewBag.SideBarItems = _menu.itemsSideBars;
            ViewBag.MyMessage = "MyMenu Privacy ";
            ViewData["Title"] = "My title Privacy";
            ViewData["MyMessege"] = "It is Index test viev data ";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
