using System.Linq.Expressions;

namespace Hermes.Common.Extension
{
    /// <summary>
    /// <seealso cref="Expression"/> 扩展方法
    /// </summary>
    public static class ExpressionExtension
    {
        /// <summary>
        /// 将 <seealso cref="Expression"/> 实例与另一个表达式进行与运算
        /// </summary>
        /// <typeparam name="T">表达式参数类型</typeparam>
        /// <param name="expression">表达式</param>
        /// <param name="other">另一个表达式</param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expression, Expression<Func<T, bool>> other)
        {
            if (expression is null)
            {
                throw new ArgumentNullException(nameof(expression));
            }
            if (other is null)
            {
                throw new ArgumentNullException(nameof(other));
            }
            var parameter = Expression.Parameter(typeof(T));

            var leftVisitor = new ReplaceExpressionVisitor(expression.Parameters[0], parameter);
            var left = leftVisitor.Visit(expression.Body);

            var rightVisitor = new ReplaceExpressionVisitor(other.Parameters[0], parameter);
            var right = rightVisitor.Visit(other.Body);

            return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(left!, right!), parameter);
        }

        private class ReplaceExpressionVisitor : ExpressionVisitor
        {
            private readonly Expression _oldValue;

            private readonly Expression _newValue;

            public ReplaceExpressionVisitor(Expression oldValue, Expression newValue)
            {
                _oldValue = oldValue;
                _newValue = newValue;
            }

            public override Expression? Visit(Expression? node)
            {
                if (node == _oldValue)
                    return _newValue;

                return base.Visit(node);
            } 
        }
    }
}