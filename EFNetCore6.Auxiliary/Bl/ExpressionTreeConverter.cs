using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EFNetCore6.Auxiliary.Bl
{
    public class ExpressionTreeConverter<ENT, DTO> : IExpressionTreeConverter<ENT, DTO>
    {
        public ParameterExpression CreateLambdaParameterNode()
        {
            ParameterExpression lambdaParam = Expression.Parameter(typeof(ENT), "x");
            return lambdaParam;
        }
        protected Expression<Func<ENT, bool>> CreateLambdaNode(Expression bodyNode)
        {
            var paramNode = CreateLambdaParameterNode();
            var lambda = Expression.Lambda<Func<ENT, bool>>( bodyNode, new ParameterExpression[] { paramNode });
            return lambda;
        }
        protected Expression CreateSubNode(Expression srcNode)
        {
            if (srcNode is BinaryExpression)
                return CreateBinaryNode((BinaryExpression)srcNode);
            else
            {
                switch(srcNode.NodeType)
                {
                    case ExpressionType.Parameter:
                        return CreateLambdaParameterNode();
                    case ExpressionType.MemberAccess:
                        return Expression.PropertyOrField(CreateLambdaParameterNode(), ((MemberExpression)srcNode).Member.Name);
                    case ExpressionType.Constant: 
                        return 
                }
            }
        }
        protected BinaryExpression CreateBinaryNode(BinaryExpression srcBody)
        {
            var left = CreateSubNode(srcBody.Left);
            var right = CreateSubNode(srcBody.Right);
            var binExp = Expression.MakeBinary(srcBody.NodeType, left, right);
            return binExp;
        }
        public Expression<Func<ENT, bool>> Convert(Expression<Func<DTO, bool>> srcTree)
        {
            if( srcTree == null)
                throw new ArgumentNullException(nameof(srcTree));

            if( srcTree.NodeType != ExpressionType.Lambda )
                throw new Exception("srcTree must have NodeType == ExpressionType.Lambda");
           
            var bodyNode = CreateSubNode(srcTree.Body);
            var dstTree = CreateLambdaNode(bodyNode);
            return dstTree;
        }
    }
}
