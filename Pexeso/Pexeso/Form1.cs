using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;


namespace Pexeso
{
    public partial class Form1 : Form
    {
        PictureBox[,] front;
        PictureBox[,] back;
        int cardsLeft = 0; //cards remaining in the current game

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dupSize.SelectedIndex = 0;
            lbTurn.Visible = false; // turn (who is playig)
            lbCurScore.Visible = false; //score of current game
            lbScore.Visible = false; //score of all games played
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            graphic();
            gamestart(dupSize.SelectedIndex) ;
        }
        private void graphic() //visuals for the game
        {
            dupSize.Visible = false;
            btStart.Visible = false;
            lbTurn.Visible = true;
            lbTurn.Left = 10;
            lbTurn.Top = 5;
            lbCurScore.Visible = true;
            lbCurScore.Left = lbTurn.Right + 5;
            lbCurScore.Top = 5;
            lbScore.Visible = true;
            lbScore.Left = lbCurScore.Right + 5;
            lbScore.Top = 5;
        }
        const byte shiftX = 10; //image spacing
        const byte shiftY = 25;
        const byte space = 5;
        private void gamestart(int indesSize) 
        {
            int size = 8 - 2 * indesSize; //gets the size of playing board based on index

            //creates array of images
            Bitmap[,] frontBit = new Bitmap[size, size];
            front = new PictureBox[size, size];
            back = new PictureBox[size, size];
            Bitmap backBit = new Bitmap(Application.StartupPath + "/My Icons/reverse.ico"); //loads my reverse icon
            int[] index = new int[size * size]; //numeric values of images
            cardsLeft = index.Length / 2; //no. of cards left in the current game

            for (int i = 0; i < index.Length; ++i) //adds values to array 
                index[i] = i / 2;

            Random shuffle = new Random();
            for (int i = 0; i < index.Length; ++i) //shuffle
            {
                int position = shuffle.Next(index.Length); //random shuffle of 2 positions in the array
                int temp = index[position];
                index[position] = index[i];
                index[i] = temp;
            }

            for (int i = 0; i < index.Length; ++i) //creation of the visuals (4x4, 6x6, 8x8)
            {
                int x = i % size; //x coordinate
                int y = i / size; //y coordinate

                //images
                frontBit[x, y] = new Bitmap(Application.StartupPath + "/My Icons/" + index[i] + ".ico"); //loads my obverse icons
                front[x, y] = new PictureBox(); //creates picture box
                front[x, y].Parent = this;
                front[x, y].BorderStyle = BorderStyle.None; //deltes border
                front[x, y].Left = shiftX + x * (space + frontBit[x, y].Width); //positions the image
                front[x, y].Top = shiftY + y * (space + frontBit[x, y].Height);
                front[x, y].Width = frontBit[x, y].Width;
                front[x, y].Height = frontBit[x, y].Height;
                front[x, y].Image = frontBit[x, y];
                front[x, y].Visible = false;

                //back, same as front
                back[x, y] = new PictureBox();
                back[x, y].Parent = this;
                back[x, y].BorderStyle = BorderStyle.None;
                back[x, y].Left = front[x, y].Location.X;
                back[x, y].Top = front[x, y].Location.Y;
                back[x, y].Width = backBit.Width;
                back[x, y].Height = backBit.Height;
                back[x, y].Image = backBit;
                back[x, y].Click += new EventHandler(Flip);
                back[x, y].Tag = index[i].ToString() + " " + x.ToString() + y.ToString(); //tags index (as well as coordinates so I dont have to calculate their position later
            }
        }
        bool ready = true; //can select 1st image
        bool secready = false; //can select 2nd image
        string aktIndex;

        public void Flip(object sender, EventArgs e) //in the event of click = card flip
        {
            if (ready && !front[(sender as PictureBox).Tag.ToString().Split(' ')[1][0] - '0', (sender as PictureBox).Tag.ToString().Split(' ')[1][1] - '0'].Visible) //cant select more than 2 cards or the same card
                if (secready) //after second card is flipped
                {
                    front[(sender as PictureBox).Tag.ToString().Split(' ')[1][0] - '0', (sender as PictureBox).Tag.ToString().Split(' ')[1][1] - '0'].Visible = true; //flips the card to show the picture
                    if ((sender as PictureBox).Tag.ToString().Split(' ')[0] == aktIndex.Split(' ')[0]) //flipped the right picture (point)
                    {
                        if (lbTurn.Text[lbTurn.Text.Length - 1] == '1')
                            ++points[0];
                        else
                            ++points[1];

                        lbCurScore.Text = "Current score: " + points[0] + " - " + points[1];
                        --cardsLeft;
                        if (cardsLeft == 0)
                            gameEnd();
                    }
                    else //dint flipped the right picture, turn: second player
                    {
                        ready = false;
                        wait(1000);
                        ready = true; //hides the images
                        front[aktIndex.Split(' ')[1][0] - '0', aktIndex.Split(' ')[1][1] - '0'].Visible = false; //flips the card to show picture
                        front[(sender as PictureBox).Tag.ToString().Split(' ')[1][0] - '0', (sender as PictureBox).Tag.ToString().Split(' ')[1][1] - '0'].Visible = false;

                        if (lbTurn.Text[lbTurn.Text.Length - 1] == '1') //switches the text of who is currrently playing
                            lbTurn.Text = "Turn: P2";
                        else
                            lbTurn.Text = "Turn: P1";
                    }

                    secready = false; //can only flipp 1st pic from now on
                }
                else //currently flipping 1st
                {
                    aktIndex = (sender as PictureBox).Tag.ToString(); //saves the tag of the 1st 
                    front[aktIndex.Split(' ')[1][0] - '0', aktIndex.Split(' ')[1][1] - '0'].Visible = true; //makes the 1st pick visible (flipped)
                    secready = true; //can now select the 2nd pic
                }
        }
        public void wait(int milliseconds) //waiting period between rounds
        {
            var timer1 = new Timer(); //creates a timer
            if (milliseconds == 0 || milliseconds < 0) return; //goes back after timer expires

            timer1.Interval = milliseconds; //starts the timer in milisec
            timer1.Enabled = true;
            timer1.Start();

            timer1.Tick += (s, e) => //ends the timer after time expired
            {
                timer1.Enabled = false;
                timer1.Stop();
            };

            while (timer1.Enabled) //if timer started, start ticking
            {
                Application.DoEvents();
            }
        }
        byte[] points = new byte[] { 0, 0, 0, 0 }; //current player1, current player2, all p1, all p2
        public void gameEnd() //the round ends
        {
            if (points[0] > points[1]) // P1 won the round
            {
                ++points[2];
                MessageBox.Show("P1 won");
            }
            else 
            {
                ++points[3];
                MessageBox.Show("P2 won");
            }
            points[0] = 0; //zeros out the points in the upcoming round
            points[1] = 0;

            lbCurScore.Text = "Current score: 0:0";
            lbScore.Text = "Score: " + points[2] + " : " + points[3];
            if ((points[2] + points[3]) % 2 == 0) //P2 won the last round
                lbTurn.Text = "Turn: P1";
            else //P1 won the last round
                lbTurn.Text = "Turn: P2";

            lbTurn.Visible = false; //can select different board size for the next round
            lbCurScore.Visible = false;
            lbScore.Visible = false;
            dupSize.Visible = true;
            btStart.Visible = true;
            foreach (PictureBox element in front) //removes the front pictures
                Controls.Remove(element);

            foreach (PictureBox element in back) //removes the back pictures
                Controls.Remove(element);
        }
    }
}
