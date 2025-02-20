namespace Sam.Logic.Common.Stats.Models;

public class SingleStatistic
{
    public string StatName { get; set; } = "";
    public int SortOrder { get; set; } = 1000;
    
    public IQueryable<ApplicationDto> Applications { get; private set; }


    public void SetApplicationQuery(IQueryable<ApplicationDto> applicationQuery)
    {
        this.Applications = applicationQuery;
    }

    public async Task<int> GetCountAsync() 
    {
        var count = 0;
        count = await this.Applications.CountAsync();
        return count;
    }

    public async Task<string> GetCountStringAsync() => ($"{await this.GetCountAsync():n0}");

    public bool IsReady()
    {
        return !string.IsNullOrEmpty(this.StatName);
    }

    public string GetName() => $"{this.StatName}".Trim();


    //
    // CONSTRUCTORS
    //


    public SingleStatistic(IQueryable<ApplicationDto> applications)
    {
        Applications = applications;
    }

    public SingleStatistic(string displayNameOfStat, int? statSortOrder, IQueryable<ApplicationDto> applications)
    {
        Applications = applications;
        this.StatName = $"{displayNameOfStat}".Trim();
        this.SortOrder = statSortOrder ?? this.SortOrder;
    }

    
}