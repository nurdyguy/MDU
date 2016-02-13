


var timer;

function Game()
{
    this.handNames = ['High Card', 'Pair', 'Two Pair', 'Trips', 'Straight', 'Flush', 'Boat!', 'Quads!!', 'Holy Crap!!!'];
    var arrPlayers = [];

    var deck = new Deck();

    var arrCommCards = [];

    var startHands = [];

    var trackPlayer = 0;

    var tracker = [];

    this.statsTable = [];

    this.GetPlayer = function(playerNum)
    {
        return arrPlayers[playerNum];
    }

    this.GetArrPlayers = function ()
    {
        return arrPlayers;
    }

    // clears out old array of players and sets new array of length num
    this.SetArrPlayers = function(num)
    {
        arrPlayers = [];
        for (var i = 0; i < num; i++)
            arrPlayers.push(new Player());
    }

    this.GetDeck = function()
    {
        return deck;
    }

    this.GetCommCards = function ()
    {
        return arrCommCards;
    }

    this.SetCommCards = function (commCards)
    {
        arrCommCards = [];
        if (typeof commCards != 'undefined' && commCards != null)
            for (var c in commCards)
                arrCommCards.push(c);
    }

    this.GetStartHands = function ()
    {
        return startHands;
    }

    this.ResetStartHands = function()
    {
        starthands = [];
    }

    this.GetTracker = function ()
    {
        return tracker;
    }

    this.GetTrackPlayer = function ()
    {
        return trackPlayer;
    }

    this.SetTrackPlayer = function (player)
    {
        trackPlayer = player;
    }

    this.GetStatsTable = function ()
    {
        //return statsTable;
    }

    this.Init();
}

Game.prototype.Init = function ()
{
    this.SetArrPlayers(10);
    var tracker = this.GetTracker();
    //var statsTable = this.GetStatsTable();
    var $row;
    $('#tableHandTracker').find('tbody').find('tr').each(function()
    {
        $row = $(this);
        tracker.push({ 'row': $row, 'win': $row.find('td').eq(1), 'lose': $row.find('td').eq(2), 'tie': $row.find('td').eq(3), 'perc': $row.find('td').eq(4) });
    });

    for (var h in this.handNames)
    {
        this.statsTable.push({ 'win': 0, 'lose': 0, 'tie': 0 });
    }
    this.statsTable['overall'] = { 'win': 0, 'lose': 0, 'tie': 0 };

    this.BindEvents();
}

Game.prototype.BeginSimulation = function (turns)
{
    
    if (turns > 100)
        $('#divProgressBarModal').show();
   
    timer = new Date();
    
    this.SimulationRound(0, turns);

}

Game.prototype.SimulationRound = function (roundNum, turns)
{
    var self = this;
    var interval = turns / 100;
    var winners;

    setTimeout(function ()
    {
        //self.ResetGameTable();
        self.ResetRound();

        self.GetDeck().Shuffle();
        self.GetDeck().DealHand(self.GetArrPlayers(), self.GetCommCards());

        winners = self.CalculateWinner();

        if (roundNum%interval == 0)
        {
            self.UpdateTable();
            self.DisplayWinner(winners);

            $('#divProgressBar').width(roundNum/interval + '%');
        }
        self.UpdateStatTable(winners);
        roundNum++;
        if (roundNum < turns)
            self.SimulationRound(roundNum, turns);
        else
        {
            $('#divProgressBar').width('0%');
            $('#divProgressBarModal').hide();
            console.log('game timer: ' + (new Date() - timer));
        }
    }, 1);
}

// sets up for another round but reasserts StartHands
Game.prototype.ResetRound = function ()
{
    var arrPlayers = this.GetArrPlayers();
    var startHands = this.GetStartHands();
    var cards = [];

    this.SetCommCards([]);
    for (var p in arrPlayers)
        arrPlayers[p].SetCards([]);
  
    for (var p in startHands)
    {
        cards = [];
        for (var c in startHands[p])
            cards.push(startHands[p][c]);
        arrPlayers[p].SetCards(cards);
    }

    $('#gameMessage').hide();
    $('div.winner').removeClass('winner');
}

