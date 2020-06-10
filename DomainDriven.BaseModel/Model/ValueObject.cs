using System.Collections.Generic;

namespace DomainDriven.BaseModel.Model
{
    /// <summary>
    /// A Value Object.
    /// https://enterprisecraftsmanship.com/posts/value-object-better-implementation/
    /// </summary>
    public abstract class ValueObject
    {
        public abstract override string ToString();

        public static bool operator ==(ValueObject lhs, ValueObject rhs)
        {
            // Check for null on left side.
            if (ReferenceEquals(lhs, null))
            {
                if (ReferenceEquals(rhs, null))
                {
                    // null == null = true.
                    return true;
                }

                // Only the left side is null.
                return false;
            }
            // Equals handles case of null on right side.
            return lhs.Equals(rhs);
        }

        public static bool operator !=(ValueObject lhs, ValueObject rhs)
        {
            return !(lhs == rhs);
        }

        protected abstract IEnumerable<object> GetAtomicValues();

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            ValueObject other = (ValueObject)obj;
            IEnumerator<object> thisValues = GetAtomicValues().GetEnumerator();
            IEnumerator<object> otherValues = other.GetAtomicValues().GetEnumerator();
            while (thisValues.MoveNext() && otherValues.MoveNext())
            {
                if (ReferenceEquals(thisValues.Current, null) ^
                    ReferenceEquals(otherValues.Current, null))
                {
                    return false;
                }

                if (thisValues.Current != null &&
                    !thisValues.Current.Equals(otherValues.Current))
                {
                    return false;
                }
            }
            return !thisValues.MoveNext() && !otherValues.MoveNext();
        }

        public override int GetHashCode()
        {
            var result = 0;
            IEnumerator<object> thisValue = GetAtomicValues().GetEnumerator();
            while (thisValue.MoveNext())
            {
                result = result ^ (thisValue.Current != null ? thisValue.Current.GetHashCode() : 0);
            }
            return result;
        }
    }
}
