using Sam.Common.Global.Enums;
using System.Linq;

namespace Sam.Common.Global.Utilities;

public static class Calculations
{
    private const string defaultSearchString = "none";
    private const bool defaultForIncludingNullOrEmptyValues = false;


    public static string GetFormattedAverageNullableField(List<int> values, int decimalPlaces)
    {
        decimal decimalValue = GetAverage(values, decimalPlaces);
        string zeroes = "0.";
        for (int i = 0; i < decimalPlaces; i++)
        {
            zeroes = zeroes + "0";
        }

        string rval = decimalValue.ToString(zeroes);
        return rval;
    }

    public static decimal GetFormattedNullableDouble(Double? value, int decimalPlaces)
    {
        return value == null ? 0.0m : Math.Round(((decimal)(value * 100)), decimalPlaces);
    }

    public static string GetFormattedAverageNullableField(List<decimal> values, int decimalPlaces)
    {
        //return GetAverage(values, decimalPlaces);
        decimal decimalValue = GetAverage(values, decimalPlaces);
        string zeroes = "0.";
        for (int i = 0; i < decimalPlaces; i++)
        {
            zeroes = zeroes + "0";
        }

        string rval = decimalValue.ToString(zeroes);
        return rval;
    }

    public static decimal IsPercentageOf(decimal count, decimal total)
    {
        decimal val = 0.00m;

        if (total > 0)
        {
            val = count * 100 / total;
            val = decimal.Round(val, 2);
        }

        return val == 0 ? 0.0m : val;
    }

    public static string NormalizeAlpha(string val, bool asLowerCase = true)
    {
        if (!string.IsNullOrEmpty(val))
        {
            return asLowerCase
                ? val.Trim().ToLower()
                : val.Trim().ToUpper();
        }
        return string.Empty;
    }

    public static int? GetValueFromDictionary(string valueKey, Dictionary<string, int> dictionary)
    {
        int? compareVal = dictionary.FirstOrDefault(v => v.Key.Equals(valueKey, StringComparison.OrdinalIgnoreCase)).Value;

        if (!compareVal.HasValue || compareVal.Value == 0)
        {
            if (int.TryParse(valueKey.Trim()[0].ToString(), out int tempVal))
            {
                if (tempVal >= 5)
                {
                    compareVal = dictionary.Last().Value + 30;
                }
            }
        }

        return compareVal;
    }

    public static bool HasAValue<T>(T item)
    {
        if (typeof(T) == typeof(string))
        {
            return !string.IsNullOrEmpty(item as string);
        }

        return !EqualityComparer<T>.Default.Equals(item, default(T))
            &&
            !string.IsNullOrEmpty(item.ToString());
    }

    public static bool HasAnyInList<T>(List<T> itemList)
    {
        return null != itemList && itemList.Any();
    }

    public static bool CheckForStringMatch(string valString, string searchString = defaultSearchString)
    {
        bool isMatch = false;

        if (!string.IsNullOrEmpty(valString) && !string.IsNullOrEmpty(searchString))
        {
            isMatch = valString.Equals(searchString, StringComparison.OrdinalIgnoreCase);
        }
        else if (string.IsNullOrEmpty(valString) && string.IsNullOrEmpty(searchString))
        {
            isMatch = true;
        }
        return isMatch;
    }

    public static bool CheckForStringMatch(List<string> valStrings, string searchString = defaultSearchString)
    {
        bool isFound = false;

        if (null != valStrings && valStrings.Any() && !string.IsNullOrEmpty(searchString))
        {
            isFound = valStrings.Any(v => v.Equals(searchString, StringComparison.OrdinalIgnoreCase));
        }
        else if (null == valStrings && string.IsNullOrEmpty(searchString))
        {
            isFound = true;
        }

        return isFound;
    }

    public static string IntToBoolString(int? value)
    {
        switch (value)
        {
            case 0:
                return "False";
            case 1:
                return "True";
            default:
                return string.Empty;
        }
    }

    public static string StringToBoolString(string value)
    {
        switch (value)
        {
            case "0":
                return "False";
            case "1":
                return "True";
            default:
                return string.Empty;
        }
    }

    public static Int32? CheckForNullInt(string value)
    {
        value = value?.Replace(",", "");

        if (int.TryParse(value, out int tmpVal))
        {
            return tmpVal;
        }
        else
        {
            return null;
        }
    }

    public static Double? CheckForNullDouble(string value)
    {
        value = value?.Replace(",", "");

        if (double.TryParse(value, out double tmpVal))
        {
            return tmpVal;
        }
        else
        {
            return null;
        }
    }

