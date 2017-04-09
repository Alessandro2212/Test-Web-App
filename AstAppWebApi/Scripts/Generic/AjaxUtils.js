function AjaxCallWithHeader(_url, _type, _dataToSend, header, _functionOnSuccess,
    _functionOnError)
{
    $.ajax({
        url: _url,
        type: _type,
        data: _dataToSend,
        datatype: 'json',
        headers: getHeaders,
        success: function (data) {
            try {
                _functionOnSuccess;
            } catch (err) {
                alert("Error on success AjaxCall: " + err.message);
            }
        },
        error: function (error) {
            _functionOnError;
            alert("Error on error AjaxCall: " + error.message);
        }
    });
}

