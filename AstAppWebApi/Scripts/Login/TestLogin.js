//function LoadtaskTableData() {
//    $.ajax({
//        url: _taskListAddress,
//        type: 'GET',
//        data: {},
//        success: function (data) {
//            try {

//                if (isToRefresh) {
//                    RefreshDatatable('#dt_show', data);
//                } else {
//                    SetDataTableWithoutAjax('#dt_show', data, _taskTableColumnTemplate,
//                    _taskTableColumnsDefs, true, 0, "asc");
//                }

//                SetPageNumber('#dt_show', parseInt(_taskCurrentPageNumber));

//            } catch (err) {
//                UIkit.modal.alert("Error on success Load Job Table: " + err.message);
//            }
//        },
//        error: function (error) {
//            UIkit.modal.alert("Error on error: " + error.message);
//        }
//    });
//}

function LoginPerformed(data) {
    var accessToken  = data.access_token
}
