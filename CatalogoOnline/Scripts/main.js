//Get methods

async function Home() {
    const urlProducts = "/Product/List"
    try {
        var getDataProducts = await GetAjaxResult(urlProducts)
        getDataProducts = JSON.parse(getDataProducts)

        if (getDataProducts != null) {
            $("#Card").empty()
            $.map(getDataProducts, (result) => {
                $("#Card").append(
                    "<div class='CardContainer'>" +
                    "<h3>" + result.ProductName + "</h3>" +
                    "<div class='d-flex justify-content-between'>" +
                    "<p class='card-text'> Price:" + result.UnitPrice + "</p>" +
                    "<small class='fw-bold'></small>" +
                    "</div>" +
                    "<div class='d-flex justify-content-between'>" +
                    "<small class='fw-bold'> In Stock:" + result.UnitInStock + "</small> <br>" +
                    "<small class='fw-bold'> Garantie:" + result.Garantie + "</small>" +
                    "</div>"
                )
            })
        }
        else {
            $("#Card").append("<h1>No items found</h1>")
        }

    }
    catch (error) {
        console.error(error)
    }
    var urlCategory = "/Product/ListCategory"
    try {

        var getDataCategories = await GetAjaxResult(urlCategory)
        getDataCategories = JSON.parse(getDataCategories)

        if (getDataCategories != null) {
            $.map(getDataCategories, (result) => {
                $("#Categories").append(
                    "<br>" +
                    "<input class='form-check-input' value=" + result.ID + " type='radio' name='CategoryId' />" +
                    "<label class='form-check-label' for='CategoryId'>" + result.CategoryName + "</label>"
                )
            })
        }
        else {
            $("#Categories").append("<h1>No categories found</h1>")
        }

    }
    catch (error) {
        console.log(error)
    }
}

async function ListCategory() {
    var urlCategory = "/Product/ListCategory"
    try {
        var getDataCategories = await GetAjaxResult(urlCategory)
        getDataCategories = JSON.parse(getDataCategories)

        if (getDataCategories != null) {
            $.map(getDataCategories, (result) => {
                $("#Categories").append(
                    "<option value=" + result.ID + ">" + result.CategoryName + "</option > "
                )
            })
        }
        else {
            $("#Categories").append("<h1>No Categories found</h1>")
        }
    }
    catch (error) {
        console.error(error)
    }
}



//Validate Forms
$("#formValidateProduct").validate({
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
        },
        Categories: {
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
        },
        Categories: {
            required: "Please select the categories of the product"
        }
    }
})

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


//Post methods
$(document).on("submit", "#formValidateProduct", function (e) {
    e.preventDefault();
    var productModel = {
        "ProductName": $('#ProductName').val(),
        "UnitPrice": $('#UnitPrice').val(),
        "UnitInStock": $('#UnitInStock').val(),
        "Garantie": $('#Garantie').val(),
        "CategoryID": $('#Categories').val(),
    }
    PostAjaxRequest('/Product/Create', productModel)
})

$(document).on("submit", "#formValidateUser", function (e) {
    e.preventDefault();
    var userModel = {
        "UserName": $('#UserName').val(),
        "UserPassword": $('#Password').val()
    }
    PostAjaxRequest('/User/Login', userModel)
})

//Get methods with params
$(document).on("submit", "#SearchForm", async function (e) {
    e.preventDefault();
    var url = "/Product/Search"
    var model = {
        "search": $('#Search').val()
    }
    try {

        var getDataProducts = await GetAjaxResultWithParameter(url, model)
        getDataProducts = JSON.parse(getDataProducts)

        if (getDataProducts != null) {
            $("#Card").empty()
            $.map(getDataProducts, (result) => {
                $("#Card").append(
                    "<div class='CardContainer'>" +
                    "<h3>" + result.ProductName + "</h3>" +
                    "<div class='d-flex justify-content-between'>" +
                    "<p class='card-text'> Price:" + result.UnitPrice + "</p>" +
                    "<small class='fw-bold'></small>" +
                    "</div>" +
                    "<div class='d-flex justify-content-between'>" +
                    "<small class='fw-bold'> In Stock:" + result.UnitInStock + "</small> <br>" +
                    "<small class='fw-bold'> Garantie:" + result.Garantie + "</small>" +
                    "</div>"
                )
            })
        }
        else {
            $("#Card").append("<h1>No items found</h1>")
        }
    }
    catch (error) {
        console.error(error)
    }
})

$(document).on("submit", "#FilterByCategoryForm", async function (e) {
    e.preventDefault();
    var url = "/Product/FilterByCategory"
    var model = {
        "CategoryId": $('input[name=CategoryId]:checked', '#FilterByCategoryForm').val()
    }
    try {
        var getDataProducts = await GetAjaxResultWithParameter(url, model)
        getDataProducts = JSON.parse(getDataProducts)

        if (getDataProducts != null) {
            $("#Card").empty()
            $.map(getDataProducts, (result) => {
                $("#Card").append(
                    "<div class='CardContainer'>" +
                    "<h3>" + result.ProductName + "</h3>" +
                    "<div class='d-flex justify-content-between'>" +
                    "<p class='card-text'> Price:" + result.UnitPrice + "</p>" +
                    "<small class='fw-bold'></small>" +
                    "</div>" +
                    "<div class='d-flex justify-content-between'>" +
                    "<small class='fw-bold'> In Stock:" + result.UnitInStock + "</small> <br>" +
                    "<small class='fw-bold'> Garantie:" + result.Garantie + "</small>" +
                    "</div>"
                )
            })
        }
        else {
            $("#Card").append("<h1>No items found</h1>")
        }
    }
    catch (error) {
        console.error(error)
    }
})



