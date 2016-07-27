///////////////////////////////////////////////////////////////////////////////////////////////
var resultStyle = { 0: "alert-danger", 1: "alert-warning", 2: "alert-success" };
var icons = { 0: "glyphicon glyphicon-exclamation-sign", 1: "glyphicon glyphicon-info-sign", 2: "glyphicon glyphicon-ok-sign" };
/*Вывод сообщения о результате операции ([idMessageBox] : id элемента куда выводится сообщение,
[Data] : данные в формате JSON с Id результата и сообщением*/
function ShowMessage(idMessageBox, Data, closeBtn) {
    var messageBox = $("#" + idMessageBox);
    var messageData = JSON.parse(Data);
    messageBox.removeAttr("class").contents().remove();
    messageBox
        .addClass("alert alert-dismissable")
        .addClass(resultStyle[messageData.ResultId])
        .append("<span class='" + icons[messageData.ResultId] + "' aria-hidden='true'></span>")
        .append(" " + messageData.Message);
    if (closeBtn) messageBox.append("<button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>")
    messageBox.show();
}
///////////////////////////////////////////////////////////////////////////////////////////////
//Проверка элемента на валидность и установка соответствующих классов элементу
function checkValidityElement(element) {
    //найти предков, которые имеют класс .form-group, для установления success/error
    var formGroup = $(element).parents('.form-group');
    //найти glyphicon, который предназначен для показа иконки успеха или ошибки
    var glyphicon = formGroup.find('.form-control-feedback');
    //для валидации данных используем HTML5 функцию checkValidity
    if (element.checkValidity()) {
        //добавить к formGroup класс .has-success, удалить has-error
        formGroup.addClass('has-success').removeClass('has-error');
        //добавить к glyphicon класс glyphicon-ok, удалить glyphicon-remove
        glyphicon.addClass('glyphicon-ok').removeClass('glyphicon-remove');
    } else {
        //добавить к formGroup класс .has-error, удалить .has-success
        formGroup.addClass('has-error').removeClass('has-success');
        //добавить к glyphicon класс glyphicon-remove, удалить glyphicon-ok
        glyphicon.addClass('glyphicon-remove').removeClass('glyphicon-ok');
    }
}
////////////////////////////////////////////////////////////////////////////////////////////
function modDialogHide(dialogId)
{
    $(dialogId).modal('hide');
}