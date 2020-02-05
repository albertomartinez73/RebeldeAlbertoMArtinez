using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using RebeldeAlbertoMArtinez.Infraestructure_Transversal.Exceptions;
using RebeldeAlbertoMArtinez.Services.SplitService;

namespace PruebasUnitariasNUnit.services
{
    class SplitServiceTest
    {
        public readonly string ValidString;
        public readonly string InvalidString;
        private readonly char _delimiter;
        private readonly SplitService _split;

        public SplitServiceTest()
        {
            ValidString = "Alberto,Zaragoza";
            InvalidString = "Alberto-Zaragoza";
            _delimiter = ',';

            _split = new SplitService();
        }

        [Test]
        public void Correcto()
        {
            var stringArray = _split.Convert(ValidString, _delimiter);

            Assert.AreEqual(2, stringArray.Length);
        }

        [Test]
        public void Incorrecto()
        {
            Assert.Throws<SplitServiceException>(() => _split.Convert(InvalidString, _delimiter));
        }
    }
}
