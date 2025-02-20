using Sam.DataModel.FilterModel.CriteriaDefinition.CriteriaHighSchool;
using Sam.DataModel.FilterModel.CriteriaDefinition.CriteriaOther;
using Sam.DataModel.FilterModel.CriteriaDefinition.CriteriaRating;
using Sam.DataModel.FilterModel.CriteriaDefinition.CriteriaStatus;
using Sam.DataModel.FilterModel.CriteriaDefinition.CriteriaStudent;
using Sam.DataModel.FilterModel.CriteriaDefinition.CriteriaTestScore;
using Sam.DataModel.FilterModel.CriteriaDefinition.CriteriaTransferStudent;
using Sam.DataModel.FilterModel.CriteriaDefinition.CriteriaUniversity;
using Sam.DataModel.FilterModel.CriteriaDefinition.CriteriaWaitList;

namespace Sam.DataModel.FilterModel.CriteriaDefinition;

public class FilterCriteria
{
    public int ListId { get; set; } = 0;
    
    public string ListName { get; set; } = string.Empty;
    
    public string Cohort { get; set; } = string.Empty;
    
    public string StudentType { get; set; } = string.Empty;

    public HighSchoolFilter HighSchool { get; set; } = new();

    public OtherFilter Other { get; set; } = new();

    public RatingFilter Rating { get; set; } = new();

    public StatusFilter Status { get; set; } = new();

    public StudentFilter Student { get; set; } = new();

    public TestScoreFilter TestScore { get; set; } = new();

    public TransferStudentFilter TransferStudent { get; set; } = new();

    public UniversityFilter University { get; set; } = new();

    public WaitListFilter WaitList { get; set; } = new();


    public FilterCriteria() { }

    public FilterCriteria(int listId)
    {
        this.ListId = listId;
    }

    public FilterCriteria(int listId, string listName, string cohort, string studentType)
    {
        this.ListId = listId;
        this.ListName = listName;
        this.Cohort = cohort;
        this.StudentType = studentType;
    }
}
