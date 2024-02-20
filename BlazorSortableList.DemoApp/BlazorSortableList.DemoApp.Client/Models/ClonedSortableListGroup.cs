namespace BlazorSortableList.DemoApp.Client.Models;

internal class ClonedSortableListGroup : MultiSortableListGroup<Item>
{
    public ClonedSortableListGroup(Action refreshComponent)
        : base(refreshComponent)
    {
    }

    protected override void ListMoveItem(int oldIndex, int newIndex, IList<Item> items1, IList<Item> items2)
    {
        // get the item at the old index in list 1
        var item = items1[oldIndex];

        var clone = item.Clone();

        // add it to the new index in list 2
        items2.Insert(newIndex, clone);
    }
   
}