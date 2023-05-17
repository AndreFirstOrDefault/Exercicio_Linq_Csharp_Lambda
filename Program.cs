using ExercicioDeFixacao_Aula242.Entities;
using System.Globalization;

namespace ExercicioDeFixacao_Aula242
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter full file path: ");
            string path = Console.ReadLine();

            Console.Write("Enter salary: ");
            double salaryIn = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
           
            List<Employee> list = new List<Employee>();

            using(StreamReader sr = File.OpenText(path))
            {
                while(!sr.EndOfStream)
                {
                    string[] fields = sr.ReadLine().Split(',');
                    string name = fields[0];
                    string email = fields[1];
                    double salary = double.Parse(fields[2],CultureInfo.InvariantCulture);
                    list.Add(new Employee(name, email, salary));
                }

                Console.WriteLine("Email of people whose salary is more than " + salaryIn + " :");
                var emailP = list.Where(p => p.Salary > salaryIn).OrderBy(p => p.Email ).Select(p => p.Email);
                
                foreach( string email in emailP)
                {
                    Console.WriteLine(email);
                }
                
              
                var sum = list.Where(p => p.Name.StartsWith('M')).Select(p => p.Salary).Sum();
                Console.Write("Sum of salary of people whose name starts with 'M': " + sum.ToString("F2",CultureInfo.InvariantCulture));
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}