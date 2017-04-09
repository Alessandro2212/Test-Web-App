/// <reference path="AstAppObjAndStruct.js" />

var getHeaders = function () {
    if (_accessToken) {
        return {
            "Authorization": "Bearer " + _accessToken
        };
    }
}

function ErrorHandler(data) {

}

function CloseModal(IdModal) {
    $(IdModal).modal('hide');
}
