namespace BlazorSortableList.DemoApp.Client;

public interface IPersistenceSample
{
    IList<NestedItem> GetRootItems();

    void StoreRootItems(IList<NestedItem> items);
}