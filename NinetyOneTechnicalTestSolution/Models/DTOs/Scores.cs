using System.ComponentModel.DataAnnotations;

namespace NinetyOneTechnicalTestSolution.Models.DTOs
{
    public class Scores
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string? FirstName { get; set; }
        [Required]
        [StringLength(255)]
        public string? LastName { get; set; }
        [Required]
        public int Score { get; set; }
    }
}
