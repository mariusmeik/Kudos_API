using AutoFixture.NUnit3;
using AutoMapper;
using Core.Contracts;
using Core.Entities;
using Core.Exceptions;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Services.Services;

namespace TestsUnit
{
    public class KudosServiceTests
    {
        private KudosService? _kudosService;

        private Mock<IKudosRepository> _kudosRepositoryMock = new();
        private Mock<IReasonRepository> _reasonRepositoryMock = new();
        private Mock<IEmployeeRepository> _employeRepositoryMock = new();

        [SetUp]
        public void SetUp()
        {
        }

        [Test, AutoData]
        public async Task Get_CalledWithoutFilter_ReturnsList(List<KudosEntity> kudosEntities)
        {
            KudosQueryParameters parameters = new();
            _kudosRepositoryMock?.Setup(x => x.Get()).Returns(Task.FromResult(kudosEntities));
            _kudosService = new KudosService(_kudosRepositoryMock.Object, _reasonRepositoryMock.Object, _employeRepositoryMock.Object);
            var result = await _kudosService.Get(parameters);

            result.Should().BeEquivalentTo(kudosEntities);
        }

        [Test, AutoData]
        public async Task Get_CalledWithFilter_ReturnsFilteredList(List<KudosEntity> kudosEntities)
        {
            foreach (var k in kudosEntities)
            {
                k.GiverId = 1;
            }
            kudosEntities[0].GiverId = 2;
            kudosEntities[0].ReceiverId = 3;

            KudosQueryParameters parameters = new();
            parameters.GiverId = 2;
            parameters.ReceiverId = 3;

            _kudosRepositoryMock?.Setup(x => x.Get()).Returns(Task.FromResult(kudosEntities));
            _kudosService = new KudosService(_kudosRepositoryMock.Object, _reasonRepositoryMock.Object, _employeRepositoryMock.Object);

            var result = await _kudosService.Get(parameters);

            result.Count().Should().Be(1);
            result[0].Should().BeEquivalentTo(kudosEntities[0]);
        }

        [Test, AutoData]
        public async Task Create_GiverAndReceiverSameId_ReturnsException(KudosEntity kudos, EmployeeEntity employee,ReasonEntity reason)
        {
            kudos.ReceiverId = kudos.GiverId;
            _reasonRepositoryMock?.Setup(x => x.GetById(kudos.ReasonId)).Returns(Task.FromResult(reason));
            _employeRepositoryMock?.Setup(x => x.GetById(kudos.GiverId)).Returns(Task.FromResult(employee));
            _employeRepositoryMock?.Setup(x => x.GetById(kudos.ReceiverId)).Returns(Task.FromResult(employee));

            _kudosService = new KudosService(_kudosRepositoryMock.Object, _reasonRepositoryMock.Object, _employeRepositoryMock.Object);
            

            var ex = Assert.ThrowsAsync<SenderIsReceiverException>(async () => await _kudosService.Create(kudos));
            Assert.That(ex.Message, Is.EqualTo("Sender can not also be a receiver"));
        }

    }
}