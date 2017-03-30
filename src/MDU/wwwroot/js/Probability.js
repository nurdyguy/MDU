

// This file holds the basic overall javascript for Poker/Probability.cshtml view

var game;
// onload
$(function ()
{
    game = new Game();

});


function Game()
{
    var arrPlayers = [];

    var deck = new Deck();

    var arrCommCards = [];

    var startHands = [];

    var trackPlayer = 0;

    var tracker = [];

    this.statsTable = [];

    this.GetPlayer = function (playerNum)
    {
        return arrPlayers[playerNum];
    }

    this.GetArrPlayers = function ()
    {
        return arrPlayers;
    }

    // clears out old array of players and sets new array of length num
    this.SetArrPlayers = function (num)
    {
        arrPlayers = [];
        for (var i = 0; i < num; i++)
            arrPlayers.push(new Player());
    }

    this.GetDeck = function ()
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

    this.ResetStartHands = function ()
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
    this.SetArrPlayers(2);
    //var statsTable = this.GetStatsTable();
    
    this.BindEvents();
}

Game.prototype.BeginSimulation = function (turns)
{

    if (turns > 100)
        $('#divProgressBarModal').show();

    timer = new Date();

    //this.SimulationRound(0, turns);
    //---------------------------------------------
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
        if (i <= num)
            $('#handPlayer' + i).show();
        else
            $('#handPlayer' + i).hide();
}


Game.prototype.ShowModal_HandPicker = function (target)
{
    var playerNum = $(target).attr('id').substring(10);

    var cards = this.GetPlayer(playerNum).GetCards();

    for (var i = 0; i < cards.length; i++)
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






