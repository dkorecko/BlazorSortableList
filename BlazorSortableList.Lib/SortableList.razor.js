export function init(id, group, pull, put, sort, handle, filter, component, forceFallback) {

    const DEBUG_MODE = true;
    if (DEBUG_MODE) {
        console.log("Init for Id:", id);
    }

    let htmlElement = document.getElementById(id);

    var sortable = new Sortable(htmlElement, {
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
            if (DEBUG_MODE) {
                console.log("onUpdate:");
                console.log(event);
            }

            let oldIndex = event.oldDraggableIndex;
            let newIndex = event.newDraggableIndex;

            // Notify .NET to update its model and re-render
            component.invokeMethodAsync('OnUpdateJS', oldIndex, newIndex, event.from.id);
        },
        onRemove: (event) => {
            if (DEBUG_MODE) {
                console.log("onRemove:");
                console.log(event);
            }

            if (event.pullMode === 'clone') {
                // Remove the clone
                event.clone.remove();
            }
            let oldIndex = event.oldDraggableIndex;
            let newIndex = event.newDraggableIndex;

            // Notify .NET to update its model and re-render
            component.invokeMethodAsync('OnRemoveJS', oldIndex, newIndex, event.from.id, event.to.id);
        }
    });
}
