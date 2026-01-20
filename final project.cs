arp
using System;
using System.Data.Entity; // EF6 namespace

namespace CodeFirstExample
{
    // This is our Student model - will be a table in the database
    public class Student
    {
        public int StudentId { get; set; } // Primary Key (EF detects "Id" or "ClassNameId")
        public string Name { get; set; }
        public int Age { get; set; }
    }

    // This class represents our database context
    public class SchoolContext : DbContext
    {
        // DbSet property will be created as a table in the database
        public DbSet<Student> Students { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // This will create the database based on our model if it doesn't exist yet
            using (var db = new SchoolContext())
            {
                // Create a new Student object
                var student = new Student
                {
                    Name = "John Smith",
                    Age = 20
                };

                // Add student to the Students table
                db.Students.Add(student);

                // Save changes to the database
                db.SaveChanges();

                Console.WriteLine("Student added successfully!");
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
```