Game.prototype.ResetGameTable = function (str)
{
    $('#gameMessage').hide();
    $('div.winner').removeClass('winner');

    if (str == 'complete')
    {
        this.SetPlayers(10);
        $('#playerNumSelect').val(10);

        $('#iterSelect').val(1);
        
        this.ResetStartHands();        
        this.SetCommCards(null);
        this.ResetModal_HandPicker();
        this.ResetStatTable();

        this.UpdateTable();
    }

}

Game.prototype.ResetStatTable = function ()
{
    this.SetTrackPlayer(0)
    $('#playerTrackerSelect').val(0);

    this.statsTable = [];
    for (var h in this.handNames)
    {
        this.statsTable.push({ 'win': 0, 'lose': 0, 'tie': 0 });
    }
    this.statsTable['overall'] = { 'win': 0, 'lose': 0, 'tie': 0 };
    
    $('#tableHandTracker').find('tr').each(function ()
    {
        $(this).find('td:gt(0)').text('-');
    });
}


Game.prototype.ResetGame = function ()
{



}

Game.prototype.DealCards = function (args)
{
    // convert array of playerNum to array of player objects
    var arrPlayers = this.GetArrPlayers();
    var players = [];
    for (var p in args.players)
        players.push(arrPlayers[args.players[p]]);

    this.GetDeck().DealCards({ 'arrPlayers': players, 'arrCards': args.cards });
}

Game.prototype.UpdateStartingHands = function (args)
{
    // convert array of playerNum to array of player objects
    var startHands = this.GetStartHands();
    var arrPlayers = this.GetArrPlayers();
    var players = [];
    
    for (var p in args.players)
    {
        startHands[args.players[p]] = [];
        players.push(arrPlayers[args.players[p]]);
        for (var c in args.cards)
            startHands[args.players[p]].push(args.cards[c]);
    }

    this.GetDeck().DealCards({ 'arrPlayers': players, 'arrCards': args.cards });
}

Game.prototype.UpdateTable = function ()
{
    var arrPlayers = this.GetArrPlayers();
    var arrCommCards = this.GetCommCards();
    var cardsInUse = [];
    for (var i = 0; i < arrPlayers.length; i++)
    {
        var $player = $('#handPlayer' + (i + 1));
        var html = ''
        switch (arrPlayers[i].GetCards().length)
        {
            case 0:
                $player.addClass('cardsDown');
                html = '<img class="cardsDown" src="../../Images/card_back_sm2.png" />';
                break;
            case 1:
                $player.removeClass('cardsDown');
                var src = '../../Images/' + arrPlayers[i].GetCards()[0] + '.png';
                html = '<img class="card" src="' + src + '" />';
                html += '<img class="card" src="../../Images/card_back_sm.png" />';
                cardsInUse.push(arrPlayers[i].GetCards()[0]);
                break;
            case 2:
                $player.removeClass('cardsDown');
                var src = '../../Images/' + arrPlayers[i].GetCards()[0] + '.png';
                html = '<img class="card" src="' + src + '" />';
                src = '../../Images/' + arrPlayers[i].GetCards()[1] + '.png';
                html += '<img class="card" src="' + src + '" />';
                cardsInUse.push(arrPlayers[i].GetCards()[0]);
                cardsInUse.push(arrPlayers[i].GetCards()[1]);
                break;
        }
        $player.find('div.hand').html(html);
    }

    for (var i = 0; i < cardsInUse.length; i++)
    {
        var $card = $('img.card[card="' + cardsInUse[i] + '"]');
        $card.addClass('inUse');
        $card.attr('src', '../../Images/card_back_sm.png');
    }

    var $commCards = $('#commCards');
    for (var i = 0; i < arrCommCards.length; i++)
    {
        var src = '../../Images/' + arrCommCards[i] + '.png';
        $commCards.find('img.card').eq(i).attr('src', src);
    }
    for (var i = arrCommCards.length; i < 5; i++)
    {
        $commCards.find('img.card').eq(i).attr('src', '../../Images/card_back_sm.png');
    }
}

