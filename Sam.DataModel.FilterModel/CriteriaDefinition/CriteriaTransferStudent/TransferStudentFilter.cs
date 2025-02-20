namespace Sam.DataModel.FilterModel.CriteriaDefinition.CriteriaTransferStudent;

public class TransferStudentFilter
{
    public bool? WasEver4Yr { get; set; } = null;
    public bool? HasMultipleColleges { get; set; } = null;

    [Range(1, maximum: 4, ErrorMessage = "Enter number betweeen 1 and 4")]
    public int? NumberOfColleges { get; set; } = null;

    public List<string> InternationalColleges { get; set; } = new List<string>();

    public string NumberOfCollegesCompareType { get; set; } = "gteq";

    public bool? IsCurrentlyAtInternationalCollege { get; set; } = null;

    public bool? HasAttendedInternationalHighSchool { get; set; } = null;



    public TransferStudentFilter() { }
}
