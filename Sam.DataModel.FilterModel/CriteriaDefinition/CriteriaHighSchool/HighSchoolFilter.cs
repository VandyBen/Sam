namespace Sam.DataModel.FilterModel.CriteriaDefinition.CriteriaHighSchool;

public class HighSchoolFilter
{
    public string EtsCode { get; set; } = string.Empty;

    public List<string> HsRatings { get; set; } = new List<string>();

    public List<string> HsStates { get; set; } = new List<string>();

    public List<string> HsNames { get; set; } = new List<string>();

    public bool? IsFocusSchool { get; set; } = null;

    public string RicComareType { get; set; } = "lteq";

    public string EricCompareType { get; set; } = "lteq";

    [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Only number up to 2 digits after decimal point")]
    public decimal? RicValue { get; set; } = new decimal(10.44);


    [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Only number up to 2 digits after decimal point")]
    public decimal? EricValue { get; set; } = null;

    public bool ShouldExcludeNullRicValues { get; set; } = false;

    public bool ShouldExcludeNullEricValues { get; set; } = false;

    public string HsGpaCompareType { get; set; } = "gteq";


    [RegularExpression(@"\d+(\.\d{1,5})?", ErrorMessage = "Only number up to 5 digits after decimal point")]
    public decimal? HsGpaValue { get; set; } = null;

    public bool ShouldIncludeNullGpa { get; set; } = true;

    public List<string> CourseworkRigors { get; set; } = new List<string>();

    public bool? IsAttendingKippSchool { get; set; } = null;

    public bool? IsAttendingRuralHighSchool { get; set; } = null;

    public bool? IsCGradeHighSchool { get; set; } = null;

    public bool? IsCGradeCollege { get; set; } = null;

    public bool? WasTitleOneHighSchool { get; set; } = null;

    public bool? WasUwcHighSchool { get; set; } = null;


    public HighSchoolFilter() { }
}
