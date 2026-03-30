using System.ComponentModel.DataAnnotations;

namespace NinetyOneTechnicalTestSolution.Models.Interfaces
{
    public interface IScores
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Score { get; set; }
    }
}
