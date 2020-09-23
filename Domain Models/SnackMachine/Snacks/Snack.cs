namespace SnackMachine.Snacks
{
    using Common;
    using Common.Models;

    public class Snack : Entity<int>, IAggregateRoot
    {
        public static readonly Snack None = new Snack("None");

        internal Snack(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }
    }
}
