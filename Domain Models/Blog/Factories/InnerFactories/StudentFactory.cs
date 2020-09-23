namespace Blog.Factories.InnerFactories
{
    using Models;

    public class StudentFactory
    {
        private string builtFirstName;
        private string builtLastName;

        internal StudentFactory()
        {
            this.builtFirstName = string.Empty;
            this.builtLastName = string.Empty;
        }

        public StudentFactory WithFirstName(string firstName)
        {
            this.builtFirstName = firstName;
            return this;
        }

        public StudentFactory WithLastName(string lastName)
        {
            this.builtLastName = lastName;
            return this;
        }

        internal Student Build()
            => new Student(this.builtFirstName, this.builtLastName);
    }
}
