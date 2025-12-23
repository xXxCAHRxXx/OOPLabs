using System.ComponentModel.DataAnnotations;

namespace Lab5.Presentation.Http.Models;

public sealed class DepositRequest
{
    public Guid SessionId { get; set; }

    [Range(minimum: 1d, maximum: double.MaxValue)]
    public decimal Amount { get; set; }
}