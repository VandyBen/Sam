namespace Sam.DataModel.FilterModel.CriteriaDefinition.CriteriaTestScore;

public class TestScoreFilter
{
    public bool IsSatRequired { get; set; } = false;

    public string SatCompareType { get; set; } = "gteq";

    [Range(400, 1600)]
    public int? SatCompareValue { get; set; } = null;

    [Range(400, 1600)]
    public int? SatRangeStartValue { get; set; } = null;

    [Range(400, 1600)]
    public int? SatRangeEndValue { get; set; } = null;

    public bool IsAndCompareForSatAndAct { get; set; } = false;

    public bool IsActRequired { get; set; } = false;

    public string ActCompareType { get; set; } = "gteq";

    [Range(0, 36)]
    public int? ActCompareValue { get; set; } = null;

    [Range(0, 36)]
    public int? ActRangeStartValue { get; set; } = null;

    [Range(0, 36)]
    public int? ActRangeEndValue { get; set; } = null;

    public bool? IsTestingSubmitted { get; set; } = null;



    public TestScoreFilter() { }
}
