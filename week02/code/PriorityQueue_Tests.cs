using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue several items with different priorities and then dequeue them all
    // Expected Result: Items are dequeued in order of priority
    // Defect(s) Found: Dequeue does not remove the item from the queue
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Medium", 5);
        priorityQueue.Enqueue("High", 10);

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Multiple items with same priority are added
    // Expected Result: Dequeue values: "First", "Second", "Third"
    // Defect(s) Found: uses >= instead of > causing wrong item to be dequeued first
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 5);
        priorityQueue.Enqueue("Second", 5);
        priorityQueue.Enqueue("Third", 5);

        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Mixed priorities with where earliest high-priority should win on tie
    // Expected Result: "A", "C", "B", "D"
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 10);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 10);
        priorityQueue.Enqueue("D", 2);

        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("D", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue after partial dequeue
    // Expected Result: Correct order maintained
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("X", 1);
        priorityQueue.Enqueue("Y", 10);
        priorityQueue.Enqueue("Z", 5);

        Assert.AreEqual("Y", priorityQueue.Dequeue());
        priorityQueue.Enqueue("W", 20);
        priorityQueue.Enqueue("V", 8);

        Assert.AreEqual("W", priorityQueue.Dequeue());
        Assert.AreEqual("V", priorityQueue.Dequeue());
        Assert.AreEqual("Z", priorityQueue.Dequeue());
        Assert.AreEqual("X", priorityQueue.Dequeue());

    }
    // Add more test cases as needed below.
}