Game.prototype.CalculateWinner = function ()
{
    var arrPlayers = this.GetArrPlayers();
    var arrWinners = [];
    var commCards = this.GetCommCards();

    var highScore = 0;
    var handScore = 0;

    var hand = [];

    for (var i = 0; i < arrPlayers.length; i++)
    {
        hand = [];
        for (var j = 0; j < commCards.length; j++)
            hand.push({'suit': commCards[j].substring(commCards[j].length - 1),
                        'num': parseInt(commCards[j])
            });

        for(var j in arrPlayers[i].GetCards())
            hand.push({'suit': arrPlayers[i].GetCards()[j].substring(arrPlayers[i].GetCards()[j].length - 1),
                        'num': parseInt(arrPlayers[i].GetCards()[j])
            });

        handScore = this.CalculateHandScore(hand)
        if (handScore == highScore)
        {
            highScore = handScore;
            arrWinners.push(i+1);
        }
        else if (handScore > highScore)
        {
            highScore = handScore;
            arrWinners = [i+1];
        }
    }

    //console.log('Winner:   Player ' + arrWinners);
    //console.log('Winning Hand: ' + highScore);
    return { 'players': arrWinners, 'score': highScore }
}

Game.prototype.DisplayWinner = function (winners)
{
    
    var winText = '';
    for (var i = 0; i < winners.players.length; i++)
    {        
        winText = ' ' + winners.players[i];
        $('#handPlayer' + (winners.players[i])).addClass('winner');

        if (i < winners.players.length - 1)
            winText = ' and ';        
    }
    $('#winningPlayer').text(winText);
    $('#winningHand').text(this.handNames[parseInt(winners.score/10000000000, 10)]);
    $('#gameMessage').show();
}

Game.prototype.UpdateStatTable = function (winners)
{
    //timer = new Date();
    // win/lose/tie/perc
    var result = 'lose';
    var scoreRow = 0;
    var tracker = this.GetTracker();
    //var statsTable = this.GetStatsTable();
    var statsTable = this.statsTable;
    var wins, losses, ties;

    if (winners.players.length == 1)
    {
        if (winners.players[0] == this.GetTrackPlayer() + 1)
            result = 'win';
    }
    else
    {
        for (var i = 0; i < winners.players[i]; i++)
            if (winners.players[i] == this.GetTrackPlayer() + 1)
                result = 'tie';
    }

    
    scoreRow = parseInt(winners.score / 10000000000, 10);

    statsTable['overall'][result]++;
    statsTable[scoreRow][result]++;
    
    tracker[0][result].text(statsTable['overall'][result]);
    tracker[0]['perc'].text((statsTable['overall']['win'] / (statsTable['overall']['win'] + statsTable['overall']['lose'] + statsTable['overall']['tie']) * 100).toFixed(2) + '%');

    tracker[scoreRow + 1][result].text(statsTable[scoreRow][result]);
    tracker[scoreRow + 1]['perc'].text((statsTable[scoreRow]['win'] / (statsTable[scoreRow]['win'] + statsTable[scoreRow]['lose'] + statsTable[scoreRow]['tie']) * 100).toFixed(2) + '%');

    /*
    
    var counter;
        
    counter = tracker[0][result].text();
    if (tracker[0][result].text() == '-')
        counter = 1;
    else
        counter = parseInt(tracker[0][result].text()) + 1;
    tracker[0][result].text(counter);

    if (tracker[0]['win'].text() == '-')
        wins = 0;
    else
        wins = parseInt(tracker[0]['win'].text());
    if (tracker[0]['lose'].text() == '-')
        losses = 0;
    else
        losses = parseInt(tracker[0]['lose'].text());
    if (tracker[0]['tie'].text() == '-')
        ties = 0;
    else
        ties = parseInt(tracker[0]['tie'].text());
    tracker[0]['perc'].text( (wins/(wins+losses+ties)*100).toFixed(2) + '%');

    counter = tracker[scoreRow][result].text();
    if (counter == '-')
        counter = 1;
    else
        counter = parseInt(tracker[scoreRow][result].text()) + 1;

    tracker[scoreRow][result].text(counter);
    if (tracker[scoreRow]['win'].text() == '-')
        wins = 0;
    else
        wins = parseInt(tracker[scoreRow]['win'].text());
    if (tracker[scoreRow]['lose'].text() == '-')
        losses = 0;
    else
        losses = parseInt(tracker[scoreRow]['lose'].text());
    if (tracker[scoreRow]['tie'].text() == '-')
        ties = 0;
    else
        ties = parseInt(tracker[scoreRow]['tie'].text());
    tracker[scoreRow]['perc'].text( (wins /(wins + losses + ties) * 100).toFixed(2) + '%');
    */

    //console.log('table timer: ' + (new Date() - timer));
}

