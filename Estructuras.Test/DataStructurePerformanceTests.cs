using System.Diagnostics;

namespace Estructuras.Test
{
    public class DataStructurePerformanceTests
    {
        [Fact]
        public void ListPerformanceTest()
        {
            const int itemCount = 100000;
            var list = new List<int>();

            var stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < itemCount; i++)
            {
                list.Add(i);
            }
            stopwatch.Stop();

            Console.WriteLine($"List insertion time: {stopwatch.ElapsedMilliseconds} ms");

            stopwatch.Restart();
            var exists = list.Contains(itemCount - 1);
            stopwatch.Stop();

            Console.WriteLine($"List containment check time: {stopwatch.ElapsedMilliseconds} ms");
            Assert.True(exists);
        }

        [Fact]
        public void HashSetPerformanceTest()
        {
            const int itemCount = 100000;
            var hashSet = new HashSet<int>();

            var stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < itemCount; i++)
            {
                hashSet.Add(i);
            }
            stopwatch.Stop();

            Console.WriteLine($"HashSet insertion Time: {stopwatch.ElapsedMilliseconds} ms");

            stopwatch.Restart();
            var exists = hashSet.Contains(itemCount - 1);
            stopwatch.Stop();

            Console.WriteLine($"HashSet containment Check Time: {stopwatch.ElapsedMilliseconds} ms");
            Assert.True(exists);
        }

        [Fact]
        public void DictionaryPerformanceTest()
        {
            const int itemCount = 100000;
            var dictionary = new Dictionary<int, string>();

            var stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < itemCount; i++)
            {
                dictionary[i] = i.ToString();
            }
            stopwatch.Stop();

            Console.WriteLine($"Dictionary insertion time: {stopwatch.ElapsedMilliseconds} ms");

            stopwatch.Restart();
            var exists = dictionary.ContainsKey(itemCount - 1);
            stopwatch.Stop();

            Console.WriteLine($"Dictionary containment Check Time: {stopwatch.ElapsedMilliseconds} ms");
            Assert.True(exists);
        }
    }
}