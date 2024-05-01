namespace BlazorSortableList;

public class SortableListModel<T>: ISortableListModel<T>
{
    protected IList<T> _items;

    public SortableListModel(IList<T> items)
    {
        _items = items;
    }

    public string Group { get; set; } = Guid.NewGuid().ToString();

    public SortableListSettings Settings { get; set; } = new SortableListSettings();

    public IList<T> Items
    {
        get
        {
            return _items;
        }
    }
    
}
