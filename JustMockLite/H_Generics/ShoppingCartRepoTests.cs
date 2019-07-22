using LOBCode;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Telerik.JustMock;
using Telerik.JustMock.Helpers;

namespace JustMockLite.H_Generics
{
    [TestFixture]
    public class ShoppingCartRepoTests
    {
        [Test]
        public void ShouldMockGenericTypes()
        {
            int userID = 5;
            string userName = "Bob";
            var intList = new List<int> { 1, 2, 3, 4, 5 };
            var strList = new List<string> { "1", "2", "3", "4", "5" };
            var repo = Mock.Create<ICartRepo>();
            repo.Arrange(x => x.GetCartItems<int>(userID)).Returns(intList);
            repo.Arrange(x => x.GetCartItems<string>(userName)).Returns(strList);
            var sut = new Login2(null, repo);
            var intResult = sut.GetCartItems(userID);
            var strResult = sut.GetCartItems(userName);
            Assert.AreSame(intList, intResult);
            Assert.AreSame(strList, strResult);
        }
    }
}
