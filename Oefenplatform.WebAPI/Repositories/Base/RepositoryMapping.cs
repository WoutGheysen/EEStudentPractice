using AutoMapper;
using Oefenplatform.Lib.Models;
using Oefenplatform.WebAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oefenplatform.WebAPI.Repositories.Base
{
    public class RepositoryMapping<T> : RepositoryBase<T> where T : EntityBase<int>
    {
        protected readonly IMapper _mapper;

        public RepositoryMapping(OefenplatformContext oefenplatformContext, IMapper mapper) : base(oefenplatformContext)
        {
            _mapper = mapper;
        }
    }
}
