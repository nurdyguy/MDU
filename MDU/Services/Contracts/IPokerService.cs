using System;
using System.Collections.Generic;
using System.Linq;

using MDU.Models.PokerModels;

namespace MDU.Services.Contracts
{
    public interface IPokerService
    {
        List<HandStatResult> GetHandStats(int NumPlayers, List<Hand> hands, List<Card> boardCards, List<Card> deadCards);

        void PlayRounds(int num = 1);
    }
}