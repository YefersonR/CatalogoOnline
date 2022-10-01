//Functions Ajax Request
function PostAjaxRequest(url, model) {
    $.post(url, model)
        .done(function (data) {
            if (data != null && data.HasError != true) {
                window.location.href = data
            }
            else {
                console.error(data.Error)
            }
        })
}
function GetAjaxResultWithParameter(url, model) {
    return Promise.resolve(
        $.ajax({
            url: url,
            method: "GET",
            dataType: "json",
            contentType: "application/json",
            data: model,
        })
    )
}
function GetAjaxResult(url) {
    return Promise.resolve(
        $.ajax({
            url: url,
            method: "GET",
            dataType: "json",
            contentType: "application/json",
        }))
}
