using System.Data;

namespace MovingTheBalls
{
    public partial class FormMain : Form
    {
        static List<PictureBox> gamefield = new List<PictureBox>();
        readonly Random random = new Random();
        Agent agent;
        static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();

        public FormMain()
        {
            InitializeComponent();
            gamefield = panelGamefield.Controls.Cast<PictureBox>().ToList();

            int number = random.Next(1, 5);
            State initial = new State();
            State target = State.InitTargetState();
            //initial = State.InitInitialState(number);
            initial = State.GenerateState(5, target);
            RedrawField(initial.Field);

            agent = new Agent(initial, target, labelSolution, buttonSolve, textBoxSolutionStats);
            myTimer.Tick += new EventHandler(DrawSolution);
            myTimer.Interval = 500;
        }

        /* * * * * Misc Functions * * * * */

        // Redraw field after change balls positions
        public static void RedrawField(int[,] field)
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

        // Select image for field's cell
        private static Image? SelectImage(int value)
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

        private void DrawSolution(Object? myObject, EventArgs myEventArgs)
        {
            Stack<State> solver = agent.getSolver();
            if (solver.Count > 0)
            {
                State state = solver.Pop();
                RedrawField(state.Field);
                if (agent.Method == "Heuristic")
                {
                    labelGCost.Text = "Current G cost: " + state.GCost;
                    labelHCost.Text = "Current H cost: " + state.HCost;
                }
            }
            if (solver.Count < 1) myTimer.Stop();
        }

        /* * * * * Buttons * * * * */

        // Shuffle field
        private void ButtonShuffle_Click(object sender, EventArgs e)
        {
            int number = random.Next(1, 5);
            agent.State = State.InitInitialState(number);
            if (pictureBoxWin.Image != null)
            {
                pictureBoxWin.Image = null;
                labelWin.Text = "";
            }
            RedrawField(agent.State.Field);
        }

        private void ButtonSolve_Click(object sender, EventArgs e)
        {
            myTimer.Start();
        }

        private void AlgorithmHandler(object sender, EventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case "buttonBFS":
                    agent.Run(agent.BFS);
                    break;
                case "buttonBidirectionalSearch":
                    agent.Run(agent.BidirectionalSearch);
                    break;
                case "buttonHeuristicSearch":
                    agent.Run(agent.HeuristicSearch);
                    break;
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
                    agent.State.MoveColumnTop(0);
                    break;
                case "buttonTop2":
                    agent.State.MoveColumnTop(1);
                    break;
                case "buttonTop3":
                    agent.State.MoveColumnTop(2);
                    break;
                case "buttonTop4":
                    agent.State.MoveColumnTop(3);
                    break;

                case "buttonLeft1":
                    agent.State.MoveRowLeft(0);
                    break;
                case "buttonLeft2":
                    agent.State.MoveRowLeft(1);
                    break;
                case "buttonLeft3":
                    agent.State.MoveRowLeft(2);
                    break;
                case "buttonLeft4":
                    agent.State.MoveRowLeft(3);
                    break;
            }

            RedrawField(agent.State.Field);

            if (agent.State.CheckWinCondition())
            {
                pictureBoxWin.Image = Properties.Resources.win;
                labelWin.Text = "You won!";
            }
        }

        /* * * * * UI * * * * */
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
    }
}
