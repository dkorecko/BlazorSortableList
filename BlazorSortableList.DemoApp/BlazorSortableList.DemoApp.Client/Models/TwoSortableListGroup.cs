namespace BlazorSortableList.DemoApp.Client.Models;

/// <summary>
/// Class TwoSortableListGroup.
/// Implements the <see cref="BlazorSortableList.SortableListGroup{BlazorSortableList.DemoApp.Client.Item}" />
/// Simple protection from direct use. Need to implement empty virtual function
/// </summary>
/// <seealso cref="BlazorSortableList.SortableListGroup{BlazorSortableList.DemoApp.Client.Item}" />
internal abstract class TwoSortableListGroup : SortableListGroup<Item>
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

    protected virtual void ListOneRemove(int oldIndex, int newIndex, IList<Item> items1, IList<Item> items2)
    {
    }

    protected virtual void ListOneUpdate(int oldIndex, int newIndex, IList<Item> items1)
    {
    }

    protected virtual void ListTwoRemove(int oldIndex, int newIndex, IList<Item> items2, IList<Item> items1)
    {
    }

    protected virtual void ListTwoUpdate(int oldIndex, int newIndex, IList<Item> items2)
    {
    }
}
