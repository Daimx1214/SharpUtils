using SharpUtils;
using Xunit;

namespace SharpUtils.Tests;

public class CollectionAndNumericTests
{
    [Fact]
    public void IsNullOrEmpty_Works()
    {
        Assert.True(((IEnumerable<int>?)null).IsNullOrEmpty());
        Assert.True(Array.Empty<int>().IsNullOrEmpty());
        Assert.False(new[] { 1 }.IsNullOrEmpty());
    }

    [Fact]
    public void Partition_SplitsByPredicate()
    {
        var (matching, rest) = new[] { 1, 2, 3, 4, 5, 6 }.Partition(x => x.IsEven());
        Assert.Equal(new[] { 2, 4, 6 }, matching);
        Assert.Equal(new[] { 1, 3, 5 }, rest);
    }

    [Fact]
    public void Batch_GroupsElements()
    {
        var batches = new[] { 1, 2, 3, 4, 5 }.Batch(2).ToList();
        Assert.Equal(3, batches.Count);
        Assert.Equal(new[] { 1, 2 }, batches[0]);
        Assert.Equal(new[] { 5 }, batches[2]);
    }

    [Theory]
    [InlineData(4, true)]
    [InlineData(7, false)]
    public void IsEven_Checks(int value, bool expected) => Assert.Equal(expected, value.IsEven());

    [Theory]
    [InlineData(17, 15)]
    [InlineData(18, 20)]
    [InlineData(12, 10)]
    [InlineData(13, 15)]
    public void RoundToNearest_Rounds(int value, int expected) =>
        Assert.Equal(expected, value.RoundToNearest(5));

    [Fact]
    public void PercentageOf_Calculates() =>
        Assert.Equal(25.0, 50.0.PercentageOf(200.0));

    [Theory]
    [InlineData(0L, "0 B")]
    [InlineData(1536L, "1.5 KB")]
    [InlineData(1048576L, "1 MB")]
    public void ToFileSize_Formats(long bytes, string expected) =>
        Assert.Equal(expected, bytes.ToFileSize());
}
