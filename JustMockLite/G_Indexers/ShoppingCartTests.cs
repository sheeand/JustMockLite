using LOBCode;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Telerik.JustMock;
using Telerik.JustMock.Helpers;

namespace JustMockLite.G_Indexers
{
    class ShoppingCartTests
    {
        [Test]
        public void Login_IndexedGetter_ShouldPass()
        {
            var repo = Mock.Create<IShoppingCart>();
            var items = Mock.Create<IList<string>>();

            string first = "1";
            string second = "2";

            repo.Arrange(x => x.Items).Returns(items); // mock of the getter
            items.Arrange(x => x[0]).Returns(first); // mock of an indexed getter
            items.Arrange(x => x[1]).Returns(second); // mock of an indexed getter

            Assert.AreEqual(first, repo.Items[0]);
            Assert.AreEqual(second, repo.Items[1]);
        }

        [Test]
        public void Login_IndexedSetter_ShouldPass()
        {
            var repo = Mock.Create<IShoppingCart>();
            var items = Mock.Create<IList<string>>(Behavior.Strict);

            string first = "1";
            string second = "2";

            repo.Arrange(x => x.Items).Returns(items); // mock of the setter
            items.ArrangeSet(x => x[0] = first); // mock of an indexed setter
            items.ArrangeSet(x => x[1] = second); // mock of an indexed setter

            repo.Items[0] = first; // Behavior.Strict forces the order to matter
            repo.Items[1] = second;
        }

    }
}
