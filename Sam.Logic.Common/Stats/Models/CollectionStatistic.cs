namespace Sam.Logic.Common.Stats.Models;

public class CollectionStatistic
{
    private IQueryable<ApplicationDto> _applications = null!;

    public List<CategoryStatistic> Categories { get; private set; } = [];

    public CollectionStatistic() { }

    public void SetApplications(IQueryable<ApplicationDto> vwApplicationViews)
    {
        this._applications = vwApplicationViews;
    }

    public CollectionStatistic(List<CategoryStatistic> categories)
    {
        this.Categories = categories;
    }

    public void AddCategory(CategoryStatistic category)
    {
        this.Categories.Add(category);
    }

    public List<CategoryStatistic> GetCategoriesSorted()
    {
        if (this.IsReady())
        {
            return this.Categories.OrderBy(givenStat => givenStat.SortOrder).ToList();
        }
        return this.Categories;
    }

    public async Task<int> TotalCountAsync()
    {
        var count = 0;
        if (Categories.Count == 0) return count;
        foreach (var category in this.Categories)
        {
            count += await category.TotalCountAsync();
        }
        return count;
    }

    public async Task<string> TotalCountStringAsync() => ($"{await this.TotalCountAsync():n0}");


    public bool IsReady()
    {
        var isReady = this.Categories.Count > 0;

        if (!isReady) return isReady;
        foreach (var category in this.Categories)
        {
            if (category.IsReady()) continue;
            isReady = false;
            break;
        }

        return isReady;
    }
}