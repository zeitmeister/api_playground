using NUnit.Framework;
using ArrangeDependencies.Autofac;
using Treehouse.AspNetCore.Services;
using ArrangeDependencies.Autofac.Extensions;
using ArrangeDependencies.Core;
using Treehouse.AspNetCore.ViewModels.AuthModel;
using Moq;
using Treehouse.AspNetCore.Repositories;

namespace TestProject
{
    [TestFixture]
    public class Tests
    {
        //[Test]
        //public void ServiceShouldReturnTrueWhenModelIsTrue()
        //{

        //    BaseAuthModel model = null;
        //    var dependencies = Arrange.Dependencies<IUserService, UserService>(depndency =>
        //    {
        //        depndency.UseMock<IUserRepository>(mock =>
        //        {
        //            //mock.Setup(x => x.GetAuth()).Returns(true);
        //            mock.Setup(x => x.SetAuth(true));
        //        });
        //        depndency.UseMock<IBaseAuthModel>(mock => mock.Setup(x => x.IsAuth).Returns(true));

        //    });
        //    var userService = dependencies.Resolve<IUserService>();

        //    //var result = mockService.Setup(x => x.GetAuth()).Returns();
        //    Assert.True(userService.GetAuth());
        //}

        [Test]
        public void ServiceShouldReturnTrueWhenRepositoryReturnsTrue()
        {

            BaseAuthModel model = null;
            var dependencies = Arrange.Dependencies<IUserService, UserService>(depndency =>
            {
                depndency.UseMock<IUserRepository>(mock =>
                {
                    mock.Setup(x => x.GetAuth()).Returns(true);
                    //mock.Setup(x => x.SetAuth(true)).Callback((x) => x.);
                });
                
            });
            var userService = dependencies.Resolve<IUserService>();

            //var result = mockService.Setup(x => x.GetAuth()).Returns();
            Assert.True(userService.GetAuth());
        }

        [Test]
        public void RepositoryShouldReturnTrueWhenAuthModelIsTrue()
        {

            BaseAuthModel model = null;
            var dependencies = Arrange.Dependencies<IUserRepository, UserRepository>(depndency =>
            {
                depndency.UseMock<IBaseAuthModel>(mock =>
                {
                    //mock.Setup(x => x.GetTest()).Returns(false);
                    mock.Setup(x => x.IsAuth).Returns(true);
                });

            });
            var repo = dependencies.Resolve<IUserRepository>();
            
            //var result = mockService.Setup(x => x.GetAuth()).Returns();
            Assert.True(repo.GetAuth());
        }
    }
}