using System.Text.Json;
using ReleaseNumberIncrements.Data;

namespace ReleaseNumberIncrements.Services
{
    public class ReleaseVersioningService : IReleaseVersioningService
    {
        public const string fileName = "ProjectDetails.json";

        public void VersionNumberUpdate(ReleaseType releaseType)
        {
            var projectDetails = DeserialiseJson();
            var versionNumber = SeparateVersionNumbers(projectDetails.Version);
            versionNumber = IncrementVersion(releaseType, versionNumber);
            ApplyNewVersionNumber(projectDetails, versionNumber);
        }

        public ProjectDetails DeserialiseJson()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);
            var jsonString = File.ReadAllText(filePath);
            var projectDetails = JsonSerializer.Deserialize<ProjectDetails>(jsonString);

            if (projectDetails == null)
            {
                throw new JsonException("Unable to deserialise json file.");
            }
            return projectDetails;
        }

        public VersionNumber SeparateVersionNumbers(string versionNumber)
        {
            var unprocessedVersionNumbers = versionNumber.Split('.');
            if (unprocessedVersionNumbers.Length != 3)
            {
                throw new InvalidDataException("Version Number is not of format Major.Minor.Patch.");
            }
            try
            {
                var processedVersionNumber = new VersionNumber
                {
                    Major = int.Parse(unprocessedVersionNumbers[0]),
                    Minor = int.Parse(unprocessedVersionNumbers[1]),
                    Patch = int.Parse(unprocessedVersionNumbers[2])
                };

                return processedVersionNumber;
            }
            catch (FormatException e)
            {
                throw new FormatException($"Version Number is not of format Major.Minor.Patch, where Major, Minor and Patch are ints. Original exception details: \n{e}");
            }
        }

        public VersionNumber IncrementVersion(ReleaseType releaseType, VersionNumber versionNumber)
        {
            if (releaseType == ReleaseType.Patch)
            {
                versionNumber.Patch++;
            }
            if (releaseType == ReleaseType.Minor)
            {
                versionNumber.Minor++;
                versionNumber.Patch = 0;
            }
            return versionNumber;
        }

        public void ApplyNewVersionNumber(ProjectDetails projectDetails, VersionNumber versionNumber)
        {
            projectDetails.Version = versionNumber.ToString();
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(projectDetails, options);
            File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), fileName), jsonString);
        }
    }
}