Game.prototype.CalculateHandScore = function (hand)
{
    var score = 0;
    var HandCheck = [this.CheckStrFlush, this.CheckFourKind, this.CheckFullHouse,
                        this.CheckFlush, this.CheckStr, this.CheckThreeKind,
                        this.CheckTwoPair, this.CheckPair, this.CheckHighCard];

    // sorts by num desc, then by suit asc
    hand = hand.sort(function (a, b)
    {
        if (a.num < b.num) return 1;
        if (a.num > b.num) return -1;
        //if (a.suit < b.suit) return -1;
        //if (a.suit > b.suit) return 1;
        return 0;
    });

    str = '';
    for (var i = 0; i < hand.length; i++)
        str += hand[i]['num'] + '' + hand[i]['suit'] + '  ';
    //console.log(str);

    for(var i = 0; i < HandCheck.length && score == 0; i++)
    {
        score = HandCheck[i](hand);
        
    }
    return score;
}

Game.prototype.CheckStrFlush = function (hand)
{
    var self = game;
    var score = 0;
    var flush, str;

    flush = self.FindFlush(hand);
    if (flush.length > 0)
    {
        str = self.FindFirstStr(flush);
        if (str.num > 0)
        {
            score = 80000000000;
            score += str.num * 100000000;
            //debugger;
            /*
            var str = 'Holy Crap: ';
            for(var i = 0; i < hand.length; i++)
                str += hand[i].num + hand[i].suit + ' ';
            console.log(str);
            */
        }
    }

    return score;
}

Game.prototype.CheckFourKind = function (hand)
{
    var self = game;
    var score = 0;
    var quad;
    var cardsLeft = 1;
    var tmpHand = [];

    for (var i = 0; i < hand.length; i++)
        tmpHand.push(hand[i]);
    
    quad = self.FindFirstQuad(tmpHand);
    if (quad.num > 0)
    {
        score = 70000000000;
        score += quad.num * 100000000;
        tmpHand.splice(quad.pos, 4);
        score += self.FindHighCard(tmpHand, cardsLeft);
    }
    return score;
}

Game.prototype.CheckFullHouse = function (hand)
{
    var self = game;
    var score = 0;
    var trip, pair;
    var tmpHand = [];

    for (var i = 0; i < hand.length; i++)
        tmpHand.push(hand[i]);
 
    trip = self.FindFirstTrip(tmpHand);
    if (trip.num > 0)
    {       
        tmpHand.splice(trip.pos, 3);
        pair = self.FindFirstPair(tmpHand);
        if (pair.num > 0)
        {           
            score = 60000000000;
            score += trip.num * 100000000;
            score += pair.num * 1000000;
        }
    }
    return score;
}

Game.prototype.CheckFlush = function (hand)
{
    var self = game;
    var score = 0;
    var flush;

    flush = self.FindFlush(hand);
    if (flush.length > 0)
    {
        score = 50000000000;
        score += self.FindHighCard(flush, 5);
    }

    return score;
}

Game.prototype.CheckStr = function (hand)
{
    var self = game;
    var score = 0;
    var str;

    str = self.FindFirstStr(hand);
    if(str.num > 0)
    {
        score = 40000000000;
        score += str.num * 100000000;
    }

    // still need check for wheel
    return score;
}

Game.prototype.CheckThreeKind = function (hand)
{
    var self = game;
    var score = 0;
    var trip;
    var cardsLeft = 2;
    var tmpHand = [];

    for (var i = 0; i < hand.length; i++)
        tmpHand.push(hand[i]);

    trip = self.FindFirstTrip(tmpHand);
    if (trip.num > 0)
    {
        score = 30000000000;
        score += trip.num * 100000000;
        tmpHand.splice(trip.pos, 3);
        score += self.FindHighCard(tmpHand, cardsLeft);
    }

    return score;
}

