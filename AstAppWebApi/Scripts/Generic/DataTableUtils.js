function SetDataTableWithoutAjax(tableName, data, columnTemplate, columnDefs,
    setScrollX, columnOrder, typeOrder) {

    var table = $(tableName).dataTable({
        "language": {
            searchPlaceholder: "Search for any record"
        },
        "aoColumnDefs": columnDefs,
        "aaData": data,
        "aoColumns": columnTemplate,
        "scrollX": setScrollX,
        "paging": true,
        "order": [[columnOrder, typeOrder]]        
    });


    $('#dt_show_length').addClass('uk-width-1-2 md-input');
    $('#dt_show_length select').addClass('uk-button uk-form-select');
    $('#dt_show_filter').addClass('uk-width-1-2');
    $('div.dataTables_filter input').addClass('md-input uk-form-width-small');
}

function SetDataTable(tableName, columnTemplate, columnDefs, url) {

    var table = $(tableName).dataTable({
        "language": {
            searchPlaceholder: "Search for any record"
        },
        "aoColumnDefs": columnDefs,
        "aoColumns": columnTemplate,
        "scrollX": false,
        "processing": true,
        "serverSide": true,
        "info": true,
        "stateSave": true,
        "ajax": {
            "url": url,
            "type": "GET"
        }
    });
}

function RefreshDatatable(tableName, data) {
    try {
        var oTable = $(tableName).dataTable();
        oTable.fnClearTable();
        oTable.fnAddData(data);
        oTable.fnDraw();
    } catch (e) {
        alert(e);
    }
}

function AddDatatableRow(tableName, data) {
    try {
        var oTable = $(tableName).dataTable();
        oTable.fnAddData(data);
    } catch (e) {
        alert(e);
    }
}

function UpdateDatatableRow(tableName, data, rowId) {
    try {
        var oTable = $(tableName).dataTable();
        oTable.fnUpdate(data, rowId);
    } catch (e) {
        alert(e);
    }
}

function DeleteDatatableRow(tableName, rowId) {
    try {
        var oTable = $(tableName).dataTable();
        oTable.fnDeleteRow(rowId);
    } catch (e) {
        alert(e);
    }
}

function CheckDataNotNull(data) {
    if (data) {                              
        return (data);
    }
    return "";
}

function ShortTextWithTooltip(data, cutOff) {

    return (data!=null && data!=undefined)&&(data.length>cutOff) ?
            '<span title="' + data + '">' + data.substr(0, cutOff) + '…' + '</span>' :
            data;
}

function DataFormat(data) {
    if (data) {
        var mDate = moment(data);
        return (mDate && mDate.isValid()) ? mDate.format("LL") : "";
    }
    return "";
}

function DatatimeFormat(data) {
    if (data) {
        var mDate = moment(data);
        return (mDate && mDate.isValid()) ? mDate.format("LL LT") : "";
    }
    return "";
}

function TimeFormat(data) {
    if (data) {
        var mDate = moment(data);
        return (mDate && mDate.isValid()) ? mDate.format("HH:mm") : "";
    }
    return "";
}

function GetTableCheckBox(data) {
    var checkBox;
    if (data == true) {
        checkBox = '<input type="checkbox" disabled checked/>';
    } else {
        checkBox = '<input type="checkbox" disabled/>';
    }
    return checkBox;
}

function GetPageNumber(tableName) {

    var table = $(tableName).DataTable();
    var info = table.page.info();

    return info.page;
}

function SetPageNumber(tableName, pageNumber) {

    var table = $(tableName).DataTable();
    table.page(pageNumber).draw(false);
}

function GetCellValue(tableName, rowId, columnName) {
    var table = $(tableName).DataTable();
    var data = table.row(rowId).data();

    return data[columnName];
}
