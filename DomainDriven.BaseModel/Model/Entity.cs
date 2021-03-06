﻿namespace DomainDriven.BaseModel.Model
{
    public abstract class Entity<T>
    {
        public abstract T Id();

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            var other = (Entity<T>) obj;
            return other.Id().Equals(Id());
        }

        public override int GetHashCode()
        {
            return Id().GetHashCode();
        }

        public override string ToString()
        {
            return GetType().Name + ": Id = " + Id();
        }
    }
}
