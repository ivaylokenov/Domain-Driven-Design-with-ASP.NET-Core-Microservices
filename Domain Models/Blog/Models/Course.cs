namespace Blog.Models
{
    using System.Collections.Generic;
    using Common;
    using Common.Models;

    public class Course : Entity<int>, IAggregateRoot
    {
        private readonly HashSet<Student> students;

        internal Course(string name)
        {
            this.Name = name;

            this.students = new HashSet<Student>();
        }

        public string Name { get; private set; }

        public void AddStudent(Student student)
            => this.students.Add(student);
    }
}
