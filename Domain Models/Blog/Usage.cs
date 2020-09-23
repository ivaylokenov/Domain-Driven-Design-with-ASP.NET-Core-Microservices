namespace Blog
{
    using System.Collections.Generic;
    using Factories;

    public class Usage
    {
        public void Use(ICourseFactory courseFactory)
        {
            var course = courseFactory
                .WithName("DDD With ASP.NET Core")
                .WithStudent(student => student
                    .WithFirstName("Ivan")
                    .WithLastName("Ivanov"))
                .WithStudent(student => student
                    .WithFirstName("Ivan")
                    .WithLastName("Ivanov"))
                .WithStudent(student => student
                    .WithFirstName("Ivan")
                    .WithLastName("Ivanov"))
                .WithStudent(student => student
                    .WithFirstName("Ivan")
                    .WithLastName("Ivanov"))
                .WithStudent(student => student
                    .WithFirstName("Ivan")
                    .WithLastName("Ivanov"))
                .WithStudent(student => student
                    .WithFirstName("Ivan")
                    .WithLastName("Ivanov"))
                .Build();
        }
    }
}
