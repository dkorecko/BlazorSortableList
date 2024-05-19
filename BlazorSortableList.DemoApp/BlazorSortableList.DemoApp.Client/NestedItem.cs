namespace BlazorSortableList.DemoApp.Client;

public class NestedItem
{
    public IList<NestedItem>? Children { get; set; }

    public int Id { get; set; }

    public string Name { get; set; } = "";

    public NestedItem Clone()
    {
        // simple ShallowCopy
        // more advanced option https://github.com/Burtsev-Alexey/net-object-deep-copy/blob/master/ObjectExtensions.cs

        return (NestedItem)MemberwiseClone();
    }
}
