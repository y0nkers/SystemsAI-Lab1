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

            public State(State Parent, int row, int column, bool reversed)
            {
                field = new int[4, 4];
                for (int i = 0; i < 4; i++)
                    for (int j = 0; j < 4; j++)
                        field[i, j] = Parent.field[i, j];
                if (row != -1)
                {
                    if (reversed) moveRowRight(row);
                    else moveRowLeft(row);
                }
                    
                else
                {
                    if (reversed) moveColumnBottom(column);
                    else moveColumnTop(column);
                }
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
            public void moveColumnTop(int j)
            {
                int last = field[0, j];
                for (int i = 1; i < 4; i++) field[i - 1, j] = field[i, j];
                field[3, j] = last;
            }

            /* Move j column to the bottom by 1 balloon */
            public void moveColumnBottom(int j)
            {
                int first = field[3, j];
                for (int i = 3; i > 0; i--) field[i, j] = field[i - 1, j];
                field[0, j] = first;
            }

            /* Move i row to the left by 1 balloon */
            public void moveRowLeft(int i)
            {
                int last = field[i, 0];
                for (int j = 1; j < 4; j++) field[i, j - 1] = field[i, j];
                field[i, 3] = last;
            }

            /* Move i row to the right by 1 balloon */
            public void moveRowRight(int i)
            {
                int first = field[i, 3];
                for (int j = 3; j > 0; j--) field[i, j] = field[i, j - 1];
                field[i, 0] = first;
            }

            /* Check if two states are equal by comparing fields */
            public static bool operator ==(State A, State B)
            {
                if (ReferenceEquals(A, B)) return true;
                if (ReferenceEquals(A, null)) return false;
                if (ReferenceEquals(B, null)) return false;

                for (int i = 0; i < 4; i++)
                    for (int j = 0; j < 4; j++)
                        if (A.field[i, j] != B.field[i, j]) return false;
                return true;
            }

            public static bool operator !=(State A, State B) => !(A == B);
            public override bool Equals(Object other)
            {
                if (ReferenceEquals(other, null)) return false;
                if (ReferenceEquals(this, other)) return true;

                var item = other as State;
                for (int i = 0; i < 4; i++)
                    for (int j = 0; j < 4; j++)
                        if (field[i, j] != item.field[i, j]) return false;
                return true;
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
                    initial.moveColumnTop(0);
                    initial.redrawField();
                    break;
                case "buttonTop2":
                    initial.moveColumnTop(1);
                    initial.redrawField();
                    break;
                case "buttonTop3":
                    initial.moveColumnTop(2);
                    initial.redrawField();
                    break;
                case "buttonTop4":
                    initial.moveColumnTop(3);
                    initial.redrawField();
                    break;

                case "buttonLeft1":
                    initial.moveRowLeft(0);
                    initial.redrawField();
                    break;
                case "buttonLeft2":
                    initial.moveRowLeft(1);
                    initial.redrawField();
                    break;
                case "buttonLeft3":
                    initial.moveRowLeft(2);
                    initial.redrawField();
                    break;
                case "buttonLeft4":
                    initial.moveRowLeft(3);
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

        private void buttonBFS_Click(object sender, EventArgs e)
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
                        int idx = i * 4 + j;
                        if (i == 0) childs[idx] = new State(current, j, -1, false);
                        else childs[idx] = new State(current, -1, j, false);

                        if (!Close.Contains(childs[idx]) && !Open.Contains(childs[idx])) Open.Enqueue(childs[idx]);
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
        private void buttonBidirectionalSearch_Click(object sender, EventArgs e)
        {
            Queue<State> initialOpen = new Queue<State>();
            Queue<State> initialClosed = new Queue<State>();

            Queue<State> targetOpen = new Queue<State>();
            Queue<State> targetClosed = new Queue<State>();

            State target = new State();
            target.initTargetState();

            bool isSolved = false;
            State initialCurrent = new State();
            State targetCurrent = new State();
            State[] initialChilds = new State[8];
            State[] targetChilds = new State[8];

            initialOpen.Enqueue(initial);
            targetOpen.Enqueue(target);

            State savedIntersection = new State();

            while (initialOpen.Count != 0 && targetOpen.Count != 0)
            {
                var state = initialOpen.Peek();
                if (targetOpen.Contains(state))
                {
                    savedIntersection = state;
                    isSolved = true;
                    break;
                }

                initialCurrent = initialOpen.Dequeue();
                targetCurrent = targetOpen.Dequeue();
                initialClosed.Enqueue(initialCurrent);
                targetClosed.Enqueue(targetCurrent);

                /* i == 0 for childs with moved row, i == 1 for childs with moved column */
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        int idx = i * 4 + j;
                        if (i == 0)
                        {
                            initialChilds[idx] = new State(initialCurrent, j, -1, false);
                            targetChilds[idx] = new State(targetCurrent, j, -1, true);
                        }
                        else
                        {
                            initialChilds[idx] = new State(initialCurrent, -1, j, false);
                            targetChilds[idx] = new State(targetCurrent, -1, j, true);
                        }

                        if (!initialClosed.Contains(initialChilds[idx]) && !initialOpen.Contains(initialChilds[idx])) initialOpen.Enqueue(initialChilds[idx]);
                        if (!targetClosed.Contains(targetChilds[idx]) && !targetOpen.Contains(targetChilds[idx])) targetOpen.Enqueue(targetChilds[idx]);
                    }
                }
            }

            if (isSolved)
            {
                // Find Intersection from Initial State side
                State initialIntersection = new State();
                while (initialOpen.Count > 0)
                {
                    initialIntersection = initialOpen.Dequeue();
                    if (initialIntersection == savedIntersection) 
                        break;
                }

                // Find Intersection from Target State side
                State targetIntersection = new State();
                while (targetOpen.Count > 0)
                {
                    targetIntersection = targetOpen.Dequeue();
                    if (targetIntersection == savedIntersection) 
                        break;
                }

                Stack<State> initialStack = new Stack<State>();
                while (initialIntersection != null)
                {
                    initialStack.Push(initialIntersection);
                    initialIntersection = initialIntersection.parent;
                }

                Stack<State> targetStack = new Stack<State>();
                while (targetIntersection != null)
                {
                    targetStack.Push(targetIntersection);
                    targetIntersection = targetIntersection.parent;
                }

                List<State> initialList= new List<State>();
                while (initialStack.Count > 0)
                    initialList.Add(initialStack.Pop());

                List<State> targetList = new List<State>();

                while (targetStack.Count > 1) // We dont need last element because its already in initialList
                    targetList.Add(targetStack.Pop());
                // Reverse list's elements because it was writed from target to intersection
                targetList.Reverse();

                var combined = initialList.Concat(targetList).ToList();
                combined.Reverse();

                for (int i = 0; i < combined.Count; i++)
                    Solver.Push(combined[i]);

                labelSolution.Text = "Solution found!";
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
