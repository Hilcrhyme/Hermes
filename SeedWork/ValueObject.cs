namespace Hermes.Common.SeedWork
{
    /// <summary>
    /// 值对象
    /// </summary>
    public abstract class ValueObject
    {
        /// <summary>
        /// 获取相等组件枚举
        /// </summary>
        /// <returns></returns>
        protected abstract IEnumerable<object> GetEqualityComponents();

        /// <summary>
        /// 是否与指定的对象相等
        /// </summary>
        /// <param name="obj">指定的对象</param>
        /// <returns></returns>
        public override bool Equals(object? obj)
        {
            if (obj is null || obj.GetType() != GetType())
            {
                return false;
            }
            var other = (ValueObject)obj;
            return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }

        /// <summary>
        /// 获取哈希码
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return GetEqualityComponents().Select(x => x is not null ? x.GetHashCode() : 0).Aggregate((x, y) => x ^ y);
        }

        /// <summary>
        /// 获取浅拷贝
        /// </summary>
        /// <returns></returns>
        public ValueObject GetCopy()
        {
            return (MemberwiseClone() as ValueObject)!;
        }

        /// <summary>
        /// 两个值对象是否相等
        /// </summary>
        /// <param name="left">相等运算符左边的值对象</param>
        /// <param name="right">相等运算符右边的值对象</param>
        /// <returns></returns>
        public static bool operator ==(ValueObject left, ValueObject right)
        {
            if (left is null)
            {
                return right is null;
            }
            return left.Equals(right);
        }

        /// <summary>
        /// 两个值对象是否不等
        /// </summary>
        /// <param name="left">不等运算符左边的值对象</param>
        /// <param name="right">不等运算符右边的值对象</param>
        /// <returns></returns>
        public static bool operator !=(ValueObject left, ValueObject right)
        {
            return !(left == right);
        }
    }
}
