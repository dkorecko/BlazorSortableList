namespace BlazorSortableList;

public class SortableListModel<T>: ISortableListModel<T>
{
    protected List<T> _items;

    public SortableListModel(List<T> items)
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