    public static DateTime? CheckForNullDate(string value)
    {
        if (DateTime.TryParse(value, out DateTime tmpVal))
        {
            return tmpVal;
        }
        else
        {
            return null;
        }
    }

    public static Expression<Func<T, bool>> ExpressionGetNullOrEmptyValues<T>(string columnName)
    {
        return q =>
            q.GetType().GetProperty(columnName).GetValue(q, null) == null
            ||
            string.IsNullOrEmpty(q.GetType().GetProperty(columnName).GetValue(q, null).ToString());
    }

    public static Expression<Func<T, bool>> ExpressionContainsValueInList<T, Z>(string columnName, List<Z> itemList, bool includeNullResults = defaultForIncludingNullOrEmptyValues)
    {
        Expression<Func<T, bool>> expressionToReturn = null;
        List<string> vals = new List<string>();
        if (itemList.Any())
        {
            vals = [.. itemList.Where(i => !string.IsNullOrEmpty($"{i}")).Select(i => $"{i}")];
        }

        if (includeNullResults)
        {
            var nullExpression = ExpressionGetNullOrEmptyValues<T>(columnName);

            if (vals.Any())
            {
                Expression<Func<T, bool>> compareExpression = null;
                compareExpression = q => vals.Contains(q.GetType().GetProperty(columnName).GetValue(q, null).ToString());
                expressionToReturn = nullExpression.Or(compareExpression);
            }
            else
            {
                expressionToReturn = nullExpression;
            }
        }
        else
        {
            if (vals.Any())
            {
                Expression<Func<T, bool>> compareExpression = null;
                compareExpression = q => vals.Contains(q.GetType().GetProperty(columnName).GetValue(q, null).ToString());
                expressionToReturn = compareExpression;
            }
        }

        return expressionToReturn;
    }

    public static Expression<Func<T, bool>> ExpressionDoesntContainValuesInList<T, Z>(string columnName, List<Z> itemList, bool includeNullsInResults = defaultForIncludingNullOrEmptyValues)
    {
        Expression<Func<T, bool>> expressionToReturn = null;
        var vals = new List<string>();
        if (itemList.Any())
        {
            vals = itemList.Select(i => i.ToString()).ToList();
        }

        if (includeNullsInResults)
        {
            var nullPredicate = ExpressionGetNullOrEmptyValues<T>(columnName);

            if (vals.Any())
            {
                Expression<Func<T, bool>> compareExpression = null;
                compareExpression = q => !vals.Contains(q.GetType().GetProperty(columnName).GetValue(q, null).ToString());
                expressionToReturn = nullPredicate.Or(compareExpression);
            }
            else
            {
                expressionToReturn = nullPredicate;
            }
        }
        else
        {
            expressionToReturn = q => !vals.Contains(q.GetType().GetProperty(columnName).GetValue(q, null).ToString());
        }

        return expressionToReturn;
    }

    public static Expression<Func<T, bool>> ExpressionCompareType<T, Z>(string columnName, ComparisonTypes compareType, Z val, bool includeEmptyValues = defaultForIncludingNullOrEmptyValues)
    {
        Expression<Func<T, bool>> expressionToReturn = null;

        if (HasAValue(val) && HasAValue(columnName) && ComparisonTypes.None != compareType)
        {
            // Make sure we are looking at records with values in the column
            Expression<Func<T, bool>> notNullPredicate = ExpressionColumnIsNotNull<T>(columnName);
            Expression<Func<T, bool>> comparePredicate = null;

            switch (compareType)
            {
                //
                // Converting to decimal because it should fit almost any number type
                //

                case ComparisonTypes.GreaterThanOrEqualTo:
                    comparePredicate = q => Convert.ToDecimal(q.GetType().GetProperty(columnName).GetValue(q, null)) >= Convert.ToDecimal(val);
                    break;
                case ComparisonTypes.GreaterThan:
                    comparePredicate = q => Convert.ToDecimal(q.GetType().GetProperty(columnName).GetValue(q, null)) > Convert.ToDecimal(val);
                    break;
                case ComparisonTypes.LessThan:
                    comparePredicate = q => Convert.ToDecimal(q.GetType().GetProperty(columnName).GetValue(q, null)) < Convert.ToDecimal(val);
                    break;
                case ComparisonTypes.LessThanOrEqualTo:
                    comparePredicate = q => Convert.ToDecimal(q.GetType().GetProperty(columnName).GetValue(q, null)) <= Convert.ToDecimal(val);
                    break;
                case ComparisonTypes.Equal:
                default:
                    comparePredicate = q => Convert.ToDecimal(q.GetType().GetProperty(columnName).GetValue(q, null)) == Convert.ToDecimal(val);
                    break;
            }

            // Combine the comparison with the not null check
            var initialExpression = notNullPredicate.And(comparePredicate);

            // If needing to include records without values as well
            if (includeEmptyValues)
            {
                var nullPredicate = ExpressionGetNullOrEmptyValues<T>(columnName);
                expressionToReturn = nullPredicate.Or(initialExpression);
            }
            else
            {
                expressionToReturn = initialExpression;
            }
        }

        return expressionToReturn;
    }

