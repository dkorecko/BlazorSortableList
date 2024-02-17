namespace BlazorSortableList.DemoApp.Client.Models;

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

    protected abstract void ListOneRemove(int oldIndex, int newIndex, IList<Item> items1, IList<Item> items2);

    protected abstract void ListTwoRemove(int oldIndex, int newIndex, IList<Item> items2, IList<Item> items1);

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
        return false;
    }
}
