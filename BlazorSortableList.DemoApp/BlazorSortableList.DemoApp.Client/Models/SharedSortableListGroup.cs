namespace BlazorSortableList.DemoApp.Client.Models;

/// <summary>
/// Class SharedSortableListGroup.
/// Implements the <see cref="MultiSortableListGroup{T}.DemoApp.Client.Item}" />
/// Use of default implementation
/// </summary>
/// <seealso cref="MultiSortableListGroup{T}.DemoApp.Client.Item}" />
internal class SharedSortableListGroup : MultiSortableListGroup<Item>
{
    public SharedSortableListGroup(Action refreshComponent)
        : base(refreshComponent)
    {
    }
}