using MiniZotero.Helpers;
using Xunit;

namespace MiniZotero.Tests
{
    public sealed class TextBoxMarkdownFormatterTests
    {
        [Fact]
        public void ApplyBoldWrapsSelectedText()
        {
            var result = TextBoxMarkdownFormatter.ApplyBold("hello world", 6, 5);

            Assert.Equal("hello **world**", result.Text);
        }

        [Fact]
        public void ApplyBoldDoesNothingWhenNothingIsSelected()
        {
            var result = TextBoxMarkdownFormatter.ApplyBold("hello world", 7, 0);

            Assert.Equal("hello world", result.Text);
            Assert.Equal(7, result.SelectionStart);
            Assert.Equal(0, result.SelectionLength);
        }

        [Fact]
        public void ApplyItalicWrapsSelectedText()
        {
            var result = TextBoxMarkdownFormatter.ApplyItalic("hello world", 6, 5);

            Assert.Equal("hello *world*", result.Text);
        }

        [Fact]
        public void ApplyHeadingPrefixesSelectedLine()
        {
            var result = TextBoxMarkdownFormatter.ApplyHeading("first\nsecond", 7, 3);

            Assert.Equal("first\n## second", result.Text);
        }

        [Fact]
        public void ApplyHeadingDoesNotDuplicatePrefix()
        {
            var result = TextBoxMarkdownFormatter.ApplyHeading("## title", 4, 0);

            Assert.Equal("## title", result.Text);
        }

        [Fact]
        public void ApplyBulletListPrefixesSelectedLines()
        {
            var result = TextBoxMarkdownFormatter.ApplyBulletList("one\ntwo\nthree", 0, 7);

            Assert.Equal("- one\n- two\nthree", result.Text);
        }

        [Fact]
        public void ApplyQuotePrefixesSelectedLines()
        {
            var result = TextBoxMarkdownFormatter.ApplyQuote("one\ntwo", 0, 7);

            Assert.Equal("> one\n> two", result.Text);
        }

        [Fact]
        public void ApplyLinkWrapsSelectedText()
        {
            var result = TextBoxMarkdownFormatter.ApplyLink("open docs", 5, 4);

            Assert.Equal("open [docs](https://)", result.Text);
        }

        [Fact]
        public void ApplyLinkDoesNothingWhenNothingIsSelected()
        {
            var result = TextBoxMarkdownFormatter.ApplyLink("open docs", 6, 0);

            Assert.Equal("open docs", result.Text);
            Assert.Equal(6, result.SelectionStart);
            Assert.Equal(0, result.SelectionLength);
        }
    }
}
