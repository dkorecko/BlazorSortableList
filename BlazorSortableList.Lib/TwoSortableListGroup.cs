namespace BlazorSortableList;


/// <summary>
/// Class TwoSortableListGroup.
/// Implements the <see cref="BlazorSortableList.SortableListGroup{T}" />
/// Default implementation sorts list1 and list2, and moves items from list1 to list2 and vice versa.
/// </summary>
/// <typeparam name="T"></typeparam>
/// <seealso cref="BlazorSortableList.SortableListGroup{T}" />
public class TwoSortableListGroup<T> : SortableListGroup<T>, ISortableListHandler
{
    private readonly Action _refreshComponent;
    public string Id1 { get; }

    public string Id2 { get; }

    protected TwoSortableListGroup(string id1, string id2, Action refreshComponent)
    {
        _refreshComponent = refreshComponent;
        Id1 = id1;
        Id2 = id2;
    }

    public virtual bool HandleRemove(string id, string group, int oldIndex, int newIndex)
    {
        var items1 = GetModel(Id1)?.Items;
        var items2 = GetModel(Id2)?.Items;
        if (items1 != null && items2 != null)
        {
            if (id == Id1)
            {
                ListOneRemove(oldIndex, newIndex, items1, items2);
            }
            else if (id == Id2)
            {
                ListTwoRemove(oldIndex, newIndex, items2, items1);
            }

            _refreshComponent();
        }

        return false;
    }

    public virtual bool HandleUpdate(string id, string group, int oldIndex, int newIndex)
    {
        if (id == Id1)
        {
            var items1 = GetModel(Id1)?.Items;
            if (items1 != null)
            {
                ListOneUpdate(oldIndex, newIndex, items1);
            }
        }
        else if (id == Id2)
        {
            var items2 = GetModel(Id2)?.Items;
            if (items2 != null)
            {
                ListTwoUpdate(oldIndex, newIndex, items2);
            }
        }

        _refreshComponent();

        return false;
    }

    protected virtual void ListOneRemove(int oldIndex, int newIndex, IList<T> items1, IList<T> items2)
    {
        // get the item at the old index in list 1
        var item = items1[oldIndex];

        // add it to the new index in list 2
        items2.Insert(newIndex, item);

        // remove the item from the old index in list 1
        items1.Remove(items1[oldIndex]);
    }

    protected virtual void ListOneUpdate(int oldIndex, int newIndex, IList<T> items1)
    {
        SortList(oldIndex, newIndex, items1);
    }

    protected virtual void ListTwoRemove(int oldIndex, int newIndex, IList<T> items2, IList<T> items1)
    {
        // get the item at the old index in list 2
        var item = items2[oldIndex];

        // add it to the new index in list 1
        items1.Insert(newIndex, item);

        // remove the item from the old index in list 2
        items2.Remove(items2[oldIndex]);
    }

    protected virtual void ListTwoUpdate(int oldIndex, int newIndex, IList<T> items2)
    {
        SortList(oldIndex, newIndex, items2);
    }

    private static void SortList(int oldIndex, int newIndex, IList<T> items)
    {
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
