using System.Linq.Expressions;

namespace org.huage.AuthManagement.DataBase.Expression;

public static class ExpressionExtension
{
    
    /// <summary>
    /// 初始化一个逻辑值为true的表达式
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <returns>新的表达式</returns>
    public static Expression<Func<TEntity, bool>> True<TEntity>()
    {
        return t => true;
    }

    /// <summary>
    /// 初始化一个逻辑值为false的表达式
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <returns>新的表达式</returns>
    public static Expression<Func<TEntity, bool>> False<TEntity>()
    {
        return t => false;
    }
    
    //生成逻辑与表达式
    public static Expression<Func<TEntity, bool>> And<TEntity>(this Expression<Func<TEntity, bool>> first, Expression<Func<TEntity, bool>> second)
    {
        ParameterExpression parameter = System.Linq.Expressions.Expression.Parameter(typeof(TEntity), "t");
        ParameterRebinder rebinder = new ParameterRebinder(parameter);
        System.Linq.Expressions.Expression left = rebinder.RebindParameter(first.Body);
        System.Linq.Expressions.Expression right = rebinder.RebindParameter(second.Body);
        System.Linq.Expressions.Expression body = System.Linq.Expressions.Expression.AndAlso(left, right);
        Expression<Func<TEntity, bool>> expression = System.Linq.Expressions.Expression.Lambda<Func<TEntity, bool>>(body, parameter);
        return expression;
    }
    
    /// <summary>
    /// 生成逻辑或表达式
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <param name="first">第一个表达式</param>
    /// <param name="second">第二个表达式</param>
    /// <returns>新的表达式</returns>
    public static Expression<Func<TEntity, bool>> Or<TEntity>( Expression<Func<TEntity, bool>> first, Expression<Func<TEntity, bool>> second)
    {
        ParameterExpression parameter = System.Linq.Expressions.Expression.Parameter(typeof(TEntity), "t");
        ParameterRebinder rebinder = new ParameterRebinder(parameter);
        System.Linq.Expressions.Expression left = rebinder.RebindParameter(first.Body);
        System.Linq.Expressions.Expression right = rebinder.RebindParameter(second.Body);
        System.Linq.Expressions.Expression body = System.Linq.Expressions.Expression.OrElse(left, right);
        Expression<Func<TEntity, bool>> expression = System.Linq.Expressions.Expression.Lambda<Func<TEntity, bool>>(body, parameter);
        return expression;
    }
}