

function StatInterface()
{
    this.players = [];

    this.deck = new Deck();

    this.commCards = [];

    this.startHands = [];

    this.deadCards = [];

    this.activePlayers = 0;

    // clears out old array of players and sets new array of length num
    this.ResetPlayers = function (num)
    {
        this.players = [];
        this.activePlayers = num;
        for (var i = 0; i < num; i++)       
            this.players.push(new Player());
    }
        
    this.ResetDeck = function ()
    {
        this.deck = new Deck();
    }

    this.ResetStartHands = function ()
    {
        this.starthands = [];
    }
    this.$idPrefix = '#divStatInterface ';
    this.Init();   
}

StatInterface.prototype.Init = function ()
{
    this.ResetPlayers(10);
    this.BindEvents();
}

StatInterface.prototype.DealCards = function (args)
{
    // convert array of playerNum to array of player objects
    var arrPlayers = this.players;
    var players = [];
    for (var p in args.players)
        players.push(arrPlayers[args.players[p]]);

    this.GetDeck().DealCards({ 'arrPlayers': players, 'arrCards': args.cards });
}

StatInterface.prototype.ResetTable = function ()
{
    ////$('#gameMessage').hide();
    ////$('div.winner').removeClass('winner');

    //this.SetPlayers(10);
    //$(this.$idPrefix +  '#playerNumSelect').val(10);

    //this.ResetStartHands();
    //this.SetCommCards(null);
    //this.ResetModal_HandPicker();

    //this.UpdateTable();
}

StatInterface.prototype.UpdateTable = function ()
{
    var players = this.players;
    var commCards = this.commCards;
    var cardsInUse = [];
    var allCards = this.deck.deckCards;
    for (var i = 0; i < players.length; i++)
    {
        var $player = $('#handPlayer' + (i + 1));
        var html = ''
        switch (players[i].playerCards.length)
        {
            case 0:
                $player.addClass('cardsDown');
                html = '<img class="cardsDown" src="../../Images/card_back_sm2.png" />';
                break;
            case 1:
                $player.removeClass('cardsDown');
                var src = '../../Images/' + allCards[players[i].playerCards[0]].shortName + '.png';
                html = '<img class="card" src="' + src + '" />';
                html += '<img class="card" src="../../Images/card_back_sm.png" />';
                cardsInUse.push(players[i].playerCards[0]);
                break;
            case 2:
                $player.removeClass('cardsDown');
                var src = '../../Images/' + allCards[players[i].playerCards[0]].shortName + '.png';
                html = '<img class="card" src="' + src + '" />';
                src = '../../Images/' + allCards[players[i].playerCards[1]].shortName + '.png';
                html += '<img class="card" src="' + src + '" />';
                cardsInUse.push(players[i].playerCards[0]);
                cardsInUse.push(players[i].playerCards[1]);
                break;
        }
        $player.find('div.hand').html(html);
    }

    for (var i = 0; i < cardsInUse.length; i++)
    {
        var $card = $('img.card[cardId="' + cardsInUse[i] + '"]');
        $card.addClass('inUse');
        $card.attr('src', '../../Images/card_back_sm.png');
    }

    var $commCards = $('#commCards');
    for (var i = 0; i < commCards.length; i++)
    {
        var src = '../../Images/' + arrCommCards[i] + '.png';
        $commCards.find('img.card').eq(i).attr('src', src);
    }
    for (var i = commCards.length; i < 5; i++)
    {
        $commCards.find('img.card').eq(i).attr('src', '../../Images/card_back_sm.png');
    }
}

StatInterface.prototype.UpdateStartingHand = function (args)
{
    
    var players = [];

    for (var c in this.startHands[args.playerId])
        this.deck;
    this.startHands[args.playerId] = [];
    players.push(this.players[args.playerId]);
    for (var c in args.cardIds)
        this.startHands[args.playerId].push(args.cardIds[c]);
    

    this.deck.DealCards(players,args.cardIds);
}

StatInterface.prototype.BindEvents = function ()
{

    var self = this;
    $(this.$idPrefix + '#divGameBoard').on('click', 'div.playerHand', function (e)
    {
        var $target = $(e.target);
        if ($target[0].nodeName == 'A')
            return;
        
        self.ShowModal_HandPicker($target.closest('div.playerHand'));
    });

    $(this.$idPrefix + '#divDeck').on('click', 'img.card', function (e)
    {
        var $target = $(e.target);
        var $deck = $target.closest('div#divDeck');
        var $modal = $(self.$idPrefix + '#divHandPickerModal');
        if (!$target.hasClass('inUse'))
        {
            if ($target.hasClass('selected'))
                $target.removeClass('selected');
            else
                if ($modal.attr('data-type') == 'player')
                    if ($deck.find('img.card.selected').length < 2)
                        $target.addClass('selected');
                    else
                    {

                        $modal.find('span.modalWarning').fadeIn(500, function ()
                        {
                            $(this).fadeOut(500, function ()
                            {
                                $(this).fadeIn(500, function ()
                                {
                                    $(this).fadeOut(500, function ()
                                    {
                                        $(this).fadeIn(500, function ()
                                        {
                                            $(this).fadeOut(500);
                                        });
                                    });
                                });
                            });
                        });                        
                    }
                else
                {

                }
        }
    });

    $(this.$idPrefix + '#divHandPickerModal .btn-primary').on('click', function () { self.CloseModal_HandPicker('save'); });
    $(this.$idPrefix + '#divHandPickerModal .btn-default, ' + this.$idPrefix + '#divHandPickerModal .close').on('click', function () { self.CloseModal_HandPicker('cancel'); });
    $(this.$idPrefix + '#playerNumSelect').on('change', function () { self.SetPlayers($(this).val()); });
    $(this.$idPrefix + '#getStats').on('click', function () { self.GetHandStats($(this).val()) });
    
    $('a.popoverData').popover({ html: true });

}

