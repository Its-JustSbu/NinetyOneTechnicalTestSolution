using NinetyOneTechnicalTestSolution.Models.DTOs;
using NinetyOneTechnicalTestSolution.Models.Interfaces;

namespace NinetyOneTechnicalTestSolution.utils
{
    public class CSVFileReader : ICSVFileReader
    {
        List<Scores> ICSVFileReader.ReadCsvSimple(Stream filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                try
                {
                    List<Scores> scores = new();
                    string line;
                    int skip = 0; // Handler to skip the header line of the CSV file

                    while ((line = reader.ReadLine()) != null)
                    {
                        if (skip == 0) continue; // skips the header line of the CSV file
                        Console.WriteLine(line);

                        string[] values = line.Split(',');

                        // Assuming the CSV will allways have the necessary structure of three columns: FirstName, LastName, Score
                        scores.Add(new Scores
                        {
                            FirstName = values[0],
                            LastName = values[1],
                            Score = int.Parse(values[2])
                        });
                    }

                    return scores;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
