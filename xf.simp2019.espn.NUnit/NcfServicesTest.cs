using System.Linq;
using NUnit.Framework;
namespace xf.simp2019.espn.NUnit
{
    [TestFixture()]
    public class NcfServicesTest
    {
        readonly Services.NcfServices ncfServices;

        public NcfServicesTest()
        {
            ncfServices = new Services.NcfServices();
        }

        [Test]
        public void GetArticles_MustRetur_Any()
        {
            Assert.IsTrue(true);
        }
    }
}