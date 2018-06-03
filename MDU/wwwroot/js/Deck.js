


function Deck()
{
    this.deckCards = [];
    for (var s in GC_Suits)
        for (var n in GC_CardNums)
            this.deckCards.push(new Card({ 'id': this.deckCards.length, 'number': n, 'suit': s, 'isUsed': false, 'shortName': n + s }));
}

Deck.prototype.DealCards = function (playerId, cardIds)
{
    for (var p in args.players)
        args.players[p].SetCards(args.cardIds);
    for (var c in args.cardIds)
        this.UpdateCard(args.cardIds[c], true);
}

Deck.prototype.DealHand = function (arrPlayers, arrCommCards)
{
    //var cards = this.GetShuffledCards();
    //      //used to force hand      
    ////cards[0] = '7S';
    ////cards[1] = '';
    //// force board cards
    ////cards[20] = '10D';
    ////cards[21] = '4D';
    ////cards[22] = '5D';
    ////cards[23] = '3D';
    ////cards[24] = '4C';
    
    //for (var i = 0; i < arrPlayers.length; i++)
    //{
    //    for (var j = arrPlayers[i].GetCards().length; j < 2; j++)
    //    {
    //        arrPlayers[i].AddCard(cards[0]);
    //        cards.splice(0,1);
    //    }
    //}

    //for (var i = 0; i < 5; i++)
    //{
    //    arrCommCards.push(cards[0]);
    //    cards.splice(0, 1);
    //}

}

Deck.prototype.Shuffle = function ()
{
    //var arrCards = this.GetCards();
    //var unused = [];
    //var shuffled = [];

    //for (var c in arrCards)
    //{
    //    if (!arrCards[c].GetIsUsed())
    //    {
    //        unused.push(c);
    //    }
    //}

    //var nextCard;
    //while (unused.length > 0)
    //{
    //    nextCard = Math.floor(Math.random()*unused.length);
    //    shuffled.push(unused[nextCard]);
    //    unused.splice(nextCard, 1);
    //}

    //this.SetShuffledCards(shuffled);
}