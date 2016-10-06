using System;
namespace ConsoleApplication
{
    public class Card
    {
        public string value;
        public string suit;
        public int num_value;
        public Card(string val, string ste, int num)
        {
            value = val;
            suit = ste;
            num_value = num;
        }
    }
    public class Deck
    {
        string[] value = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        string[] suit = { "Clubs", "Spades", "Hearts", "Diamonds" };
        public Card[] cards = new Card[52];
        public Deck()
        {
            int idx = 0;
            int num = 2;
            for (int i = 0; i < 13; i++)
            {
                for (int s = 0; s < 4; s++)
                {
                    cards[idx] = new Card(value[i], suit[s], num);
                    idx++;
                }
                num++;
            }
            // for (int k = 0; k < 52; k++)
            // {
            //     Console.WriteLine(cards[k].value + " " + cards[k].suit + " " + cards[k].num_value);
            // }
        }
        public void Shuffle()
        {
            dynamic temp = null;
            Random rand = new Random();
            for (int i = 0; i < cards.Length; i++)
            {
                int j = rand.Next(0, 52);
                temp = cards[i];
                cards[i] = cards[j];
                cards[j] = temp;
            }
            Console.WriteLine("Dealer shuffling the Deck...... ");
            // for (int k = 0; k < 52; k++)
            // {
            //     Console.WriteLine(cards[k].value + " " + cards[k].suit + " " + cards[k].num_value);
            // }
        }
        public Card Deal()
        {
            for (int i = 0; i < 53; i++)
            {
                if (cards[i] != null)
                {
                    Card singlecard = cards[i];
                    cards[i] = null;
                    return singlecard;
                }
            }
            return new Card("nocard", "nocard", 0);
        }
    }
    public class Dealer
    {
        public int total = 0;
        public void Draw(Deck deckname)
        {
            Card newcard = deckname.Deal();
            if (newcard.num_value < 10)
            {
                total += newcard.num_value;
            }
            else if (newcard.num_value >= 10 && newcard.num_value < 14)
            {
                total += 10;
            }
            else if (newcard.num_value == 14)
            {
                total += 11;
            }
            Console.WriteLine("Dealer drew a " + newcard.value + " of " + newcard.suit + ",house total is " + total);
            if (total > 21)
            {
                Console.WriteLine("Dealer bust, YOU WIN!");
            }
            else if (total < 18)
            {
                Draw(deckname);
            }
        }
    }
    public class Player
    {
        public Card[] hand = new Card[10];
        public int total = 0;
        public int count = 0;
        public string username;
        public Player(string name)
        {
            username = name;
        }
        public void Draw(Deck deckname)
        {
            Card newcard = deckname.Deal();
            count++;
            if (newcard.num_value < 10)
            {
                total += newcard.num_value;
            }
            else if (newcard.num_value >= 10 && newcard.num_value < 14)
            {
                total += 10;
            }
            else if (newcard.num_value == 14)
            {
                total += 11;
            }
            Console.WriteLine("You drew a " + newcard.value + " of " + newcard.suit + ", your current total is " + total);
            
            if (count < 2)
            {
                Draw(deckname);
            }
            else if (count >= 2)
            {
                if (total > 21)
                {
                    Console.WriteLine("You bust fool");
                    return;
                }
                if (total == 21)
                {
                    Console.WriteLine("blackjack!");
                    return;
                }
                Console.WriteLine("Would you like to draw again? y/n ");
                string poop = Console.ReadLine();
                if (poop == "y")
                {
                    Draw(deckname);
                }
                if (poop == "n")
                {
                    Dealer dealer = new Dealer();
                    dealer.Draw(deckname);
                    if (dealer.total > total && dealer.total <= 21)
                    {
                        Console.WriteLine("House wins, you lose!");
                        return;
                    }
                    else if (dealer.total < total)
                    {
                        Console.WriteLine("You win! yipeee");
                        return;
                    }
                    else if (dealer.total == total)
                    {
                        Console.WriteLine("It's a tie, that sucks");
                        return;
                    }
                }
            }
            if (total > 21 && count < 2)
            {
                Console.WriteLine("You bust fool");
                return;
            }
            else if (total == 21 && count < 2)
            {
                Console.WriteLine("blackjack!");
                return;
            }
            //    if(hand[0] == null)
            //    {
            //        hand[0] = newcard;
            //    }else{
            //        hand[1] = newcard;
            //    }
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("~~~~~~~~~BLACKJACK~~~~~~~~~~~");
            Console.WriteLine("*****************************");
            Console.WriteLine("*---------------------------*");            
            Console.WriteLine("*-A-------------------------*");
            Console.WriteLine("*-%-------------------------*");
            Console.WriteLine("*-----------##--------------*");                      
            Console.WriteLine("*----------####-------------*");
            Console.WriteLine("*--------########-----------*");
            Console.WriteLine("*------############---------*");
            Console.WriteLine("*----################-------*");
            Console.WriteLine("*---##################------*");
            Console.WriteLine("*----################-------*");
            Console.WriteLine("*-----#####-##-#####--------*");
            Console.WriteLine("*----------####-------------*");
            Console.WriteLine("*----------####-------------*");
            Console.WriteLine("*--------########-----------*");
            Console.WriteLine("*------############---------*"); 
            Console.WriteLine("*-------------------------%-*");
            Console.WriteLine("*-------------------------A-*");
            Console.WriteLine("*---------------------------*");                
            Console.WriteLine("*****************************");
            Deck lol = new Deck();
            lol.Shuffle();
            Player player = new Player("Dylan");
            Console.WriteLine("Hello " + player.username);
            player.Draw(lol);
        }
    }
}