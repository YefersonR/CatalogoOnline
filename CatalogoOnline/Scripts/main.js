//User
$("#formValidateUser").validate({
    rules: {
        UserName: {
            required: true,
            minlength: 5
        },
        Password: {
            required: true

        }
    },
    messages: {
        UserName: {
            required: "Please enter your username"
        },
        Password: {
            required: "Please enter your password"
        }
    }
})

function ValidateForm(FormId) {

}
$(document).on("submit", "#formValidateUser", function (e) {
    e.preventDefault();
    var productModel = {
        "UserName": $('#UserName').val(),
        "UserPassword": $('#Password').val(),
    }
    $.post('/User/Login', productModel)
        .done(function (data) {
            if (data != null) {
                window.location.href = data;
            }
        })
})


//Create Products 

$("#formValidate").validate({
    rules: {
        ProductName: {
            required: true,
            minlength: 5
        },
        UnitPrice: {
            required: true

        },
        UnitInStock: {
            required: true

        },
        Garantie: {
            required: true
        }
    },
    messages: {
        ProductName: {
            required: "Please enter the product name",
            minlength: "Name at least 5 character"
        },
        UnitPrice: {
            required: "Please enter the unit price"

        },
        UnitInStock: {
            required: "Please enter the unit in stock"

        },
        Garantie: {
            required: "Please enter the garantie for the product"

        }

    }
})
$(document).on("submit", "#formValidate", function (e) {
    e.preventDefault();
    var productModel = {
        "ProductName": $('#ProductName').val(),
        "UnitPrice": $('#UnitPrice').val(),
        "UnitInStock": $('#UnitInStock').val(),
        "Garantie": $('#Garantie').val(),
        "CategoryID": $('#Categories').val(),
        "Autor": "@ViewBag.user.UserName"
    }
    $.post('./Create', productModel)
        .done(function (data) {
            if (data != null) {
                window.location.href = "/Home/Index"
            }
        })
})
window.onload = () => {
    var urlCategory = "/Product/ListCategory"
    $.ajax({
        url: urlCategory,
        method: "GET",
        dataType: "json",
        contentType: "application/json",
        success: function (data) {
            data = JSON.parse(data);
            console.log(data);
            $.map(data, (category) => {
                $("#Categories").append(
                    "<option value=" + category.ID + ">" + category.CategoryName + "</option > "
                )
            })

        },
        error: function (err) {
            console.error(err);
        }
    })
}


//Home Produtcts

window.onload = () => {
    var url = "/Product/List"
    $.ajax({
        url: url,
        method: "GET",
        dataType: "json",
        contentType: "application/json",
        success: function (data) {
            data = JSON.parse(data);
            if (data != null) {
                $.map(data, (product) => {
                    $("#Card").append(
                        "<div class='CardContainer'>" +
                        "<h3>" + product.ProductName + "</h3>" +
                        "<div class='d-flex justify-content-between'>" +
                        "<p class='card-text'> Price:" + product.UnitPrice + "</p>" +
                        "<small class='fw-bold'></small>" +
                        "</div>" +
                        "<div class='d-flex justify-content-between'>" +
                        "<small class='fw-bold'> In Stock:" + product.UnitInStock + "</small> <br>" +
                        "<small class='fw-bold'> Garantie:" + product.Garantie + "</small>" +
                        "</div>")
                })
            }
            else {
                $("#Card").append("<h1>No items found</h1>")

            }
        },
        error: function (err) {
            console.error(err);
        }
    })
    var urlCategory = "/Product/ListCategory"
    $.ajax({
        url: urlCategory,
        method: "GET",
        dataType: "json",
        contentType: "application/json",
        success: function (data) {
            data = JSON.parse(data);
            console.log(data);
            $.map(data, (category) => {
                console.log(category);
                $("#Categories").append(
                    "<br>" +
                    "<input class='form-check-input' value=" + category.ID + " type='radio' name='CategoryId' />" +
                    "<label class='form-check-label' for='CategoryId'>" + category.CategoryName + "</label>") +
                    "<br>"

            })

        },
        error: function (err) {
            console.error(err);
        }
    })
}

$(document).on("submit", "#SearchForm", function (e) {
    e.preventDefault();
    var url = "/Product/Search"
    $.ajax({
        url: url,
        method: "GET",
        dataType: "json",
        contentType: "application/json",
        data: {
            "search": $('#Search').val()
        },
        success: function (data) {
            data = JSON.parse(data);
            if (data != null) {
                $("#Card").empty();
                $.map(data, (product) => {
                    $("#Card").append(
                        "<div class='CardContainer'>" +
                        "<h3>" + product.ProductName + "</h3>" +
                        "<div class='d-flex justify-content-between'>" +
                        "<p class='card-text'> Price:" + product.UnitPrice + "</p>" +
                        "<small class='fw-bold'></small>" +
                        "</div>" +
                        "<div class='d-flex justify-content-between'>" +
                        "<small class='fw-bold'> In Stock:" + product.UnitInStock + "</small> <br>" +
                        "<small class='fw-bold'> Garantie:" + product.Garantie + "</small>" +
                        "</div>")

                })
            }
            else {
                $("#Card").append("<h1>No items found</h1>")

            }
        },
        error: function (err) {
            console.error(err);
        }

    })
})

$(document).on("submit", "#FilterByCategoryForm", function (e) {
    e.preventDefault();
    var url = "/Product/FilterByCategory"
    $.ajax({
        url: url,
        method: "GET",
        dataType: "json",
        contentType: "application/json",
        data: {
            "CategoryId": $('input[name=CategoryId]:checked', '#FilterByCategoryForm').val()
        },
        success: function (data) {
            data = JSON.parse(data);
            console.log(data);
            if (data != null) {
                $("#Card").empty();
                $.map(data, (product) => {
                    $("#Card").append(
                        "<div class='CardContainer'>" +
                        "<h3>" + product.ProductName + "</h3>" +
                        "<div class='d-flex justify-content-between'>" +
                        "<p class='card-text'> Price:" + product.UnitPrice + "</p>" +
                        "<small class='fw-bold'></small>" +
                        "</div>" +
                        "<div class='d-flex justify-content-between'>" +
                        "<small class='fw-bold'> In Stock:" + product.UnitInStock + "</small> <br>" +
                        "<small class='fw-bold'> Garantie:" + product.Garantie + "</small>" +
                        "</div>")

                })
            }
            else {
                $("#Card").append("<h1>No items found</h1>")

            }
        },
        error: function (err) {
            console.error(err);
        }

    })
})