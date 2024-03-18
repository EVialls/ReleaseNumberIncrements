using ReleaseNumberIncrements.Data;

namespace ReleaseNumberIncrements.Services
{
    public interface IReleaseVersioningService
    {
        public void VersionNumberUpdate(ReleaseType releaseType);
        public ProjectDetails DeserialiseJson();
        public VersionNumber SeparateVersionNumbers(string versionNumber);
        public VersionNumber IncrementVersion(ReleaseType releaseType, VersionNumber versionNumber);
        public void ApplyNewVersionNumber(ProjectDetails projectDetails, VersionNumber versionNumber);
    }
}
