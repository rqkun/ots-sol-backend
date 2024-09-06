using OTS.Data.Interfaces;
using OTS.Data.Models;
using OTS.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Service.Services
{
    public class SubmitService : ISubmitService
    {
        private readonly ISubmitRepository _submitRepository;
        public SubmitService(ISubmitRepository submitRepository)
        {
            this._submitRepository = submitRepository;
        }
    }
}