StatInterface.prototype.SetPlayers = function (num)
{
    num = parseInt(num);
    this.activePlayers = num;
    var players = this.players;

    for (var i = 1; i < 11; i++)
    {
        if (i <= num)
        {
            $('#handPlayer' + i).show();
            //this.UpdateStartingHand({ 'cardIds': players[i-1].playerCards, 'playerId': i-1 });
        }
        else
        {
            $('#handPlayer' + i).hide();
            for (var j = 0; j < players[i - 1].playerCards.length; j++)
            {
                this.deck.deckCards[players[i - 1].playerCards[j]].isUsed = false;
                var cardId = players[i - 1].playerCards[j];
                $('img.card.inUse[cardId="' + cardId + '"]').removeClass('.inUse').attr('src', '../../Images/' + this.deck.deckCards[cardId].shortName + '.png');
            }
            players[i - 1].playerCards = [];
        }
    }
    this.UpdateTable();
}

StatInterface.prototype.ShowModal_HandPicker = function ($target)
{
    var playerId = parseInt($target.attr('playerId'));

    var cards = this.players[playerId].playerCards;
    var allCards = this.deck.deckCards;
    for (var i = 0; i < cards.length; i++)
    {
        var $card = $('img.card.inUse[cardId="' + cards[i] + '"]');
        $card.removeClass('inUse');
        $card.attr('src', '../../Images/' + allCards[cards[i]].shortName + '.png');
        $card.addClass('selected');
    }


    $('#spanPlayerNumber').text((playerId + 1))
    $(this.$idPrefix + '#divHandPickerModal').attr('data-type', 'player');
    $('#divHandPickerModal').show();

}

StatInterface.prototype.CloseModal_HandPicker = function (cmd)
{
    if (cmd == 'save')
    {
        var playerId = parseInt($('#spanPlayerNumber').text(), 10) - 1;
        this.players[playerId].playerCards = [];
        var self = this;
        $('#divDeck').find('img.card.selected').each(function ()
        {
            var $this = $(this);
            var cardId = parseInt($this.attr('cardId'));
            self.players[playerId].playerCards.push(cardId);
            self.deck.deckCards[cardId].isUsed = true;
            $this.removeClass('selected').addClass('inUse');
        });
    }
    else
    {
        $('#divDeck').find('img.card.selected').removeClass('selected');
    }
    this.UpdateTable();    
    $('#divHandPickerModal').hide();
}

StatInterface.prototype.ResetModal_HandPicker = function ()
{
    var $this;
    $('#divDeck').find('img.card.inUse').each(function ()
    {
        $this = $(this);
        $this.attr('src', '../../Images/' + $this.attr('card') + '.png');
        $this.removeClass('inUse');
    });
}

StatInterface.prototype.GetHandStats = function ()
{
    // validate
    var startHands = [];
    for (var i = 0; i < this.activePlayers; i++)
    {
        if (this.players[i].playerCards.length == 2)
        {
            startHands.push(this.players[i].playerCards);
        }
        else
        {
            alert('Each player must have 2 cards');
            return;
        }
    }
    
    var request =
    {
        'NumPlayers'    :   this.activePlayers,
        'HandCardIds'   :   startHands,
        'DeadCards'     :   this.deadCards,
        'BoardCards'    :   this.commCards
    };
    var self = this;
    $('#runningOverlay').show();
    $.ajax(
    {
        url: '/poker/GetHandStats',
        type: "POST",
        async: true,
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(request),
        success: function (retObj)
        {
            self.DisplayResults(retObj);
        },
        error: function (retObj)
        {
            alert('error');
        },
        complete: function ()
        {
            $('#runningOverlay').hide();
        }
    });
}

StatInterface.prototype.DisplayResults = function (result)
{
    var str = '';
        
    for (var i = 0; i < result.NumWins.length; i++)
    {
        str = 'Won: ' + numberWithCommas(result.HandStats[i].wins) 
            + '<br>Lost: ' + numberWithCommas(result.TotalHands - result.HandStats[i].wins - result.HandStats[i].chops) 
            + '<br>Chopped: ' + numberWithCommas(result.HandStats[i].chops);
        $('#handPlayer' + (i + 1)).find('a.popoverData').attr('data-content', str).html('&nbsp;' + (result.HandStats[i].wins * 100 / result.TotalHands).toFixed(1) + '% ').show();
    }
}


