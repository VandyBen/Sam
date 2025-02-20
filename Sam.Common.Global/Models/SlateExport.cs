namespace Sam.Common.Global.Models;

public class SlateExport
{
    public Guid ApplicationId { get; set; }

    public Guid PersonId { get; set; }

    public string EvaluationStatus { get; set; } = string.Empty;
}