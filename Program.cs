using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab9Tuples
{

    public class MathOperations
    {
        public (double average, int median) CalculateAverageAndMedian(IEnumerable<int> numbers)
        {
            if (numbers == null || !numbers.Any())
            {
                throw new ArgumentException("Collection cannot be null or empty");
            }

            double average = numbers.Average();
            int median;

            var sortedNumbers = numbers.OrderBy(n => n).ToList();
            int count = sortedNumbers.Count;

            if (count % 2 == 0)
            {
                median = (sortedNumbers[count / 2 - 1] + sortedNumbers[count / 2]) / 2;
            }
            else
            {
                median = sortedNumbers[count / 2];
            }

            return (average, median);
        }
    }

    public record Employee(int StaffId, string Name, string Address)
    {
        public Employee WithNewAddress(string newAddress) => this with { Address = newAddress };
        // Deconstructor
        public void Deconstruct(out int staffId, out string name, out string address)
        {
            staffId = StaffId;
            name = Name;
            address = Address;
        }
    }

    public class Program
    {
        public static void Main()
        {
            var employee = new Employee(1, "John Doe", "123 Main St");
            Console.WriteLine($"Original Employee: {employee}");

            var employeeWithNewAddress = employee.WithNewAddress("456 Elm St");
            Console.WriteLine($"Employee with New Address: {employeeWithNewAddress}");

            // Deconstructor test
            var (id, name, address) = employeeWithNewAddress;
            Console.WriteLine($"Deconstructed Employee: ID: {id}, Name: {name}, Address: {address}");
        }
    }


    
}