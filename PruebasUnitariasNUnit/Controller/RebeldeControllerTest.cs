using RebeldeAlbertoMArtinez.Controllers;
using RebeldeAlbertoMArtinez.Services.Repository;
using System.Collections.Specialized;
using NUnit.Framework;
using RebeldeAlbertoMArtinez.Services.Log;

namespace PruebasUnitariasNUnit.Controller
{
    public class RebeldeControllerTest
    {
        public readonly RebeldeController Controller;
        private readonly FakeRepository fakeRepository;
        private readonly StringCollection _invalidRebelCollection;
        private readonly StringCollection _validRebelCollection;
        private readonly EscribirLogTxt writeLog;

        public RebeldeControllerTest()
        {
            _invalidRebelCollection = new StringCollection
            {
                "abc"
            };
            _validRebelCollection = new StringCollection
            {
                "Paco,Murcia"
            };
            Controller = new RebeldeController(fakeRepository, writeLog);
        }

        [Test]
        public void ItReturnsCollectionOfSpeakers()
        {
            var result = Controller.Get();
            Assert.NotNull(result);
        }

        [Test]
        public void ItHasPostMethod()
        {
            var result = Controller.Post(_validRebelCollection);
            Assert.NotNull(result);
        }

    }

}
