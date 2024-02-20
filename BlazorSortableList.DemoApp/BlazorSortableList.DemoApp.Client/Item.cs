namespace BlazorSortableList.DemoApp.Client;


public class Item
{
    public int Id { get; set; }
    public string Name { get; set; } = "";

    public bool Disabled { get; set; } = false;

    public Item Clone()
    {
        // simple ShallowCopy
        // more advanced option https://github.com/Burtsev-Alexey/net-object-deep-copy/blob/master/ObjectExtensions.cs

        return (Item)MemberwiseClone();
    }
}