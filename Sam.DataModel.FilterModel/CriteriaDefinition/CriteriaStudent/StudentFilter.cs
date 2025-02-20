namespace Sam.DataModel.FilterModel.CriteriaDefinition.CriteriaStudent;

public class StudentFilter
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public bool IsAndCompareForName { get; set; } = true;

    public List<string> Genders { get; set; } = new List<string>();

    public List<string> Ipeds { get; set; } = new List<string>();

    public bool? IsPellEligible { get; set; } = null;

    public bool? HasFinancialAidInterest { get; set; } = null;

    public bool? IsFirstGeneration { get; set; } = null;

    public List<string> Regions { get; set; } = new List<string>();

    public List<string> OuaGeoMarkets { get; set; } = new List<string>();

    public string IsAthlete { get; set; } = null;

    public bool? HasPrimaryCitizenshipCountry { get; set; } = null;

    public List<string> PrimaryCitizenshipCountries { get; set; } = new List<string>();

    public bool? HasSecondaryCitizenshipCountry { get; set; } = null;

    public List<string> SecondaryCitizenshipCountries { get; set; } = new List<string>();

    public List<string> SlateRefIds { get; set; } = new List<string>();

    public string SlateRefId { get; set; } = "";

    public string EmplId { get; set; } = "";

    public List<string> EmplIds { get; set; } = new List<string>();

    public bool? IsDacaUndocumented { get; set; } = null;

    public bool? IsApplicationComplete { get; set; } = true;

    public string NeighborhoodChallengeScoreCompareType { get; set; } = "gteq";


    [Range(1, 100)]
    public int? NeighborhoodChallengeScoreCompareValue { get; set; } = null;

    public bool ShouldIncludeNullNeighborhoodChallengeValues { get; set; } = false;

    public string HighSchoolChallengeScoreCompareType { get; set; } = "gteq";

    [Range(1, 100)]
    public int? HighSchoolChallengeScoreCompareValue { get; set; } = null;

    public bool IsAndCompareForChallengeScores { get; set; } = true;

    public bool ShouldIncludeNullHighSchoolChallengeValues { get; set; } = false;



    public StudentFilter() { }
}
