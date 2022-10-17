namespace RubiksCubeExercise
{
    /// <summary>
    /// The Move Class.
    /// </summary>
    public static class Move
    {
        /// <summary>
        /// Executes the move.
        /// </summary>
        /// <param name="move">The move.</param>
        /// <param name="segments">The segments.</param>
        /// <param name="reverse">if set to <c>true</c> [reverse].</param>
        /// <exception cref="System.ArgumentOutOfRangeException">move - null</exception>
        public static void ExecuteMove(FaceEnum move, IEnumerable<Segment> segments, bool reverse)
        {
            switch (move)
            {
                case FaceEnum.U:
                    UpdateSegments(segments, AxisEnum.Y, 1, reverse ? -1 : 1);
                    break;
                case FaceEnum.D:
                    UpdateSegments(segments, AxisEnum.Y, -1, reverse ? 1 : -1);
                    break;
                case FaceEnum.R:
                    UpdateSegments(segments, AxisEnum.X, 1, reverse ? 1 : -1);
                    break;
                case FaceEnum.L:
                    UpdateSegments(segments, AxisEnum.X, -1, reverse ? -1 : 1);
                    break;
                case FaceEnum.F:
                    UpdateSegments(segments, AxisEnum.Z, 1, reverse ? 1 : -1);
                    break;
                case FaceEnum.B:
                    UpdateSegments(segments, AxisEnum.Z, -1, reverse ? -1 : 1);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(move), move, null);
            }
        }

        /// <summary>
        /// Updates the segments.
        /// </summary>
        /// <param name="segments">The segments.</param>
        /// <param name="axis">The axis.</param>
        /// <param name="layerIndex">Index of the layer.</param>
        /// <param name="direction">The direction.</param>
        private static void UpdateSegments(IEnumerable<Segment> segments, AxisEnum axis, int layerIndex, int direction)
        {
            foreach (Segment segment in segments)
                switch (axis)
                {
                    case AxisEnum.X:
                        if (segment.X == layerIndex) segment.RotateSegment(axis, direction);
                        break;
                    case AxisEnum.Y:
                        if (segment.Y == layerIndex) segment.RotateSegment(axis, direction);
                        break;
                    case AxisEnum.Z:
                        if (segment.Z == layerIndex) segment.RotateSegment(axis, direction);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(axis), axis, null);
                }
        }
    }
}