namespace AdventOfCode.Year2023.Tests;

public class Day8
{
    [Theory]
    [InlineData("AAA = (BBB, CCC)", "AAA", "BBB", "CCC")]
    public void ShouldCreateNode(string nodeInput, string expectedKey, string expectedLeft, string expectedRight)
    {
        // Arrange
        var expectedNode = new Node(expectedKey, expectedLeft, expectedRight);
        
        // Act
        // var actualNode = 

        // Assert

    }
}