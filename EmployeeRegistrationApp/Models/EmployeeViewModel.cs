using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace EmployeeRegistrationApp.Models
{
    public class EmployeeViewModel
    {
        public Employee Employee { get; set; } = new Employee(); // Initialize to avoid null reference
        public IEnumerable<SelectListItem> PositionList { get; set; }
        public IEnumerable<SelectListItem> DepartmentList { get; set; }
    }
}
