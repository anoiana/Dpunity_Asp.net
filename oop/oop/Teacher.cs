using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop
{
    internal class Teacher : Person
    {
        private double salaries;

        public Teacher(String name, int age,String role, double salaries) {
            this.setName(name);
            this.setAge(age);
            this.setRole(role);
            this.salaries = salaries;
        }

        public double getSalaries() { return salaries;}
        public void setSalaries(double salary) { this.salaries = salary; }

        public override void toString()
        {
            Console.WriteLine("Full name: " + getName());
            Console.WriteLine("Age: " + getAge());
            Console.WriteLine("Role: " + getRole());
            Console.WriteLine("Salaries: " + this.salaries);
        }
    }
}
