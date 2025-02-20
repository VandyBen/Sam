namespace Sam.Logic.Common.Stats.Enums;

public enum StatisticCategories
{
    None,
    Gender,
    School,
    PellLikely
}

public static partial class Extensions
{
    public static string ToDisplayString(this StatisticCategories category)
    {
        switch (category)
        {
            case StatisticCategories.Gender:
                return "Gender";

            case StatisticCategories.School:
                return "School";

            case StatisticCategories.PellLikely:
                return "Pell-Likely";

            case StatisticCategories.None:
            default: 
                return string.Empty;
        }
    }

    public static int ToSortOrder(this StatisticCategories category)
    {
        return category switch
        {
            StatisticCategories.School => 10,
            StatisticCategories.Gender => 20,
            StatisticCategories.PellLikely => 30,
            StatisticCategories.None => 100,
            _ => 1000
        };
    }
}