public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1
        if (value == Data)
        {
            // Do not insert duplicates
            return;
        }

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2
        if (value == Data)
            return true;

        if(value < Data)
        {
            if (Left is null)
                return false; // Not found
            return Left.Contains(value);
        }
        else
        {
            if (Right is null)
                return false;
            else
                return Right.Contains(value);
        }
        
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        // Base case: if leaf node, height is 1
        int leftHeight = Left?.GetHeight() ?? 0;

        // Recursive case: height is 1 + max height of left/right subtrees
        int rightHeight = Right?.GetHeight() ?? 0;

        // Height of current node
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}