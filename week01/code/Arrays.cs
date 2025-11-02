public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        
        double[] multiples = new double[length]; // Create an empty array of doubles with exact length of elements to store in
        for (int i = 0; i < length; i++) // For loop is used to iterate 'length' times (i = 0; i > length)
        {
            multiples[i] = number * (i + 1); // For each iteration i, calculates the multiples 
        }
        return multiples; // The multiples array is returned after the loop is complete
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
       //  

        if(data.Count == 0) // Since we are working with list we use count to find the number of elements in the collection
        return;             // If list is empty then we do nothing

        int n = data.Count;
        List<int> lastAmount = data.GetRange(n - amount, amount); // Get the last amount element using the GetRange method; this gives a new list to move to the front
        data.InsertRange(0, lastAmount);  // insert the new last amount at the beginning of the list using the InsertRange method
        data.RemoveRange(n, amount); // Remove the lastamount elements using the RemoveRange method
    }
}
