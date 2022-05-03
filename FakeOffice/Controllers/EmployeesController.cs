using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FakeOffice.Services.Interfaces;
using FakeOffice.ViewModels;
using FakeOffice.Models;

namespace FakeOffice.Controllers;

    [Authorize(Roles = "Admin")]

public class EmployeesController : Controller
{ 
        private readonly ILogger<EmployeesController> _logger;
        private readonly IEmployeesStore _EmployeesStore;

        public EmployeesController(ILogger<EmployeesController> logger, IEmployeesStore EmployeesStore)
        {
            _EmployeesStore = EmployeesStore;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var employees = _EmployeesStore.GetAll();  
            return View(employees);
        }

        public IActionResult Details( int id)
        {
            var employee = _EmployeesStore.GetById(id); 
            if (employee is null) return NotFound();

        return View(new EmployeesViewModel
        {
            Id = employee.Id,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Patronymic = employee.Patronymic,
            Birthday = employee.Birthday,
        });
    }

    [HttpPost]
    public IActionResult Edit (EmployeesViewModel Model)
    {
        var employee = new Employee
        {
            Id = Model.Id,
            FirstName = Model.FirstName,    
            LastName = Model.LastName,  
            Patronymic = Model.Patronymic,  
            Birthday = Model.Birthday,  
        };

        if (employee.Id == 0 )
        {
            var id = _EmployeesStore.Add(employee);
            return RedirectToAction("Details", new { id});   
        }
        var success = _EmployeesStore.Edit(employee);
        if (!success)    
            return NotFound();
        return RedirectToAction("Index");
    }
    /*   edit again?       */
    public IActionResult Edit(int? id)
    {
       if (id is null) return View(new EmployeesViewModel());

        var employee = _EmployeesStore.GetById((int)id);
        if (employee is null) return NotFound();

        return View(new EmployeesViewModel
        {
            Id = employee.Id,   
            FirstName = employee.FirstName, 
            LastName= employee.LastName,    
            Patronymic= employee.Patronymic,        
            Birthday= employee.Birthday,    
        });
    }

    public IActionResult Delete(int id)
    {
        var employee = _EmployeesStore.GetById(id);
    }
}