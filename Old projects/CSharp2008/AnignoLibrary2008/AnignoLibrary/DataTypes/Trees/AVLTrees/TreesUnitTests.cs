using System;
using System.Diagnostics;
using AnignoLibrary.DataTypes.Trees.AVLTrees;
using NUnit.Framework;

namespace AnignoLibrary.DataTypes.Trees.AVLTrees
{
    [TestFixture]
    public class TreesUnitTests
    {

        #region (------  Const Fields  ------)

        private const int MAX = 10000;

        #endregion (------  Const Fields  ------)

        #region (------  Fields  ------)


        private Stopwatch sw = new Stopwatch();

        #endregion (------  Fields  ------)

        #region (------  Tests  ------)


        [Test]
        public void Test_Trees()
        {
            Test_Tree(new AVLTree<int>());
            Debug.WriteLine("-------------------------------------");
            Test_Tree(new BinaryTree<int>());
        }


        public void Test_Tree(BinaryTree<int> tree)
        {
            Random RND = new Random(DateTime.Now.Millisecond);
            Debug.WriteLine("Starting "+tree.GetType()+" tree test");

            Debug.WriteLine("Adding " + MAX + " random numbers");
            sw.Reset();
            sw.Start();
            for (int a = 0; a < MAX; a++)
            {
                tree.Add(RND.Next(0, MAX * 10));
            }
            long ms = sw.ElapsedMilliseconds;
            Debug.WriteLine("End Time: " + ms);

            Debug.WriteLine("Adding " + MAX + " sequential numbers");
            sw.Reset();
            sw.Start();
            for (int a = 0; a < MAX; a++)
            {
                tree.Add(a);
            }
            ms = sw.ElapsedMilliseconds;
            Debug.WriteLine("End Time: " + ms);

            Debug.WriteLine("Reading all numbers");
            int prev = -1;
            sw.Reset();
            sw.Start();
            foreach (int a in tree)
            {
                Assert.GreaterOrEqual(a, prev);
                prev = a;
            }
            ms = sw.ElapsedMilliseconds;
            Debug.WriteLine("End Time: " + ms);
        }


        #endregion (------  Tests  ------)

    }
}