Game.prototype.CheckTwoPair = function (hand)
{
    var self = game;
    var score = 0;
    var pair1, pair2;
    var cardsLeft = 1;
    var tmpHand = [];
    
    for(var i = 0; i < hand.length; i++)
        tmpHand.push(hand[i]);

    pair1 = self.FindFirstPair(tmpHand);
    if (pair1.num > 0)
    {
        tmpHand.splice(pair1.pos, 2);
        pair2 = self.FindFirstPair(tmpHand);
        if (pair2.num > 0)
        {
            score = 20000000000;
            score += pair1.num * 100000000;
            score += pair2.num * 1000000;

            tmpHand.splice(pair2.pos, 2);
            score += self.FindHighCard(tmpHand, cardsLeft);
        }
    }

    return score;
}

Game.prototype.CheckPair = function (hand)
{
    var self = game;
    var score = 0;
    var pair;
    var cardsLeft = 3;
    var tmpHand = [];

    for (var i = 0; i < hand.length; i++)
        tmpHand.push(hand[i]);

    pair = self.FindFirstPair(tmpHand);
    if(pair.num > 0)
    {
        score = 10000000000;
        score += pair.num * 100000000;

        tmpHand.splice(pair.pos, 2);
        score += self.FindHighCard(tmpHand, cardsLeft);
    }
    
    return score;
}

Game.prototype.CheckHighCard = function (hand)
{
    var self = game;
    var score = 0;

    score = self.FindHighCard(hand, 5);

    return score;
}

// assumes no more pair/trips left --- hand may be only partial
Game.prototype.FindHighCard = function (hand, numCards)
{
    var score = 0;
    var cardsLeft = numCards;

    if (typeof numCards == 'undefined' || numCards == null)
        cardsLeft = 5;
  
    for (var i = 0; i < hand.length && cardsLeft > 0; i++)
    {
        score += hand[i].num * Math.pow(100, cardsLeft - 1);
        cardsLeft--;
    }

    return score;
}

Game.prototype.FindFirstPair = function (hand)
{
    for (var i = 0; i < hand.length - 1; i++)
        if (hand[i].num == hand[i+1].num)
        {
            return { 'num': hand[i].num, 'pos': i };
        }  
    return { 'num': 0, 'pos': 0 };
}

Game.prototype.FindFirstTrip = function (hand)
{
    for (var i = 0; i < hand.length - 2; i++)
        if (hand[i].num == hand[i+1].num && hand[i].num == hand[i+2].num)
        {
            return { 'num': hand[i].num, 'pos': i };
        }
    return { 'num': 0, 'pos': 0 };
}

Game.prototype.FindFirstStr = function (hand)
{
    var inARow = 0;
    var failed = false;
    var passed = false;
    var start = 0;

    var i = start;
    while (start + 4 < hand.length && !passed)
    {
        i = start;
        failed = false;
        inARow = 0;
        while (i + 1 < hand.length && !failed && inARow < 4)
        {
            switch (hand[i].num - hand[i + 1].num)
            {
                case 0:
                    i++;
                    break;
                case 1:
                    inARow++
                    i++;
                    break;
                default:
                    failed = true;
                    start = i + 1;
            }
        }
        if (inARow == 4)
        {
            passed = true;
        }
        else
        {
            start = i + 1;
        }
    }
    if (passed)
    {
        return { 'num': hand[start].num, 'pos': start };
    }

    // if not a normal straight, check for wheel
    return this.FindWheel(hand);
}

