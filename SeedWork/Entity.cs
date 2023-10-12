using MediatR;

namespace Hermes.Common.SeedWork
{
    /// <summary>
    /// 实体
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// 已请求的哈希码
        /// </summary>
        private int? _requestedHashCode;

        /// <summary>
        /// 实体 Id
        /// </summary>
        public virtual long Id { get; protected init; } = default;

        /// <summary>
        /// 实体的创建时间
        /// </summary>
        public DateTime CreatedTime { get; protected init; } = default;

        /// <summary>
        /// 领域事件列表
        /// </summary>
        private readonly List<INotification> _domainEvents = new();

        /// <summary>
        /// 领域事件只读集合
        /// </summary>
        public IReadOnlyCollection<INotification> DomainEvents => _domainEvents;

        /// <summary>
        /// 添加领域事件
        /// </summary>
        /// <param name="eventItem">领域事件</param>
        public void AddDomainEvent(INotification eventItem)
        {
            _domainEvents.Add(eventItem);
        }

        /// <summary>
        /// 移除领域事件
        /// </summary>
        /// <param name="eventItem">领域事件</param>
        public void RemoveDomainEvent(INotification eventItem)
        {
            _domainEvents.Remove(eventItem);
        }

        /// <summary>
        /// 清除领域事件列表
        /// </summary>
        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

        /// <summary>
        /// 是否为暂时性的实体
        /// </summary>
        /// <returns></returns>
        public bool IsTransient()
        {
            return Id == default;
        }

        /// <summary>
        /// 是否与指定的对象相等
        /// </summary>
        /// <param name="obj">指定的对象</param>
        /// <returns></returns>
        public override bool Equals(object? obj)
        {
            if (obj == null || obj is not Entity)
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (GetType() != obj.GetType())
            {
                return false;
            }
            var item = (Entity)obj;
            if (item.IsTransient() || IsTransient())
            {
                return false;
            }
            return item.Id == Id;
        }

        /// <summary>
        /// 获取哈希码
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                if (!_requestedHashCode.HasValue)
                {
                    _requestedHashCode = Id.GetHashCode() ^ 31; // XOR for random distribution (http://blogs.msdn.com/b/ericlippert/archive/2011/02/28/guidelines-and-rules-for-gethashcode.aspx)
                }
                return _requestedHashCode.Value;
            }
            return base.GetHashCode();
        }

        /// <summary>
        /// 两个实体是否相等
        /// </summary>
        /// <param name="left">相等运算符左边的实体</param>
        /// <param name="right">相等运算符右边的实体</param>
        /// <returns></returns>
        public static bool operator ==(Entity left, Entity right)
        {
            if (left is null)
            {
                return right is null;
            }
            return left.Equals(right);
        }

        /// <summary>
        /// 两个实体是否不等
        /// </summary>
        /// <param name="left">不等运算符左边的实体</param>
        /// <param name="right">不等运算符右边的实体</param>
        /// <returns></returns>
        public static bool operator !=(Entity left, Entity right)
        {
            return !(left == right);
        }
    }
}