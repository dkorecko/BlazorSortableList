namespace BlazorSortableList;

public interface ISortableListModel<T>
{
    string Group { get; }

    //string Id { get; }

    public SortableListSettings Settings { get; }

    IList<T> Items { get; }

}