using System.ComponentModel.DataAnnotations;

namespace Lab5.Presentation.Http.Models;

public sealed class AddUserSessionRequest
{
    public long AccountId { get; set; }

    [Range(minimum: 1000, maximum: 9999)]
    public int PinCode { get; set; }
}