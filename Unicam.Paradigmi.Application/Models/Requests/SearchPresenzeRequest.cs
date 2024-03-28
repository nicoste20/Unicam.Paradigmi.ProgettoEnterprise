namespace Unicam.Paradigmi.Application.Models.Requests;

public class SearchPresenzeRequest
{
    public string courseName { get; set; } = string.Empty;
    public string studentSurname { get; set; } = null;
    public string lecturerSurname { get; set; } = null;
    public DateTime? lessonDate { get; set; } = null;
    public int page { get; set; } = 1;
    public int pageSize { get; set; } = 10;
}