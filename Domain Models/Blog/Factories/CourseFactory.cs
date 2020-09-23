namespace Blog.Factories
{
    using System;
    using System.Collections.Generic;
    using InnerFactories;
    using Models;

    public class CourseFactory : ICourseFactory
    {
        private readonly List<Student> builtStudents;
        private string builtName;

        internal CourseFactory()
        {
            this.builtName = string.Empty;

            this.builtStudents = new List<Student>();
        }

        public ICourseFactory WithName(string name)
        {
            this.builtName = name;
            return this;
        }

        public ICourseFactory WithStudent(Action<StudentFactory> student)
        {
            var studentFactory = new StudentFactory();

            student(studentFactory);

            this.builtStudents.Add(studentFactory.Build());

            return this;
        }

        public Course Build()
        {
            var course = new Course(this.builtName);

            this.builtStudents.ForEach(s => course.AddStudent(s));

            return course;
        }
    }
}
