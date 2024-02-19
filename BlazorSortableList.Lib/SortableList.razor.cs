using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BlazorSortableList
{
    public partial class SortableList<T>
    {

        [Parameter]
        public RenderFragment<T>? SortableItemTemplate { get; set; }

        [Parameter, AllowNull]
        public IList<T> Items { get; set; }

        [Parameter]
        public ISortableListGroup<T>? GroupModel { get; set; }

        [Parameter]
        public EventCallback<(int oldIndex, int newIndex)> OnUpdate { get; set; }

        [Parameter]
        public EventCallback<(int oldIndex, int newIndex)> OnRemove { get; set; }

        [Parameter]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Parameter]
        public string Group { get; set; } = Guid.NewGuid().ToString();

        [Parameter]
        public string? Pull { get; set; }

        [Parameter]
        public bool Put { get; set; } = true;

        [Parameter]
        public bool Sort { get; set; } = true;

        [Parameter]
        public string? Handle { get; set; }

        [Parameter]
        public string? Filter { get; set; }

        [Parameter]
        public bool ForceFallback { get; set; } = true;

        [Parameter]
        public bool DefaultSort { get; set; }

        private DotNetObjectReference<SortableList<T>>? selfReference;

        private ISortableListHandler? _sortableListHandler;

        /// <summary>
        /// Method invoked when the component has received parameters from its parent in
        /// the render tree, and the incoming values have been assigned to properties.
        /// </summary>
        /// <returns>A <see cref="T:System.Threading.Tasks.Task" /> representing any asynchronous operation.</returns>
        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();
            _sortableListHandler = GroupModel as ISortableListHandler;

            if (GroupModel != null)
            {
                ISortableListModel<T>? model = GroupModel.GetModel(Id);
                if (model != null)
                {
                    Group = model.Group;
                    Items = model.Items;
                    var settings = model.Settings;

                    if (settings != null)
                    {
                        if (settings.CloneMode)
                        {
                            Pull = "clone";
                        }

                        Put = settings.AllowDrop;
                        Sort = settings.AllowReorder;
                        if (string.IsNullOrEmpty(Handle))
                        {
                            Handle = settings.CssForDragHandle;
                        }

                        Filter = settings.CssForDisabledItem;
                        ForceFallback = !settings.AllowHtml5DragAndDrop;
                    }
                }
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                selfReference = DotNetObjectReference.Create(this);
                var module = await JS.InvokeAsync<IJSObjectReference>("import", "./_content/BlazorSortableList/SortableList.razor.js");

                //await JS.InvokeVoidAsync("console.log", $"***id:{Id}, group:{Group},pull: {Pull},put:{Put},sort:{Sort}, handle:{Handle}, filter:{Filter}, forceFallback:{ForceFallback}");
                await module.InvokeAsync<string>("init", Id, Group, Pull, Put, Sort, Handle, Filter, selfReference, ForceFallback);
            }
        }

        [JSInvokable]
        public void OnUpdateJS(int oldIndex, int newIndex)
        {
            if (_sortableListHandler != null)
            {
                if (_sortableListHandler.HandleUpdate(Id, Group, oldIndex, newIndex))
                {
                    StateHasChanged();
                }
            }
            else
            {
                if (OnUpdate.HasDelegate)
                {
                    if (DefaultSort)
                    {
                        throw new ArgumentException($"It must be defined as either {{nameof(OnUpdate)}} or {{nameof(DefaultSort)}}, but not both together.");
                    }
                    // invoke the OnUpdate event passing in the oldIndex and the newIndex
                    OnUpdate.InvokeAsync((oldIndex, newIndex));
                }
                else if (DefaultSort)
                {
                    SortList(oldIndex, newIndex);
                }
            }
        }

        [JSInvokable]
        public void OnRemoveJS(int oldIndex, int newIndex)
        {
            if (_sortableListHandler != null)
            {
                if (_sortableListHandler.HandleRemove(Id, Group, oldIndex, newIndex))
                {
                    StateHasChanged();
                }
            }
            else
            {
                // remove the item from the list
                OnRemove.InvokeAsync((oldIndex, newIndex));
            }
        }

        public void Dispose() => selfReference?.Dispose();

        private void SortList(int oldIndex, int newIndex)
        {

            var items = Items;
            if (items != null)
            {
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
        }
    }
}