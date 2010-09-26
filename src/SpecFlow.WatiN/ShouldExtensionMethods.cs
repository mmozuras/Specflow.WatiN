using NUnit.Framework;
using WatiN.Core;

namespace SpecFlow.WatiN
{
    public static class ShouldExtensionMethods
    {
        public static void ShouldContain(this string actual, string expected)
        {
            StringAssert.Contains(expected, actual);
        }

        public static void ShouldNotContain(this string actual, string expected)
        {
            StringAssert.DoesNotContain(expected, actual);
        }       

        public static void ShouldEqual<T>(this T actual, T expected)
        {
            Assert.AreEqual(expected, actual);
        }

        public static void ShouldNotEqual<T>(this T actual, T expected)
        {
            Assert.AreNotEqual(expected, actual);
        }

        public static void ShouldBeChecked<T>(this RadioCheck<T> checkBox) where T : Element
        {
            checkBox.Checked.ShouldEqual(true);
        }

        public static void ShouldNotBeChecked<T>(this RadioCheck<T> checkBox) where T : Element
        {
            checkBox.Checked.ShouldEqual(false);
        }

        public static void ShouldBeNull(this Element anObject)
        {
            Assert.IsNull(anObject);
        }

        public static Element ShouldNotBeNull(this Element element)
        {
            Assert.IsNotNull(element);
            return element;
        }
    }
}