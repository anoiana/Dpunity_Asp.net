using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop
{
    internal class Student : Person, StudentInterface
    {
        private long studentCode;
        private double math;
        private double physics;
        private double Chemistry;

        public Student(String name, int age, String role, long studentCode, double math, double physics, double Chemistry)
        {
            this.setName(name);
            this.setAge(age);
            this.setRole(role);
            this.math = math;
            this.physics = physics;
            this.Chemistry = Chemistry;
            this.studentCode = studentCode;
        }
        public long getStudentCode() { return studentCode; }
        public void setStudentCode(long code) { this.studentCode = code; }
        public double averageScore(double math, double physics, double Chemistry)
        {
            return (math * 2 + Chemistry + physics) / 4.0;
        }

        public override void toString()
        {
            Console.WriteLine("Full name: " + getName());
            Console.WriteLine("Age: " + getAge());
            Console.WriteLine("Role: " + getRole());
            Console.WriteLine("Stduent Code: " + this.studentCode);
            Console.WriteLine("Average Score: " + averageScore(this.math, this.physics, this.Chemistry));
        }
    }
}
