using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace poker_Testing
{
    public enum suits { Clubs, Diamonds, Hearts, Spades };
    public enum Face { Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace };

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int PlayerOneWin;

        public MainWindow()
        {
            int playerOneScore;
            int playerTwoScore;

            string hand1;
            string hand2;
            string line;

            string[] hand1cards = new string[5];
            suits[] hand1Suits = new suits[5];
            Face[] hand1Face = new Face[5];

            string[] hand2cards = new string[5];
            suits[] hand2Suits = new suits[5];
            Face[] hand2Face = new Face[5];

            System.IO.StreamReader sr = new System.IO.StreamReader("test.txt");

            InitializeComponent();

            
            while (!sr.EndOfStream)
            {
                line = sr.ReadLine().ToString();
                hand1 = line.Substring(0, 14);
                hand2 = line.Substring(15, 14);

                //MessageBox.Show(hand1);

                for (int j = 0; j < hand1cards.Length; j++)
                {
                    hand1cards[j] = hand1.Substring(j * 3, 2);
                    switch (hand1cards[j][1])
                    {
                        case 'D': hand1Suits[j] = suits.Diamonds; break;
                        case 'H': hand1Suits[j] = suits.Hearts; break;
                        case 'S': hand1Suits[j] = suits.Spades; break;
                        case 'C': hand1Suits[j] = suits.Clubs; break;
                    }

                    switch (hand1cards[j][0])
                    {
                        case 'A': hand1Face[j] = Face.Ace; break;
                        case '2': hand1Face[j] = Face.Two; break;
                        case '3': hand1Face[j] = Face.Three; break;
                        case '4': hand1Face[j] = Face.Four; break;
                        case '5': hand1Face[j] = Face.Five; break;
                        case '6': hand1Face[j] = Face.Six; break;
                        case '7': hand1Face[j] = Face.Seven; break;
                        case '8': hand1Face[j] = Face.Eight; break;
                        case '9': hand1Face[j] = Face.Nine; break;
                        case 'T': hand1Face[j] = Face.Ten; break;
                        case 'J': hand1Face[j] = Face.Jack; break;
                        case 'Q': hand1Face[j] = Face.Queen; break;
                        case 'K': hand1Face[j] = Face.King; break;
                    }
                    //MessageBox.Show(hand1Suits[j].ToString() + " " + hand1Face[j].ToString());
                }
                                                
                //MessageBox.Show(hand2);

                for (int j = 0; j < hand2cards.Length; j++)
                {
                    hand2cards[j] = hand2.Substring(j * 3, 2);
                    switch (hand2cards[j][1])
                    {
                        case 'D': hand2Suits[j] = suits.Diamonds; break;
                        case 'H': hand2Suits[j] = suits.Hearts; break;
                        case 'S': hand2Suits[j] = suits.Spades; break;
                        case 'C': hand2Suits[j] = suits.Clubs; break;

                    }

                    switch (hand2cards[j][0])
                    {
                        case 'A': hand2Face[j] = Face.Ace; break;
                        case '2': hand2Face[j] = Face.Two; break;
                        case '3': hand2Face[j] = Face.Three; break;
                        case '4': hand2Face[j] = Face.Four; break;
                        case '5': hand2Face[j] = Face.Five; break;
                        case '6': hand2Face[j] = Face.Six; break;
                        case '7': hand2Face[j] = Face.Seven; break;
                        case '8': hand2Face[j] = Face.Eight; break;
                        case '9': hand2Face[j] = Face.Nine; break;
                        case 'T': hand2Face[j] = Face.Ten; break;
                        case 'J': hand2Face[j] = Face.Jack; break;
                        case 'Q': hand2Face[j] = Face.Queen; break;
                        case 'K': hand2Face[j] = Face.King; break;

                    }
                    //MessageBox.Show(hand2Suits[j].ToString() + " " + hand2Face[j].ToString());

                }
                Array.Sort(hand1Face);
                Array.Sort(hand2Face);

                playerOneScore = 0;
                playerTwoScore = 0;

                //player One Royal Flush
                if (hand1Suits[0] == hand1Suits[1] && hand1Suits[0] == hand1Suits[2] && hand1Suits[0] == hand1Suits[3] && hand1Suits[0] == hand1Suits[4] && playerOneScore == 0)
                {
                    if (hand1Face[0] == Face.Ace)
                    {
                        if (hand1Face[0] - hand1Face[4] == -12 && hand1Face[1] - hand1Face[2] == -1 && hand1Face[2] - hand1Face[3] == -1 && hand1Face[3] - hand1Face[4] == -1)
                        {
                            playerOneScore += 10;//Royal Flush
                        }
                    }
                }
                //player One Stright Flush
                if (hand1Suits[0] == hand1Suits[1] && hand1Suits[0] == hand1Suits[2] && hand1Suits[0] == hand1Suits[3] && hand1Suits[0] == hand1Suits[4] && playerOneScore == 0)
                {
                    if (hand1Face[0] == Face.Ace)
                    {
                        if (hand1Face[0] - hand1Face[1] == -1 && hand1Face[1] - hand1Face[2] == -1 && hand1Face[2] - hand1Face[3] == -1 && hand1Face[3] - hand1Face[4] == -1)
                        {
                            playerOneScore += 9;//Straight Flush
                        }
                    }
                    if (hand1Face[0] != Face.Ace)
                    {
                        if (hand1Face[0] - hand1Face[1] == -1 && hand1Face[1] - hand1Face[2] == -1 && hand1Face[2] - hand1Face[3] == -1 && hand1Face[3] - hand1Face[4] == -1)
                        {
                            playerOneScore += 9;//Straight Flush
                        }
                    }
                }
                //Player One Four Of A Kind
                if (hand1Face[0] == hand1Face[1] && playerOneScore == 0)
                {
                    if (hand1Face[0] == hand1Face[2])
                    {
                        if (hand1Face[0] == hand1Face[3])
                        {
                            playerOneScore += 8;//Four of a Kind
                        }
                    }
                }
                if (hand1Face[1] == hand1Face[2] && playerOneScore == 0)
                {
                    if (hand1Face[1] == hand1Face[3])
                    {
                        if (hand1Face[1] == hand1Face[4])
                        {
                            playerOneScore += 8;//Four of a Kind
                        }
                    }
                }
                //Player One FullHouse
                if (hand1Face[0] == hand1Face[1] && playerOneScore == 0)
                {
                    if (hand1Face[0] == hand1Face[2])
                    {
                        if (hand1Face[3] == hand1Face[4])
                        {
                            playerOneScore += 7;//Full House
                        }
                    }
                }
                if (hand1Face[2] == hand1Face[3] && playerOneScore == 0)
                {
                    if (hand1Face[2] == hand1Face[4])
                    {
                        if (hand1Face[0] == hand1Face[1])
                        {
                            playerOneScore += 7;//Full House
                        }
                    }
                }
                //Player One Flush
                if (hand1Suits[0] == hand1Suits[1] && hand1Suits[0] == hand1Suits[2] && hand1Suits[0] == hand1Suits[3] && hand1Suits[0] == hand1Suits[4] && playerOneScore == 0)
                {
                    if (playerOneScore == 0)
                    {
                        playerOneScore += 6;//Flush
                    }
                }
                //Player one Straight
                if (hand1Face[0] - hand1Face[1] == -1 && hand1Face[1] - hand1Face[2] == -1 && hand1Face[2] - hand1Face[3] == -1 && hand1Face[3] - hand1Face[4] == -1 && playerOneScore == 0)
                {
                    playerOneScore += 5;//Straight 
                }
                //Player One Three of a Kind
                if (hand1Face[0] == hand1Face[1] && playerOneScore == 0)
                {
                    if (hand1Face[0] == hand1Face[2])
                    { 
                        playerOneScore += 4;//Three of a kind
                    }
                }
                if (hand1Face[1] == hand1Face[2] && playerOneScore == 0)
                {
                    if (hand1Face[1] == hand1Face[3])
                    {
                        playerOneScore += 4;//Three of a kind
                    }
                }
                if (hand1Face[2] == hand1Face[3] && playerOneScore == 0)
                {
                    if (hand1Face[2] == hand1Face[4])
                    {
                        playerOneScore += 4;//Three of a kind
                    }
                }
                //Player One Two Pair
                if (hand1Face[0] == hand1Face[1] && hand1Face[2] == hand1Face[3] && playerOneScore == 0)
                {
                    playerOneScore += 3;//Two Pair
                }
                if (hand1Face[0] == hand1Face[1] && hand1Face[3] == hand1Face[4] && playerOneScore == 0)
                {
                    playerOneScore += 3;//Two Pair
                }
                if (hand1Face[1] == hand1Face[2] && hand1Face[3] == hand1Face[4] && playerOneScore == 0)
                {
                    playerOneScore += 3;//Two Pair
                }
                //Player One one pair
                if(hand1Face[0] == hand1Face[1] && playerOneScore == 0)
                {
                    playerOneScore += 2;//One Pair
                }
                if (hand1Face[1] == hand1Face[2] && playerOneScore == 0)
                {
                    playerOneScore += 2;//One Pair
                }
                if (hand1Face[2] == hand1Face[3] && playerOneScore == 0)
                {
                    playerOneScore += 2;//One Pair
                }
                if (hand1Face[3] == hand1Face[4] && playerOneScore == 0)
                {
                    playerOneScore += 2;//One Pair
                }
                //Player One High Card
                if(hand1Face[0] < hand1Face[4] && playerOneScore == 0)
                {
                    playerOneScore += 1;//High Card
                }

                //MessageBox.Show(playerOneScore.ToString());



                //Player Two
                //player Two Royal Flush
                if (hand2Suits[0] == hand2Suits[1] && hand2Suits[0] == hand2Suits[2] && hand2Suits[0] == hand2Suits[3] && hand2Suits[0] == hand2Suits[4] && playerOneScore == 0)
                {
                    if (hand2Face[0] == Face.Ace)
                    {
                        if (hand2Face[0] - hand2Face[4] == -12 && hand2Face[1] - hand2Face[2] == -1 && hand2Face[2] - hand2Face[3] == -1 && hand2Face[3] - hand2Face[4] == -1)
                        {
                            playerTwoScore += 10;//Royal Flush
                        }
                    }
                }
                //player Two Stright Flush
                if (hand2Suits[0] == hand2Suits[1] && hand2Suits[0] == hand2Suits[2] && hand2Suits[0] == hand2Suits[3] && hand2Suits[0] == hand2Suits[4] && playerTwoScore == 0)
                {
                    if (hand2Face[0] == Face.Ace)
                    {
                        if (hand2Face[0] - hand2Face[1] == -1 && hand2Face[1] - hand2Face[2] == -1 && hand2Face[2] - hand2Face[3] == -1 && hand2Face[3] - hand2Face[4] == -1)
                        {
                            playerTwoScore += 9;//Straight Flush
                        }
                    }
                    if (hand2Face[0] != Face.Ace)
                    {
                        if (hand2Face[0] - hand2Face[1] == -1 && hand2Face[1] - hand2Face[2] == -1 && hand2Face[2] - hand2Face[3] == -1 && hand2Face[3] - hand2Face[4] == -1)
                        {
                            playerTwoScore += 9;//Straight Flush
                        }
                    }
                }
                //Player Two Four Of A Kind
                if (hand2Face[0] == hand2Face[1] && playerTwoScore == 0)
                {
                    if (hand2Face[0] == hand2Face[2])
                    {
                        if (hand2Face[0] == hand2Face[3])
                        {
                            playerTwoScore += 8;//Four of a Kind
                        }
                    }
                }
                if (hand2Face[1] == hand2Face[2] && playerTwoScore == 0)
                {
                    if (hand2Face[1] == hand2Face[3])
                    {
                        if (hand2Face[1] == hand2Face[4])
                        {
                            playerTwoScore += 8;//Four of a Kind
                        }
                    }
                }
                //Player Two FullHouse
                if (hand2Face[0] == hand2Face[1] && playerTwoScore == 0)
                {
                    if (hand2Face[0] == hand2Face[2])
                    {
                        if (hand2Face[3] == hand2Face[4])
                        {
                            playerTwoScore += 7;//Full House
                        }
                    }
                }
                if (hand2Face[2] == hand2Face[3] && playerTwoScore == 0)
                {
                    if (hand2Face[2] == hand2Face[4])
                    {
                        if (hand2Face[0] == hand2Face[1])
                        {
                            playerTwoScore += 7;//Full House
                        }
                    }
                }
                //Player Two Flush
                if (hand2Suits[0] == hand2Suits[1] && hand2Suits[0] == hand2Suits[2] && hand2Suits[0] == hand2Suits[3] && hand2Suits[0] == hand2Suits[4] && playerTwoScore == 0)
                {
                    if (playerTwoScore == 0)
                    {
                        playerTwoScore += 6;//Flush
                    }
                }
                //Player Two Straight
                if (hand2Face[0] - hand2Face[1] == -1 && hand2Face[1] - hand2Face[2] == -1 && hand2Face[2] - hand2Face[3] == -1 && hand2Face[3] - hand2Face[4] == -1 && playerTwoScore == 0)
                {
                    playerTwoScore += 5;//Straight 
                }
                //Player Two Three of a Kind
                if (hand2Face[0] == hand2Face[1] && playerTwoScore == 0)
                {
                    if (hand2Face[0] == hand2Face[2])
                    {
                        playerTwoScore += 4;//Three of a kind
                    }
                }
                if (hand2Face[1] == hand2Face[2] && playerTwoScore == 0)
                {
                    if (hand2Face[1] == hand2Face[3])
                    {
                        playerTwoScore += 4;//Three of a kind
                    }
                }
                if (hand2Face[2] == hand2Face[3] && playerTwoScore == 0)
                {
                    if (hand2Face[2] == hand2Face[4])
                    {
                        playerTwoScore += 4;//Three of a kind
                    }
                }
                //Player Two Two Pair
                if (hand2Face[0] == hand2Face[1] && hand2Face[2] == hand2Face[3] && playerTwoScore == 0)
                {
                    playerTwoScore += 3;//Two Pair
                }
                if (hand2Face[0] == hand2Face[1] && hand2Face[3] == hand2Face[4] && playerTwoScore == 0)
                {
                    playerTwoScore += 3;//Two Pair
                }
                if (hand2Face[1] == hand2Face[2] && hand2Face[3] == hand2Face[4] && playerTwoScore == 0)
                {
                    playerTwoScore += 3;//Two Pair
                }
                //Player Two one pair
                if (hand2Face[0] == hand2Face[1] && playerTwoScore == 0)
                {
                    playerTwoScore += 2;//One Pair
                }
                if (hand2Face[1] == hand2Face[2] && playerTwoScore == 0)
                {
                    playerTwoScore += 2;//One Pair
                }
                if (hand2Face[2] == hand2Face[3] && playerTwoScore == 0)
                {
                    playerTwoScore += 2;//One Pair
                }
                if (hand2Face[3] == hand2Face[4] && playerTwoScore == 0)
                {
                    playerTwoScore += 2;//One Pair
                }
                //Player Two High Card
                if (hand2Face[0] < hand2Face[4] && playerTwoScore == 0)
                {
                    playerTwoScore += 1;//High Card
                }
                //Check for Tie
                if (playerOneScore == playerTwoScore)
                {
                    if (hand1Face[4] > hand2Face[4])
                    {
                        PlayerOneWin += 1;
                    }
                }
                //Check who wins
                else if (playerOneScore > playerTwoScore)
                {
                    PlayerOneWin += 1;
                }
                //MessageBox.Show(PlayerOneWin.ToString());
                lblOutput.Content = (PlayerOneWin);
            }
        }
    }
}
 