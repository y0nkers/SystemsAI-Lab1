using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovingTheBalls
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

        public class State : IComparable<State>
        {
            public int[,] field;
            public State? parent;
            public int gCost; // Cost of path from initial state to current state
            public int hCost; // Heurestic cost

            // Default constructor
            public State() { field = new int[4, 4]; parent = null; gCost = 0; hCost = 0; }

            /// <summary>
            /// Constructor init
            /// </summary>
            /// <param name="parent">Parent of created state</param>
            /// <param name="row">Which row needs to be rotated. -1 if column needs to rotated.</param>
            /// <param name="column">Which column needs to be rotated. -1 if row needs to be rotated.</param>
            /// <param name="reversed">True if created state is child of target state (going from end to the middle).</param>
            public State(State parent, int row, int column, bool reversed)
            {
                this.parent = parent;
                field = new int[4, 4];
                for (int i = 0; i < 4; i++)
                    for (int j = 0; j < 4; j++)
                        field[i, j] = parent.field[i, j];
                if (row != -1)
                {
                    if (reversed) MoveRowRight(row);
                    else MoveRowLeft(row);
                }

                else
                {
                    if (reversed) MoveColumnBottom(column);
                    else MoveColumnTop(column);
                }
                gCost = parent.gCost + 1;
                hCost = HeuristicH1();
            }

            /* Initialize initial state of field by shuffle balloons */
            public void InitInitialState(int number)
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

                RedrawField();
            }

            /* Initialize target state of field. */
            public void InitTargetState()
            {
                for (int column = 0; column < 4; column++)
                    for (int row = 0; row < 4; row++)
                        field[row, column] = column;
            }

            /* Move j column to the top by 1 balloon */
            public void MoveColumnTop(int j)
            {
                int last = field[0, j];
                for (int i = 1; i < 4; i++) field[i - 1, j] = field[i, j];
                field[3, j] = last;
            }

            /* Move j column to the bottom by 1 balloon */
            public void MoveColumnBottom(int j)
            {
                int first = field[3, j];
                for (int i = 3; i > 0; i--) field[i, j] = field[i - 1, j];
                field[0, j] = first;
            }

            /* Move i row to the left by 1 balloon */
            public void MoveRowLeft(int i)
            {
                int last = field[i, 0];
                for (int j = 1; j < 4; j++) field[i, j - 1] = field[i, j];
                field[i, 3] = last;
            }

            /* Move i row to the right by 1 balloon */
            public void MoveRowRight(int i)
            {
                int first = field[i, 3];
                for (int j = 3; j > 0; j--) field[i, j] = field[i, j - 1];
                field[i, 0] = first;
            }

            /* Check if two states are equal by comparing fields */
            public static bool operator ==(State? A, State? B)
            {
                if (ReferenceEquals(A, B)) return true;
                if (ReferenceEquals(A, null)) return false;
                if (ReferenceEquals(B, null)) return false;

                for (int i = 0; i < 4; i++)
                    for (int j = 0; j < 4; j++)
                        if (A.field[i, j] != B.field[i, j]) return false;
                return true;
            }

            public static bool operator !=(State? A, State? B) => !(A == B);

            public override bool Equals(Object? other)
            {
                var item = other as State;
                if (ReferenceEquals(item, null)) return false;
                if (ReferenceEquals(this, item)) return true;

                for (int i = 0; i < 4; i++)
                    for (int j = 0; j < 4; j++)
                        if (field[i, j] != item.field[i, j]) return false;
                return true;
            }

            public override int GetHashCode() => field.GetHashCode();

            public int CompareTo(State? other)
            {
                if (other == null) return 1;
                int result = 0;
                if (gCost + hCost < other.gCost + other.hCost) result = -1;
                else if (gCost + hCost > other.gCost + other.hCost) result = 1;
                else if (gCost + hCost == other.gCost + other.hCost) result = 0;
                return result;
            }

            // Select image for field's cell
            public static Image? SelectImage(int value)
            {
                switch (value)
                {
                    case 0: return Properties.Resources.red;
                    case 1: return Properties.Resources.green;
                    case 2: return Properties.Resources.blue;
                    case 3: return Properties.Resources.purple;
                }
                return null;
            }

            // Redraw field after change balls positions
            public void RedrawField()
            {
                int k = 0;
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        gamefield[k].Image = SelectImage(field[i, j]);
                        k++;
                    }
                }
            }

            // Check if current state is a win-state
            public bool CheckWinCondition()
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

            public void SetHeuresticCost(Func<int> function)
            {
                hCost = function();
            }

            // Heurestic function h1 (Hamming distance) - counts the number of balls that are out of place
            public int HeuristicH1()
            {
                int h1 = 0;
                for (int column = 0; column < 4; ++column)
                    for (int row = 0; row < 4; ++row)
                        if (field[row, column] != column) h1++;
                return h1;
            }
        }

        State initial = new State();
        State target = new State();
        static List<PictureBox> gamefield = new List<PictureBox>();
        static Stack<State> Solver = new Stack<State>();
        static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
        static Label gCost, hCost;

        public FormMain()
        {
            InitializeComponent();
            gamefield = panelGamefield.Controls.Cast<PictureBox>().ToList();
            Solver = new Stack<State>();
            Random random = new Random();
            int number = random.Next(1, 5);
            initial.InitInitialState(number);
            target.InitTargetState();
            myTimer.Tick += new EventHandler(DrawSolution);
            myTimer.Interval = 500;
            gCost = labelGCost;
            hCost = labelHCost;

            Queue<State> open = new Queue<State>();
            initial.SetHeuresticCost(initial.HeuristicH1);
            target.SetHeuresticCost(target.HeuristicH1);
            open.Enqueue(initial);
            open.Enqueue(target);
            var min = open.Min();

        }

        public static void UpdateHeuresticSearch(int g, int h)
        {
            gCost.Text = "Current G cost: " + g;
            hCost.Text = "Current H cost: " + h;
        }

        private void ButtonShuffle_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int number = random.Next(1, 5);
            initial.InitInitialState(number);
            if (pictureBoxWin.Image != null)
            {
                pictureBoxWin.Image = null;
                labelWin.Text = "";
            }
        }

        private void MovementHandler(object sender, EventArgs e)
        {
            if (pictureBoxWin.Image != null)
            {
                pictureBoxWin.Image = null;
                labelWin.Text = "";
            }

            switch (((Button)sender).Name)
            {
                case "buttonTop1":
                    initial.MoveColumnTop(0);
                    initial.RedrawField();
                    break;
                case "buttonTop2":
                    initial.MoveColumnTop(1);
                    initial.RedrawField();
                    break;
                case "buttonTop3":
                    initial.MoveColumnTop(2);
                    initial.RedrawField();
                    break;
                case "buttonTop4":
                    initial.MoveColumnTop(3);
                    initial.RedrawField();
                    break;

                case "buttonLeft1":
                    initial.MoveRowLeft(0);
                    initial.RedrawField();
                    break;
                case "buttonLeft2":
                    initial.MoveRowLeft(1);
                    initial.RedrawField();
                    break;
                case "buttonLeft3":
                    initial.MoveRowLeft(2);
                    initial.RedrawField();
                    break;
                case "buttonLeft4":
                    initial.MoveRowLeft(3);
                    initial.RedrawField();
                    break;
            }

            if (initial.CheckWinCondition())
            {
                pictureBoxWin.Image = Properties.Resources.win;
                labelWin.Text = "You won!";
            }
        }

        private void ButtonTopHover(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            button.Image = Properties.Resources.buttonTopHover;
        }

        private void ButtonTopLeaveHover(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.Image = Properties.Resources.buttonTop;
        }

        private void ButtonLeftHover(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            button.Image = Properties.Resources.buttonLeftHover;
        }

        private void ButtonLeftLeaveHover(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.Image = Properties.Resources.buttonLeft;
        }

        private void ButtonBFS_Click(object sender, EventArgs e)
        {
            Queue<State> opened = new Queue<State>();
            Queue<State> closed = new Queue<State>();

            bool isSolved = false;
            State? current = new State();
            State[] childs = new State[8];

            opened.Enqueue(initial);
            /* loop for finding path to solution */
            while (opened.Count != 0)
            {
                current = opened.Dequeue();
                if (current == target)
                {
                    isSolved = true;
                    break;
                }

                closed.Enqueue(current);

                /* i == 0 for childs with moved row, i == 1 for childs with moved column */
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        int idx = i * 4 + j;
                        if (i == 0) childs[idx] = new State(current, j, -1, false);
                        else childs[idx] = new State(current, -1, j, false);

                        if (!closed.Contains(childs[idx]) && !opened.Contains(childs[idx])) opened.Enqueue(childs[idx]);
                    }
                }
            }

            if (isSolved)
            {
                labelSolution.Text = "Solution found!";
                while (current != initial && current != null)
                {
                    Solver.Push(current);
                    current = current.parent;
                }
                buttonSolve.Visible = true;

            }
            else labelSolution.Text = "Solution not found!";
        }
        private void ButtonBidirectionalSearch_Click(object sender, EventArgs e)
        {
            Queue<State> initialOpened = new Queue<State>();
            Queue<State> initialClosed = new Queue<State>();

            Queue<State> targetOpen = new Queue<State>();
            Queue<State> targetClosed = new Queue<State>();

            bool isSolved = false;
            State[] initialChilds = new State[8];
            State[] targetChilds = new State[8];

            initialOpened.Enqueue(initial);
            targetOpen.Enqueue(target);

            State savedIntersection = new State();

            while (initialOpened.Count != 0 && targetOpen.Count != 0)
            {
                var state = initialOpened.Peek();
                if (targetOpen.Contains(state))
                {
                    savedIntersection = state;
                    isSolved = true;
                    break;
                }

                State initialCurrent = initialOpened.Dequeue();
                State targetCurrent = targetOpen.Dequeue();
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

                        if (!initialClosed.Contains(initialChilds[idx]) && !initialOpened.Contains(initialChilds[idx])) initialOpened.Enqueue(initialChilds[idx]);
                        if (!targetClosed.Contains(targetChilds[idx]) && !targetOpen.Contains(targetChilds[idx])) targetOpen.Enqueue(targetChilds[idx]);
                    }
                }
            }

            if (isSolved)
            {
                // Find Intersection from Initial State side
                State? initialIntersection = new State();
                while (initialOpened.Count > 0)
                {
                    initialIntersection = initialOpened.Dequeue();
                    if (initialIntersection == savedIntersection)
                        break;
                }

                // Find Intersection from Target State side
                State? targetIntersection = new State();
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

                List<State> initialList = new List<State>();
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

        private void ButtonHeuristicSearch_Click(object sender, EventArgs e)
        {
            List<State> opened = new List<State>();
            List<State> closed = new List<State>();

            bool isSolved = false;
            State? current = new State();
            State[] childs = new State[8];

            opened.Add(initial);
            /* loop for finding path to solution */
            while (opened.Count != 0)
            {
                current = opened.Min();
                opened.Remove(current);

                if (current == target)
                {
                    isSolved = true;
                    break;
                }

                closed.Add(current);

                /* i == 0 for childs with moved row, i == 1 for childs with moved column */
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        int idx = i * 4 + j;
                        if (i == 0) childs[idx] = new State(current, j, -1, false);
                        else childs[idx] = new State(current, -1, j, false);

                        // Branch 1. If State is not in any of the lists, then we put it in the Open list
                        if (!closed.Contains(childs[idx]) && !opened.Contains(childs[idx])) opened.Add(childs[idx]);
                        // Branch 2. If State is in the Open list and its new cost is lower than the old one, then we replace it.
                        else if (opened.Contains(childs[idx]))
                        {
                            var state = opened.Find(x => (x.hCost + x.gCost >= childs[idx].hCost + childs[idx].gCost) && (x.field == childs[idx].field));
                            if (state != null)
                            {
                                opened.Remove(state);
                                opened.Add(childs[idx]);
                            }
                        }
                        // Branch 3. If the State is already in Closed and its new cost is lower than the old one,
                        // then move it from Closed to Open, replace the old cost with the new one.
                        else if (closed.Contains(childs[idx]))
                        {
                            var state = closed.Find(x => (x.hCost + x.gCost >= childs[idx].hCost + childs[idx].gCost) && (x.field == childs[idx].field));
                            if (state != null)
                            {
                                closed.Remove(state);
                                opened.Add(childs[idx]);
                            }
                        }
                    }
                }
            }

            if (isSolved)
            {
                labelSolution.Text = "Solution found!";
                while (current != initial && current != null)
                {
                    Solver.Push(current);
                    current = current.parent;
                }
                buttonSolve.Visible = true;

            }
            else labelSolution.Text = "Solution not found!";
        }

        private static void DrawSolution(Object? myObject, EventArgs myEventArgs)
        {
            if (Solver.Count > 0)
            {
                State state = Solver.Pop();
                state.RedrawField();
                UpdateHeuresticSearch(state.gCost, state.hCost);
                
            }
        }

        private void ButtonSolve_Click(object sender, EventArgs e)
        {
            myTimer.Start();
            if (Solver.Count < 1) myTimer.Stop();
        }
    }
}
