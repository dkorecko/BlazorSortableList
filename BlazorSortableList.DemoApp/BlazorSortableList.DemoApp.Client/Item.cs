using BlazorSortableList.DemoApp.Client.Models;

namespace BlazorSortableList.DemoApp.Client;


public class Item : ISelectableItem
{
    public int Id { get; set; }

    public string Name { get; set; } = "";

    public bool Disabled { get; set; } = false;

    public bool Selected { get; set; } = false;

    public Item Clone()
    {
        // simple ShallowCopy
        // more advanced option https://github.com/Burtsev-Alexey/net-object-deep-copy/blob/master/ObjectExtensions.cs

        return (Item)MemberwiseClone();
    }

    /// <summary>Returns a string that represents the current object.</summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString()
    {
        return $"{Id}.{Name}";
    }
}