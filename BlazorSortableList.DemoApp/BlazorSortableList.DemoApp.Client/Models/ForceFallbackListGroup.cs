namespace BlazorSortableList.DemoApp.Client.Models;

/// <summary>
/// Class ForceFallbackListGroup.
/// Implements the <see cref="MultiSortableListGroup{T}.DemoApp.Client.Item}" />
/// Use of default implementation
/// </summary>
/// <seealso cref="MultiSortableListGroup{T}.DemoApp.Client.Item}" />
internal class ForceFallbackListGroup : MultiSortableListGroup<Item>
{
    public ForceFallbackListGroup(Action refreshComponent)
        : base(refreshComponent)
    {
    }
}
