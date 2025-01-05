namespace Fourier.Tests
{
    [TestClass]
    public sealed class Test1
    {

        [TestInitialize]
        public void TestInitialize()
        {
        }

        [TestCleanup]
        public void TestCleanup()
        {
        }




        [TestMethod]
        public void VergleichAsserts()
        {
            Assert.AreEqual(5, 2 + 3, "Die Werte sind nicht gleich!");
            Assert.AreNotEqual(10, 2 + 3, "Die Werte sollten ungleich sein!");
        }

        [TestMethod]
        public void BooleanAsserts()
        {
            Assert.IsTrue(5 > 3, "Die Bedingung ist falsch!");
            Assert.IsFalse(5 < 3, "Die Bedingung ist wahr, sollte aber falsch sein!");
        }

        [TestMethod]
        public void NullAsserts()
        {
            object obj = null;
            Assert.IsNull(obj, "Das Objekt sollte null sein!");

            obj = new object();
            Assert.IsNotNull(obj, "Das Objekt sollte nicht null sein!");
        }

        [TestMethod]
        public void TypAsserts()
        {
            var str = "Test";
            Assert.IsInstanceOfType(str, typeof(string), "Das Objekt ist nicht vom Typ string!");
            Assert.IsNotInstanceOfType(str, typeof(int), "Das Objekt sollte kein int sein!");
        }

        [TestMethod]
        public void StringAsserts()
        {
            var message = "Hello, World!";
            StringAssert.Contains(message, "World", "Die Zeichenkette 'World' fehlt!");
            StringAssert.StartsWith(message, "Hello", "Die Zeichenkette beginnt nicht mit 'Hello'!");
            StringAssert.EndsWith(message, "World!", "Die Zeichenkette endet nicht mit 'World!'!");
            StringAssert.Matches(message, new System.Text.RegularExpressions.Regex(@"^Hello.*!$"), "Die Zeichenkette passt nicht zum Regex!");
        }

        [TestMethod]
        public void CollectionAsserts()
        {
            var list = new List<int> { 1, 2, 3 };
            CollectionAssert.AreEqual(new List<int> { 1, 2, 3 }, list, "Die Sammlungen sind nicht gleich!");
            CollectionAssert.AreNotEqual(new List<int> { 1, 2 }, list, "Die Sammlungen sollten ungleich sein!");
            CollectionAssert.AllItemsAreNotNull(list, "Die Sammlung enthält null-Elemente!");
            CollectionAssert.AllItemsAreUnique(list, "Die Sammlung enthält Duplikate!");
            CollectionAssert.Contains(list, 2, "Die Sammlung enthält das Element 2 nicht!");
            CollectionAssert.DoesNotContain(list, 4, "Die Sammlung sollte das Element 4 nicht enthalten!");
        }

        [TestMethod]
        public void ExceptionAsserts()
        {
            Assert.ThrowsException<ArgumentNullException>(
                () => throw new ArgumentNullException(), "Die erwartete Ausnahme wurde nicht ausgelöst!");
            async Task TestAsync() => throw new InvalidOperationException();
            Assert.ThrowsExceptionAsync<InvalidOperationException>(
                async () => await TestAsync(), "Die erwartete Ausnahme wurde nicht ausgelöst!");
        }
    }
}
