using System.Diagnostics;

namespace BlazorSortableList.DemoApp.Client;

public class PersistenceSample : IPersistenceSample
{
    private List<NestedItem>? storedRootItems;

    private List<NestedItem> rootItems = Enumerable.Range(1, 3).Select(i => new NestedItem { Id = i, Name = $"Sample Item 1.{i}" }).ToList();

    private List<NestedItem> items2 = Enumerable.Range(11, 3).Select(i => new NestedItem { Id = i, Name = $"Sample Item 2.{i}" }).ToList();

    private List<NestedItem> items3 = Enumerable.Range(21, 3).Select(i => new NestedItem { Id = i, Name = $"Sample Item 2.3.{i}" }).ToList();

    private List<NestedItem> items4 = Enumerable.Range(31, 3).Select(i => new NestedItem { Id = i, Name = $"Sample Item 4.{i}" }).ToList();

    public IList<NestedItem> GetRootItems()
    {
        if (storedRootItems == null)
        {
            items2[1].Children = items3;
            rootItems[0].Children = items2;
            rootItems[2].Children = items4;
            return rootItems;
        }
        return storedRootItems;
    }

    public void StoreRootItems(IList<NestedItem> items)
    {
        Trace.WriteLine("**Store data**");
    }
}
