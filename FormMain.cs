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

        public class State
        {
            public int[,] field;
            public State parent;

            public State() { field = new int[4, 4]; parent = null; }

            public State(State Parent, int row, int column)
            {
                field = new int[4, 4];
                for (int i = 0; i < 4; i++)
                    for (int j = 0; j < 4; j++)
                        field[i, j] = Parent.field[i, j];
                if (row != -1) moveRow(row);
                else moveColumn(column);
                parent = Parent;
            }

            /* Initialize initial state of field by shuffle balloons */
            public void initInitialState(int number)
            {
                //Random random = new Random();
                //int redCount = 0, greenCount = 0, blueCount = 0, purpleCount = 0;

                //for (int i = 0; i < 4; i++)
                //{
                //    for (int j = 0; j < 4;)
                //    {
                //        int number = random.Next(0, 4);
                //        switch (number)
                //        {
                //            case (int)BALLOONS.RED:
                //                if (redCount < 4)
                //                {
                //                    redCount++;
                //                    field[i, j++] = number;
                //                }
                //                else continue;
                //                break;
                //            case (int)BALLOONS.GREEN:
                //                if (greenCount < 4)
                //                {
                //                    greenCount++;
                //                    field[i, j++] = number;
                //                }
                //                else continue;
                //                break;
                //            case (int)BALLOONS.BLUE:
                //                if (blueCount < 4)
                //                {
                //                    blueCount++;
                //                    field[i, j++] = number;
                //                }
                //                else continue;
                //                break;
                //            case (int)BALLOONS.PURPLE:
                //                if (purpleCount < 4)
                //                {
                //                    purpleCount++;
                //                    field[i, j++] = number;
                //                }
                //                else continue;
                //                break;
                //        }
                //    }
                //}

                for (int column = 0; column < 4; column++)
                    for (int row = 0; row < 4; row++)
                        field[row, column] = column;

                switch (number)
                {
                    case 1:
                        field[0, 0] = 3;
                        field[0, 1] = 0;
                        field[0, 2] = 1;
                        field[0, 3] = 2;

                        field[1, 0] = 2;
                        field[1, 1] = 3;
                        field[1, 2] = 0;
                        field[1, 3] = 1;

                        field[2, 0] = 2;
                        field[2, 1] = 3;
                        field[2, 2] = 0;
                        field[2, 3] = 1;
                        break;
                    case 2:
                        field[1, 0] = 3;
                        field[1, 1] = 0;
                        field[1, 2] = 1;
                        field[1, 3] = 2;

                        field[2, 0] = 1;
                        field[2, 1] = 2;
                        field[2, 2] = 3;
                        field[2, 3] = 0;
                        break;
                    case 3:
                        field[0, 0] = 2;
                        field[0, 1] = 3;
                        field[0, 2] = 0;
                        field[0, 3] = 1;

                        field[3, 0] = 1;
                        field[3, 1] = 2;
                        field[3, 2] = 3;
                        field[3, 3] = 0;
                        break;
                    case 4:
                        field[1, 0] = 1;
                        field[1, 1] = 2;
                        field[1, 2] = 3;
                        field[1, 3] = 0;

                        field[2, 0] = 2;
                        field[2, 1] = 3;
                        field[2, 2] = 0;
                        field[2, 3] = 1;
                        break;
                }

                redrawField();
            }
            
            /* Initialize target state of field. */
            public void initTargetState()
            {
                for (int column = 0; column < 4; column++)
                    for (int row = 0; row < 4; row++)
                        field[row, column] = column;
            }

            /* Move j column to the top by 1 balloon */
            public void moveColumn(int j)
            {
                int last = field[0, j];
                for (int i = 1; i < 4; i++) field[i - 1, j] = field[i, j];
                field[3, j] = last;
            }

            /* Move i row to the left by 1 balloon */
            public void moveRow(int i)
            {
                int last = field[i, 0];
                for (int j = 1; j < 4; j++) field[i, j - 1] = field[i, j];
                field[i, 3] = last;
            }

            /* Check if two states are equal by comparing fields */
            public static bool operator ==(State A, State B)
            {
                for (int i = 0; i < 4; i++)
                    for (int j = 0; j < 4; j++)
                        if (A.field[i, j] != B.field[i, j]) return false;
                return true;
            }

            public static bool operator !=(State A, State B)
            {
                for (int i = 0; i < 4; i++)
                    for (int j = 0; j < 4; j++)
                        if (A.field[i, j] != B.field[i, j]) return true;
                return false;
            }

            public Image selectImage(int value)
            {
                switch (value)
                {
                    case 0: return Lab1.Properties.Resources.red;
                    case 1: return Lab1.Properties.Resources.green;
                    case 2: return Lab1.Properties.Resources.blue;
                    case 3: return Lab1.Properties.Resources.purple;
                }
                return null;
            }

            public void redrawField()
            {
                int k = 0;
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        gamefield[k].Image = selectImage(field[i, j]);
                        k++;
                    }
                }
            }

            public bool checkWinCondition()
            {
                /* Counting values from every cell in 0-3 columns. If sum is not equal to 4 * column we dont need to check further */
                for (int column = 0; column < 4; column++)
                {
                    int sum = 0;
                    for (int row = 0; row < 4; row++) sum += field[row, column];
                    if (sum != 4 * column) return false;
                }
                return true;
            }
        }

        State initial = new State();
        static List<PictureBox> gamefield;
        static Stack<State> Solver = new Stack<State>();
        static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();

        public FormMain()
        {
            InitializeComponent();
            gamefield = panelGamefield.Controls.Cast<PictureBox>().ToList();
            Solver = new Stack<State>();
            Random random = new Random();
            int number = random.Next(1, 5);
            initial.initInitialState(number);
            myTimer.Tick += new EventHandler(drawSolution);
            myTimer.Interval = 500;
        }

        private void buttonShuffle_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int number = random.Next(1, 5);
            initial.initInitialState(number);
            if (pictureBoxWin.Image != null)
            {
                pictureBoxWin.Image = null;
                labelWin.Text = "";
            }
        }

        private void movementHandler(object sender, EventArgs e)
        {
            if (pictureBoxWin.Image != null)
            {
                pictureBoxWin.Image = null;
                labelWin.Text = "";
            }

            switch ((sender as Button).Name)
            {
                case "buttonTop1":
                    initial.moveColumn(0);
                    initial.redrawField();
                    break;
                case "buttonTop2":
                    initial.moveColumn(1);
                    initial.redrawField();
                    break;
                case "buttonTop3":
                    initial.moveColumn(2);
                    initial.redrawField();
                    break;
                case "buttonTop4":
                    initial.moveColumn(3);
                    initial.redrawField();
                    break;

                case "buttonLeft1":
                    initial.moveRow(0);
                    initial.redrawField();
                    break;
                case "buttonLeft2":
                    initial.moveRow(1);
                    initial.redrawField();
                    break;
                case "buttonLeft3":
                    initial.moveRow(2);
                    initial.redrawField();
                    break;
                case "buttonLeft4":
                    initial.moveRow(3);
                    initial.redrawField();
                    break;
            }

            if (initial.checkWinCondition())
            {
                pictureBoxWin.Image = Lab1.Properties.Resources.win;
                labelWin.Text = "You won!";
            }
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

        private void buttonFindSolution_Click(object sender, EventArgs e)
        {
            Queue<State> Open = new Queue<State>();
            Queue<State> Close = new Queue<State>();

            State target = new State();
            target.initTargetState();

            bool isSolved = false;
            State current = new State();
            State[] childs = new State[8];

            Open.Enqueue(initial);
            /* loop for finding path to solution */
            while (Open.Count != 0)
            {
                current = Open.Dequeue();
                if (current == target)
                {
                    isSolved = true;
                    break;
                }

                Close.Enqueue(current);

                /* i == 0 for childs with moved row, i == 1 for childs with moved column */
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (i == 0) childs[i * 4 + j] = new State(current, j, -1);
                        else childs[i * 4 + j] = new State(current, -1, j);

                        if (!Close.Contains(childs[i * 4 + j]) && !Open.Contains(childs[i * 4 + j])) Open.Enqueue(childs[i * 4 + j]);
                    }
                }
            }

            if (isSolved)
            {
                labelSolution.Text = "Solution found!";
                while (current != initial)
                {
                    Solver.Push(current);
                    current = current.parent;
                }
                buttonSolve.Visible = true;
                
            }
            else labelSolution.Text = "Solution not found!";
        }

        private static void drawSolution(Object myObject, EventArgs myEventArgs)
        {
            State state = new State();
            if (Solver.Count > 0)
            {
                state = Solver.Pop();
                state.redrawField();
            }
        }
        
        private void buttonSolve_Click(object sender, EventArgs e)
        {
            myTimer.Start();
            if (Solver.Count < 1) myTimer.Stop();
        }
    }
}
