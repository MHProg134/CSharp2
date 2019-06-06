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

//  Homework 5 - Mark Hill - CSHP 220

namespace Homework_5
{
    public partial class MainWindow : Window
    {
        private string currentPlayer = "X";                     // X or O      
        private int turnsTaken = 0;
        private const int gridSize = 3;                         // size of game grid (always square) 
                                                                //  - tic tac toe is 3x3 but...

        private int[,] gameGrid = new int[gridSize, gridSize];  // tracking grid
        private string[] tag = new string[2];                   // button clicked coordinates

        //private enum Coordinates
        //{
        //    x = 0,
        //    y = 1,
        //    undefined =-1
        //}

        private enum PlayerValue
        {
            X = gridSize,
            Y = gridSize * -1
        };

        //private int[] buttonClicked = new int[] {(int)Coordinates.undefined, (int)Coordinates.undefined };

        public MainWindow()
        {
            InitializeComponent();
            ResetGame();
        }

        private void ResetGame()
        {
            turnsTaken = 0;
            currentPlayer = "X";
            uxTurn.Text = currentPlayer + "'s turn";

            Array.Clear(gameGrid,   0, gameGrid.Length);

            foreach (Control ctrl in uxGrid.Children)
            {
                if (ctrl is Button)
                {
                    Button tb = ctrl as Button;
                    tb.Content = "";
                }
            }
        }

        public void uxNewGame_Click(object sender, System.EventArgs e)
        {
            ResetGame();
        }

        public void uxExit_Click(object sender, System.EventArgs e)
        {
            Application.Current.Shutdown();
        }

        public void Button_Click(object sender, System.EventArgs e)
        {
            if (turnsTaken < (gridSize * gridSize))        // If gane is over, don't respond to button clicks
            {
                Button btn = (sender as Button);

                if ((string)btn.Content == "")
                {
                    tag = btn.Tag.ToString().Split(',').ToArray();

                    // MessageBox.Show(tag[0] + ", " + tag[1]);
                    btn.Content = currentPlayer;
                }
                else
                {
                    //  do nothing
                }

                if (IsWinner())
                {
                    uxTurn.Text = currentPlayer + " is a winner";
                    turnsTaken = (gridSize * gridSize);     // diable further selection in this game
                }
                else
                {
                    SwitchPlayer();
                    turnsTaken++;
                    if (turnsTaken == (gridSize * gridSize))
                    {
                        // draw
                        uxTurn.Text = "This game is a draw";
                    }
                    else
                    {
                        // display players turn
                        uxTurn.Text = currentPlayer + "'s turn";
                    }
                }
            }
        }

        private void SwitchPlayer()
        {
            if (currentPlayer == "X")
            {
                currentPlayer = "O";
            }
            else
            {
                currentPlayer = "X";
            }
        }

        private int PlayerScore()
        {
            if (currentPlayer == "X")
            {
                return gridSize;
            }
            else 
            {
                return gridSize * -1;
            }
        }

        private Boolean IsWinner()
        {
            int x = int.Parse(tag[0]);
            int y = int.Parse(tag[1]);

            gameGrid[int.Parse(tag[0]), int.Parse(tag[1])] = PlayerScore();     // update tracking grid
            if (Math.Abs(RowTotal(x)) == (gridSize * gridSize))
            {
                return true;
            }
            else if (Math.Abs(ColTotal(y)) == (gridSize * gridSize))
            {
                return true;
            }
            else if (Math.Abs(DiagLeftTotal()) == (gridSize * gridSize))
            {
                return true;
            }
            else if (Math.Abs(DiagRightTotal()) == (gridSize * gridSize))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private int RowTotal(int row)
        {
            int total = 0;
            for (int col = 0; col < gridSize; col++)
            {
                total += gameGrid[row, col];
            }
            return total;
        }

        private int ColTotal(int col)
        {
            int total = 0;
            for (int row = 0; row < gridSize; row++)
            {
                total += gameGrid[row, col];
            }
            return total;
        }

        private int DiagLeftTotal()
        {
            int total = 0;
            for (int index = 0; index < gridSize; index++)
            {
                total += gameGrid[index, index];
            }
            return total;
        }

        private int DiagRightTotal()
        {
            int total = 0;
            for (int index = 0; index < gridSize; index++)
            {
                total += gameGrid[index, gridSize - 1 -index];
            }
            return total;
        }

    }
}
