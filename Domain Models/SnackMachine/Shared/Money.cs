namespace SnackMachine.Shared
{
    using System;
    using Common.Models;

    public class Money : ValueObject
    {
        public static readonly Money None = new Money(0, 0, 0, 0, 0, 0);
        public static readonly Money Cent = new Money(1, 0, 0, 0, 0, 0);
        public static readonly Money TenCent = new Money(0, 1, 0, 0, 0, 0);
        public static readonly Money Quarter = new Money(0, 0, 1, 0, 0, 0);
        public static readonly Money Dollar = new Money(0, 0, 0, 1, 0, 0);
        public static readonly Money FiveDollar = new Money(0, 0, 0, 0, 1, 0);
        public static readonly Money TwentyDollar = new Money(0, 0, 0, 0, 0, 1);

        internal Money(
            int oneCentCount,
            int tenCentCount,
            int quarterCount,
            int oneDollarCount,
            int fiveDollarCount,
            int twentyDollarCount)
        {
            if (oneCentCount < 0)
            {
                throw new InvalidOperationException();
            }

            if (tenCentCount < 0)
            {
                throw new InvalidOperationException();
            }

            if (quarterCount < 0)
            {
                throw new InvalidOperationException();
            }

            if (oneDollarCount < 0)
            {
                throw new InvalidOperationException();
            }

            if (fiveDollarCount < 0)
            {
                throw new InvalidOperationException();
            }

            if (twentyDollarCount < 0)
            {
                throw new InvalidOperationException();
            }

            this.OneCentCount = oneCentCount;
            this.TenCentCount = tenCentCount;
            this.QuarterCount = quarterCount;
            this.OneDollarCount = oneDollarCount;
            this.FiveDollarCount = fiveDollarCount;
            this.TwentyDollarCount = twentyDollarCount;
        }

        public int OneCentCount { get; private set; }

        public int TenCentCount { get; private set; }

        public int QuarterCount { get; private set; }

        public int OneDollarCount { get; private set; }

        public int FiveDollarCount { get; private set; }

        public int TwentyDollarCount { get; private set; }

        public decimal Amount =>
            this.OneCentCount * 0.01m +
            this.TenCentCount * 0.10m +
            this.QuarterCount * 0.25m +
            this.OneDollarCount +
            this.FiveDollarCount * 5 +
            this.TwentyDollarCount * 20;

        public static Money operator +(Money first, Money second)
        {
            var sum = new Money(
                first.OneCentCount + second.OneCentCount,
                first.TenCentCount + second.TenCentCount,
                first.QuarterCount + second.QuarterCount,
                first.OneDollarCount + second.OneDollarCount,
                first.FiveDollarCount + second.FiveDollarCount,
                first.TwentyDollarCount + second.TwentyDollarCount);

            return sum;
        }

        public static Money operator -(Money first, Money second)
        {
            var result = new Money(
                first.OneCentCount - second.OneCentCount,
                first.TenCentCount - second.TenCentCount,
                first.QuarterCount - second.QuarterCount,
                first.OneDollarCount - second.OneDollarCount,
                first.FiveDollarCount - second.FiveDollarCount,
                first.TwentyDollarCount - second.TwentyDollarCount);

            return result;
        }

        public static Money operator *(Money first, int multiplier)
        {
            var result = new Money(
                first.OneCentCount * multiplier,
                first.TenCentCount * multiplier,
                first.QuarterCount * multiplier,
                first.OneDollarCount * multiplier,
                first.FiveDollarCount * multiplier,
                first.TwentyDollarCount * multiplier);

            return result;
        }

        public override string ToString()
        {
            if (this.Amount < 1)
            {
                return "¢" + (this.Amount * 100).ToString("0");
            }

            return "$" + this.Amount.ToString("0.00");
        }

        public bool CanAllocate(decimal amount)
        {
            var money = this.AllocateCore(amount);

            return money.Amount == amount;
        }

        public Money Allocate(decimal amount)
        {
            if (!this.CanAllocate(amount))
            {
                throw new InvalidOperationException();
            }

            return this.AllocateCore(amount);
        }

        private Money AllocateCore(decimal amount)
        {
            var twentyDollarCount = Math.Min((int)(amount / 20), this.TwentyDollarCount);
            amount -= twentyDollarCount * 20;

            var fiveDollarCount = Math.Min((int)(amount / 5), this.FiveDollarCount);
            amount -= fiveDollarCount * 5;

            var oneDollarCount = Math.Min((int)amount, this.OneDollarCount);
            amount -= oneDollarCount;

            var quarterCount = Math.Min((int)(amount / 0.25m), this.QuarterCount);
            amount -= quarterCount * 0.25m;

            var tenCentCount = Math.Min((int)(amount / 0.1m), this.TenCentCount);
            amount -= tenCentCount * 0.1m;

            var oneCentCount = Math.Min((int)(amount / 0.01m), this.OneCentCount);

            return new Money(
                oneCentCount,
                tenCentCount,
                quarterCount,
                oneDollarCount,
                fiveDollarCount,
                twentyDollarCount);
        }
    }
}