Game.prototype.FindWheel = function(hand)
{
    var found = false;
    var pos;
    // first card has to be Ace and last card a 2
    if (hand[0].num == 14 && hand[hand.length - 1].num == 2)
    {
        // look for 5 -- cant be in first or last 3 spots
        for (var i = 1; i < hand.length - 3 && !found; i++)
            if (hand[i].num == 5)
                found = true;
        if(!found)
            return { 'num': 0, 'pos': 0 };
        pos = i;
        // look for 4 -- cant be in first 2 or last 2 spots
        found = false;
        for (var i = 2; i < hand.length - 2 && !found; i++)
            if (hand[i].num == 4)
                found = true;
        if(!found)
            return { 'num': 0, 'pos': 0 };

        // look for 3 -- cant be in first 3 or last 1 spots
        found = false;
        for (var i = 3; i < hand.length - 1 && !found; i++)
            if (hand[i].num == 3)
                found = true;
        if(!found)
            return { 'num': 0, 'pos': 0 };

        //got to here so passed
        return { 'num': 5, 'pos': pos };
    }
    return { 'num': 0, 'pos': 0 };
}

Game.prototype.FindFlush = function(hand)
{
    var suits = {}
    suits['C'] = [];
    suits['D'] = [];
    suits['H'] = [];
    suits['S'] = [];
   
    for (var i = 0; i < hand.length; i++)
    {
        suits[hand[i].suit].push(hand[i]);
    }

    for (var s in suits)
        if (suits[s].length >= 5)
            return suits[s];

    return [];
}

Game.prototype.FindFirstQuad = function (hand)
{
    for (var i = 0; i < hand.length - 3; i++)
        if (hand[i].num == hand[i + 1].num
            && hand[i].num == hand[i + 2].num
            && hand[i].num == hand[i + 3].num)
        {
            return { 'num': hand[i].num, 'pos': i };
        }
    return { 'num': 0, 'pos': 0 };
}








Game.prototype.BindEvents = function ()
{

    var self = this;
    $('#divGameBoard').on('click', 'div.playerHand', function (e)
    {       
        switch (e.target.nodeName)
        {
            case 'DIV':
                self.ShowModal_HandPicker(e.target);
                break;
            case 'IMG':
                self.ShowModal_HandPicker(e.target.parentNode.parentNode);
                break;    
            case 'H6':
                self.ShowModal_HandPicker(e.target.parentNode);
                break;
            default:
        }


    });

    $('#divDeck').on('click', 'img.card', function (e)
    {       
        var $target = $(e.target);
        if (!$target.hasClass('inUse'))
        {
            if ($target.hasClass('selected'))
                $target.removeClass('selected');
            else
                if ($('#divDeck').find('img.card.selected').length < 2)
                    $target.addClass('selected');
        }
    });


}

Game.prototype.SetPlayers = function (num)
{
    num = parseInt(num);
    this.SetArrPlayers(num);
    this.ResetGame();
       
    for (var i = 1; i < 11; i++)
        if(i <= num)
            $('#handPlayer' + i).show();
        else
            $('#handPlayer' + i).hide();
}


Game.prototype.ShowModal_HandPicker = function(target)
{
    var playerNum = $(target).attr('id').substring(10);

    var cards = this.GetPlayer(playerNum - 1).GetCards();
    
    for(var i = 0; i < cards.length; i++)
    {
        var $card = $('img.card.inUse[card="' + cards[i] + '"]');
        $card.removeClass('inUse');
        $card.attr('src', '../../Images/' + cards[i] + '.png');
        $card.addClass('selected');
    }


    $('#spanPlayerNumber').text(playerNum);
    $('#divHandPickerModal').show();

}

Game.prototype.CloseModal_HandPicker = function (cmd)
{
    if (cmd == 'save')
    {
        var arrChosenCards = [];
        var playerNum = parseInt($('#spanPlayerNumber').text(), 10) - 1;
        
        $('#divDeck').find('img.card.selected').each(function ()
        {
            arrChosenCards.push($(this).attr('card'));
        });
        
        //this.DealCards();

        this.UpdateStartingHands({ 'cards': arrChosenCards, 'players': [playerNum] });
    }
    else
    {

    }
    
    
    this.UpdateTable();
    $('#divDeck').find('img.card.selected').removeClass('selected');
    $('#divHandPickerModal').hide();

}

Game.prototype.ResetModal_HandPicker = function ()
{
    var $this;
    $('#divDeck').find('img.card.inUse').each(function ()
    {
        $this = $(this);
        $this.attr('src', '../../Images/' + $this.attr('card') + '.png');
        $this.removeClass('inUse');
    });
}

