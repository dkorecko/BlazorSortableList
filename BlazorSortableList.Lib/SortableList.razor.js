export function init(id, group, pull, put, sort, handle, filter, component, forceFallback, cssForSelection, multiDragKey, avoidImplicitDeselect) {

    let multiDrag = (typeof cssForSelection !== 'undefined');
    console.log(multiDragKey);

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

        multiDrag: multiDrag,
        selectedClass:cssForSelection,
        multiDragKey: multiDragKey,
        avoidImplicitDeselect: avoidImplicitDeselect,

        onUpdate: (event) => {
            console.log("onUpdate:");
            console.log(event);


            let newIndex = event.newDraggableIndex;
            // in multi selection mode we have newIndicies only
            let newIndicies = Array.from(event.newIndicies);
            if (newIndicies.length > 0) {
                newIndex = newIndicies[0].index;

                // Revert the DOM to match the .NET state
                newIndicies.forEach((item) => {
                    event.from.removeChild(item.multiDragElement);
                    // remove selection
                    //toggleClass(item.multiDragElement, cssForSelection, false);
                    //sortable.utils.deselect(item.multiDragElement);

                });

                let oldIndicies = Array.from(event.oldIndicies);
                oldIndicies.forEach((item) => {
                    event.to.insertBefore(item.multiDragElement, event.to.childNodes[item.index]);
                });
                //oldIndicies.forEach((item) => event.from.insertBefore(Node(item.multiDragElement), item.index));
                //oldIndicies.forEach((item) => event.from.insertBefore(Node(item.multiDragElement), event.from.childNodes[item.index]));

                //oldIndicies.forEach((item) => {
                //    const newNode = event.from.ownerDocument.importNode(item.multiDragElement, true);
                //    event.from.insertBefore(newNode, event.from.childNodes[item.index]);
                //});
            } else {
                event.item.remove();
                event.to.insertBefore(event.item, event.to.childNodes[event.oldIndex]);
            }
            // Notify .NET to update its model and re-render
            component.invokeMethodAsync('OnUpdateJS',
                event.oldDraggableIndex,
                newIndex,
                event.from.id
                );
        },
        onRemove: (event) => {
            console.log("onRemove:");
            console.log(event);
            if (event.pullMode === 'clone') {
                // Remove the clone
                event.clone.remove();
            }

            let newIndex = event.newDraggableIndex;
            // in multi selection mode we have newIndicies only
            let newIndicies = Array.from(event.newIndicies);
            if (newIndicies.length > 0) {
                newIndex = newIndicies[0].index;

                // Revert the DOM to match the .NET state
                newIndicies.forEach((item) => {
                    event.to.removeChild(item.multiDragElement);
                    // remove selection???
                    
                });

                let oldIndicies = Array.from(event.oldIndicies);
                oldIndicies.forEach((item) => {
                    event.from.insertBefore(item.multiDragElement, event.from.childNodes[item.index]);
                });
            } else {
                // Revert the DOM to match the .NET state
                event.item.remove();
                event.from.insertBefore(event.item, event.from.childNodes[event.oldIndex]);
            }

            // Notify .NET to update its model and re-render
            component.invokeMethodAsync('OnRemoveJS',
                event.oldDraggableIndex,
                newIndex,
                event.from.id,
                event.to.id);
        },
        onSelect: (event) => {
            console.log("onSelect:");
            let children = Array.from(event.from.childNodes);
            console.log(event);
            console.log(children);
            let index = children.indexOf(event.item);
            console.log(index);

            // Notify .NET to update its model and re-render
            component.invokeMethodAsync('OnSelectJS', event.from.id, index);
        },
        onDeselect: (event) => {
            console.log("onDeselect:");
            console.log(event);

            let children = Array.from(event.from.childNodes);
            let index = children.indexOf(event.item);
            console.log(index);

            // Notify .NET to update its model and re-render
            component.invokeMethodAsync('OnDeselectJS', event.from.id, index);
        }
    });
}
