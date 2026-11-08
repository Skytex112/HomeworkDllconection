using HomeworkDll;
using System.Reflection;
namespace HomeworkDllconection
{
    internal class Program
    {
        static void Main(string[] args)
        {
                
                Assembly asm = Assembly.Load(AssemblyName.GetAssemblyName("HomeworkDll.dll"));

                // Get type Person from the assembly
                Type personType = asm.GetType("HomeworkDll.Person");

                if (personType == null)
                {
                    Console.WriteLine("Class Person not found!");
                    return;
                }

                // 2. Print full name of Person class
                Console.WriteLine($"Full class name: {personType.FullName}\n");

                // 3. Create Person instance using Activator.CreateInstance
                object person = Activator.CreateInstance(personType, new object[] { "Ivan", "Ivanov", 30 });

                // 4. Call ToString() and print result
                string str = personType.GetMethod("ToString").Invoke(person, null).ToString();
                Console.WriteLine($"ToString(): {str}\n");

                // 5. Print all methods of Person class
                Console.WriteLine("Methods:");
                foreach (var method in personType.GetMethods())
                {
                    Console.WriteLine($"- {method.Name}");
                }
                Console.WriteLine();

                // 6. Print all properties of Person class
                Console.WriteLine("Properties:");
                foreach (var prop in personType.GetProperties())
                {
                    Console.WriteLine($"- {prop.Name} ({prop.PropertyType.Name})");
                }
                Console.WriteLine();

                // 7. Get value of FirstName property
                var firstNameProp = personType.GetProperty("FirstName");
                string firstName = firstNameProp.GetValue(person).ToString();
                Console.WriteLine($"FirstName = {firstName}\n");

                // 8. Set new value for Age property and call ToString again
                var ageProp = personType.GetProperty("Age");
                ageProp.SetValue(person, 45);
                string updatedStr = personType.GetMethod("ToString").Invoke(person, null).ToString();
                Console.WriteLine($"After updating Age: {updatedStr}\n");

                // 9. Check if method PrintInfo exists
                var printInfoMethod = personType.GetMethod("PrintInfo");
                if (printInfoMethod != null)
                {
                   Console.WriteLine("Method PrintInfo found.");
                    // 10. Invoking PrintInfo
                    printInfoMethod.Invoke(person, null);
                }
                else
                {
                    Console.WriteLine("Method PrintInfo NOT found.");
                }

                var ToStringMethod = personType.GetMethod("ToString");
                if (ToStringMethod != null)
                {
                    Console.WriteLine("Method ToString found.");
                    // 10. Invoking Tostirng
                    ToStringMethod.Invoke(person, null);
                }
                else
                {
                    Console.WriteLine("Method ToString NOT found.");
                }

        }
    
    }
}
