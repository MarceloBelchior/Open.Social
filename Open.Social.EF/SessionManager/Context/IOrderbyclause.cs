using System.Linq;

namespace Open.Social.EF.SessionManager.Context
{
    public interface IOrderByClause<T> where T : class, new()
    {
        IOrderedQueryable<T> ApplySort(IQueryable<T> query, bool firstSort);
    }
    public enum SortDirection
    {
        Ascending,
        Decending
    }
}