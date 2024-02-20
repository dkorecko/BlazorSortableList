namespace BlazorSortableList;

public interface ISortableListHandler
{
    public bool HandleRemove(string fromId, string toId, int oldIndex, int newIndex);

    public bool HandleUpdate(string fromId, string toId, int oldIndex, int newIndex);
}
