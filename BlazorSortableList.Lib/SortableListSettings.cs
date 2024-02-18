namespace BlazorSortableList;

public class SortableListSettings
{
    /// <summary>
    /// Gets or sets a value indicating whether the list is in clone mode.
    /// Note: Similar to the Pull parameter
    /// </summary>
    /// <value><c>true</c> if [clone mode]; otherwise, <c>false</c>.</value>
    public bool CloneMode { get; set; } = false;

    /// <summary>
    /// Gets or sets a value indicating whether this list allows dropping from another list.
    /// Note: Similar to the Put parameter
    /// </summary>
    /// <value><c>true</c> if [allow drop]; otherwise, <c>false</c>.</value>
    public bool AllowDrop { get; set; } = true;


    /// <summary>
    /// Gets or sets a value indicating whether the list allows reordering of items.
    /// Note: Similar to the Sort parameter
    /// </summary>
    /// <value><c>true</c> if [allow reorder]; otherwise, <c>false</c>.</value>
    public bool AllowReorder { get; set; } = true;

    /// <summary>
    /// Gets or sets the CSS class name to display the drag handle of the list item.
    /// Note: Similar to the Handle parameter
    /// </summary>
    /// <value>The CSS for drag handle with leading point</value>
    public string CssForDragHandle { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets the CSS class name for the disabled list item
    /// Note: Similar to the Filter parameter
    /// </summary>
    /// <value>The CSS for disabled item.</value>
    public string CssForDisabledItem { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets a value indicating whether this list used HTML5 drag and drop mode.
    /// Note: Similar to the inverted ForceFallback parameter
    /// </summary>
    /// <value><c>true</c> if [allow HTML5 drag and drop]; otherwise, <c>false</c>.</value>
    public bool AllowHtml5DragAndDrop { get; set; } = false;
}
