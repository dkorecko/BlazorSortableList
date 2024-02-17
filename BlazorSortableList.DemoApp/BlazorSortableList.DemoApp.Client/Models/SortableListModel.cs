namespace BlazorSortableList.DemoApp.Client.Models;

internal class SortableListModel: ISortableListModel<Item>
{
    protected List<Item> _items;

    public SortableListModel(List<Item> items)
    {
        _items = items;
    }

    public string Group { get; set; } = Guid.NewGuid().ToString();

   // public string Id { get; set; } = Guid.NewGuid().ToString();

    public SortableListSettings Settings { get; set; } = new SortableListSettings();

    public IList<Item> Items
    {
        get
        {
            return _items;
        }
    }
    
}
