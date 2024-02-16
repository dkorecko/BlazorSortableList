# Blazor Sortable List
## Overview
An implementation of the [SortableJS library](https://sortablejs.github.io/Sortable/) for Blazor. This example shows you how to reorder elements within a list using drag and drop.

[View Demos .NET7 web assembly](https://mango-flower-090e9130f.4.azurestaticapps.net/)
[View Demos .NET8 server prerendering](https://blazorsortablelistdemoapp2024.azurewebsites.net/)
[View Youtube demonstration](https://www.youtube.com/watch?v=DdsD1j8a-DA)

Great implementation, but I would like to make some changes:
- extract package
- use .NET 8.0 project style

> The latest changes will appear first on the development branch.

## Prerequisites

- [dotnet 8](https://dotnet.microsoft.com/download/dotnet/8.0)

## Running Locally

1. Clone this repository.
1. Run the project 'BlazorSortableList.DemoApp' using `dotnet watch`.

## How to use it in your own project

1. **Install the latest NuGet Package**

 - Using Package Manager
```
Install-Package BlazorSortableList
```

 - Using .NET CLI
```
dotnet add package BlazorSortableList
```

 - Using MS VS Manage NuGet Packages search for `BlazorSortableList`

2. Add SortableJS to your `index.html`/`app.razor` file. You can either download from the [SortableJS website](https://sortablejs.github.io/Sortable/) or use a CDN...

 ```
<script src="https://cdn.jsdelivr.net/npm/sortablejs@latest/Sortable.min.js"></script>
 ```

3. Add the `SortableList.razor.js` to your `index.html`/'app.razor' file..

 ```
<script type="module" src="_content/BlazorSortableList/SortableList.razor.js"></script>
 ```

4. Add the SortableList component to your page and define the SortableItemTemplate...

        <SortableList Id="sortable" Items="items" OnUpdate="@SortList" Context="item">
            <SortableItemTemplate>
                <div>
                    <p>@item.Name</p>
                </div>
            </SortableItemTemplate>
        </SortableList>

 - ***Items***: The list of items to be displayed. Can be of any type.
 - ***OnUpdate***: The method to be called when the list is updated.
 - ***Context***: The name of the variable to be used in the template.

The `SortableItemTemplate` can contain any markup or components that you want.

## Attributes

### Properties

All properties are optional and have default values.

`Id`: String (Default: GUID): The id of the HTML element that will be turned into a sortable. If you don't supply this, a random id (GUID) will be generated for you.

`Group`: String (Default: null) - Used for dragging between lists. Set the group to the same value on both lists to enable.

`Pull`: String (Default: null) - Used when you want to clone elments into a list instead of moving them. Set `Pull` to "clone".

`Put`: Boolean (Default: True) - Set to false to disable dropping from another list onto the current list.

`Sort`: Boolean (Default: True) - Disable sorting within a list by setting to `false`.

`Handle` (Default: ""): The CSS class you want the sortable to respect as the drag handle. 

`Filter` (Default: ""): The CSS class you want to use to identify elements that cannot be sorted or moved.

`ForceFallback`: Boolean (Default: True) - Enable HTML5 drag and drop by setting to `false`.

### Events

`OnUpdate` (Optional): The method to be called when the list is updated. You can name this method whatever you like, but it expects a `oldIndex` and `newIndex` parameters when the drag and drop occurs.

`OnRemove` (Optional): The method to be called when an item is removed from a list. This method is useful for handling the drop even between multiple lists. Like `OnUpdate`, it expects `oldIndex` and `newIndex` parameters.

You will need to handle all events yourself. **If you don't handle any events, no sort or move will happen** as Blazor needs to make the changes to the underlying data structures so it can re-render the list. 

Here is an example of how to reorder your list when the OnUpdate is fired...

```csharp
    private void SortList((int oldIndex, int newIndex) indices)
    {
        var (oldIndex, newIndex) = indices;

        var items = this.items;
        var itemToMove = items[oldIndex];
        items.RemoveAt(oldIndex);

        if (newIndex < items.Count)
        {
            items.Insert(newIndex, itemToMove);
        }
        else
        {
            items.Add(itemToMove);
        }

        StateHasChanged();
    }
```

## History
V1.0.0 - orignal component