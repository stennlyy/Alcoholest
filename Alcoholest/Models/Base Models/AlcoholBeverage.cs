using System;

using Alcoholest.Models.Model_Interfaces;

namespace Alcoholest.Models
{
    public abstract class AlcoholBeverage : IDeletableEntity
    {
        public AlcoholBeverage()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedOn = DateTime.UtcNow;
        }

        public string Id { get; set; }

        public int? Year { get; set; }

        public string Brand { get; set; }

        public int Quantity { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? ModifiedOn { get; set; }

        protected void DeleteEntity()
        {
            this.IsDeleted = true;
            this.DeletedOn = DateTime.UtcNow;
        }

        protected bool CheckIfEntityDeleted()
        {
            if (this.IsDeleted)
            {
                return true;
            }

            return false;
        }
    }
}
