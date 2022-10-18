namespace MovingTheBalls
{
    public class State : IComparable<State>
    {
        enum BALLOONS
        {
            RED = 0,
            GREEN = 1,
            BLUE = 2,
            PURPLE = 3
        }

        // Fields
        private int[,] field { get; set; } // Represents field of balloons
        private State? parent; // Parent of current state. Null if its initial state
        private int gCost; // Cost of path from initial state to current state
        private int hCost; // Heurestic cost

        // Properties
        public int[,] Field { get { return field; } }
        public State? Parent { get { return parent; } }
        public int GCost { get { return gCost; } }
        public int HCost { get { return hCost; } }

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
            // hCost = HeuristicCost(HeuristicH1);
            hCost = HeuristicCost(HeuristicH2);
        }

        /* Initialize initial state of field by shuffle balloons */
        public void InitInitialState(int state)
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

            switch (state)
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

        // Set function for calculate state's heuristic cost 
        public int HeuristicCost(Func<int> function)
        {
            hCost = function();
            return hCost;
        }

        // Heuristic function h1 (Hamming distance) - counts the number of balls that are out of place
        public int HeuristicH1()
        {
            int h1 = 0;
            for (int column = 0; column < 4; ++column)
                for (int row = 0; row < 4; ++row)
                    if (field[row, column] != column) h1++;
            return h1;
        }

        // Heuristic function h2 (Manhattan distance). For this objective function h2 IS NOT admissible 
        public int HeuristicH2()
        {
            int h2 = 0;
            for (int color = 0; color < 4; color++)
            {
                // 1. Find all balls of current color
                (int row, int column)[] coordinates = new (int, int)[4];
                int count = 0;
                for (int i = 0; i < 4; i++)
                    for (int j = 0; j < 4; j++)
                        if (field[i, j] == color) coordinates[count++] = (i, j);

                // 2. Calculate costs for every possible permutation case (4 * 3 * 2 * 1 = 24 cases)
                int min = -1;
                foreach(var permutation in Permutations(coordinates))
                {
                    int temp = 0;
                    for (int cell = 0; cell < 4; cell++)
                    {
                        // Columns
                        if (permutation[cell].column == 0 && color == 1) temp += 3; // Green in column 1 => 3 steps
                        else if (permutation[cell].column == 1 && color == 2) temp += 3; // Blue in column 2 => 3 steps
                        else if (permutation[cell].column == 0 && color == 3) temp += 1; // Purple in column 1 => 1 step
                        else temp += Math.Abs(permutation[cell].column - color); // cell.column - color

                        // Rows
                        if (permutation[cell].row == 0 && cell == 3) temp += 1; // Ball in row 1 going in row 4 => 1 step
                        else if (permutation[cell].row == 1 && cell == 2) temp += 3; // Ball in row 2 going in row 3 => 3 steps
                        else if (permutation[cell].row == 2 && cell == 3) temp += 3; // Ball in row 3 going in row 4 => 3 steps
                        else temp += Math.Abs(permutation[cell].row - cell); // cell.row - cell
                    }
                    if (min == -1 || temp < min) min = temp;
                }

                // 3. Add to the h2 the minimum number of steps for balls of current color
                h2 += min;
            }
            return h2;
        }

        /* Magic block. Do not touch. 
         * List of all permutations for 4 balls  */
        private static IEnumerable<T[]> Permutations<T>(T[] values, int fromInd = 0)
        {
            if (fromInd + 1 == values.Length) 
                yield return values;
            else
            {
                foreach (var v in Permutations(values, fromInd + 1))
                    yield return v;

                for (var i = fromInd + 1; i < values.Length; i++)
                {
                    SwapValues(values, fromInd, i);
                    foreach (var v in Permutations(values, fromInd + 1))
                        yield return v;
                    SwapValues(values, fromInd, i);
                }
            }
        }

        private static void SwapValues<T>(T[] values, int pos1, int pos2)
        {
            if (pos1 != pos2)
            {
                T tmp = values[pos1];
                values[pos1] = values[pos2];
                values[pos2] = tmp;
            }
        }
    }
}
