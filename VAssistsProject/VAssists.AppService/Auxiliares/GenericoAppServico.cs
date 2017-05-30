using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAssists.AppService.Auxiliares.Interfaces;

namespace VAssists.AppService.Auxiliares
{
    public abstract class GenericoAppServico
    {
        protected readonly IUnitOfWork unitOfWork;

        public GenericoAppServico(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
    }
}
