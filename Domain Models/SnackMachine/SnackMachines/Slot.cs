namespace SnackMachine.SnackMachines
{
    using Common.Models;

    public class Slot : Entity<int>
    {
        internal Slot(int position)
        {
            // Validate position logic.

            this.Position = position;

            this.SnackPile = SnackPile.Empty;
        }

        public SnackPile SnackPile { get; private set; }

        public int Position { get; private set; }

        public void LoadSnackPile(SnackPile snackPile)
            => this.SnackPile = snackPile;

        public void RemoveOne()
            => this.SnackPile = this.SnackPile.RemoveOne();
    }
}
