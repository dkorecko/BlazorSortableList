namespace BlazorSortableList;

public class SortableListGroup<T> : ISortableListGroup<T>
{
    private readonly Dictionary<string, ISortableListModel<T>> _itemMap = new();
    public ISortableListModel<T>? GetModel(string id)
    {
        return _itemMap.GetValueOrDefault(id);
    }

    public void AddModel(string id, ISortableListModel<T> model)
    {
        _itemMap.Add(id, model);
    }
}
