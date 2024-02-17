namespace BlazorSortableList;

public interface ISortableListGroup<T>
{
    ISortableListModel<T>? GetModel(string id);
    void AddModel(string id, ISortableListModel<T> model);
}
