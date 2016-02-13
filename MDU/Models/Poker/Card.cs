using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MDU.Models;

namespace MDU.Models.Poker
{
    public class Card : EnumClass
    {
        private int _id;
        private Suit _suit;
        private int _number;
        private string _shortName;
        private string _name;
        private string _image;

        #region CardEnum
        public static readonly Card Club2 = new Card(0, Suit.Clubs, 2, "2c", "2 of clubs", "Images/2C.png");
        public static readonly Card Club3 = new Card(1, Suit.Clubs, 3, "3c", "3 of clubs", "Images/3C.png");
        public static readonly Card Club4 = new Card(2, Suit.Clubs, 4, "4c", "4 of clubs", "Images/4C.png");
        public static readonly Card Club5 = new Card(3, Suit.Clubs, 5, "5c", "5 of clubs", "Images/5C.png");
        public static readonly Card Club6 = new Card(4, Suit.Clubs, 6, "6c", "6 of clubs", "Images/6C.png");
        public static readonly Card Club7 = new Card(5, Suit.Clubs, 7, "7c", "7 of clubs", "Images/7C.png");
        public static readonly Card Club8 = new Card(6, Suit.Clubs, 8, "8c", "8 of clubs", "Images/8C.png");
        public static readonly Card Club9 = new Card(7, Suit.Clubs, 9, "9c", "9 of clubs", "Images/9C.png");
        public static readonly Card Club10 = new Card(8, Suit.Clubs, 10, "10c", "10 of clubs", "Images/10C.png");
        public static readonly Card Club11 = new Card(9, Suit.Clubs, 11, "Jc", "Jack of clubs", "Images/11C.png");
        public static readonly Card Club12 = new Card(10,Suit.Clubs, 12, "Qc", "Queen of clubs", "Images/12C.png");
        public static readonly Card Club13 = new Card(11,Suit.Clubs, 13, "Kc", "King of clubs", "Images/13C.png");
        public static readonly Card Club14 = new Card(12,Suit.Clubs, 14, "Ac", "Ace of clubs", "Images/14C.png");
        public static readonly Card Diamond2 = new Card(13, Suit.Diamonds, 2, "2d", "2 of diamonds", "Images/2D.png");
        public static readonly Card Diamond3 = new Card(14, Suit.Diamonds, 3, "3d", "3 of diamonds", "Images/3D.png");
        public static readonly Card Diamond4 = new Card(15, Suit.Diamonds, 4, "4d", "4 of diamonds", "Images/4D.png");
        public static readonly Card Diamond5 = new Card(16, Suit.Diamonds, 5, "5d", "5 of diamonds", "Images/5D.png");
        public static readonly Card Diamond6 = new Card(17, Suit.Diamonds, 6, "6d", "6 of diamonds", "Images/6D.png");
        public static readonly Card Diamond7 = new Card(18, Suit.Diamonds, 7, "7d", "7 of diamonds", "Images/7D.png");
        public static readonly Card Diamond8 = new Card(19, Suit.Diamonds, 8, "8d", "8 of diamonds", "Images/8D.png");
        public static readonly Card Diamond9 = new Card(20, Suit.Diamonds, 9, "9d", "9 of diamonds", "Images/9D.png");
        public static readonly Card Diamond10 = new Card(21, Suit.Diamonds, 10, "10d", "10 of diamonds", "Images/10D.png");
        public static readonly Card Diamond11 = new Card(22, Suit.Diamonds, 11, "Jd", "Jack of diamonds", "Images/11D.png");
        public static readonly Card Diamond12 = new Card(23, Suit.Diamonds, 12, "Qd", "Queen of diamonds", "Images/12D.png");
        public static readonly Card Diamond13 = new Card(24, Suit.Diamonds, 13, "Kd", "King of diamonds", "Images/13D.png");
        public static readonly Card Diamond14 = new Card(25, Suit.Diamonds, 14, "Ad", "Ace of diamonds", "Images/14D.png");
        public static readonly Card Heart2 = new Card(26, Suit.Hearts, 2, "2h", "2 of hearts", "Images/2H.png");
        public static readonly Card Heart3 = new Card(27, Suit.Hearts, 3, "3h", "3 of hearts", "Images/3H.png");
        public static readonly Card Heart4 = new Card(28, Suit.Hearts, 4, "4h", "4 of hearts", "Images/4H.png");
        public static readonly Card Heart5 = new Card(29, Suit.Hearts, 5, "5h", "5 of hearts", "Images/5H.png");
        public static readonly Card Heart6 = new Card(30, Suit.Hearts, 6, "6h", "6 of hearts", "Images/6H.png");
        public static readonly Card Heart7 = new Card(31, Suit.Hearts, 7, "7h", "7 of hearts", "Images/7H.png");
        public static readonly Card Heart8 = new Card(32, Suit.Hearts, 8, "8h", "8 of hearts", "Images/8H.png");
        public static readonly Card Heart9 = new Card(33, Suit.Hearts, 9, "9h", "9 of hearts", "Images/9H.png");
        public static readonly Card Heart10 = new Card(34, Suit.Hearts, 10, "10h", "10 of hearts", "Images/10H.png");
        public static readonly Card Heart11 = new Card(35, Suit.Hearts, 11, "Jh", "Jack of hearts", "Images/11H.png");
        public static readonly Card Heart12 = new Card(36, Suit.Hearts, 12, "Qh", "Queen of hearts", "Images/12H.png");
        public static readonly Card Heart13 = new Card(37, Suit.Hearts, 13, "Kh", "King of hearts", "Images/13H.png");
        public static readonly Card Heart14 = new Card(38, Suit.Hearts, 14, "Ah", "Ace of hearts", "Images/14H.png");
        public static readonly Card Spade2 = new Card(39, Suit.Spades, 2, "2s", "2 of spades", "Images/2S.png");
        public static readonly Card Spade3 = new Card(40, Suit.Spades, 3, "3s", "3 of spades", "Images/3S.png");
        public static readonly Card Spade4 = new Card(41, Suit.Spades, 4, "4s", "4 of spades", "Images/4S.png");
        public static readonly Card Spade5 = new Card(42, Suit.Spades, 5, "5s", "5 of spades", "Images/5S.png");
        public static readonly Card Spade6 = new Card(43, Suit.Spades, 6, "6s", "6 of spades", "Images/6S.png");
        public static readonly Card Spade7 = new Card(44, Suit.Spades, 7, "7s", "7 of spades", "Images/7S.png");
        public static readonly Card Spade8 = new Card(45, Suit.Spades, 8, "8s", "8 of spades", "Images/8S.png");
        public static readonly Card Spade9 = new Card(46, Suit.Spades, 9, "9s", "9 of spades", "Images/9S.png");
        public static readonly Card Spade10 = new Card(47, Suit.Spades, 10, "10s", "10 of spades", "Images/10S.png");
        public static readonly Card Spade11 = new Card(48, Suit.Spades, 11, "Js", "Jack of spades", "Images/11S.png");
        public static readonly Card Spade12 = new Card(49, Suit.Spades, 12, "Qs", "Queen of spades", "Images/12S.png");
        public static readonly Card Spade13 = new Card(50, Suit.Spades, 13, "Ks", "King of spades", "Images/13S.png");
        public static readonly Card Spade14 = new Card(51, Suit.Spades, 14, "As", "Ace of spades", "Images/14S.png");
        #endregion

