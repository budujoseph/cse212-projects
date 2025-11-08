/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: Can I add one customer and then serve the customer?
        // Expected Result: Should display the customer that was added
        Console.WriteLine("Test 1");
        var cs = new CustomerService(5);
        Console.WriteLine("=================");
        // Defect(s) Found: This found that the ServeCustomer should get the customer before deleting from the list

        // Test 2
        // Scenario: Can I add multiple customers and then serve them?
        // Expected Result: Should display all customers in the order they were added
        Console.WriteLine("Test 2");
        var cs2 = new CustomerService(5);
        cs2.AddNewCustomer();
        cs2.AddNewCustomer();
        Console.WriteLine($"Before serving customers: {cs2}");
        cs2.ServeCustomer();
        cs2.ServeCustomer();
        Console.WriteLine($"After serving customers: {cs2}");
        Console.WriteLine("=================");
        // Defect(s) Found: None :)

        Console.WriteLine("=================");

        // Test 3
        // Scenario: Can I serve a customer if there is no customer?
        // Expected Result: Should display some error message
        Console.WriteLine("Test 3");
        var cs3 = new CustomerService(5);
        cs3.ServeCustomer();
        Console.WriteLine("=================");
        // Defect(s) Found: This found that I need to check the length in serve_customer and display an error message



        // Test 4
        // Scenario: Does the max queue size get enforced?
        // Expected Result: Should display some error message when the max size is exceeded
        Console.WriteLine("Test 4");
        var cs4 = new CustomerService(5);
        cs4.AddNewCustomer();
        cs4.AddNewCustomer();
        cs4.AddNewCustomer();
        cs4.AddNewCustomer();
        cs4.AddNewCustomer();
        Console.WriteLine($"Service Queue: {cs4}");
        Console.WriteLine("=================");
        // Defect(s) Found: This found that I need to check the length in add_new_customer and display an error message
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        _queue.RemoveAt(0);
        var customer = _queue[0];
        Console.WriteLine(customer);
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}