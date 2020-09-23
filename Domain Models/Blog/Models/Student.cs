namespace Blog.Models
{
    using Common.Models;

    public class Student : Entity<int>
    {
        internal Student(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }
    }
}
