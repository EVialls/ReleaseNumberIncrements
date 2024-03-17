using ReleaseNumberIncrements.Data;
using ReleaseNumberIncrements.Services;

public class ReleaseExercise
{
    public static ProjectDetails ProjectDetails;

    public static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("No release type defined.");
            return;
        }

        ReleaseType releaseType;
        if (args[0] == "minor" || args[0] == "Minor")
        {
            Console.WriteLine("Minor Release Detected.");
            releaseType = ReleaseType.Minor;
        }
        else if (args[0] == "patch" || args[0] == "Patch")
        {
            Console.WriteLine("Patch Release Detected.");
            releaseType = ReleaseType.Patch;
        }
        else
        {
            Console.WriteLine("Error, unknown or unimplemented release type.");
            return;
        }

        var releaseVersioningService = new ReleaseVersioningService();
        releaseVersioningService.VersionNumberUpdate(releaseType);
    }


}