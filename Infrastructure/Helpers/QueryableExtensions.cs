using System.Globalization;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace Infrastructure.Helpers;

internal static partial class QueryableExtensions
{
    internal static IOrderedQueryable<TEntity> OrderByField<TEntity>(this IQueryable<TEntity> source, string orderByProperty, bool ask)
    {
        TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

        string titleCase = textInfo.ToTitleCase(orderByProperty);

        orderByProperty = ToTitleCase().Replace(titleCase, string.Empty);

        string command = ask ? "OrderBy" : "OrderByDescending";
        var type = typeof(TEntity);
        var property = type.GetProperty(orderByProperty);
        var parameter = Expression.Parameter(type, "p");
        var propertyAccess = Expression.MakeMemberAccess(parameter, property);
        var orderByExpression = Expression.Lambda(propertyAccess, parameter);
        var resultExpression = Expression.Call(typeof(Queryable), command, new Type[] { type, property.PropertyType },
            source.Expression, Expression.Quote(orderByExpression));

        return (IOrderedQueryable<TEntity>)source.Provider.CreateQuery<TEntity>(resultExpression);
    }

    [GeneratedRegex("[_]")]
    private static partial Regex ToTitleCase();
}
