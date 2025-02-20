namespace Sam.Common.Global.Enums;

public enum ComparisonTypes
{
    None = 0,
    Equal,
    LessThan,
    GreaterThan,
    LessThanOrEqualTo,
    GreaterThanOrEqualTo
}

public static class ExtendsComparisonTypes
{
    public static ComparisonTypes ToComparisonType(this string compareTypeString)
    {
        if (string.IsNullOrEmpty(compareTypeString))
            return ComparisonTypes.None;

        compareTypeString = compareTypeString.Trim().ToLower();

        switch(compareTypeString)
        {
            case "lt":
            case "lessthan":
                return ComparisonTypes.LessThan;

            case "gt":
            case "greaterthan":
                return ComparisonTypes.GreaterThan;

            case "lte":
            case "lteq":
            case "lessthanorequal":
            case "lessthanorequalto":
                return ComparisonTypes.LessThanOrEqualTo;

            case "gte":
            case "gteq":
            case "greaterthanorequal":
            case "greaterthanorequalto":
                return ComparisonTypes.GreaterThanOrEqualTo;

            case "eq":
            case "equal":
                return ComparisonTypes.Equal;

            default:
                return ComparisonTypes.None;
        }
    }

    public static string ToComparisonTypeString(this ComparisonTypes compareType)
    {
        switch (compareType)
        {
            case ComparisonTypes.LessThan:
                return "lt";

            case ComparisonTypes.GreaterThan:
                return "gt";

            case ComparisonTypes.LessThanOrEqualTo:
                return "lteq";

            case ComparisonTypes.GreaterThanOrEqualTo:
                return "gteq";

            case ComparisonTypes.Equal:
                return "eq";

            case ComparisonTypes.None:
            default:
                return string.Empty;
        }
    }
}