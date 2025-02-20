namespace Sam.DataModel.FilterModel.CriteriaDefinition.CriteriaOther;

public class OtherFilter
{
    public List<int> CustomAttributes { get; set; } = new List<int>();
    public bool? IsPosse { get; set; } = null;
    public List<string> QuestBridge { get; set; } = new List<string>();

    public bool? IsQuestBridge { get; set; } = null;

    public bool? IsChicagoScholar { get; set; } = null;

    public bool? IsNationalMeritAwardFinalist { get; set; } = null;

    public bool? IsCorneliusVanderbiltScholarship { get; set; } = null;

    public bool? IsIngramScholarship { get; set; } = null;

    public bool? IsChancellorsScholarship { get; set; } = null;

    public bool? IsMosaic { get; set; } = null;

    public string InstitutionalNeedCompareType { get; set; } = "gt";

    public int? InstitutionalNeedValue { get; set; } = null;

    public bool? InstitutionalNeedIncludeNulls { get; set; } = null;

    public bool ShouldIncludeFinancialNeed { get; set; } = false;

    public List<int> ChancellorDiversityList { get; set; } = new List<int>();

    public List<int> ChancellorBridgingGapsList { get; set; } = new List<int>();

    public List<int> ChancellorLeadershipList { get; set; } = new List<int>();

    public List<int> ChancellorOverallList { get; set; } = new List<int>();


    public OtherFilter() { }
}
