using System.Text.Json;

namespace Booking.API.ViewModels;

public class ErrorViewModel
{
    public int StatusCode { get; set; }
    public string? Message { get; set; }
    public string? Path { get; set; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}