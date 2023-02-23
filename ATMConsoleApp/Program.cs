class cardHolder
{
    string firstName;
    string lastName;
    int pin;
    int cardNumber;
    double balance;

    public cardHolder(string firstName, string lastName, int pin, int cardNumber, double balance)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.pin = pin;
        this.cardNumber = cardNumber;
        this.balance = balance;
    }

    /*Getters*/

    public string getFirstName()
    {
        return firstName;
    }

    public int getPin()
    {
        return pin;
    }

    public int getCardNumber()
    {
        return cardNumber;
    }

    public double getBalance()
    {
        return balance;
    }

    /*Setters*/

    public void setFirstName(string newFirstName)
    {
        firstName = newFirstName;
    }


    public void setPin(int newPin)
    {
        pin = newPin;
    }

    public void setCardNumber(int newCardNumber)
    {
        cardNumber = newCardNumber;
    }

    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

    public static void Main(String[] args)
    {
        void showOptions()
        {
            Console.WriteLine("Please choose one of the following options");
            Console.WriteLine("#1: Deposit");
            Console.WriteLine("#2: Withdraw");
            Console.WriteLine("#3: Show Balance");
            Console.WriteLine("#4: Exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much would you like to deposit");
            try
            {
                double amount = double.Parse(Console.ReadLine());
                currentUser.setBalance(currentUser.balance + amount);
                Console.WriteLine($"You're new balance is {currentUser.getBalance()}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Please input a valid number");
            }
        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much would you like to withdraw");
            try
            {
                double withdrawalAmount = double.Parse(Console.ReadLine());
                if (withdrawalAmount > currentUser.balance)
                {
                    Console.WriteLine("Insufficient Funds.");
                }
                else
                {
                    currentUser.setBalance(currentUser.balance - withdrawalAmount);
                    Console.WriteLine($"You're new balance is {currentUser.getBalance()}");
                }

            }
            catch (FormatException)
            {
                Console.WriteLine("Please input a valid number");
            }

        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine($"Your current balance is {currentUser.getBalance()}");
        }

        List<cardHolder> users = new List<cardHolder>();
        users.Add(new cardHolder("Jared", "Gomez", 0970, 615521957, 228.76));
        users.Add(new cardHolder("Ashley", "Gomez", 0278, 407493196, 732.09));
        users.Add(new cardHolder("Christian", "Andersson", 8745, 786556177, 10.21));



        Console.WriteLine("Welcome to Jared's Bank");




        try
        {
            Console.WriteLine("Please enter your account number");
            int accountNumber = int.Parse(Console.ReadLine());
            cardHolder currentUser = users.FirstOrDefault(a => a.cardNumber == accountNumber);
            if (currentUser != null)
            {
                Console.WriteLine("Please input your pin");
                int pinNumber = int.Parse(Console.ReadLine());
                if (currentUser.getPin() == pinNumber)
                {
                    while (true)
                    {
                        showOptions();
                        string option = Console.ReadLine();
                        if (option == "1")
                        {
                            deposit(currentUser);
                        }
                        else if (option == "2")
                        {
                            withdraw(currentUser);
                        }
                        else if (option == "3")
                        {
                            balance(currentUser);
                        }
                        else if (option == "4")
                        {
                            Console.WriteLine("Thank you for visiting the ATM!");
                            break;

                        }
                        else
                        {
                            Console.WriteLine("Invalid option. Please try again.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect Pin");
                }
            }
            else
            {
                Console.WriteLine("Card not recognized. Please try again");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Please input a valid number");
        }





    }
}
