namespace RubiksCubeExercise
{
    /// <summary>
    /// The Segment class.
    /// </summary>
    public class Segment
    {
        /// <summary>
        /// Gets the x.
        /// </summary>
        /// <value>
        /// The x.
        /// </value>
        public int X { get; private set; }

        /// <summary>
        /// Gets the y.
        /// </summary>
        /// <value>
        /// The y.
        /// </value>
        public int Y { get; private set; }

        /// <summary>
        /// Gets the z.
        /// </summary>
        /// <value>
        /// The z.
        /// </value>
        public int Z { get; private set; }

        /// <summary>
        /// Gets the segment faces.
        /// </summary>
        /// <value>
        /// The segment faces.
        /// </value>
        public SegmentFace[] SegmentFaces { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Segment" /> class.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="z">The z.</param>
        public Segment(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;

            SegmentFaces = new SegmentFace[6]
            {
                // F Face
                new(new[] { 0, 0, 1 }, ConsoleColor.Green),
                // B Face
                new(new[] { 0, 0, -1 }, ConsoleColor.Blue),
                // U Face
                new(new[] { 0, 1, 0 }, ConsoleColor.White),
                // D Face
                new(new[] { 0, -1, 0 }, ConsoleColor.Yellow),
                // R Face
                new(new[] { 1, 0, 0 }, ConsoleColor.Red),
                // L Face
                new(new[] { -1, 0, 0 }, ConsoleColor.DarkYellow)
            };
        }

        /// <summary>
        /// Rotates the segment.
        /// </summary>
        /// <param name="axis">The axis.</param>
        /// <param name="direction">The direction.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">axis - null</exception>
        public void RotateSegment(AxisEnum axis, int direction)
        {
            switch (axis)
            {
                case AxisEnum.X:
                    (int xItem1, int xItem2) = Transform.RotateMatrix(Y, Z, direction);

                    Y = xItem1;
                    Z = xItem2;
                    break;
                case AxisEnum.Y:
                    (int yItem1, int yItem2) = Transform.RotateMatrix(X, Z, direction);

                    X = yItem1;
                    Z = yItem2;
                    break;
                case AxisEnum.Z:
                    (int zItem1, int zItem2) = Transform.RotateMatrix(X, Y, direction);

                    X = zItem1;
                    Y = zItem2;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(axis), axis, null);
            }

            foreach (SegmentFace face in SegmentFaces) face.RotateFaceSegment(axis, direction);
        }
    }
}