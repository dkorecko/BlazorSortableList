namespace BlazorSortableList.DemoApp.Client.Models;

internal class DisableSortingListGroup : MultiSortableListGroup<Item>
{
    public DisableSortingListGroup(Action refreshComponent)
        : base(refreshComponent)
    {
    }

    protected override void ListMoveItem(int oldIndex, int newIndex, IList<Item> items1, IList<Item> items2)
    {
        var item = items1[oldIndex];

        var clone = item.Clone();

        items2.Insert(newIndex, clone);
    }

    //protected override void ListTwoUpdate(int oldIndex, int newIndex, IList<Item> items2)
    //{
    //    var items = items2;
    //    var itemToMove = items[oldIndex];
    //    items.RemoveAt(oldIndex);

    //    if (newIndex < items2.Count)
    //    {
    //        items.Insert(newIndex, itemToMove);
    //    }
    //    else
    //    {
    //        items.Add(itemToMove);
    //    }
    //}
}
