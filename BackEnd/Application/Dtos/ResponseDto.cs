namespace Service.Catalog.API;
public class ResponseDto
{
    public bool IsSuccess { get; set; } = true;
    public object Result { get; set; }
    public string DisplayMessage { get; set; }
    public List<string> ErrorMessage { get; set; }
}
