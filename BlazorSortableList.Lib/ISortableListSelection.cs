namespace BlazorSortableList;

public interface ISortableListSelection
{
    public bool HandleSelect(string fromId,  int index);

    public bool HandleDeselect(string fromId, int index);
}