    public static Expression<Func<T, bool>> ExpressionStartsWith<T>(string columnName, string valueToSearch)
    {
        return q => $"{q.GetType().GetProperty(columnName).GetValue(q, null)}".StartsWith(valueToSearch, StringComparison.OrdinalIgnoreCase);
    }

    public static Expression<Func<T, bool>> ExpressionColumnIsNotNull<T>(string columnName)
    {
        return q =>
        (
            q.GetType().GetProperty(columnName).GetValue(q, null) != null
            &&
            !string.IsNullOrEmpty(q.GetType().GetProperty(columnName).GetValue(q, null).ToString())
        );
    }


    //
    // BELOW HERE ARE GENERIC METHODS TO STANDARDIZE FILTERING DATA
    //



    public static IQueryable<T> CompareBoolean<T>(IQueryable<T> query, string columnName, bool valToCheckFor, bool includeEmptyValues = defaultForIncludingNullOrEmptyValues)
    {
        if (includeEmptyValues)
        {
            query = query.Where(q =>
                string.IsNullOrEmpty(q.GetType().GetProperty(columnName).GetValue(q, null).ToString())
                ||
                (
                    !string.IsNullOrEmpty(q.GetType().GetProperty(columnName).GetValue(q, null).ToString())
                    &&
                    Convert.ToBoolean(q.GetType().GetProperty(columnName).GetValue(q, null)) == valToCheckFor)
                );
        }
        else
        {
            query = query.Where(q =>
                !string.IsNullOrEmpty(q.GetType().GetProperty(columnName).GetValue(q, null).ToString())
                &&
                Convert.ToBoolean(q.GetType().GetProperty(columnName).GetValue(q, null)) == valToCheckFor
            );
        }

        return query;
    }


    public static IQueryable<T> CompareTypeIntValue<T>(IQueryable<T> query, string columnName, string compareType, int? val)
    {
        if (HasAValue(val) && HasAValue(compareType) && !CheckForStringMatch(compareType) && null != query)
        {
            var expression = ExpressionCompareType<T, int?>(columnName, compareType.ToComparisonType(), val);
            query = query.Where(expression);
        }

        return query;
    }


    public static IQueryable<T> CompareTypeValue<T, Z>(IQueryable<T> query, string columnName, string compareType, Z val, bool includeEmptyValues = defaultForIncludingNullOrEmptyValues)
    {
        if (HasAValue(val) && HasAValue(compareType) && !CheckForStringMatch(compareType) && null != query)
        {
            var expression = ExpressionCompareType<T, Z>(columnName, compareType.ToComparisonType(), val, includeEmptyValues);
            query = query.Where(expression);
        }

        return query;
    }


    public static IQueryable<T> CompareTypeDateTimeValue<T>(IQueryable<T> query, string columnName, string compareType, DateTime? val, bool includeEmptyValues = defaultForIncludingNullOrEmptyValues)
    {
        if (!string.IsNullOrEmpty(columnName) && !string.IsNullOrEmpty(compareType) && val.HasValue && null != query)
        {
            var valToCompare = val.Value;
            var predicate = PredicateBuilder.Get<T>();

            if (includeEmptyValues)
            {
                predicate = predicate.Or(q => string.IsNullOrEmpty($"{q.GetType().GetProperty(columnName).GetValue(q, null)}"));
            }

            switch (compareType.ToLower())
            {
                case "gteq":
                    predicate = predicate.Or(q => Convert.ToDateTime(q.GetType().GetProperty(columnName).GetValue(q, null)) >= valToCompare);
                    break;
                case "gt":
                    predicate = predicate.Or(q => Convert.ToDateTime(q.GetType().GetProperty(columnName).GetValue(q, null)) > valToCompare);
                    break;
                case "lt":
                    predicate = predicate.Or(q => Convert.ToDateTime(q.GetType().GetProperty(columnName).GetValue(q, null)) < valToCompare);
                    break;
                case "lteq":
                    predicate = predicate.Or(q => Convert.ToDateTime(q.GetType().GetProperty(columnName).GetValue(q, null)) <= valToCompare);
                    break;
                case "eq":
                default:
                    predicate = predicate.Or(q => Convert.ToDateTime(q.GetType().GetProperty(columnName).GetValue(q, null)) == valToCompare);
                    break;
            }

            query = query.Where(predicate);
        }

        return query;
    }


