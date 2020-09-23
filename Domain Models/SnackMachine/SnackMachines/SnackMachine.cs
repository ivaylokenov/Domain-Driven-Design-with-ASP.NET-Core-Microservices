namespace SnackMachine.SnackMachines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;
    using Common.Models;
    using Shared;

    public class SnackMachine : Entity<int>, IAggregateRoot
    {
        private readonly IList<Slot> slots;

        internal SnackMachine()
        {
            this.MoneyInside = Money.None;
            this.MoneyInTransaction = 0;

            this.slots = new List<Slot>
            {
                new Slot(1),
                new Slot(2),
                new Slot(3)
            };
        }

        public Money MoneyInside { get; private set; }

        public decimal MoneyInTransaction { get; private set; }

        public SnackPile GetSnackPile(int position) 
            => this.GetSlot(position).SnackPile;

        public IReadOnlyList<SnackPile> GetAllSnackPiles() 
            => this.slots
                .OrderBy(x => x.Position)
                .Select(x => x.SnackPile)
                .ToList();

        private Slot GetSlot(int position) 
            => this.slots.Single(x => x.Position == position);

        public void InsertMoney(Money money)
        {
            var coinsAndNotes = new []
            {
                Money.Cent, Money.TenCent, Money.Quarter, Money.Dollar, Money.FiveDollar, Money.TwentyDollar
            };

            if (!coinsAndNotes.Contains(money))
            {
                throw new InvalidOperationException();
            }

            this.MoneyInTransaction += money.Amount;
            this.MoneyInside += money;
        }

        public void ReturnMoney()
        {
            var moneyToReturn = this.MoneyInside.Allocate(this.MoneyInTransaction);

            this.MoneyInside -= moneyToReturn;
            this.MoneyInTransaction = 0;
        }

        public string CanBuySnack(int position)
        {
            var snackPile = this.GetSnackPile(position);

            if (snackPile.Quantity == 0)
            {
                return "The snack pile is empty";
            }

            if (this.MoneyInTransaction < snackPile.Price)
            {
                return "Not enough money";
            }

            if (!this.MoneyInside.CanAllocate(this.MoneyInTransaction - snackPile.Price))
            {
                return "Not enough change";
            }

            return string.Empty;
        }

        public void BuySnack(int position)
        {
            if (this.CanBuySnack(position) != string.Empty)
            {
                throw new InvalidOperationException();
            }

            var slot = this.GetSlot(position);
            
            slot.RemoveOne();

            var change = this.MoneyInside.Allocate(this.MoneyInTransaction - slot.SnackPile.Price);
            
            this.MoneyInside -= change;
            this.MoneyInTransaction = 0;
        }

        public void LoadSnacks(int position, SnackPile snackPile)
        {
            var slot = this.GetSlot(position);

            slot.LoadSnackPile(snackPile);
        }

        public void LoadMoney(Money money) 
            => this.MoneyInside += money;

        public Money UnloadMoney()
        {
            if (this.MoneyInTransaction > 0)
            {
                throw new InvalidOperationException();
            }

            var money = this.MoneyInside;

            this.MoneyInside = Money.None;

            return money;
        }
    }
}
