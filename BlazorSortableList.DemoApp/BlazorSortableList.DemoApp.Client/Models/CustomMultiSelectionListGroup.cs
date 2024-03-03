namespace BlazorSortableList.DemoApp.Client.Models;

internal class CustomMultiSelectionListGroup : MultiSelectionListGroup<Item>
{
    public CustomMultiSelectionListGroup(Action refreshComponent)
        : base(refreshComponent)
    {
    }
}
