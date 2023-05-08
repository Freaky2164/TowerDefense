using System.Collections;
using Enemies;
using NUnit.Framework;
using UnityEngine.TestTools;

public class FirstTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void FirstTestSimplePasses()
    {
        var e = new Enemy();
        e.Damage(100);

        Assert.Equals(false, e.HasHealthLeft());

        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator FirstTestWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