    public static IQueryable<T> CompareQueryContainsList<T, Z>(IQueryable<T> query, string columnName, List<Z> itemList, bool includeNullResults = defaultForIncludingNullOrEmptyValues)
    {
        if (null != query && !string.IsNullOrEmpty(columnName) && itemList.Any())
        {
            List<string> valueList = itemList.Where(i => !string.IsNullOrEmpty(i.ToString())).Select(i => i.ToString()).ToList();
            if (valueList.Count > 0)
            {
                var expression = ExpressionContainsValueInList<T, string>(columnName, valueList, includeNullResults);
                query = query.Where(expression);
            }
        }

        return query;
    }


    public static IQueryable<T> CompareQueryDoesntContainListItems<T, Z>(IQueryable<T> query, string columnName, List<Z> itemList, bool includeNullResults = defaultForIncludingNullOrEmptyValues)
    {
        if (null != query && !string.IsNullOrEmpty(columnName) && itemList.Any())
        {
            List<string> valueList = itemList.Where(i => !string.IsNullOrEmpty(i.ToString())).Select(i => i.ToString()).ToList();
            if (valueList.Count > 0)
            {
                var expression = ExpressionDoesntContainValuesInList<T, string>(columnName, valueList, includeNullResults);
                query = query.Where(expression);
            }
        }

        return query;
    }


    public static IQueryable<T> CompareGettingNullValues<T>(IQueryable<T> query, string columnName)
    {
        if (HasAValue(columnName))
        {
            var expression = ExpressionGetNullOrEmptyValues<T>(columnName);
            query = query.Where(expression);
        }

        return query;
    }


    public static IQueryable<T> CompareGetOnlyNotNullValues<T>(IQueryable<T> query, string columnName)
    {
        if (HasAValue(columnName))
        {
            var expression = ExpressionColumnIsNotNull<T>(columnName);
            query = query.Where(expression);
        }

        return query;
    }


    public static IQueryable<T> CompareString<T>(IQueryable<T> query, string columnName, string compareString, bool includeEmptyValues = defaultForIncludingNullOrEmptyValues)
    {
        //
        // TODO: this is only stretched out because I have not gotten back to refactoring it.
        //


        if (null != query && !string.IsNullOrEmpty(columnName) && !string.IsNullOrEmpty(compareString))
        {
            if (includeEmptyValues)
            {
                query = query.Where(q =>
                    q.GetType().GetProperty(columnName).GetValue(q, null) == null
                    ||
                    string.IsNullOrEmpty(q.GetType().GetProperty(columnName).GetValue(q, null).ToString())
                    ||
                    (
                        !string.IsNullOrEmpty(q.GetType().GetProperty(columnName).GetValue(q, null).ToString())
                        &&
                        q.GetType().GetProperty(columnName).GetValue(q, null).ToString().Equals(compareString, StringComparison.OrdinalIgnoreCase)
                    )
                );
            }
            else
            {
                query = query.Where(q =>
                    !string.IsNullOrEmpty(q.GetType().GetProperty(columnName).GetValue(q, null).ToString())
                    &&
                    q.GetType().GetProperty(columnName).GetValue(q, null).ToString().Equals(compareString, StringComparison.OrdinalIgnoreCase)
                );
            }

        }

        return query;
    }


    //
    //
    // PRIVATE
    //
    //


    private static decimal GetAverage<T>(List<T> values, int decimalSpaces)
    {
        decimal val = 0.00m;
        string avg = string.Empty;


        if (values.Any())
        {
            if (values.First() is int)
            {
                avg = values.Cast<int>().Where(x => x != 0).DefaultIfEmpty(0).Average().ToString();
            }

            if (values.First() is decimal)
            {
                avg = values.Cast<decimal>().Where(x => x != 0).DefaultIfEmpty(0).Average().ToString();
            }

            if (string.IsNullOrEmpty(avg) || !decimal.TryParse(avg, out val))
            {
                return val;
            }


            val = decimal.Round(val, decimalSpaces);

            return val == 0 ? 0.0m : val;
        }
        else
        {
            return 0.00m;
        }
    }


}
