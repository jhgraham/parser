using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Parser;

namespace Fred
{
    public class GDMQLVisitor : GDMQLBaseVisitor<object>
    {
        //SQLQueryModel Model { get; set; } = new SQLQueryModel();

        
        public GDMQLVisitor()
        {

        }

        //public override string VisitString(GDMQLParser.StringContext context)
        //{
        //    return context.GetText().ToLower();
        //}

        //public override string VisitNumber(GDMQLParser.NumberContext context)
        //{
        //    return context.GetText();
        //}

        //public override string VisitAnd(GDMQLParser.AndContext context)
        //{
        //    return Visit(context.expression(0)) + "&" + Visit(context.expression(1));
        //}

        //public override string VisitOr(GDMQLParser.OrContext context)
        //{
        //    return Visit(context.expression(0)) + "|" + Visit(context.expression(1));
        //}

        public override object VisitStatement(GDMQLParser.StatementContext context)
        {
            Select select = new Select();

            if (context.IDENTIFIER().Length > 0)
            {
                for (int i = 0; i < context.IDENTIFIER().Length; ++i)
                {
                    ITerminalNode col = context.IDENTIFIER(i);
                    select.Attributes.Add(col.GetText());
                }
            }
            else
            {
                select.Attributes.Add("*");
            }

            select.From = (From)Visit(context.from());

            select.Where = (Where)Visit(context.where());

            return select;
        }

        public override object VisitFrom(GDMQLParser.FromContext context)
        {
            From from = new From();
            for (int i = 0; i < context.IDENTIFIER().Length; ++i)
            {
                ITerminalNode tbl = context.IDENTIFIER(i);
                from.Tables.Add(tbl.GetText());
            }

            return from;
        }


        public override object VisitWhere(GDMQLParser.WhereContext context)
        {
            Where where = new Where();

            Visit(context.expression());

            //for (int i = 0; i < .Length; ++i)
            //{
            //    where.Expression
            //     = (Expression)Visit(context.predicate()[i]);
            //}
            //where.Expression = null; // (Expression)Visit(context.predicate()[0]);

            //(Expression)Visit(context.predicate()[]);
            return where;
        }

        public override object VisitExpression(GDMQLParser.ExpressionContext context)
        {

            //if (context.() != null)
            //{
            //    for (int i = 0; i < context.expression().Length; ++i)
            //    {
            //        Visit(context.expression(i));
            //    }

            //}
            if (context != null)
            {
                //BooleanOperator booleanOperator = (BooleanOperator)Visit(context.booleanOperator());
                //booleanOperator.Left = (Expression)Visit(context.expression()[0]);
                //booleanOperator.Right = (Expression)Visit(context.expression()[1]);
                //return booleanOperator;
            }


            return VisitChildren(context); 
        }


        public override object VisitAndExpression([NotNull] GDMQLParser.AndExpressionContext context)
        {
            return VisitChildren(context);
        }


