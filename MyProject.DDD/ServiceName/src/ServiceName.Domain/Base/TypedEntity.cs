using MediatR;
using System;
using System.Collections.Generic;

namespace ServiceName.Domain.Base
{
    public abstract class TypedEntity<T> : Entity
    {
        int? _requestedHashCode;
        T _Id;
        public virtual T Id
        {
            get
            {
                return _Id;
            }
            protected set
            {
                _Id = value;
            }
        }

        public bool IsTransient()
        {
            return EqualityComparer<T>.Default.Equals(this.Id, default(T));
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is TypedEntity<T>))
                return false;

            if (Object.ReferenceEquals(this, obj))
                return true;

            if (this.GetType() != obj.GetType())
                return false;

            TypedEntity<T> item = (TypedEntity<T>)obj;

            if (item.IsTransient() || this.IsTransient())
                return false;
            else
                return EqualityComparer<T>.Default.Equals(item.Id, this.Id);
        }

        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                if (!_requestedHashCode.HasValue)
                    _requestedHashCode = this.Id.GetHashCode() ^ 31; // XOR for random distribution (http://blogs.msdn.com/b/ericlippert/archive/2011/02/28/guidelines-and-rules-for-gethashcode.aspx)

                return _requestedHashCode.Value;
            }
            else
                return base.GetHashCode();

        }
        public static bool operator ==(TypedEntity<T> left, TypedEntity<T> right)
        {
            if (Object.Equals(left, null))
                return (Object.Equals(right, null)) ? true : false;
            else
                return left.Equals(right);
        }

        public static bool operator !=(TypedEntity<T> left, TypedEntity<T> right)
        {
            return !(left == right);
        }
    }
}
