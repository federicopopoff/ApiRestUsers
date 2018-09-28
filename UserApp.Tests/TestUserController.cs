using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserApp.Models;
using UserApp.Controllers;
using System.Web.Http.Results;
using System.Net;

namespace UserApp.Tests
{
    [TestClass]
    public class TestUserController
    {
        [TestMethod]
        public void PostUser_ShouldReturnSameUser()
        {
            var controller = new UserController(new TestUserContext());

            var item = GetDemoUser();

            var result =
                controller.PostUser(item) as CreatedAtRouteNegotiatedContentResult<User>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteName, "DefaultApi");
            Assert.AreEqual(result.RouteValues["id"], result.Content.Id);
            Assert.AreEqual(result.Content.Name, item.Name);
        }

        [TestMethod]
        public void PutUser_ShouldReturnStatusCode()
        {
            var controller = new UserController(new TestUserContext());

            var item = GetDemoUser();

            var result = controller.PutUser(item.Id, item) as StatusCodeResult;
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }

        [TestMethod]
        public void PutUser_ShouldFail_WhenDifferentID()
        {
            var controller = new UserController(new TestUserContext());

            var badresult = controller.PutUser(999, GetDemoUser());
            Assert.IsInstanceOfType(badresult, typeof(BadRequestResult));
        }

        [TestMethod]
        public void GetUser_ShouldReturnUserWithSameID()
        {
            var context = new TestUserContext();
            context.Users.Add(GetDemoUser());

            var controller = new UserController(context);
            var result = controller.GetUser(3) as OkNegotiatedContentResult<User>;

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Content.Id);
        }

        [TestMethod]
        public void GetUsers_ShouldReturnAllUsers()
        {
            var context = new TestUserContext();
            context.Users.Add(new User { Id = 1, Name = "Fede", LastName = "GOn" });
            context.Users.Add(new User { Id = 2, Name = "Sergio", LastName = "DFD" });
            context.Users.Add(new User { Id = 3, Name = "Pablo", LastName = "dtyty" });

            var controller = new UserController(context);
            var result = controller.GetUsers() as TestUserDbSet;

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Local.Count);
        }

        [TestMethod]
        public void DeleteUser_ShouldReturnOK()
        {
            var context = new TestUserContext();
            var item = GetDemoUser();
            context.Users.Add(item);

            var controller = new UserController(context);
            var result = controller.DeleteUser(3) as OkNegotiatedContentResult<User>;

            Assert.IsNotNull(result);
            Assert.AreEqual(item.Id, result.Content.Id);
        }

        User GetDemoUser()
        {
            return new User() { Id = 3, Name = "Demo name", LastName = "Last Name" };
        }
    }
}