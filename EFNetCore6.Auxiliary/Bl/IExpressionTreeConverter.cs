using System.Linq.Expressions;

namespace EFNetCore6.Auxiliary.Bl
{
    public interface IExpressionTreeConverter<ENT,DTO>
    {
        Expression<Func<ENT, bool>> Convert(Expression<Func<DTO, bool>> srcTree);
    }
}
