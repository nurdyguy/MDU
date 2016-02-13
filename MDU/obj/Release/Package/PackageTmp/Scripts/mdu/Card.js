

function Card(args)
{
    var number, suit, isUsed;

    


    this.GetNumber = function ()
    {
        return number;
    }

    this.SetNumber = function (n)
    {
        if (n in GC_CardNums)
            number = n;
        else
            return false
    }

    this.GetSuit = function ()
    {
        return suit;
    }

    this.SetSuit = function (s)
    {
        if (s in GC_Suits)
            suit = s;
        else
            return false;
    }

    this.GetIsUsed = function ()
    {
        return isUsed;
    }

    this.SetIsUsed = function (used)
    {
        if (typeof used == 'boolean')
            isUsed = used;
        else
            return false;
    }

    
    if (typeof args.number != 'undefined')
        this.SetNumber(args.number);

    if (typeof args.suit != 'undefined')
        this.SetSuit(args.suit);

    if (typeof args.isUsed != 'undefined')
        this.SetIsUsed(args.isUsed);
}


























