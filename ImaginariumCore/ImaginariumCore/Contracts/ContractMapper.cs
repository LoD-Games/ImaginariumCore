using System.Collections.Generic;
using System.Linq;
using Domain.Entities;

namespace ImaginariumCore.Contracts
{
    public class ContractMapper
    {
        public IList<string> ToUpdate(IEnumerable<Player> players)
        {
            IList<string> result  = new List<string>();
            foreach (var player in players)
            {
                result.Add(player.Token);
            }
            return result;
        } 
    }
}
