function AjaxAddBlockBegin() {
    $('#div_AddBlock').hide();
}

//scroll to the end of page
function Scroll() {
    var $target = $('html,body');
    $target.animate({ scrollTop: $target.height() }, 1100);
}
