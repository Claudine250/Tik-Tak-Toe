/*
 * This is a simple Tik Tak Toe game.
 * Allows user to play against the computer.
 * Wins are counted and displayed.
 * After each game, the board is reset.
 * */

namespace Tik_Tak_Toe
{
    public partial class Form1 : Form
    {

        //create an enum custom data type
        public enum player
        {
            X, O
        }

        //create global variables with the enum player data type
        player currentPlayer;
        Random random = new Random();
        int player1WinCount = 0;
        int Player2WinCount = 0;
        List<Button> buttons;

        public Form1()
        {
            InitializeComponent();
            //when game start, reset
            RestartGame();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //private bool isPlayer1Turn = true;  // Start with Player 1 (X)

        private void Player2move(object sender, EventArgs e)
        {
            //check if players have no buttons selected
            if (buttons.Count > 0)

                // Only proceed if it's Player 2's turn and there are buttons available
              //if (isPlayer1Turn || buttons.Count <= 0) return;
            {
                //select a random number and store it inside the index
                int index = random.Next(buttons.Count);
                buttons[index].Enabled = false;
                currentPlayer = player.O;
                buttons[index].Text = currentPlayer.ToString();
                buttons[index].BackColor = Color.LightPink;
                buttons.RemoveAt(index);

                //isPlayer1Turn = true;  // Switch back to Player 1's turn
                CheckGame();
                CPUTimer.Stop();
            }
        }

        private void PlayerClickButton(object sender, EventArgs e)
        {
            // Only allow clicks during Player 1's turn
            var button = (Button)sender;
            currentPlayer = player.X;
            //converting x information to a string
            button.Text = currentPlayer.ToString();
            //disable button once it has been clicked
            button.Enabled = false;
            button.BackColor = Color.Beige;
            //remove button once it has been selected
            buttons.Remove(button);
            //check if player has three buttons in a similar pattern
            CheckGame();
            //if it hasn't
            CPUTimer.Start();
        }

        private void Restart(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void CheckGame()
        {

            if (button1.Text == "X" && button2.Text == "X" && button3.Text == "X")  // Test just top row
            {
                CPUTimer.Stop();
                MessageBox.Show("Player1 Wins");
                player1WinCount++;
                label1.Text = "player1 wins: " + player1WinCount;
                RestartGame();
            }
            //if the following buttons match player win
            if
                // Horizontal rows
                   (button1.Text == "X" && button2.Text == "X" && button3.Text == "X"
                || (button4.Text == "X" && button5.Text == "X" && button6.Text == "X")
                || (button7.Text == "X" && button8.Text == "X" && button9.Text == "X")
                // vertical columns
                || (button1.Text == "X" && button4.Text == "X" && button7.Text == "X")
                || (button2.Text == "X" && button5.Text == "X" && button8.Text == "X")
                || (button3.Text == "X" && button6.Text == "X" && button9.Text == "X")
                // Diagonals
                || (button1.Text == "X" && button5.Text == "X" && button9.Text == "X")
                || (button3.Text == "X" && button5.Text == "X" && button7.Text == "X")

                )
            {
                //if any of the conditions above are met, stop player two's timer
                CPUTimer.Stop();
                MessageBox.Show("Player1 Wins");
                player1WinCount++;
                label1.Text = "player1 wins: " + player1WinCount;

                RestartGame();

            }
            else if (
                 // Horizontal rows
                (button1.Text == "O" && button2.Text == "O" && button3.Text == "O") ||
                (button4.Text == "O" && button5.Text == "O" && button6.Text == "O") ||
                (button7.Text == "O" && button8.Text == "O" && button9.Text == "O") ||
                // Vertical columns
                (button1.Text == "O" && button4.Text == "O" && button7.Text == "O") ||
                (button2.Text == "O" && button5.Text == "O" && button8.Text == "O") ||
                (button3.Text == "O" && button6.Text == "O" && button9.Text == "O") ||
                 // Diagonals
                (button1.Text == "O" && button5.Text == "O" && button9.Text == "O") ||
                (button3.Text == "O" && button5.Text == "O" && button7.Text == "O")
)
            {
                CPUTimer.Stop();
                MessageBox.Show("Player Wins 2");
                Player2WinCount++;
                label2.Text = "player2 wins: " + Player2WinCount;

                RestartGame();
            }

            // Check for draw condition
            else if (buttons.Count == 0)
            {
                CPUTimer.Stop();
                MessageBox.Show("It's a Draw!", "Game Over");
                RestartGame();
            }
        }

        private void RestartGame()
        {
            //create a list of buttons
            buttons = new List<Button> { button1, button2, button3,button4, button5, button6, button7, button8, button9 };

            //for loop to loop through each button
            foreach (Button x in buttons)
            {
                //enable the buttons
                x.Enabled = true;
                x.Text = "?";
                x.BackColor = Color.Green;
            }
        }

        private void button9_BackColorChanged(object sender, EventArgs e)
        {

        }
    }
}