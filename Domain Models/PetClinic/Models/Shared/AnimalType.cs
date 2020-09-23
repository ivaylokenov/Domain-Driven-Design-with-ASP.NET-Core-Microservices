namespace PetClinic.Models.Shared
{
    using Common.Models;

    public class AnimalType : ValueObject
    {
        internal AnimalType(string species, string breed)
        {
            // Validate data.

            this.Species = species;
            this.Breed = breed;
        }

        public string Species { get; private set; }

        public string Breed { get; private set; }
    }
}
