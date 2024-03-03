namespace BlazorSortableList;

public class MultiSelectionListGroup<T> : MultiSortableListGroup<T>, ISortableListSelection where T : ISelectableItem
{
    public MultiSelectionListGroup(Action refreshComponent)
        : base(refreshComponent)
    {
    }

    public virtual bool HandleDeselect(string fromId, int index)
    {
        bool ret = false;
        var items = GetModel(fromId)?.Items;
        if (items != null && index >= 0 && index < items.Count)
        {
            T item = items[index];
            if (item.Selected)
            {
                item.Selected = false;
                ret = true;
            }
        }

        return ret;
    }

    public virtual bool HandleSelect(string fromId, int index)
    {
        bool ret = false;
        var items = GetModel(fromId)?.Items;
        if (items != null && index >= 0 && index < items.Count)
        {
            T item = items[index];
            if (!item.Selected)
            {
                item.Selected = true;
                ret = true;
            }
        }

        return ret;
    }

    protected override void ListArrangeItems(int oldIndex, int newIndex, IList<T> items)
    {
        List<T> selected = CutSelected(items);

        if (selected.Any())
        {
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
        }
        else
        {
            base.ListArrangeItems(oldIndex, newIndex, items);
        }
    }

    protected override void ListMoveItem(int oldIndex, int newIndex, IList<T> items1, IList<T> items2)
    {
        List<T> selected = GetSelected(items1);

        if (selected.Any())
        {
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
                item.Selected = false;
            }
        }
        else
        {
            base.ListMoveItem(oldIndex, newIndex, items1, items2);
        }
    }

    protected static List<T> CutSelected(IList<T> items)
    {
        var selected = new List<T>();
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

        return selected;
    }

    protected static List<T> GetSelected(IList<T> items)
    {
        var selected = new List<T>();
        for (int i = 0; i < items.Count; i++)
        {
            var item = items[i];
            if (item.Selected)
            {
                selected.Add(item);
            }
        }

        return selected;
    }
}
