namespace Sam.DataModel.FilterModel.CriteriaDefinition.CriteriaWaitList;

public class WaitListFilter
{
    public string WaitListActiveDateCompareType { get; set; } = "gteq";

    public DateTime? WaitListActiveDate { get; set; } = null;

    public bool HasWaitListStrong { get; set; } = false;

    public bool HasWaitListChallenge1 { get; set; } = false;

    public bool HasWaitListChallenge2 { get; set; } = false;

    public bool HasWaitListChallenge3 { get; set; } = false;

    public bool HasWaitListChallenge4 { get; set; } = false;

    public bool HasWaitListChallenge5 { get; set; } = false;

    public bool HasWaitListChallenge6 { get; set; } = false;

    public bool HasWaitListChallenge7 { get; set; } = false;

    public bool HasWaitListChallenge8 { get; set; } = false;

    public bool HasWaitListChallenge9 { get; set; } = false;

    public bool HasWaitListPreOffer { get; set; } = false;

    public bool HasWaitListPreOfferResponse { get; set; } = false;

    public string WaitListStrongDateCompareType { get; set; } = "lt";

    public DateTime? WaitListStrongDate { get; set; } = null;



    public WaitListFilter() { }
}
