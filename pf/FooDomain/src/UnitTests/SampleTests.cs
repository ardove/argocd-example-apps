using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PF.FooDomain.UnitTests
{
    [TestClass]
    public class SampleTests
    {
        [TestMethod]
        public void ShouldBe_Succeeds_WhenObjectsAreEqual()
        {
            var example = new { Property = "Value" };
            var copy = example;

            copy.Should().Be(example);
        }
    }
}
