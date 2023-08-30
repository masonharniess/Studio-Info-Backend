namespace StudioInfoAPI.Entities {
  public class StudioEntity {
    public long Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateOnly? CreatedDate { get; set; }
  }
}
