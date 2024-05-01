namespace BlazorSortableList.DemoApp.Client;

public class NestedItem
{
    public int Id { get; set; }

    public string Name { get; set; } = "";

    public IList<NestedItem>? Children { get; set; }
}
