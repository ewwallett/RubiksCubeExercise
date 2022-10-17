namespace RubiksCubeExercise
{
    /// <summary>
    /// The Segment Face class.
    /// </summary>
    public class SegmentFace
    {
        /// <summary>
        /// Gets the vector.
        /// </summary>
        /// <value>
        /// The vector.
        /// </value>
        public int[] Vector { get; private set; }

        /// <summary>
        /// Gets the color.
        /// </summary>
        /// <value>
        /// The color.
        /// </value>
        public ConsoleColor Color { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SegmentFace" /> class.
        /// </summary>
        /// <param name="vector">The vector.</param>
        /// <param name="color">The color.</param>
        public SegmentFace(int[] vector, ConsoleColor color)
        {
            Vector = vector;
            Color = color;
        }

        /// <summary>
        /// Rotates the face segment.
        /// </summary>
        /// <param name="axis">The axis.</param>
        /// <param name="direction">The direction.</param>
        public void RotateFaceSegment(AxisEnum axis, int direction)
        {
            int[] newVector = new int[Enum.GetValues(typeof(AxisEnum)).Length];

            switch (axis)
            {
                case AxisEnum.X:
                    (int xItem1, int xItem2) =
                        Transform.RotateMatrix(Vector[(int)AxisEnum.Y], Vector[(int)AxisEnum.Z], direction);

                    newVector[(int)AxisEnum.X] = Vector[(int)AxisEnum.X];
                    newVector[(int)AxisEnum.Y] = xItem1;
                    newVector[(int)AxisEnum.Z] = xItem2;
                    break;
                case AxisEnum.Y:
                    (int yItem1, int yItem2) =
                        Transform.RotateMatrix(Vector[(int)AxisEnum.X], Vector[(int)AxisEnum.Z], direction);

                    newVector[(int)AxisEnum.X] = yItem1;
                    newVector[(int)AxisEnum.Y] = Vector[(int)AxisEnum.Y];
                    newVector[(int)AxisEnum.Z] = yItem2;
                    break;
                case AxisEnum.Z:
                    (int zItem1, int zItem2) =
                        Transform.RotateMatrix(Vector[(int)AxisEnum.X], Vector[(int)AxisEnum.Y], direction);

                    newVector[(int)AxisEnum.X] = zItem1;
                    newVector[(int)AxisEnum.Y] = zItem2;
                    newVector[(int)AxisEnum.Z] = Vector[(int)AxisEnum.Z];
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(axis), axis, null);
            }

            Vector = newVector;
        }
    }
}