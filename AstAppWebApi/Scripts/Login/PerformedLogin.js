/// <reference path="../Shared/AstAppObjAndStruct.js" />
/// <reference path="../Shared/AstAppShared.js" />
/// <reference path="../Generic/AjaxUtils.js" />


function LoginPerformed(data) {
    _accessToken = data.access_token;
    CloseModal('#loginModal');
    //Hide login/register link

    //Call web server to get pools
    $.ajax({
        url: _homeIndexAuthorizeAddress,
        type: "GET",
        data: {},
        datatype: 'json',
        headers: getHeaders(),
        success: function (data) {
            try {

                alert('success');


            } catch (err) {
                alert("Error on success LoginPerformed: " + err.message);
            }
        },
        error: function (error) {
            
            alert("Error on error LoginPerformed: " + error.message);
        }
    });
}
