namespace RubiksCubeExercise
{
    /// <summary>
    /// The Face Vector class.
    /// </summary>
    public class FaceVector
    {
        /// <summary>
        /// Gets the face.
        /// </summary>
        /// <value>
        /// The face.
        /// </value>
        public FaceEnum Face { get; }

        /// <summary>
        /// Gets the x.
        /// </summary>
        /// <value>
        /// The x.
        /// </value>
        public int[] Vector { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FaceVector"/> class.
        /// </summary>
        /// <param name="face">The face.</param>
        /// <param name="vector">The vector.</param>
        public FaceVector(FaceEnum face, int[] vector)
        {
            Face = face;
            Vector = vector;
        }
    }
}