        //[JsonConstructor]
        private Card(int Id, Suit Suit, int Number, string ShortName, string Name, string Image)
        {
            _id = Id;
            _suit = Suit;
            _number = Number;
            _shortName = ShortName;
            _name = Name;
            _image = Image;
        }

        public int Id   { get { return _id; } }
        public Suit Suit { get { return _suit; } }
        public int Number { get { return _number; } }
        public string ShortName { get { return _shortName; } }
        public string Name { get { return _name; } }
        public string Image { get { return _image; } }

        public static SortedList<int, Card> AllCards =         
            new SortedList<int, Card>()
            {
                {Card.Club2.Id,     Card.Club2},
                {Card.Club3.Id,     Card.Club3}, 
                {Card.Club4.Id,     Card.Club4}, 
                {Card.Club5.Id,     Card.Club5}, 
                {Card.Club6.Id,     Card.Club6}, 
                {Card.Club7.Id,     Card.Club7}, 
                {Card.Club8.Id,     Card.Club8}, 
                {Card.Club9.Id,     Card.Club9}, 
                {Card.Club10.Id,    Card.Club10}, 
                {Card.Club11.Id,    Card.Club11},
                {Card.Club12.Id,    Card.Club12}, 
                {Card.Club13.Id,    Card.Club13}, 
                {Card.Club14.Id,    Card.Club14}, 
                {Card.Diamond2.Id,  Card.Diamond2}, 
                {Card.Diamond3.Id,  Card.Diamond3}, 
                {Card.Diamond4.Id,  Card.Diamond4}, 
                {Card.Diamond5.Id,  Card.Diamond5},
                {Card.Diamond6.Id,  Card.Diamond6}, 
                {Card.Diamond7.Id,  Card.Diamond7}, 
                {Card.Diamond8.Id,  Card.Diamond8}, 
                {Card.Diamond9.Id,  Card.Diamond9},
                {Card.Diamond10.Id, Card.Diamond10},  
                {Card.Diamond11.Id, Card.Diamond11},  
                {Card.Diamond12.Id, Card.Diamond12},  
                {Card.Diamond13.Id, Card.Diamond13},  
                {Card.Diamond14.Id, Card.Diamond14},
                {Card.Heart2.Id,    Card.Heart2}, 
                {Card.Heart3.Id,    Card.Heart3},
                {Card.Heart4.Id,    Card.Heart4},
                {Card.Heart5.Id,    Card.Heart5},
                {Card.Heart6.Id,    Card.Heart6},
                {Card.Heart7.Id,    Card.Heart7},
                {Card.Heart8.Id,    Card.Heart8}, 
                {Card.Heart9.Id,    Card.Heart9}, 
                {Card.Heart10.Id,   Card.Heart10},
                {Card.Heart11.Id,   Card.Heart11}, 
                {Card.Heart12.Id,   Card.Heart12},
                {Card.Heart13.Id,   Card.Heart13},
                {Card.Heart14.Id,   Card.Heart14},
                {Card.Spade2.Id,    Card.Spade2},
                {Card.Spade3.Id,    Card.Spade3},
                {Card.Spade4.Id,    Card.Spade4}, 
                {Card.Spade5.Id,    Card.Spade5},
                {Card.Spade6.Id,    Card.Spade6},
                {Card.Spade7.Id,    Card.Spade7},
                {Card.Spade8.Id,    Card.Spade8},
                {Card.Spade9.Id,    Card.Spade9},
                {Card.Spade10.Id,   Card.Spade10},
                {Card.Spade11.Id,   Card.Spade11},
                {Card.Spade12.Id,   Card.Spade12},
                {Card.Spade13.Id,   Card.Spade13},
                {Card.Spade14.Id,   Card.Spade14}
            };

        public static Card GetCardById(int cardId) { return AllCards[cardId]; }
    }

    public class Suit : EnumClass 
    {
        private int _id;
        private string _shortName;
        private string _name;
        private string _image;
        public static readonly Suit Clubs = new Suit(0, "C", "Clubs", "Images/Clubs.png");
        public static readonly Suit Diamonds = new Suit(1, "D", "Diamonds", "Images/Diamonds.png");
        public static readonly Suit Hearts = new Suit(2, "H", "Hearts", "Images/Hearts.png");
        public static readonly Suit Spades = new Suit(3, "S", "Spades", "Images/Spades.png");
        private Suit(int Id, string ShortName, string Name, string Image)
        {
            _id = Id;
            _shortName = ShortName;
            _name = Name;
            _image = Image;
        }
        public int Id { get { return _id; } }
        public string ShortName { get { return _shortName; } }
        public string Name { get { return _name; } }
        public string Image { get { return _image; } }

        public static List<Suit> Suits { get { return new List<Suit>() { Suit.Clubs, Suit.Diamonds, Suit.Hearts, Suit.Spades }; } }
    }
}