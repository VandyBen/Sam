namespace Sam.Logic.Common.Stats.Models;

public class CategoryStatistic
{
    public StatisticCategories Category { get; set; } = StatisticCategories.None;
    public string CategoryName { get; set; } = "";
    public int SortOrder { get; } = 0;

    private IQueryable<ApplicationDto> _applications;
    public List<SingleStatistic> Stats { get; private set; } = [];
    public string CategoryHtmlPanelId => $"{(this.Category.ToDisplayString()).Replace(" ", "_")}_P_{(int)this.Category}";
    public string CategoryHtmlHeadingId => $"{(this.Category.ToDisplayString()).Replace(" ", "_")}_H_{(int)this.Category}";
    public string CategoryHtmlBodyId => $"{(this.Category.ToDisplayString()).Replace(" ", "_")}_B_{(int)this.Category}";

    public List<SingleStatistic> GetStatsSorted()
    {
        return this.IsReady() 
            ? this.Stats.OrderByDescending(givenStat => givenStat.SortOrder).ToList() 
            : this.Stats;
    }

    public void AddStat(SingleStatistic statistic)
    {
        this.Stats.Add(statistic);
    }

    public async Task<int> TotalCountAsync()
    {
        var count = 0;
        if (Stats.Count == 0) return count;
        foreach (var stat in Stats)
        {
            count += await stat.GetCountAsync();
        }
        return count;
    }

    public async Task<string> TotalCountStringAsync() => ($"{await this.TotalCountAsync():n0}");

    public void SetApplications(IQueryable<ApplicationDto> applicationDtos)
    {
        this._applications = applicationDtos;
    }

    public bool IsReady()
    {
        var isReady = Stats.Count != 0 && !string.IsNullOrEmpty(this.CategoryName);
        if (!isReady) return isReady;
        if (this.Stats.Any(stat => !stat.IsReady()))
        {
            isReady = false;
        }

        return isReady;
    }

    public CategoryStatistic(IQueryable<ApplicationDto> applications)
    {
        _applications = applications;
    }

    public CategoryStatistic(StatisticCategories category, IQueryable<ApplicationDto> applications)
    {
        this.Category = category;
        this.CategoryName = this.Category.ToDisplayString();
        this.SortOrder = this.Category.ToSortOrder();
        this.Stats = [];
        this._applications = applications;
    }

    public CategoryStatistic(string categoryDisplayName, int? sortOrder, IQueryable<ApplicationDto> applications)
    {
        this.CategoryName = $"{categoryDisplayName}".Trim();
        this.SortOrder = sortOrder ?? this.Category.ToSortOrder();
        this._applications = applications;
    }

    public CategoryStatistic(StatisticCategories category, string categoryDisplayName, int? sortOrder, List<SingleStatistic> stats, IQueryable<ApplicationDto> applications)
    {
        this.Category = category;
        this.CategoryName = !string.IsNullOrEmpty(categoryDisplayName) ? categoryDisplayName.Trim() : this.Category.ToString();
        this.SortOrder = sortOrder ?? this.Category.ToSortOrder();
        this.Stats = stats;
        _applications = applications;
    }
}