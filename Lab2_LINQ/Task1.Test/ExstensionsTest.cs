namespace Task1.Test;
using Task1_Extension;
public class ExtensionsTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ReverseTest_StringReversed_OK()
    {
        string str = "Some little test string";
        string reversedStr = "gnirts tset elttil emoS";
        Assert.That(reversedStr.Equals(str.Reverse()));
        str = "qwerty";
        reversedStr = "ytrewq";
        Assert.That(reversedStr.Equals(str.Reverse()));
    }
    
    [Test]
    public void CountElementOfSting_returnRightNumber()
    {
        string str = "Some little test string";
        Assert.That(str.CountElement('i') == 2);
        Assert.That(str.CountElement('e') == 3);
        Assert.That(str.CountElement('t') == 5);
    }
    
    [Test]
    public void CountElementOfArray_returnRightNumber()
    {
        int[] arr = { 1, 2, 2, 3, 4, 2, 2 };
        Assert.That(arr.CountElement(2) == 4);

        char[] arr2 = { 'a', 'b', 'c', 'd', 'c', 'c', 'e', 'c' };
        Assert.That(arr2.CountElement('c') == 4);
    }
    
    [Test]
    public void RemoveRepeatedElements_removedOk()
    {
        int[] arr = { 1, 2, 2, 3, 4, 2, 2 };
        Assert.That(arr.MakeUnique().Count(s => s == 1) == 1);
        Assert.That(arr.MakeUnique().Count(s => s == 2) == 1);
        Assert.That(arr.MakeUnique().Count(s => s == 3) == 1);
        Assert.That(arr.MakeUnique().Count(s => s == 4) == 1);

        char[] arr2 = { 'a', 'b', 'c', 'd', 'c', 'c', 'e', 'c' };
        Assert.That(arr2.MakeUnique().Count(s => s == 'a') == 1);
        Assert.That(arr2.MakeUnique().Count(s => s == 'b') == 1);
        Assert.That(arr2.MakeUnique().Count(s => s == 'c') == 1);
        Assert.That(arr2.MakeUnique().Count(s => s == 'd') == 1);
        Assert.That(arr2.MakeUnique().Count(s => s == 'e') == 1);
        
    }
}