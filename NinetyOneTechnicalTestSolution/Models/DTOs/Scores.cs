using System.ComponentModel.DataAnnotations;

namespace NinetyOneTechnicalTestSolution.Models.DTOs
{
    public class Scores
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string? FirstName { get; set; }
        [Required]
        [MaxLength(255)]
        public string? LastName { get; set; }
        [Required]
        public int Score { get; set; }
    }
}
