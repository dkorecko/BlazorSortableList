export function init(id, group, pull, put, sort, handle, filter, component, forceFallback) {
    
    var sortable = new Sortable(document.getElementById(id), {
        animation: 200,
        group: {
            name: group,
            pull: pull || true,
            put: put
        },
        filter: filter || undefined,
        sort: sort,
        forceFallback: forceFallback,
        handle: handle || undefined,
        onUpdate: (event) => {
            //console.log("onUpdate:");
            //console.log(event);

            // Revert the DOM to match the .NET state
            event.item.remove();
            event.to.insertBefore(event.item, event.to.childNodes[event.oldIndex]);

            // Notify .NET to update its model and re-render
            component.invokeMethodAsync('OnUpdateJS',
                event.oldDraggableIndex,
                event.newDraggableIndex,
                event.from.id
                );
        },
        onRemove: (event) => {
            //console.log("onRemove:");
            //console.log(event);
            if (event.pullMode === 'clone') {
                // Remove the clone
                event.clone.remove();
            }

            event.item.remove();
            event.from.insertBefore(event.item, event.from.childNodes[event.oldIndex]);

            // Notify .NET to update its model and re-render
            component.invokeMethodAsync('OnRemoveJS',
                event.oldDraggableIndex,
                event.newDraggableIndex,
                event.from.id,
                event.to.id);
        },
        onSelect: (event) => {
          console.log("onSelect:");
          console.log(event);
        },
        onDeselect: (event) => {
            console.log("onDeselect:");
            console.log(event);
        }
    });
}
