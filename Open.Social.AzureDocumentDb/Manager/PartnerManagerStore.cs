using AutoMapper;
using Open.Social.AzureDocumentDb.Interface;
using Open.Social.AzureDocumentDb.Model;
using Open.Social.Core.Interface;
using Open.Social.Core.Model.TimeSheet;
using Open.Social.Core.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Open.Social.AzureDocumentDb.Manager
{
    public class PartnerManagerStore : IPartnerManagerStore
    {
        private readonly IPartnerCollection _partnerCollection;


        public PartnerManagerStore(IPartnerCollection  partnerCollection)
        {
            _partnerCollection = partnerCollection;
            Mapper.Initialize(cfg => cfg.CreateMap<Partner, PartnerEntity>());
        }

        public IEnumerable<Partner> Consult(Expression<Func<Partner, bool>> expression)
        {
            var entities = _partnerCollection.SetupBaseQuery<IPartnerCollection>().RunQuery();
            return Mapper.Map<IList<PartnerEntity>, IList<Partner>>(entities);
            
        }



        public void Remove(Partner entidade)
        {
            throw new NotImplementedException();
        }

        public void SaveOrUpdate(Partner entity)
        {
            PartnerEntity dto = Mapper.Map<PartnerEntity>(entity);
            _partnerCollection.CreateAsync(dto);
        }

        public Partner SelectById(Partner entidade)
        {
            throw new NotImplementedException();
        }
    }
}
