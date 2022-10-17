namespace RubiksCubeExercise
{
    /// <summary>
    /// The Program class.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The dimension.
        /// </summary>
        public const int Dimension = 3;

        /// <summary>
        /// The face vectors.
        /// </summary>
        public static readonly FaceVector[] FaceVectors = new FaceVector[6]
        {
            new(FaceEnum.F, new[] { 0, 0, 1 }),
            new(FaceEnum.B, new[] { 0, 0, -1 }),
            new(FaceEnum.U, new[] { 0, 1, 0 }),
            new(FaceEnum.D, new[] { 0, -1, 0 }),
            new(FaceEnum.R, new[] { 1, 0, 0 }),
            new(FaceEnum.L, new[] { -1, 0, 0 })
        };

        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        private static void Main()
        {
            ShowStartOptions();
        }

        /// <summary>
        /// Initialises the segments.
        /// </summary>
        /// <returns>
        /// A Segment class array.
        /// </returns>
        private static Segment[] InitialiseSegments()
        {
            Segment[] segments = new Segment[Dimension * Dimension * Dimension];

            int index = 0;
            for (int x = -1; x <= 1; x++)
            for (int y = -1; y <= 1; y++)
            for (int z = -1; z <= 1; z++)
            {
                segments[index] = new Segment(x, y, z);
                index++;
            }

            return segments;
        }

        /// <summary>
        /// Shows the start options.
        /// </summary>
        private static void ShowStartOptions()
        {
            Segment[] segments = InitialiseSegments();

            switch (ChooseOption(new[] { "Execute Move", "Solve Complete Solution" }))
            {
                case 0:
                    ShowMoveOptions(segments);
                    break;
                case 1:

                    Move.ExecuteMove(FaceEnum.F, segments, false);
                    Move.ExecuteMove(FaceEnum.R, segments, true);
                    Move.ExecuteMove(FaceEnum.U, segments, false);
                    Move.ExecuteMove(FaceEnum.B, segments, true);
                    Move.ExecuteMove(FaceEnum.L, segments, false);
                    Move.ExecuteMove(FaceEnum.D, segments, true);
                    RenderDiagram(segments);
                    ShowEndOptions();
                    break;
            }
        }

        /// <summary>
        /// Shows the end options.
        /// </summary>
        private static void ShowEndOptions()
        {
            switch (ChooseOption(new[] { "Reset", "Exit" }))
            {
                case 0:
                    Console.Clear();
                    ShowStartOptions();
                    break;
            }
        }

        /// <summary>
        /// Shows the move options.
        /// </summary>
        /// <param name="segments">The segments.</param>
        private static void ShowMoveOptions(Segment[] segments)
        {
            switch (ChooseOption(new[] { "U", "U'", "D", "D'", "R", "R'", "L", "L'", "F", "F'", "B", "B'" }))
            {
                case 0:
                    Move.ExecuteMove(FaceEnum.U, segments, false);
                    break;
                case 1:
                    Move.ExecuteMove(FaceEnum.U, segments, true);
                    break;
                case 2:
                    Move.ExecuteMove(FaceEnum.D, segments, false);
                    break;
                case 3:
                    Move.ExecuteMove(FaceEnum.D, segments, true);
                    break;
                case 4:
                    Move.ExecuteMove(FaceEnum.R, segments, false);
                    break;
                case 5:
                    Move.ExecuteMove(FaceEnum.R, segments, true);
                    break;
                case 6:
                    Move.ExecuteMove(FaceEnum.L, segments, false);
                    break;
                case 7:
                    Move.ExecuteMove(FaceEnum.L, segments, true);
                    break;
                case 8:
                    Move.ExecuteMove(FaceEnum.F, segments, false);
                    break;
                case 9:
                    Move.ExecuteMove(FaceEnum.F, segments, true);
                    break;
                case 10:
                    Move.ExecuteMove(FaceEnum.B, segments, false);
                    break;
                case 11:
                    Move.ExecuteMove(FaceEnum.B, segments, true);
                    break;
            }

            RenderDiagram(segments);
            ShowMoreMoveOptions(segments);
        }

        /// <summary>
        /// Shows the more move options.
        /// </summary>
        /// <param name="segments">The segments.</param>
        private static void ShowMoreMoveOptions(Segment[] segments)
        {
            switch (ChooseOption(new[] { "Another Move", "Reset", "Exit" }))
            {
                case 0:
                    ShowMoveOptions(segments);
                    break;
                case 1:
                    Console.Clear();
                    ShowStartOptions();
                    break;
            }
        }

        /// <summary>
        /// Chooses the option.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>
        /// The chosen option.
        /// </returns>
        private static int ChooseOption(IReadOnlyList<string> options)
        {
            int optionsLength = options.Count;
            int selectedOption = 0;
            bool selectionComplete = false;

            while (!selectionComplete)
            {
                for (int i = 0; i < optionsLength; i++)
                {
                    if (selectedOption == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("> ");
                    }
                    else
                    {
                        Console.Write("  ");
                    }

                    Console.WriteLine(options[i]);

                    Console.ResetColor();
                }

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedOption = Math.Max(0, selectedOption - 1);
                        break;
                    case ConsoleKey.DownArrow:
                        selectedOption = Math.Min(optionsLength - 1, selectedOption + 1);
                        break;
                    case ConsoleKey.Enter:
                        selectionComplete = true;
                        break;
                }

                if (!selectionComplete) Console.CursorTop -= optionsLength;
            }

            return selectedOption;
        }

        /// <summary>
        /// Renders the diagram.
        /// </summary>
        /// <param name="segments">The segments.</param>
        private static void RenderDiagram(Segment[] segments)
        {
            ConsoleColor[][] cubeColors = {
                new ConsoleColor[Dimension],
                new ConsoleColor[Dimension],
                new ConsoleColor[Dimension],
                new ConsoleColor[Dimension * 4],
                new ConsoleColor[Dimension * 4],
                new ConsoleColor[Dimension * 4],
                new ConsoleColor[Dimension],
                new ConsoleColor[Dimension],
                new ConsoleColor[Dimension]
            };

            // U Face
            RenderFace(cubeColors, FaceEnum.U, 0, 0, 
                segments.Where(s => s.Y == 1).OrderBy(s => s.Z).ThenBy(s => s.X));
            // L Face
            RenderFace(cubeColors, FaceEnum.L, 0, 3,
                segments.Where(s => s.X == -1).OrderByDescending(s => s.Y).ThenBy(s => s.Z));
            // F Face
            RenderFace(cubeColors, FaceEnum.F, 3, 3,
                segments.Where(s => s.Z == 1).OrderByDescending(s => s.Y).ThenBy(s => s.X));
            // R Face
            RenderFace(cubeColors, FaceEnum.R, 6, 3,
                segments.Where(s => s.X == 1).OrderByDescending(s => s.Y).ThenByDescending(s => s.Z));
            // B Face
            RenderFace(cubeColors, FaceEnum.B, 9, 3,
                segments.Where(s => s.Z == -1).OrderByDescending(s => s.Y).ThenByDescending(s => s.X));
            // D Face
            RenderFace(cubeColors, FaceEnum.D, 0, 6,
                segments.Where(s => s.Y == -1).OrderByDescending(s => s.Z).ThenBy(s => s.X));

            for (int i = 0; i < cubeColors.Length; i++)
            {
                Console.WriteLine("");

                for (int j = 0; j < cubeColors[i].Length; j++)
                {
                    if (j % 3 == 0)
                    {
                        if (new[] { 3, 4, 5 }.Contains(i))
                        {
                            if (j > 0) Console.Write(" ");
                        }
                        else
                        {
                            Console.Write("       ");
                        }
                    }

                    Console.ForegroundColor = cubeColors[i][j];
                    Console.Write("[]");
                }

                if (i == 2 || i == 5) Console.WriteLine("");
            }

            Console.ResetColor();
            Console.WriteLine("\n");
        }

        /// <summary>
        /// Renders the face.
        /// </summary>
        /// <param name="cubeColors">The cube colors.</param>
        /// <param name="face">The face.</param>
        /// <param name="rowStartIndex">Start index of the row.</param>
        /// <param name="columnStartIndex">Start index of the column.</param>
        /// <param name="orderedSegments">The ordered segments.</param>
        private static void RenderFace(IReadOnlyList<ConsoleColor[]> cubeColors, FaceEnum face, int rowStartIndex,
            int columnStartIndex, IEnumerable<Segment> orderedSegments)
        {
            int[] checkVector = FaceVectors.Single(x => x.Face == face).Vector;

            int columnIndex = columnStartIndex;
            int rowIndex = rowStartIndex;

            foreach (Segment segment in orderedSegments)
            {
                if (rowIndex != rowStartIndex && rowIndex % Dimension == 0)
                {
                    columnIndex++;
                    rowIndex = rowStartIndex;
                }

                ConsoleColor color = segment.SegmentFaces.Single(x => checkVector.SequenceEqual(x.Vector)).Color;
                cubeColors[columnIndex][rowIndex] = color;

                rowIndex++;
            }
        }
    }
}