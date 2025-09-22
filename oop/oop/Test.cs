using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop
{
    internal class Test
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            person.setName("Danh Nguyen Nhut An");
            person.setAge(20);
            person.setRole("Person");
            person.toString();
            Console.WriteLine("______________________________________________");
            Student st1 = new Student("Nguyen Van B", 20,"Student", 52200008, 10, 9 ,8);
            st1.toString();
            Console.WriteLine("______________________________________________");
            Teacher tea = new Teacher("Nguyen Van B", 32, "Teacher", 19000000);
            tea.toString();
            
        }
    }
}
