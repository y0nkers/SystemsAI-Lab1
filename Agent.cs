namespace MovingTheBalls
{
    public class Agent
    {
        private State initial, target;
        public State State { get { return initial; } }
        private string? method;
        public string? Method { get { return method; } }
        private Stack<State> solver = new Stack<State>();

        private Label labelSolution;
        private Button buttonSolve;
        private TextBox heuresticStats;

        public Agent(State initial, State target, Label labelSolution, Button buttonSolve, TextBox heuresticStats)
        {
            this.initial = initial;
            this.target = target;
            this.labelSolution = labelSolution;
            this.buttonSolve = buttonSolve;
            this.heuresticStats = heuresticStats;
        }

        // Breadth-first search algorithm
        public void BFS()
        {
            method = "BFS";
            Queue<State> opened = new Queue<State>();
            Queue<State> closed = new Queue<State>();

            bool isSolved = false;
            State? current = new State();
            State[] childs = new State[8];

            if (initial != null) opened.Enqueue(initial);
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
                    solver.Push(current);
                    current = current.Parent;
                }
                buttonSolve.Visible = true;

            }
            else labelSolution.Text = "Solution not found!";
        }

        // Bidirectional Search algorithm
        public void BidirectionalSearch()
        {
            method = "Bidirectional";
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
                    initialIntersection = initialIntersection.Parent;
                }

                Stack<State> targetStack = new Stack<State>();
                while (targetIntersection != null)
                {
                    targetStack.Push(targetIntersection);
                    targetIntersection = targetIntersection.Parent;
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
                    solver.Push(combined[i]);

                labelSolution.Text = "Solution found!";
                buttonSolve.Visible = true;

            }
            else labelSolution.Text = "Solution not found!";
        }

        // HeuristicSearch algorithm
        public void HeuristicSearch()
        {
            method = "Heuristic";
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
                if (current == null) return;
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
                            var state = opened.Find(x => (x.HCost + x.GCost >= childs[idx].HCost + childs[idx].GCost) && (x.Field == childs[idx].Field));
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
                            var state = closed.Find(x => (x.HCost + x.GCost >= childs[idx].HCost + childs[idx].GCost) && (x.Field == childs[idx].Field));
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

                int N = opened.Count + closed.Count;
                int d = current.GCost;
                string formula = N + " = b";
                for (int i = 2; i <= d; ++i) formula += " + b^" + i + " ";
                string text = "Total number of states N = " + N + Environment.NewLine + "Solution Depth d = " + d + Environment.NewLine + "Formula for calculating b*:" + Environment.NewLine + formula;
                heuresticStats.Visible = true;
                heuresticStats.Text = text;

                while (current != initial && current != null)
                {
                    solver.Push(current);
                    current = current.Parent;
                }
                buttonSolve.Visible = true;


            }
            else labelSolution.Text = "Solution not found!";
        }

        public Stack<State> getSolver() { return solver; }
    }
}
