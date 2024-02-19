namespace BlazorSortableList.DemoApp.Client.Models;

/// <summary>
/// Class ForceFallbackListGroup.
/// Implements the <see cref="BlazorSortableList.TwoSortableListGroup{BlazorSortableList.DemoApp.Client.Item}" />
/// Use of default implementation
/// </summary>
/// <seealso cref="BlazorSortableList.TwoSortableListGroup{BlazorSortableList.DemoApp.Client.Item}" />
internal class ForceFallbackListGroup : TwoSortableListGroup<Item>
{
    public ForceFallbackListGroup(string id1, string id2, Action refreshComponent)
        : base(id1, id2, refreshComponent)
    {
    }
}
