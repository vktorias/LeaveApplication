using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveApplication.Models
{
    
    public class LeaveForm
    {
        [Key]
        public int LeaveApplicationId { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public LeaveType Type { get; set; }
        public DateTime ApplicationDate { get; set; } = DateTime.Now;
        [ForeignKey("Employee")]
        public int FkEmployeeId { get; set; }
        public Employee? Employee { get; set; }
    }

    public enum LeaveType
    {
        Vacation,
        SickLeave,
        ParentalLeave,
        MaternityLeave,
        StudyLeave,
        PersonalLeave,
    }
}
