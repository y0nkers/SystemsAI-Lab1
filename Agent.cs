namespace MovingTheBalls
{
    public class Agent
    {
        private State initial, target;
        public State State { get { return initial; } set { initial = value; } }
        private string? method;
        public string? Method { get { return method; } }
        private Stack<State> solver = new Stack<State>();

        private Label labelSolution;
        private Button buttonSolve;
        private TextBox tbStats;

        private int openedNodes = 0, closedNodes = 0, solutionDepth = 0, iterationsCount = 0; 

        public Agent(State initial, State target, Label labelSolution, Button buttonSolve, TextBox tbStats)
        {
            this.initial = initial;
            this.target = target;
            this.labelSolution = labelSolution;
            this.buttonSolve = buttonSolve;
            this.tbStats = tbStats;
        }

        public void Run(Action method)
        {
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            method();
            stopwatch.Stop();
            PrintStats(stopwatch.ElapsedMilliseconds);
        }

        private static string ReadableTime(long milliseconds)
        {
            var parts = new List<string>();
            Action<int, string> add = (val, unit) => { if (val > 0) parts.Add(val+unit); };
            var t = TimeSpan.FromMilliseconds(milliseconds);

            add(t.Minutes, "m");
            add(t.Seconds, "s");
            add(t.Milliseconds, "ms");

            return string.Join(" ", parts);
        }

        private void PrintStats(long milliseconds)
        {
            TimeSpan timeSpan = TimeSpan.FromMilliseconds(milliseconds);
            int N = openedNodes + closedNodes;
            string formula = N + " = b";
            for (int i = 2; i <= solutionDepth; ++i) formula += " + b^" + i + " ";
            string text = "Elapsed time: " + milliseconds + " ms (" + ReadableTime(milliseconds) + ")" + Environment.NewLine 
                + "Iterations count: " + iterationsCount + Environment.NewLine
                + "Opened nodes: O = " + openedNodes + Environment.NewLine
                //+ "Closed nodes: C = " + closedNodes + Environment.NewLine
                + "Total number of nodes: N = " + N + Environment.NewLine
                + "Solution Depth d = " + solutionDepth + Environment.NewLine
                + "Formula for calculating b*:" + Environment.NewLine + formula;
            tbStats.Visible = true;
            tbStats.Text = text;
        }

        // Breadth-first search algorithm
        public void BFS()
        {
            openedNodes = closedNodes = solutionDepth = iterationsCount = 0;
            method = "BFS";
            Queue<State> opened = new Queue<State>();
            Queue<State> closed = new Queue<State>();

            bool isSolved = false;
            State? current = new State();
            State[] childs = new State[8];

            if (initial != null)
            {
                opened.Enqueue(initial);
                ++openedNodes;
            }

            /* loop for finding path to solution */
            while (opened.Count != 0)
            {
                ++iterationsCount;
                current = opened.Dequeue();
                --openedNodes;
                if (current == target)
                {
                    solutionDepth = current.GCost;
                    isSolved = true;
                    break;
                }

                closed.Enqueue(current);
                ++closedNodes;

                /* i == 0 for childs with moved row, i == 1 for childs with moved column */
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        int idx = i * 4 + j;
                        if (i == 0) childs[idx] = new State(current, j, -1, false);
                        else childs[idx] = new State(current, -1, j, false);

                        if (!closed.Contains(childs[idx]) && !opened.Contains(childs[idx]))
                        {
                            opened.Enqueue(childs[idx]);
                            ++openedNodes;
                        }
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
            openedNodes = closedNodes = solutionDepth = iterationsCount = 0;
            method = "Bidirectional";
            Queue<State> initialOpened = new Queue<State>();
            Queue<State> initialClosed = new Queue<State>();

            Queue<State> targetOpened = new Queue<State>();
            Queue<State> targetClosed = new Queue<State>();

            bool isSolved = false;
            State[] initialChilds = new State[8];
            State[] targetChilds = new State[8];

            initialOpened.Enqueue(initial);
            targetOpened.Enqueue(target);
            openedNodes += 2;

            State savedIntersection = new State();

            while (initialOpened.Count != 0 && targetOpened.Count != 0)
            {
                ++iterationsCount;
                var stateInitial = initialOpened.Peek();
                var stateTarget = targetOpened.Peek();

                if (targetOpened.Contains(stateInitial))
                {
                    savedIntersection = stateInitial;
                    isSolved = true;
                    break;
                }
                else if (initialOpened.Contains(stateTarget))
                {
                    savedIntersection = stateTarget;
                    isSolved = true;
                    break;
                }

                State initialCurrent = initialOpened.Dequeue();
                State targetCurrent = targetOpened.Dequeue();
                openedNodes -= 2;
                initialClosed.Enqueue(initialCurrent);
                targetClosed.Enqueue(targetCurrent);
                closedNodes += 2;

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

                        if (!initialClosed.Contains(initialChilds[idx]) && !initialOpened.Contains(initialChilds[idx]))
                        {
                            initialOpened.Enqueue(initialChilds[idx]);
                            openedNodes++;
                        }
                        if (!targetClosed.Contains(targetChilds[idx]) && !targetOpened.Contains(targetChilds[idx]))
                        {
                            targetOpened.Enqueue(targetChilds[idx]);
                            openedNodes++;
                        }
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
                while (targetOpened.Count > 0)
                {
                    targetIntersection = targetOpened.Dequeue();
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
                // We dont need last element because its already in initialList
                while (targetStack.Count > 1) 
                    targetList.Add(targetStack.Pop());
                
                // Reverse list's elements because it was writed from target to intersection
                targetList.Reverse();

                var combined = initialList.Concat(targetList).ToList();
                combined.Reverse();

                for (int i = 0; i < combined.Count; i++) 
                    solver.Push(combined[i]);

                labelSolution.Text = "Solution found!";
                buttonSolve.Visible = true;
                solutionDepth = solver.Count - 1;
            }
            else labelSolution.Text = "Solution not found!";
        }

        // HeuristicSearch algorithm
        public void HeuristicSearch()
        {
            openedNodes = closedNodes = solutionDepth = iterationsCount = 0;
            method = "Heuristic";
            List<State> opened = new List<State>();
            List<State> closed = new List<State>();

            bool isSolved = false;
            State? current = new State();
            State[] childs = new State[8];

            opened.Add(initial);
            ++openedNodes;

            /* loop for finding path to solution */
            while (opened.Count != 0)
            {
                ++iterationsCount;
                current = opened.Min();
                if (current == null) return;
                opened.Remove(current);
                --openedNodes;

                if (current == target)
                {
                    solutionDepth = current.GCost;
                    isSolved = true;
                    break;
                }

                closed.Add(current);
                ++closedNodes;

                /* i == 0 for childs with moved row, i == 1 for childs with moved column */
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        int idx = i * 4 + j;
                        if (i == 0) childs[idx] = new State(current, j, -1, false);
                        else childs[idx] = new State(current, -1, j, false);

                        // Branch 1. If State is not in any of the lists, then we put it in the Open list
                        if (!closed.Contains(childs[idx]) && !opened.Contains(childs[idx]))
                        {
                            opened.Add(childs[idx]);
                            ++openedNodes;
                        }
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
                                --closedNodes;
                                opened.Add(childs[idx]);
                                ++openedNodes;
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
