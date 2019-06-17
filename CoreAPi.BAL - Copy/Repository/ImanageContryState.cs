using CoreAPi.BAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPi.BAL.Repository
{
    public interface ImanageContryState
    {
        Task<List<Stateclass>> GetStateById(int id);      
        // Task<List<State>> GetState();
        // Task<List<Contry>> GetContry();
    }
}
