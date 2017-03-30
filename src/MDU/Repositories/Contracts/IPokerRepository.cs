using System;
using System.Collections.Generic;
using System.Linq;

using MDU.Models.PokerModels;

namespace MDU.Repositories.Contracts
{
    public interface IPokerRepository
    {
        List<HeadToHeadStat> GetNextCalcBatch(int batchSize);
        
        List<HeadToHeadStat> UpdateHeadToHeadStatValues(long handId, long p0Wins, long p1Wins, long chops);
        
        HeadToHeadStat Get2PlayerStatById(int requestId);        
    }
}