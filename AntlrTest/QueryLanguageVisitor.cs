using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parser;

namespace AntlrTest
{
    public class QueryLanguageVisitor : QueryLanguageBaseVisitor<object>
    {

        public override object VisitStatement(QueryLanguageParser.StatementContext context)
        {
            QueryStatement statement = new QueryStatement();
            statement.Select = (Select)Visit(context.select());
            statement.From = (From)Visit(context.from());

            if(context.where() != null)
            {
                statement.Where = (Where)Visit(context.where());
            }

            if(context.join() != null)
            {
                for (int i = 0; i < context.join().Length; ++i)
                {
                    statement.Join.Add((Join)Visit(context.join(i)));
                }
            }
            return statement; 
        }

        public override object VisitSelect(QueryLanguageParser.SelectContext context)
        {
            Select select = new Select();  
            if(context.ASTERISK() == null)
            {
                for (int i = 0; i < context.column().Length; ++i)
                {
                    select.Attributes.Add(context.column(i).GetText());
                }
            }
            return select; 
        }
        public override object VisitFrom(QueryLanguageParser.FromContext context)
        {
            From from = new From();
            for (int i = 0; i < context.table().Length; ++i)
            {
                from.Tables.Add(context.table(i).GetText());
            }

            return from;
        }

        public override object VisitJoin(QueryLanguageParser.JoinContext context)
        {
            Join join = new Join();
            join.Type = Join.JoinType.INNER;

            join.Table = context.table().GetText();
            join.column1 = context.joinPredicate().column(0).GetText();
            join.column2 = context.joinPredicate().column(1).GetText();
            return join;
        }

        public override object VisitWhere(QueryLanguageParser.WhereContext context)
        {
            Where where = new Where();

            where.Expression = (Expression)Visit(context.expression());

            return where; 
        }



        public override object VisitAnd(QueryLanguageParser.AndContext context)
        {
            BooleanOperator booleanExpression = new BooleanOperator(BooleanOperator.BooleanOperatorEnum.AND);
            booleanExpression.Left = (Expression)Visit(context.expression(0));
            booleanExpression.Right = (Expression)Visit(context.expression(1));
            return booleanExpression;
        }

        public override object VisitOr(QueryLanguageParser.OrContext context)
        {
            BooleanOperator booleanExpression = new BooleanOperator(BooleanOperator.BooleanOperatorEnum.OR);
            booleanExpression.Left = (Expression)Visit(context.expression(0));
            booleanExpression.Right = (Expression)Visit(context.expression(1));
            return booleanExpression;
        }

        public override object VisitBracketExpression(QueryLanguageParser.BracketExpressionContext context)
        {
            return (Expression)Visit(context.expression());
        }

        private Predicate.ComparisonEnum GetComparator(string comp)
        {
            Predicate.ComparisonEnum compType;
            switch (comp)
            {
                case "==":
                    compType = Predicate.ComparisonEnum.Equals;
                    break;
                case ">":
                    compType = Predicate.ComparisonEnum.GreaterThan;
                    break;
                case "<":
                    compType = Predicate.ComparisonEnum.LessThan;
                    break;
                case ">=":
                    compType = Predicate.ComparisonEnum.GreaterThanOrEqualTo;
                    break;
                case "<=":
                    compType = Predicate.ComparisonEnum.LessThanOrEqualTo;
                    break;
                case "!=":
                    compType = Predicate.ComparisonEnum.NotEquals;
                    break;
                default:
                    compType = Predicate.ComparisonEnum.NotDefined;
                    break;
            }
            return compType;
        }

        public override object VisitPredicate( QueryLanguageParser.PredicateContext context)
        {
            string comparator = context.comparison_operator().GetText();
            Predicate.ComparisonEnum comparisonType = GetComparator(comparator);
            Predicate predicate = new Predicate(comparisonType);
            predicate.Attribute = context.column().GetText();
            predicate.Value = Visit(context.value());
            return predicate;
        }

        public override object VisitStringLiteralValue(QueryLanguageParser.StringLiteralValueContext context)
        {
            return context.GetText().Replace("'", ""); //remove single quotes
        }

        public override object VisitIntegerValue(QueryLanguageParser.IntegerValueContext context)
        {
            return int.Parse(context.GetText());
        }

        public override object VisitDoubleValue(QueryLanguageParser.DoubleValueContext context)
        {
            return double.Parse(context.GetText());
        }

        public override object VisitPlaceHolderValue(QueryLanguageParser.PlaceHolderValueContext context)
        {
            return context.GetText();
        }
    }
}
