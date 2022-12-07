using Core.Contracts;
using Core.Entities;
using Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class KudosService : IKudosService
    {
        private IKudosRepository _kudosRepository;
        private IReasonRepository _reasonRepository;
        private IEmployeeRepository _employeRepository;

        public KudosService(IKudosRepository kudosRepository, IReasonRepository reasonRepository, IEmployeeRepository employeRepository)
        {
            _kudosRepository = kudosRepository;
            _reasonRepository = reasonRepository;
            _employeRepository = employeRepository;
        }

        public async Task<int> Create(KudosEntity kudos)
        {
            ReasonEntity reason = await _reasonRepository.GetById(kudos.ReasonId);
            if (reason == null)
            {
                throw new ReasonNotFoundException("Invalid reason");
            };

            EmployeeEntity giver = await _employeRepository.GetById(kudos.GiverId);
            if (giver == null)
            {
                throw new EmployeeNotFoundException("giver");
            };

            EmployeeEntity receiver = await _employeRepository.GetById(kudos.ReceiverId);
            if (receiver == null)
            {
                throw new EmployeeNotFoundException("receiver");
            };

            if (kudos.ReceiverId == kudos.GiverId)
            {
                throw new SenderIsReceiverException("");
            }

            return await _kudosRepository.Create(kudos);
        }

        public async Task<List<KudosEntity>> Get(KudosQueryParameters parameters)
        {
            var kudos = await _kudosRepository.Get();
            if (parameters.GiverId != null)
            {
                kudos = kudos.Where(x => x.GiverId == parameters.GiverId).ToList();
            };
            if (parameters.ReceiverId != null)
            {
                kudos = kudos.Where(x => x.ReceiverId == parameters.ReceiverId).ToList();
            }
            return kudos;
        }

        public async Task<KudosEntity> Exchange(int id)
        {
            var kudos=await _kudosRepository.GetById(id);
            if(kudos== null)
            {
                throw new KudosNotFoundException("");
            }
            KudosEntity kudosEntity= await _kudosRepository.Exchange(id);

            return kudosEntity;
        }
       
    }
}
