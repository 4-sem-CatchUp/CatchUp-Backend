using CatchUpBackend.Social.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchUp_TestProject
{
    [TestClass]
    public class ProfileTests
    {
        [TestMethod]
        public void UpdateProfile_ShouldChangeValues_WhenNotNull()
        {
            // Arrange
            var profile = new Profile("OldName");

            // Act
            profile.UpdateProfile("NewName", new byte[] { 1, 2, 3 }, "NewBio");

            // Assert
            Assert.AreEqual("NewName", profile.Name);
            CollectionAssert.AreEqual(new byte[] { 1, 2, 3 }, profile.ProfilePic);
            Assert.AreEqual("NewBio", profile.Bio);
        }

        [TestMethod]
        public void AddFriend_ShouldAdd_WhenNotAlreadyFriend()
        {
            // Arrange
            var profile = new Profile("User");
            var friendId = Guid.NewGuid();

            // Act
            profile.AddFriend(friendId);

            // Assert
            Assert.IsTrue(profile.Friends.Contains(friendId));
        }

        [TestMethod]
        public void AddFriend_ShouldNotDuplicate_WhenAlreadyFriend()
        {
            // Arrange
            var profile = new Profile("User");
            var friendId = Guid.NewGuid();
            profile.AddFriend(friendId);

            // Act
            profile.AddFriend(friendId);

            // Assert
            Assert.AreEqual(1, profile.Friends.Count);
        }
    }
}
