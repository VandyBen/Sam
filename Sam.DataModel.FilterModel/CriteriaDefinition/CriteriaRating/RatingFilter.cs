namespace Sam.DataModel.FilterModel.CriteriaDefinition.CriteriaRating;

public class RatingFilter
{
    public string ArCompareType { get; set; } = "gteq";

    public string PrCompareType { get; set; } = "gteq";

    public string SfrCompareType { get; set; } = "gteq";

    public string OvrCompareType { get; set; } = "gteq";

    [RegularExpression(@"\d?([\-\+])?", ErrorMessage = "Only allowed are numbers and plus or minus allowed")]
    public string ArCompareValueStr { get; set; } = "";

    [RegularExpression(@"\d?([\-\+])?", ErrorMessage = "Only allowed are numbers and plus or minus allowed")]
    public string PrCompareValueStr { get; set; } = "";

    [RegularExpression(@"\d?([\-\+])?", ErrorMessage = "Only allowed are numbers and plus or minus allowed")]
    public string SfrCompareValueStr { get; set; } = "";

    [RegularExpression(@"\d?([\-\+])?", ErrorMessage = "Only allowed are numbers and plus or minus allowed")]
    public string OvrCompareValueStr { get; set; } = "";

    public string CsCompareType { get; set; } = "gteq";
    public string LcCompareType { get; set; } = "gteq";
    public string UbCompareType { get; set; } = "gteq";

    [Range(minimum: 1, maximum: 5, ErrorMessage = "Only numbers between 1 and 5 are allowed")]
    public string CsCompareValueStr { get; set; } = "";

    [Range(minimum: 1, maximum: 5, ErrorMessage = "Only numbers between 1 and 5 are allowed")]
    public string LcCompareValueStr { get; set; } = "";

    [Range(minimum: 1, maximum: 5, ErrorMessage = "Only numbers between 1 and 5 are allowed")]
    public string UbCompareValueStr { get; set; } = "";

    public string DgCompareType { get; set; } = "gteq";

    [Range(minimum: 1, maximum: 4, ErrorMessage = "Only numbers between 1 and 4 are acceptable.")]
    public string DgCompareValueStr { get; set; } = "";


    public RatingFilter() { }
}
