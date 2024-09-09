using System.Linq.Expressions;

namespace PSMobile.core.Extensions;
public static class IQueryableExtensions
{
    public static IQueryable<T> When<T>(this IQueryable<T> source, bool trigger, Expression<Func<T, bool>> expression)
    {
        if (trigger)
            return source.Where(expression);

        return source;

    }
}
