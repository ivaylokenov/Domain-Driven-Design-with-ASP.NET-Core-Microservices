namespace CarRentalSystem.Domain.Renting.Models
{
    using System;
    using Common.Models;

    public class DateTimeRange : ValueObject
    {
        internal DateTimeRange(DateTime start, DateTime end)
        {
            // TODO: Validate end date is after start date.

            this.Start = start;
            this.End = end;
        }

        internal DateTimeRange(DateTime start, TimeSpan duration)
            : this(start, start.Add(duration))
        {
        }

        public DateTime Start { get; private set; }

        public DateTime End { get; private set; }

        public int DurationInMinutes()
            => (this.End - this.Start).Minutes;

        public DateTimeRange NewEnd(DateTime newEnd)
            => new DateTimeRange(this.Start, newEnd);

        public DateTimeRange NewDuration(TimeSpan newDuration)
            => new DateTimeRange(this.Start, newDuration);

        public DateTimeRange NewStart(DateTime newStart)
            => new DateTimeRange(newStart, this.End);

        public static DateTimeRange CreateOneDayRange(DateTime day)
            => new DateTimeRange(day, day.AddDays(1));

        public static DateTimeRange CreateOneWeekRange(DateTime startDay)
            => new DateTimeRange(startDay, startDay.AddDays(7));

        public bool Overlaps(DateTimeRange dateTimeRange)
            => this.Start < dateTimeRange.End &&
               this.End > dateTimeRange.Start;
    }
}