namespace SnackMachine.SnackMachines
{
    using System;
    using Common.Models;
    using Snacks;

    public class SnackPile : ValueObject
    {
        internal static readonly SnackPile Empty = new SnackPile(Snack.None, 0, 0m);

        internal SnackPile(Snack snack, int quantity, decimal price)
        {
            if (quantity < 0)
            {
                throw new InvalidOperationException();
            }

            if (price < 0)
            {
                throw new InvalidOperationException();
            }

            if (price % 0.01m > 0)
            {
                throw new InvalidOperationException();
            }

            this.Snack = snack;
            this.Quantity = quantity;
            this.Price = price;
        }

        public Snack Snack { get; private set; }

        public int Quantity { get; private set; }

        public decimal Price { get; private set; }

        public SnackPile RemoveOne() 
            => new SnackPile(this.Snack, this.Quantity - 1, this.Price);
    }
}
