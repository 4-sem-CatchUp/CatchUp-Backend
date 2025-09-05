using CatchUpBackend.Social.Core;
using CatchUpBackend.Social.Core.Application;
using CatchUpBackend.Social.Core.Ports.Outgoing;
using Moq;

namespace CatchUp_TestProject
{
    [TestClass]
    public class ProfileServiceTests
    {
        private Mock<IProfileRepository> _mockRepo;
        private ProfileService _service;

        [TestInitialize]
        public void Setup()
        {
            _mockRepo = new Mock<IProfileRepository>();
            _service = new ProfileService(_mockRepo.Object);
        }

        [TestMethod]
        public async Task CreateProfileAsync_ShouldReturnProfileId_AndSaveProfile()
        {
            // Arrange
            string userName = "TestUser";

            // Act
            var result = await _service.CreateProfileAsync(userName);

            // Assert
            Assert.AreNotEqual(Guid.Empty, result);
            _mockRepo.Verify(r => r.AddProfileAsync(It.Is<Profile>(p => p.Name == userName)), Times.Once);
        }

        [TestMethod]
        public async Task UpdateProfileAsync_ShouldUpdateProfile_WhenProfileExists()
        {
            // Arrange
            var profileId = Guid.NewGuid();
            var profile = new Profile("OldName");
            _mockRepo.Setup(r => r.GetProfileByIdAsync(profileId)).ReturnsAsync(profile);

            // Act
            await _service.UpdateProfileAsync(profileId, "NewName", null, "NewBio");

            // Assert
            Assert.AreEqual("NewName", profile.Name);
            Assert.AreEqual("NewBio", profile.Bio);
            _mockRepo.Verify(r => r.UpdateProfileAsync(profile), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public async Task UpdateProfileAsync_ShouldThrow_WhenProfileNotFound()
        {
            // Arrange
            var profileId = Guid.NewGuid();
            _mockRepo.Setup(r => r.GetProfileByIdAsync(profileId)).ReturnsAsync((Profile)null!);

            // Act
            await _service.UpdateProfileAsync(profileId, "NewName", null, "NewBio");
        }

        [TestMethod]
        public async Task AddFriendAsync_ShouldAddFriend_WhenBothProfilesExist()
        {
            // Arrange
            var profileId = Guid.NewGuid();
            var friendId = Guid.NewGuid();
            var profile = new Profile("User");

            _mockRepo.Setup(r => r.GetProfileByIdAsync(profileId)).ReturnsAsync(profile);
            _mockRepo.Setup(r => r.GetProfileByIdAsync(friendId)).ReturnsAsync(new Profile("Friend"));

            // Act
            await _service.AddFriendAsync(profileId, friendId);

            // Assert
            Assert.IsTrue(profile.Friends.Contains(friendId));
            _mockRepo.Verify(r => r.UpdateProfileAsync(profile), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public async Task AddFriendAsync_ShouldThrow_WhenFriendNotFound()
        {
            // Arrange
            var profileId = Guid.NewGuid();
            var friendId = Guid.NewGuid();
            var profile = new Profile("User");

            _mockRepo.Setup(r => r.GetProfileByIdAsync(profileId)).ReturnsAsync(profile);
            _mockRepo.Setup(r => r.GetProfileByIdAsync(friendId)).ReturnsAsync((Profile)null!);

            // Act
            await _service.AddFriendAsync(profileId, friendId);
        }
    }
}
