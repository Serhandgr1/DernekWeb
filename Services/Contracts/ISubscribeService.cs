using Entities.ModelsDto;
using Services.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ISubscribeService
    {
        IEnumerable<SubscribeDto> GetAllSubscribe();
        SubscribeDto GetByIdSubscribe(int id);
        SubscribeDto CreateSubscribe(SubscribeDto subscribeDto);
        void UpdateSubscribe(SubscribeDto subscribeDto);
        void DeleteSubscribe(int id);
    }
}
