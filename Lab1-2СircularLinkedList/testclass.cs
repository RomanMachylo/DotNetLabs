using Xunit;
using Lab1_circularLinkedList;
using System;
using System.Collections.Generic;

public class testclass 
{
    [Fact]
    public void TestInsert()
    {   // Arrange
        CircularLinkedList<int> circularList = new CircularLinkedList<int>();
        List<int> List = new List<int>(new[] { 1, 2, 3, 4});

        // Assert
        Assert.Equal(0, circularList.count);

        // Act
        foreach(var Element in List) circularList.Add(Element);

        // Assert
        Assert.Equal(4, circularList.count);
    }

    [Fact]
    public void TestInsert_nullData()
    {   // Arrange
        CircularLinkedList<string> circularList = new CircularLinkedList<string>();

        // Act + Assert
        Assert.Throws<ArgumentNullException>(() => circularList.Add(null));
    }

    [Fact]
    public void TestDeletion_True()
    {   // Arrange
        CircularLinkedList<int> circularList = new CircularLinkedList<int>();
        List<int> List2 = new List<int>(new[] { 1, 2, 3, 4});

        // Act
        foreach(var Element in List2) circularList.Add(Element);
        circularList.Remove(3);
        circularList.Remove(4);

        // Assert
        Assert.Equal(2, circularList.count);
        Assert.True(circularList.Remove(2));
    }

    [Fact]
    public void TestDeletion_false()
    {   // Arrange
        CircularLinkedList<int> circularList = new CircularLinkedList<int>();
        List<int> List2 = new List<int>(new[] { 1, 2, 3, 4});

        // Act
        foreach(var Element in List2) circularList.Add(Element);

        // Assert
        Assert.False(circularList.Remove(5));
    }

    [Fact]
    public void TestDeletion_nullData()
    {   // Arrange
        CircularLinkedList<string> circularList = new CircularLinkedList<string>();

        // Act + Assert
        Assert.Throws<ArgumentNullException>(() => circularList.Remove(null));
    }

    [Fact]
    public void TestDeletion_NotExistingNode()
    {   // Arrange
        CircularLinkedList<string> circularList = new CircularLinkedList<string>();
        List<string> List2 = new List<string>(new[] { "a", "b", "c", "d"});

        // Act + Assert
        foreach(var Element in List2) circularList.Add(Element);
        Assert.True(!circularList.Remove("e"));
    }

    [Fact]
    public void TestClear()
    {   // Arrange
        CircularLinkedList<int> circularList = new CircularLinkedList<int>();
        List<int> List2 = new List<int>(new[] { 1, 2, 3, 4});

        // Act
        foreach(var Element in List2) circularList.Add(Element);
        circularList.Clear(0);

        // Assert
        Assert.Equal(0, circularList.count);
    }

    [Fact]
    public void TestContains_True()
    {   // Arrange
        CircularLinkedList<string> circularList = new CircularLinkedList<string>();
        List<string> List2 = new List<string>(new[] { "a", "b", "c", "d"});

        // Act + Assert
        foreach(var Element in List2) circularList.Add(Element);
        Assert.True(circularList.Contains("a"));
    }

    [Fact]
    public void TestContains_False()
    {   // Arrange
        CircularLinkedList<string> circularList = new CircularLinkedList<string>();
        List<string> List2 = new List<string>(new[] { "a", "b", "c", "d"});

        // Act + Assert
        foreach(var Element in List2) circularList.Add(Element);
        Assert.False(circularList.Contains("e"));
    }

    [Fact]
    public void TestContains_NullData()
    {   // Arrange
        CircularLinkedList<string> circularList = new CircularLinkedList<string>();
        List<string> List2 = new List<string>(new[] { "a", "b", "c", "d"});

        // Act + Assert
        foreach(var Element in List2) circularList.Add(Element);
        Assert.Throws<ArgumentNullException>(() => circularList.Contains(null));
    }

    [Fact]
    public void Enumerator()
    {
        // Arrange
        CircularLinkedList<string> circularList = new CircularLinkedList<string>();

        // Act
        circularList.Add("a");
        circularList.Add("b");
        circularList.Add("c");
        circularList.Add("d");

        //Assert
        foreach (var item in circularList) Assert.True(circularList.Contains(item));
    }
}