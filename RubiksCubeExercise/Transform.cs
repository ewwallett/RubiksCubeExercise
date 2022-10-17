namespace RubiksCubeExercise
{
    /// <summary>
    /// The Transform Class.
    /// </summary>
    public static class Transform
    {
        /// <summary>
        /// The rotation angle
        /// </summary>
        private const double RotationAngle = Math.PI / 2;

        /// <summary>
        /// Rotates the matrix.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <param name="direction">The direction.</param>
        /// <returns>
        /// A int Tuple.
        /// </returns>
        public static Tuple<int, int> RotateMatrix(int a, int b, int direction)
        {
            double angle = RotationAngle * direction;

            return new Tuple<int, int>(
                (int)Math.Round(a * Math.Cos(angle) - b * Math.Sin(angle)),
                (int)Math.Round(a * Math.Sin(angle) + b * Math.Cos(angle))
            );
        }
    }
}