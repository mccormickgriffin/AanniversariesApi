public class AaMember
{
    public long Id { get; set; }
    public string Name { get; set; }
    public DateTime SobrietyDate { get; set; }

    public string? Secret { get; set; }

    public AaMember(long id, string name, DateTime sobrietyDate)
    {
        Id = id;
        Name = name;
        SobrietyDate = sobrietyDate;
    }
}