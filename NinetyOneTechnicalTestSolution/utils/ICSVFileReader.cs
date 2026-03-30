using NinetyOneTechnicalTestSolution.Models.DTOs;

namespace NinetyOneTechnicalTestSolution.utils
{
    public interface ICSVFileReader
    {
        List<Scores> ReadCsvSimple(Stream filePath);
    }
}