        public override object VisitPredicate([NotNull] GDMQLParser.PredicateContext context)
        {
            //if (context.OPENPAREN() != null)
            //{
            //    return Visit(context.expression().First());
            //}

            // expression booleanOperator expression
            //if (context.() != null)
            //{
            //    BooleanOperator booleanOperator = (BooleanOperator)Visit(context.booleanOperator());
            //    booleanOperator.Left = (Expression)Visit(context.expression()[0]);
            //    booleanOperator.Right = (Expression)Visit(context.expression()[1]);
            //    return booleanOperator;
            //}

            // operand operator operand
            if (context.comparison_operator() != null)
            {
                ComparisonOperator compareOp = (ComparisonOperator)Visit(context.comparison_operator());
                compareOp.Attribute = (String)context.IDENTIFIER().GetText();
                compareOp.Value = Visit(context.value());
                return compareOp;
            }

            throw new Exception("Unhandled Predicate");
        }
        /*
        public override object VisitExpression(GDMQLParser.ExpressionContext context)
        {
            // OpenParen expression CloseParen
            if (context.OPENPAREN() != null)
            {
                return Visit(context.expression().First());
            }

            // expression booleanOperator expression
            if (context.booleanOperator() != null)
            {
                BooleanOperator booleanOperator = (BooleanOperator)Visit(context.booleanOperator());
                booleanOperator.Left = (Expression)Visit(context.expression()[0]);
                booleanOperator.Right =(Expression)Visit(context.expression()[1]);
                return booleanOperator;
            }

            // operand operator operand
            if (context.comparison_operator() != null)
            {
                ComparisonOperator compareOp = (ComparisonOperator)Visit(context.comparison_operator());
                compareOp.Attribute = (String)context.IDENTIFIER().GetText();
                compareOp.Value = Visit(context.value());
                return compareOp;
            }

            throw new Exception("Unhandled Predicate");
        }
        */
        public override object VisitBooleanOperator(GDMQLParser.BooleanOperatorContext context)
        {
            var terminal = (ITerminalNode)context.GetChild(0);
            var symbolType = terminal.Symbol.Type;

            switch (symbolType)
            {
                case GDMQLParser.AND:
                    return new BooleanOperator(BooleanOperator.BooleanOperatorEnum.AND);
                case GDMQLParser.OR:
                    return new BooleanOperator(BooleanOperator.BooleanOperatorEnum.AND);
            }

            throw new Exception("Unhandled Boolean Operator");
        }



        //public override object VisitAndExpression(GDMQLParser.AndExpressionContext context)
        //{
        //    And and = new And();
        //    and.Left = (Expression)Visit(context.expression(0));
        //    and.Right = (Expression)Visit(context.expression(1));
        //    return and; 
        //}

        //public override object VisitOrExpression(GDMQLParser.OrExpressionContext context)
        //{
        //    Or or = new Or();
        //    or.Left = (Expression)Visit(context.expression(0));
        //    or.Right = (Expression)Visit(context.expression(1));
        //    return or;
        //}

        ////public override object VisitPredicateExpression(GDMQLParser.PredicateExpressionContext context)
        ////{
        ////    return Visit(context.predicate()); ;
        ////}

        //public override object VisitBracketExpression(GDMQLParser.BracketExpressionContext context)
        //{
        //    return (Expression)Visit(context.expression());
        //}

        //public override object VisitOperatorPredicate(GDMQLParser.OperatorPredicateContext context)
        //{
        //    Predicate predicate = new Predicate();
        //    predicate.Operator = (Operator)Visit(context.comparison_operator());
        //    predicate.Value = Visit(context.value());
        //    predicate.Attribute = context.IDENTIFIER().GetText();
        //    return predicate;
        //}

        public override object VisitComparison_operator(GDMQLParser.Comparison_operatorContext context)
        {
            switch (context.GetText())
            {
                case "<=":
                    return new ComparisonOperator(ComparisonOperator.ComparisonEnum.LessThanOrEqualTo);
                case ">=":
                    return new ComparisonOperator(ComparisonOperator.ComparisonEnum.GreaterOrEqualTo);
                case "<":
                    return new ComparisonOperator(ComparisonOperator.ComparisonEnum.LessThan);
                case ">":
                    return new ComparisonOperator(ComparisonOperator.ComparisonEnum.GreaterThan);
                case "==":
                    return new ComparisonOperator(ComparisonOperator.ComparisonEnum.Equals);
                case "!=":
                    return new ComparisonOperator(ComparisonOperator.ComparisonEnum.NotEquals);
                default:
                    return new ComparisonOperator(ComparisonOperator.ComparisonEnum.NotDefined);
            }
        }

        public override object VisitIntegerValue(GDMQLParser.IntegerValueContext context)
        {
            return Int32.Parse(context.GetText()); 
        }

        
        public override object VisitDoubleValue(GDMQLParser.DoubleValueContext context)
        {
            return Double.Parse(context.GetText());
        }

        public override object VisitStringValue(GDMQLParser.StringValueContext context)
        {
            return context.GetText();
        }

        public override object VisitPlaceHolderValue(GDMQLParser.PlaceHolderValueContext context)
        {
            return context.GetText();
        }

    }
}
