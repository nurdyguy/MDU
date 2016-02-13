


function Deck()
{
    var arrCards = {};
    for (var s in GC_Suits)
        for (var n in GC_CardNums)
            arrCards[n + s] = new Card({ 'number': n, 'suit': s, 'isUsed': false });

    var shuffledCards = [];

    this.GetCards = function ()
    {
        return arrCards;
    }

    this.UpdateCard = function (cardID, isUsed)
    {
        arrCards[cardID].SetIsUsed(isUsed);
    }

    this.GetShuffledCards = function()
    {
        return shuffledCards;
    }

    this.SetShuffledCards = function(cards)
    {
        shuffledCards = cards;
    }

   


}

Deck.prototype.DealCards = function (args)
{
    // if arrPlayers is undefined then deal we are dealing to all available players
    if (typeof args.arrPlayers == 'undefined' || args.arrPlayers == null)
    {
        
    }
    else
    {

    }

    // arrCards is not required--- if undefined then use entire deck
    if (typeof args.arrCards == 'undefined' || args.arrCards == null)
    {


        
    }
    else
    {
        for (var p in args.arrPlayers)
            args.arrPlayers[p].SetCards(args.arrCards);
        for (var c in args.arrCards)
            this.UpdateCard(args.arrCards[c], true);
    }

}

Deck.prototype.DealHand = function (arrPlayers, arrCommCards)
{
    var cards = this.GetShuffledCards();
          //used to force hand      
    //cards[0] = '7S';
    //cards[1] = '';
    // force board cards
    //cards[20] = '10D';
    //cards[21] = '4D';
    //cards[22] = '5D';
    //cards[23] = '3D';
    //cards[24] = '4C';
    
    for (var i = 0; i < arrPlayers.length; i++)
    {
        for (var j = arrPlayers[i].GetCards().length; j < 2; j++)
        {
            arrPlayers[i].AddCard(cards[0]);
            cards.splice(0,1);
        }
    }

    for (var i = 0; i < 5; i++)
    {
        arrCommCards.push(cards[0]);
        cards.splice(0, 1);
    }

}

Deck.prototype.Shuffle = function ()
{
    var arrCards = this.GetCards();
    var unused = [];
    var shuffled = [];

    for (var c in arrCards)
    {
        if (!arrCards[c].GetIsUsed())
        {
            unused.push(c);
        }
    }

    var nextCard;
    while (unused.length > 0)
    {
        nextCard = Math.floor(Math.random()*unused.length);
        shuffled.push(unused[nextCard]);
        unused.splice(nextCard, 1);
    }

    this.SetShuffledCards(shuffled);
}