namespace BlazorSortableList;

public class SingleSortableListGroup<T> : SortableListGroup<T>, ISortableListHandler
{
    private readonly IList<T> _items;

    public ISortableListModel<T> Model { get; }

    public SingleSortableListGroup(string id, ISortableListModel<T> model)

    {
        AddModel(id, model);

        Model = model;
        _items = model.Items;
    }

    public virtual bool HandleRemove(string id, string group, int oldIndex, int newIndex)
    {
        return false;
    }

    public virtual bool HandleUpdate(string id, string group, int oldIndex, int newIndex)
    {
        SortList(oldIndex, newIndex);
        return true;
    }

    private void SortList(int oldIndex, int newIndex)
    {
        var items = _items;
        var itemToMove = items[oldIndex];
        items.RemoveAt(oldIndex);

        if (newIndex < items.Count)
        {
            items.Insert(newIndex, itemToMove);
        }
        else
        {
            items.Add(itemToMove);
        }
    }
}
