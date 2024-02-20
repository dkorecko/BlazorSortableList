namespace BlazorSortableList.DemoApp.Client.Models;

internal class ThreeSortableListGroup : MultiSortableListGroup<Item>
{
    public ThreeSortableListGroup(Action refreshComponent)
        : base(refreshComponent)
    {
    }
}
