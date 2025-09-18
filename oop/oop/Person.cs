using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop
{
    internal class Person
    {
        private String name;
        private int age;
        private String role;

        public Person() { }
        public Person(String name, int age, string role)
        {
            this.name = name;
            this.age = age;
            this.role = role;
        }

        public String getName()
        {
            return this.name;
        }
        public int getAge()
        {
            return this.age;
        }

        public void setAge(int age)
        {
            this.age = age;
        }

        public void setName(String name)
        {
            this.name = name;
        }

        public String getRole() { 
            return this.role;
        }

        public void setRole(String newRole) { 
            this.role=newRole;
        }

        public void toString()
        {
            Console.WriteLine("Full name: " + this.name);
            Console.WriteLine("Age: " + this.age);
            Console.WriteLine("Role: " + this.role);
        }
    }
}
