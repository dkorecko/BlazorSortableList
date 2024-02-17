using Microsoft.AspNetCore.Components;

namespace BlazorSortableList.DemoApp.Client.Models;

internal class SharedSortableListGroup : SortableListGroup<Item>, ISortableListHandler
{
    private readonly Action _refreshComponent;

    public string Id1 { get; }

    public string Id2 { get; }

    public SharedSortableListGroup(string id1, string id2, Action refreshComponent)
    {
        _refreshComponent = refreshComponent;
        Id1 = id1;
        Id2 = id2;
    }

    public bool HandleRemove(string id, string group, int oldIndex, int newIndex)
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

    private static void ListTwoRemove(int oldIndex, int newIndex, IList<Item> items2, IList<Item> items1)
    {
        // get the item at the old index in list 2
        var item = items2[oldIndex];

        // add it to the new index in list 1
        items1.Insert(newIndex, item);

        // remove the item from the old index in list 2
        items2.Remove(items2[oldIndex]);
    }

    private static void ListOneRemove(int oldIndex, int newIndex, IList<Item> items1, IList<Item> items2)
    {
        // get the item at the old index in list 1
        var item = items1[oldIndex];

        // add it to the new index in list 2
        items2.Insert(newIndex, item);

        // remove the item from the old index in list 1
        items1.Remove(items1[oldIndex]);
    }

    public bool HandleUpdate(string id, string group, int oldIndex, int newIndex)
    {
        return false;
    }

   
}
