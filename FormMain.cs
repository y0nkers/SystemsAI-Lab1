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
            shuffle_field();
        }

        /* Randomly place balloons on field. Not very effective, but it works. */
        public void shuffle_field()
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
            change_field();
        }

        public void change_field()
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
        }

        private void buttonShuffle_Click(object sender, EventArgs e)
        {
            shuffle_field();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int j = 0;
            int last_element = field[0, j];
            for (int i = 1; i != 4; ++i)
            {
                field[i - 1, j] = field[i, j];
            }
            field[3, j] = last_element;
            change_field();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            int j = 1;
            int last_element = field[0, j];
            for (int i = 1; i != 4; ++i)
            {
                field[i - 1, j] = field[i, j];
            }
            field[3, j] = last_element;
            change_field();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            int j = 2;
            int last_element = field[0, j];
            for (int i = 1; i != 4; ++i)
            {
                field[i - 1, j] = field[i, j];
            }
            field[3, j] = last_element;
            change_field();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            int j = 3;
            int last_element = field[0, j];
            for (int i = 1; i != 4; ++i)
            {
                field[i - 1, j] = field[i, j];
            }
            field[3, j] = last_element;
            change_field();
        }

        private void Button13_Click(object sender, EventArgs e)
        {
            int i = 0;
            int last_element = field[i, 0];
            for (int j = 1; j != 4; ++j)
            {
                field[i, j - 1] = field[i, j];
            }
            field[i, 3] = last_element;
            change_field();
        }

        private void Button14_Click(object sender, EventArgs e)
        {
            int i = 1;
            int last_element = field[i, 0];
            for (int j = 1; j != 4; ++j)
            {
                field[i, j - 1] = field[i, j];
            }
            field[i, 3] = last_element;
            change_field();
        }

        private void Button15_Click(object sender, EventArgs e)
        {
            int i = 2;
            int last_element = field[i, 0];
            for (int j = 1; j != 4; ++j)
            {
                field[i, j - 1] = field[i, j];
            }
            field[i, 3] = last_element;
            change_field();
        }

        private void Button16_Click(object sender, EventArgs e)
        {
            int i = 3;
            int last_element = field[i, 0];
            for (int j = 1; j != 4; ++j)
            {
                field[i, j - 1] = field[i, j];
            }
            field[i, 3] = last_element;
            change_field();
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
