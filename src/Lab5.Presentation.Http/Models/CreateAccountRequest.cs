using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Lab5.Presentation.Http.Models;

public sealed class CreateAccountRequest
{
    public Guid SessionId { get; set; }

    [Required]
    [NotNull]
    public string? Name { get; set; }

    [Range(minimum: 1000, maximum: 9999)]
    public int PinCode { get; set; }

    [Range(minimum: 0d, maximum: double.MaxValue)]
    public decimal Balance { get; set; }
}