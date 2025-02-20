namespace Sam.DataModel.FilterModel.CriteriaDefinition.CriteriaUniversity;

public class UniversityFilter
{
    public List<string> StudentTypes { get; set; } = new List<string>();

    public List<string> Schools { get; set; } = new List<string>();

    public List<string> Majors { get; set; } = new List<string>();

    public List<string> GpcMajors { get; set; } = new List<string>();

    public List<string> AdmitTypes { get; set; } = new List<string>();

    public bool IsLegacyCompareTypeIs { get; set; } = true;

    public List<string> LegacyTypes { get; set; } = new List<string>();

    public bool IsVanderbiltEmploymentTypeIs { get; set; } = true;

    public List<string> VanderbiltEmploymentTypes { get; set; } = new List<string>();

    public List<string> OriginalRoundStudentTypes { get; set; } = new List<string>();



    public UniversityFilter() { }
}
