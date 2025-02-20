namespace Sam.DataModel.FilterModel.CriteriaDefinition.CriteriaStatus;

public class StatusFilter
{
    public List<int> Protections { get; set; } = new List<int>();

    public List<string> EvaluationStatuses { get; set; } = new List<string>();

    public List<string> ApplicationStatuses { get; set; } = new List<string>();

    public List<string> ApplicationDecisionReasons { get; set; } = new List<string>();

    public List<string> LatestEvaluations { get; set; } = new List<string>();

    public List<string> FrozenStatus { get; set; } = new List<string>();

    public StatusFilter() { }

}
