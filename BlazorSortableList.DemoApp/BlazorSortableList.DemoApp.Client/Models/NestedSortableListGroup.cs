namespace BlazorSortableList.DemoApp.Client.Models;

internal class NestedSortableListGroup : MultiSortableListGroup<NestedItem>
{
    public NestedSortableListGroup(Action refreshComponent)
        : base(refreshComponent)
    {
    }
}
