// externe js: packery.pkgd.js, draggabilly.pkgd.js

var $grid = $('.grid').packery({
    itemSelector: '.grid-item',
    columnWidth: 100
});

 //grid items draggable maken
$grid.find('.grid-item').each(function (i, gridItem) {
    var draggie = new Draggabilly(gridItem);
    // bind drag events to Packery
    $grid.packery('bindDraggabillyEvents', draggie);
});

