function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode;
    if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57)) {
        return false;
    } else {
        return true;
    }
}
function PrintGrid(html, css) {
    var printWin = window.open('', '', 'left=0,top=0,width=1000,height=600,scrollbars=1');
    //printWin.document.write('<style type = "text/css">' + css + '</style>');
    printWin.document.write(html);
    printWin.document.close();
    printWin.focus();
    printWin.print();
    printWin.close();
}