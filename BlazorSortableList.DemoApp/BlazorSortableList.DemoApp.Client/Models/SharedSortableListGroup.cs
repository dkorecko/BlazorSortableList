namespace BlazorSortableList.DemoApp.Client.Models;

/// <summary>
/// Class SharedSortableListGroup.
/// Implements the <see cref="BlazorSortableList.TwoSortableListGroup{BlazorSortableList.DemoApp.Client.Item}" />
/// Use of default implementation
/// </summary>
/// <seealso cref="BlazorSortableList.TwoSortableListGroup{BlazorSortableList.DemoApp.Client.Item}" />
internal class SharedSortableListGroup : TwoSortableListGroup<Item>
{
    public SharedSortableListGroup(string id1, string id2, Action refreshComponent)
        : base(id1, id2, refreshComponent)
    {
    }
}