using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace FakeOffice.ViewModels
{
    public class EmployeesViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Required]
        [Display(Name ="Фамилия")]
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; } 
        public string? Patronymic { get; set; }
        public DateTime Birthday { get; set; }  
    }
}
