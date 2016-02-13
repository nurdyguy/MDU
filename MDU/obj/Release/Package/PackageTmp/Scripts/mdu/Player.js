



function Player()
{
    // array of cardIDs
    var arrCards = [];



    this.GetCards = function ()
    {
        return arrCards;
    }

    // reset and sets hand
    this.SetCards = function(cards)
    {
        arrCards = [];
        if (typeof cards != 'undefined' && cards != null)
            for(var c in cards) 
                arrCards.push(cards[c]);
    }

    // adds a single card to existing hand
    this.AddCard = function (card)
    {
        arrCards.push(card);
    }


}