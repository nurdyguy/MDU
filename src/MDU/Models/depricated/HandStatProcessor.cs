﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//

//namespace MDU.Models.Poker
//{
//    public class HandStatProcessor
//    {
//        //-------------------moved to poker service
//        //public HandStatRequest Request { get; set; }
//        //public HandStatResponse Response { get; set; }

//        //public int NumPlayers { get; set; }
//        //public List<Hand> StartHands { get; set; }
//        //public List<int> NewOrder { get; set; }
//        //public List<Hand> OrderedStartHands { get; set; }
//        //public List<Card> DeadCards { get; set; }
//        //public List<Card> BoardCards { get; set; }
//        //public HandCalculator hCalc { get; set; }

//        //public HandStatProcessor()
//        //{
//        //}

//        //public HandStatProcessor(HandStatRequest request)
//        //{
//        //    hCalc = new HandCalculator();
//        //    StartHands = new List<Hand>();
//        //    OrderedStartHands = new List<Hand>();
//        //    BoardCards = new List<Card>();
//        //    DeadCards = new List<Card>();
//        //    SetUpStartHands(request);
//        //    if (request.BoardCardIds != null && request.BoardCardIds.Count > 0)
//        //        SetUpBoardCards(request);
//        //    if (request.DeadCardIds != null && request.DeadCardIds.Count > 0)
//        //        SetUpDeadCards(request);
//        //}

//        //public void SetUpStartHands(HandStatRequest request)
//        //{
//        //    NumPlayers = request.NumPlayers;            
//        //    for (int i = 0; i < request.HandCardIds.Count; i++)
//        //    {
//        //        var cards = new List<Card>();
//        //        if(request.HandCardIds[i].Count != 2)
//        //            throw new Exception("Invalid request.");
//        //        for (int j = 0; j < request.HandCardIds[i].Count; j++)
//        //        {
//        //            cards.Add(Card.AllCards[request.HandCardIds[i][j]]);
//        //        }

//        //        StartHands.Add(new Hand(cards));
//        //    }
            
//        //    OrderedStartHands = StartHands.OrderBy(sh => sh.Cards[0].Id).ToList();
//        //}

//        //public void SetUpBoardCards(HandStatRequest request)
//        //{
//        //    if (request.BoardCardIds.Count > 5)
//        //        throw new Exception("Invalid request.");
//        //    for (int i = 0; i < request.BoardCardIds.Count; i++)
//        //        BoardCards.Add(Card.AllCards[request.BoardCardIds[i]]);
//        //}

//        //public void SetUpDeadCards(HandStatRequest request)
//        //{
//        //    for (int i = 0; i < request.BoardCardIds.Count; i++)
//        //        DeadCards.Add(Card.AllCards[request.DeadCardIds[i]]);
//        //}

//        //public HandStatResponse ProcessRequest()
//        //{
//        //    switch (OrderedStartHands.Count)
//        //    {
//        //        case 0:
//        //        case 1:
//        //            throw new Exception("Invalid request.");
//        //            break;
//        //        case 2:
//        //            if (BoardCards.Count + DeadCards.Count == 0)
//        //            {
//        //                int requestId = 0;
//        //                for (int i = 0; i < OrderedStartHands.Count; i++)
//        //                    requestId += (int)Math.Pow(10000, (OrderedStartHands.Count - i - 1)) * OrderedStartHands[i].HandId;
//        //                var resultStat = PokerRepository.Get2PlayerStatById(requestId);
//        //                return Build2PlayerResponse(resultStat);
//        //            }           
//        //            // else use default
//        //            goto default;                    
//        //            break;
//        //        case 3:
//        //            if (BoardCards.Count + DeadCards.Count == 0)
//        //            {
//        //            }
//        //            // else use default
//        //            goto default;
//        //            break;
//        //        case 4:
//        //            if (BoardCards.Count + DeadCards.Count == 0)
//        //            {
//        //            }
//        //            // else use default
//        //            goto default;
//        //            break;
//        //        case 5:
//        //            if (BoardCards.Count + DeadCards.Count == 0)
//        //            {
//        //            }
//        //            // else use default
//        //            goto default;
//        //            break;
//        //        default:
//        //            var result = hCalc.CalculateRound(OrderedStartHands, BoardCards, DeadCards);
//        //            return BuildDefaultResponse(result);   
//        //            break;
//        //    }
//        //    return null;
//        //}







//        //public HandStatResponse Build2PlayerResponse(HeadToHeadStat stat)
//        //{
//        //    if (StartHands[0].HandId == stat.Hand0Id)
//        //    {
//        //        var wins = new List<long>() { stat.Hand0Wins, stat.Hand1Wins };
//        //        var chops = new List<long>() { stat.Chops, stat.Chops };
//        //        return new HandStatResponse(wins, chops);
//        //    }
//        //    else
//        //    {
//        //        var wins = new List<long>() { stat.Hand1Wins, stat.Hand0Wins };
//        //        var chops = new List<long>() { stat.Chops, stat.Chops };
//        //        return new HandStatResponse(wins, chops);
//        //    }
//        //}

//        //public HandStatResponse BuildDefaultResponse(HandStatResponse response)
//        //{

//        //    return response;
//        //}

//        //public HandStatResponse BuildDefaultResponse(List<long> result)
//        //{
//        //    var response = new HandStatResponse();
//        //    var found = false;
//        //    for (int i = 0; i < StartHands.Count; i++)
//        //    {
//        //        found = false;
//        //        for (int j = 0; j < OrderedStartHands.Count && !found; j++)
//        //        {
//        //            if (StartHands[i].HandId == OrderedStartHands[j].HandId)
//        //            {
//        //                response.NumWins[i] = result[j];
//        //                response.Chops[i] = result[j + 10];
//        //                found = true;
//        //            }
//        //        }
//        //    }
//        //    response.TotalHands = result[20];

//        //    return response;
//        //}
//    }


    
//}