using System;
using System.Collections.Generic;

namespace backEndChallenge
{
    class Program
    {
        static void Main(string[] args)
        { 
            Console.WriteLine("*** Challenge C# Junior Developer ***");
            Console.WriteLine();
            Console.WriteLine("Select an option: ");
            Console.WriteLine();
            Console.WriteLine("1. Sum of multiples");
            Console.WriteLine("2. Find Power number");
            Console.WriteLine("3. Make matriz and sum diagonals");
            Console.WriteLine("4. ");
            Console.WriteLine("5. Class objects");
            Console.WriteLine("6. Exit");
            Console.WriteLine();
            Console.WriteLine("Option: ");
            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Console.WriteLine();
                    Console.WriteLine("Enter two multiples");
                    Console.WriteLine("Multiple 1: ");
                    int num1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Multiple 2: ");
                    int num2 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter final number");
                    int n = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("The sum is: " + findSum(num1, num2, n));
                    break;

                case 2:
                    Console.WriteLine();
                    Console.WriteLine("The number can be 1");
                    Console.WriteLine("Another number is: ");
                    findNumber();
                    break;

                case 3:
                    Console.WriteLine();
                    Console.WriteLine("Enter the size of the matrix: ");
                    int num3 = Convert.ToInt32(Console.ReadLine());
                    int[,] a = new int[100, 100];
                    findMatriz(num3, a);
                    for (int i = 0; i < num3; i++)
                    {
                        for (int j = 0; j < num3; j++)
                        {
                            Console.Write(a[i, j] + " ");
                        }
                        Console.Write("\n");
                    }
                    break;

                case 4:
                    // code block
                    break;

                case 5:
                    Employee employee1 = new Employee("Daniel Lopez", "123456789", 25, "daniel@gmail.com", "Manager", 5000);
                    Employee employee2 = new Employee("Lorenzo Correa", "987654321", 26, "lorenzo1@gmail.com", "Engineer", 4000);
                    Employee employee3 = new Employee("Luisa Ramirez", "147852369", 27, "luisar@gmail.com", "Digital artist", 4000);
                    Customer customer1 = new Customer("Alexander Moreno", "963258741", 28, "alexandermoreno@gmail.com", "gold");
                    Customer customer2 = new Customer("Sandra Martinez", "456987123", 29, "sandra123@gmail.com", "platinum");
                    Customer customer3 = new Customer("Marcela Zapata", "789321456", 23, "mz987@gmail.com", "diamond");

                    Console.Write(employee1.ToString());
                    Console.Write(employee2.ToString());
                    Console.Write(employee3.ToString());
                    Console.Write(customer1.ToString());
                    Console.Write(customer2.ToString());
                    Console.Write(customer3.ToString());
                    break;

                case 6:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Please select a correct option");
                    break;
            }
        }

        static int findSum(int num1, int num2, int n)
        {
            int cont = 0;
            for(int i = 0; i< n; i++)
            {
                if(i % num1 == 0 || i % num2 == 0)
                {
                    cont += i;
                }
            }
            return cont;
        }

        static void findNumber()
        {
            bool flag = true;
            int i = 2;

            while (flag)
            {
                List<int> spliceNumbers = new List<int>();
                int j = i;
                int cont = 0;

                while (j > 0)
                {
                    int mod = j % 10;
                    spliceNumbers.Add(mod);
                    j = j / 10;
                }

                foreach (int x in spliceNumbers)
                {
                    cont += x * x * x * x * x;
                }

                if(i == cont)
                {
                    Console.WriteLine(i);
                    flag = false;
                }

                i++;
            }
        }
        static void findMatriz(int n, int[,] a)
        {
            int len = n;
            int valorDia = 0;
            int m = n;
            int val = n*n;
            int k = 0, l = 0;

            while (k < m && l < n)
            {

                for (int i = n-1; i >= l; --i)
                {
                    a[k, i] = val--;
                }

                k++;
                
                for (int i = k; i < m; ++i)
                {
                    a[i, l] = val--;
                }
                l++;
                
                if (k < m)
                {
                    for (int i = l; i < n; ++i)
                    {
                        a[m - 1, i] = val--;
                    }
                    m--;
                }

                if (l < n)
                {
                    for (int i = m - 1; i >= k; --i)
                    {
                        a[i, n-1] = val--;
                    }
                    n--;
                }
            }
            
            int j = len - 1;
            for (int i = 0; i < len; i++, j--)
            {
                valorDia += a[i,i] + a[i,j];
            }

            if (len % 2 != 0)
            {
                valorDia -= 1;
            }
            Console.WriteLine();
            Console.WriteLine("Sum of diagonals: " + valorDia);
            Console.WriteLine();
        }

    }

    public abstract class Person
    {
        protected String name;
        protected String id;
        protected int age;
        protected String email;

        public String SetName
        {
            set { name = value; }
        }

        public String SetId
        {
            set { id = value; }
        }

        public int SetAge
        {
            set { age = value; }
        }

        public String SetEmail
        {
            set { email = value; }
        }

        public String GetName
        {
            get { return name; }
        }

        public String GetId
        {
            get { return id; }
        }

        public int GetAge
        {
            get { return age; }
        }

        public String GetEmail
        {
            get { return email; }
        }

        public abstract string Walk();

    }

    public class Employee : Person
    {
        private String position;
        private double salary;

        public String SetPosition
        {
            set { position = value; }
        }

        public double SetSalary
        {
            set { salary = value; }
        }

        public String GetPosition
        {
            get { return position; }
        }

        public double GetSalary
        {
            get { return salary; }
        }

        public Employee(string vrName, string vrId, int vrAge, string vrEmail, string vrPosition, double vrSalary)
        {
            name = vrName;
            id = vrId;
            age = vrAge;
            email = vrEmail;
            position = vrPosition;
            salary = vrSalary;
        }

        public override string Walk()
        {
            return "I'm walking as an employee";
        }

        public override string ToString()
        {
            return ("\n" + "Name: " + name  + "\n" + "Id: " + id + "\n" + "Age: " + age + "\n" + "Email: " + email  + 
                "\n" + "Position: " + position  + "\n" + "Salary: " + salary + "\n");
        }
    }

    public class Customer : Person
    {
        private string category;

        public String SetCategory
        {
            set { category = value; }
        }

        public String GetCategory
        {
            get { return category; }
        }

        public Customer(string vrName, string vrId, int vrAge, string vrEmail, string vrCategory)
        {
            name = vrName;
            id = vrId;
            age = vrAge;
            email = vrEmail;
            category = vrCategory;
        }

        public override string Walk()
        {
            return "I'm walking as a customer";
        }

        public override string ToString()
        {
            return ("\n" + "Name: " + name + "\n" + "Id: " + id + "\n" + "Age: " + age + "\n" + "Email: " + email + 
                "\n" + "Category: " + category + "\n");
        }
    }
}
