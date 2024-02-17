namespace BlazorSortableList.DemoApp.Client.Models;

internal class ClonedSortableListGroup : TwoSortableListGroup, ISortableListHandler
{
    public ClonedSortableListGroup(string id1, string id2, Action refreshComponent)
        : base(id1, id2, refreshComponent)
    {
    }

    protected override void ListOneRemove(int oldIndex, int newIndex, IList<Item> items1, IList<Item> items2)
    {
        // get the item at the old index in list 1
        var item = items1[oldIndex];

        var clone = item;

        // add it to the new index in list 2
        items2.Insert(newIndex, clone);
    }

    protected override void ListTwoRemove(int oldIndex, int newIndex, IList<Item> items2, IList<Item> items1)
    {
        // get the item at the old index in list 2
        var item = items2[oldIndex];

        // make a copy
        var clone = item;

        // add it to the new index in list 1
        items1.Insert(newIndex, clone);
    }
}