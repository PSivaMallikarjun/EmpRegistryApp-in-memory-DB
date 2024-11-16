using EmployeeRegistrationApp.Data; // Ensure this is the correct path to your DbContext
using EmployeeRegistrationApp.Models; // Ensure this matches your namespace
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeRegistrationApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Create Employee
        public IActionResult Create()
        {
            var model = new EmployeeViewModel
            {
                PositionList = GetPositions(),
                DepartmentList = GetDepartments(),
                Employee = new Employee() // Initialize Employee property
            };

            return View(model);
        }

        // POST: Create Employee
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Add the new employee to the database
                _context.Employees.Add(model.Employee);
                _context.SaveChanges();

                TempData["SuccessMessage"] = "Employee created successfully.";
                return RedirectToAction("Index"); // Redirect to Index action
            }

            // If validation fails, repopulate the dropdown lists
            model.PositionList = GetPositions();
            model.DepartmentList = GetDepartments();

            return View(model);
        }

        // Method to get positions for the dropdown
        private IEnumerable<SelectListItem> GetPositions()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Value = "Manager", Text = "Manager" },
                new SelectListItem { Value = "Developer", Text = "Developer" },
                new SelectListItem { Value = "Tester", Text = "Tester" }
            };
        }

        // Method to get departments for the dropdown
        private IEnumerable<SelectListItem> GetDepartments()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Value = "HR", Text = "HR" },
                new SelectListItem { Value = "IT", Text = "IT" },
                new SelectListItem { Value = "Finance", Text = "Finance" }
            };
        }

        // GET: Employee Index
        public IActionResult Index()
        {
            var employees = _context.Employees.ToList(); // Retrieve all employees from the database
            return View(employees); // Pass the employee list to the view
        }

    }
}
