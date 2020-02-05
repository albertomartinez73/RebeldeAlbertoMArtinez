using System.Collections.Specialized;
using NUnit.Framework;
using RebeldeAlbertoMArtinez.Infraestructure_Transversal.Exceptions;
using RebeldeAlbertoMArtinez.Services.RebeldeFactory;
using RebeldeAlbertoMArtinez.Services.SplitService;

namespace PruebasUnitariasNUnit.Services
{
    public class RebeldFactoryTests
    {
        public readonly RebeldeFactory Factory;
        public readonly ISplitService Split;
        private readonly StringCollection _stringCollection;
        private readonly StringCollection _stringCollectionEmpty;

        public RebeldFactoryTests()
        {
            Split = new SplitService();
            Factory = new RebeldeFactory(Split);
            _stringCollection = new StringCollection();
            _stringCollectionEmpty = new StringCollection();

        }

        [Test]
        public void CreateObjectStringCollectionNull()
        {
            Assert.Throws<RebeldeFactoryException>(() => Factory.Create(_stringCollectionEmpty));
        }

        [Test]
        public void CreateObjectStringCollection()
        {
            _stringCollection.Add("Alberto,Zaragoza");
            var rebelde = Factory.Create(_stringCollection);

            Assert.IsNotNull(rebelde);
        }
    }
}