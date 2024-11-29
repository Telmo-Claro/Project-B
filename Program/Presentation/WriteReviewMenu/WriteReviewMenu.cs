public static class WriteReviewMenu
{
    public static void DisplayMenu(Account account)
    {
        Console.Clear();
        Console.WriteLine($"---------------- TRENLINES -----------------");
        Console.WriteLine($"Thank you, {account.FirstName} {account.LastName}!, for taking your time to write us a review!");
        Thread.Sleep(1000);
        Console.WriteLine("At TRENLINES\u2122 (Under TrenBoyZZ Solutions\u2122) we do our best to deliver the best!");
        Thread.Sleep(1000);
        Console.WriteLine($"--------------------------------------------");
        string? message;
        do
        {
            Console.WriteLine("Please leave us a message below:");
            Console.Write("> ");
            message = Console.ReadLine();

        } while (string.IsNullOrEmpty(message));
        if (!string.IsNullOrEmpty(message))
        {
            Console.WriteLine("Your review will be validated and processed!");
            Console.WriteLine("Press any key to continue...");
            FeedbackLogic.AddFeedback(account, message);
            Console.ReadKey();
        }
    }
}