using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReleaseNumberIncrements.Data;
using ReleaseNumberIncrements.Services;

namespace ReleaseNumberIncrementsTests
{
    [TestClass]
    public class ReleaseVersioningServiceTests
    {
        private ReleaseVersioningService _service;

        public ReleaseVersioningServiceTests()
        {
            _service = new ReleaseVersioningService();
        }

        [TestMethod]
        public void SeparateVersionNumbersOk()
        {
            //Arrange
            var unprocessedVersionNumber = "1.2.3";
            var processedVersionNumber = new VersionNumber
            {
                Major = 1,
                Minor = 2,
                Patch = 3
            };

            //Act
            var result = _service.SeparateVersionNumbers(unprocessedVersionNumber);

            //Assert
            Assert.AreEqual(result.Major, processedVersionNumber.Major);
            Assert.AreEqual(result.Minor, processedVersionNumber.Minor);
            Assert.AreEqual(result.Patch, processedVersionNumber.Patch);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void SeparateVersionNumbersNoDividers()
        {
            //Arrange
            var unprocessedVersionNumber = "123";

            //Act
            _service.SeparateVersionNumbers(unprocessedVersionNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void SeparateVersionNumbersNotInts()
        {
            //Arrange
            var unprocessedVersionNumber = "hello.im.incorrect";

            //Act
            _service.SeparateVersionNumbers(unprocessedVersionNumber);
        }

        [TestMethod]
        public void IncrementVersionPatchOk()
        {
            //Arrange
            var prevMajorNumber = 1;
            var prevMinorNumber = 1;
            var prevPatchNumber = 23;
            var releaseType = ReleaseType.Patch;
            var prevVersionNumber = new VersionNumber
            {
                Major = prevMajorNumber,
                Minor = prevMinorNumber,
                Patch = prevPatchNumber
            };
            var resultVersionNumber = new VersionNumber
            {
                Major = prevMajorNumber,
                Minor = prevMinorNumber,
                Patch = prevPatchNumber + 1
            };

            //Act
            var result = _service.IncrementVersion(releaseType, prevVersionNumber);

            //Assert
            Assert.AreEqual(result.Major, resultVersionNumber.Major);
            Assert.AreEqual(result.Minor, resultVersionNumber.Minor);
            Assert.AreEqual(result.Patch, resultVersionNumber.Patch);
        }

        [TestMethod]
        public void IncrementVersionMinorOk()
        {
            //Arrange
            var prevMajorNumber = 1;
            var prevMinorNumber = 1;
            var prevPatchNumber = 23;
            var releaseType = ReleaseType.Minor;
            var prevVersionNumber = new VersionNumber
            {
                Major = prevMajorNumber,
                Minor = prevMinorNumber,
                Patch = prevPatchNumber
            };
            var resultVersionNumber = new VersionNumber
            {
                Major = prevMajorNumber,
                Minor = prevMinorNumber + 1,
                Patch = 0
            };

            //Act
            var result = _service.IncrementVersion(releaseType, prevVersionNumber);

            //Assert
            Assert.AreEqual(result.Major, resultVersionNumber.Major);
            Assert.AreEqual(result.Minor, resultVersionNumber.Minor);
            Assert.AreEqual(result.Patch, resultVersionNumber.Patch);
        }

        [TestMethod]
        public void IncrementVersionMajorNoChange()
        {
            //Arrange
            var prevMajorNumber = 1;
            var prevMinorNumber = 1;
            var prevPatchNumber = 23;
            var releaseType = ReleaseType.Major;
            var versionNumber = new VersionNumber
            {
                Major = prevMajorNumber,
                Minor = prevMinorNumber,
                Patch = prevPatchNumber
            };

            //Act
            var result = _service.IncrementVersion(releaseType, versionNumber);

            //Assert
            Assert.AreEqual(result.Major, versionNumber.Major);
            Assert.AreEqual(result.Minor, versionNumber.Minor);
            Assert.AreEqual(result.Patch, versionNumber.Patch);
        }

        [TestMethod]
        public void IncrementVersionNoneNoChange()
        {
            //Arrange
            var prevMajorNumber = 1;
            var prevMinorNumber = 1;
            var prevPatchNumber = 23;
            var releaseType = ReleaseType.None;
            var versionNumber = new VersionNumber
            {
                Major = prevMajorNumber,
                Minor = prevMinorNumber,
                Patch = prevPatchNumber
            };

            //Act
            var result = _service.IncrementVersion(releaseType, versionNumber);

            //Assert
            Assert.AreEqual(result.Major, versionNumber.Major);
            Assert.AreEqual(result.Minor, versionNumber.Minor);
            Assert.AreEqual(result.Patch, versionNumber.Patch);
        }
    }
}