using System.Collections.Generic;
using CodeChallengeATM.Exceptions;
using CodeChallengeATM.Models;
using CodeChallengeATM.Services;
using NUnit.Framework;
using Moq;

namespace CodeChallengeATM.Test
{
    public class AtmServiceTest
    {
        private Mock<IAtmService> _mock;
        [SetUp]
        public void Setup()
        {

            _mock = new Mock<IAtmService>() { CallBase = true };
        }

        [Test]
        public void GetNotes_InputNotDividedByLowestNote()
        {
            _mock.Setup(atm => atm.GetNotes(new InputForm() { ImputedAmount = 45 }))
                .Throws(new NoteUnavailableException());
        }
        [Test]
        public void GetNotes_InputNegative()
        {
            _mock.Setup(atm => atm.GetNotes(new InputForm() { ImputedAmount = -40 }))
                .Throws(new InvalidArgumentException());
        }
        [Test]
        public void GetNotes_InputProperValue()
        {
            var form = new InputForm() { ImputedAmount = 40, Results = new List<decimal>() };
            var atmService = new AtmService();
            atmService.GetNotes(form);
            Assert.AreEqual(new List<decimal>() { 0, 0, 2, 0 }, form.Results);
        }
    }
}