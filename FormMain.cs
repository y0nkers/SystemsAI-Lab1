using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class FormMain : Form
    {
        enum BALLOONS
        {
            RED = 0,
            GREEN = 1,
            BLUE = 2,
            PURPLE = 3
        }

        static string[] balloonsPaths = { "../../sprites/red.png", "../../sprites/green.png", "../../sprites/blue.png", "../../sprites/purple.png" };
        static int[,] field = new int[4, 4];
        static List<PictureBox> gamefield;

        public FormMain()
        {
            InitializeComponent();
            gamefield = panelGamefield.Controls.Cast<PictureBox>().ToList();
            shuffleField();
        }

        private void buttonShuffle_Click(object sender, EventArgs e)
        {
            shuffleField();
        }

        /* Change image for every cell on field. */
        public void redrawField()
        {
            int k = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    gamefield[k].Image = Image.FromFile(balloonsPaths[field[i, j]]);
                    k++;
                }
            }

            checkWinCondition();
        }
        
        /* Randomly place balloons on field. Not very effective, but it works. */
        public void shuffleField()
        {
            Random random = new Random();
            int redCount = 0, greenCount = 0, blueCount = 0, purpleCount = 0;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4;)
                {
                    int number = random.Next(0, 4);
                    switch (number)
                    {
                        case (int)BALLOONS.RED:
                            if (redCount < 4)
                            {
                                redCount++;
                                field[i, j++] = number;
                            }
                            else continue;
                            break;
                        case (int)BALLOONS.GREEN:
                            if (greenCount < 4)
                            {
                                greenCount++;
                                field[i, j++] = number;
                            }
                            else continue;
                            break;
                        case (int)BALLOONS.BLUE:
                            if (blueCount < 4)
                            {
                                blueCount++;
                                field[i, j++] = number;
                            }
                            else continue;
                            break;
                        case (int)BALLOONS.PURPLE:
                            if (purpleCount < 4)
                            {
                                purpleCount++;
                                field[i, j++] = number;
                            }
                            else continue;
                            break;
                    }
                }
            }

            if (pictureBoxWin.Image != null)
            {
                pictureBoxWin.Image = null;
                labelWin.Text = "";
            }

            redrawField();
        }

        public void checkWinCondition()
        {
            /* Counting values from every cell in 0-3 columns. If sum is not equal to 4 * column we dont need to check further */
            for (int column = 0; column < 4; column++)
            {
                int sum = 0;
                for (int row = 0; row < 4; row++) sum += field[row, column];
                if (sum != 4 * column) return;
            }

            /* If we reach this point, we win. */
            pictureBoxWin.Image = Lab1.Properties.Resources.win;
            labelWin.Text = "You won!";
        }

        private void movementHandler(object sender, EventArgs e)
        {
            switch ((sender as Button).Name)
            {
                case "buttonTop1":
                    moveColumn(0);
                    break;
                case "buttonTop2":
                    moveColumn(1);
                    break;
                case "buttonTop3":
                    moveColumn(2);
                    break;
                case "buttonTop4":
                    moveColumn(3);
                    break;

                case "buttonLeft1":
                    moveRow(0);
                    break;
                case "buttonLeft2":
                    moveRow(1);
                    break;
                case "buttonLeft3":
                    moveRow(2);
                    break;
                case "buttonLeft4":
                    moveRow(3);
                    break;
            }
        }

        private void moveColumn(int j)
        {
            int last = field[0, j];
            for (int i = 1; i < 4; i++) field[i - 1, j] = field[i, j];
            field[3, j] = last;
            redrawField();
        }

        private void moveRow(int i)
        {
            int last = field[i, 0];
            for (int j = 1; j < 4; j++) field[i, j - 1] = field[i, j];
            field[i, 3] = last;
            redrawField();
        }

        private void buttonTopHover(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            button.Image = Lab1.Properties.Resources.buttonTopHover;
        }

        private void buttonTopLeaveHover(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.Image = Lab1.Properties.Resources.buttonTop;
        }

        private void buttonLeftHover(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            button.Image = Lab1.Properties.Resources.buttonLeftHover;
        }

        private void buttonLeftLeaveHover(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.Image = Lab1.Properties.Resources.buttonLeft;
        }
    }
}
