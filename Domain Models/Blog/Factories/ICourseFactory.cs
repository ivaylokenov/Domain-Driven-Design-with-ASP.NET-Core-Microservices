namespace Blog.Factories
{
    using System;
    using Common;
    using InnerFactories;
    using Models;

    public interface ICourseFactory : IFactory<Course>
    {
        ICourseFactory WithName(string name);

        ICourseFactory WithStudent(Action<StudentFactory> student);
    }
}
