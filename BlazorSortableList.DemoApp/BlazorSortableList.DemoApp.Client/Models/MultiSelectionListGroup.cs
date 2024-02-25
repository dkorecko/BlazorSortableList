
namespace BlazorSortableList.DemoApp.Client.Models;
internal class MultiSelectionListGroup : MultiSortableListGroup<Item>, ISortableListSelection
{
    public MultiSelectionListGroup(Action refreshComponent)
        : base(refreshComponent)
    {
    }

    protected override void ListArrangeItems(int oldIndex, int newIndex, IList<Item> items)
    {
        //return;
        var selected = new List<Item>();
        for (int i = 0; i < items.Count;)
        {
            var item1 = items[i];
            if (item1.Selected)
            {
                selected.Add(item1);
                items.RemoveAt(i);
            }
            else
            {
                i++;
            }
        }

        var index = newIndex;
        if (index >= items.Count)
        {
            foreach (var item in selected)
            {
                item.Selected = false;
                items.Add(item);
            }
        }
        else
        {
            foreach (var item in selected)
            {
                item.Selected = false;
                items.Insert(index++, item);
            }
        }

        //foreach (var item in selected)
        //{
        //    items.Remove(item);
        //}
    }

    protected override void ListMoveItem(int oldIndex, int newIndex, IList<Item> items1, IList<Item> items2)
    {
        return;
        List<Item> selected = GetSelected(items1);

        var index = newIndex;
        if (index >= items2.Count)
        {
            foreach (var item in selected)
            {
                items2.Add(item);
            }
        }
        else
        {
            foreach (var item in selected)
            {
                items2.Insert(index++, item);
            }
        }

        foreach (var item in selected)
        {
            items1.Remove(item);
        }
    }

    private static List<Item> GetSelected(IList<Item> items1)
    {
        var selected = new List<Item>();
        for (int i = 0; i < items1.Count;)
        {
            var item = items1[i];
            if (item.Selected)
            {
                selected.Add(item);
                //items1.RemoveAt(i);
            }
            else
            {
                i++;
            }
        }

        return selected;
    }

    public bool HandleSelect(string fromId, int index)
    {
        bool ret = false;
        var items = GetModel(fromId)?.Items;
        if (items != null)
        {
            Item item = items[index];
            if (!item.Selected)
            {
                item.Selected = true;
                ret = true;
            }
        }
        return ret;
    }

    public bool HandleDeselect(string fromId, int index)
    {
        bool ret = false;
        var items = GetModel(fromId)?.Items;
        if (items != null && index < items.Count)
        {
            Item item = items[index];
            if (item.Selected)
            {
                item.Selected = false;
                ret = true;
            }
        }
        return ret;
    }
}
