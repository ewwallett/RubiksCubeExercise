namespace RubiksCubeExercise.Tests
{
    /// <summary>
    /// The Transform Class Test.
    /// </summary>
    public class TransformTest
    {
        /// <summary>
        /// Tests the rotates matrix method.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <param name="direction">The direction.</param>
        /// <param name="expectedItem1">The expected item1.</param>
        /// <param name="expectedItem2">The expected item2.</param>
        [Theory]
        [InlineData(-1, 1, -1, 1, 1)]
        [InlineData(0, 1, -1, 1, 0)]
        [InlineData(1, 1, -1, 1, -1)]
        [InlineData(-1, -1, 1, 1, -1)]
        public void RotateMatrix_ReturnsAxisRotation(int a, int b, int direction, int expectedItem1, int expectedItem2)
        {
            (int item1, int item2) = Transform.RotateMatrix(a, b, direction);

            Assert.Equal(item1, expectedItem1);
            Assert.Equal(item2, expectedItem2);
        }
    }
}