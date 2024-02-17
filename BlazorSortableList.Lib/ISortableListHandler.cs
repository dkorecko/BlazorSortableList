namespace BlazorSortableList;

public interface ISortableListHandler
{
    public bool HandleRemove(string id, string group, int oldIndex, int newIndex);

    public bool HandleUpdate(string id, string group, int oldIndex, int newIndex);
}
