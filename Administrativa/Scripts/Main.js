//User

    async function UserHome() {
        var url = "/User/List"
        try {
            var getDataUser = await GetAjaxResult(url)
            getDataUser = JSON.parse(getDataUser)
            if (getDataUser != null) {
                $.map(getDataUser, (result) => {
                    $("#Card").append(
                        "<div class='CardContainer'>" +
                        "<h3>" + result.FirstName + "</h3>" +
                        "<h4>" + result.UserName + "</h4>" +
                        "<div class='d-flex justify-content-between'>" +
                        "<p class='card-text'> " + result.Email + "</p>" +
                        "<p class='card-text'> " + result.Address + "</p>" +
                        "<p class='card-text'>" + result.PhoneNumber + "</p>" +
                        "<p class='card-text'>" + result.IsActive + "</p>" +
                        "<small class='fw-bold'></small>" +
                        "<div class='btn-group'>" +
                        "<button type='button' class='btn btn-primary' data-toggle='modal' data-target='#myModal' onclick='GetUserbyID(" + result.ID + ")'>Edit</button>" +
                        "<a class='btn btn-danger' onclick='DeleteUser(" + result.ID + ")'>Borrar</a>" +
                        "</div>"
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
    async function ProductHome() {
        var url = "/Product/List"
        var urlCategory = "/Category/List"

        try {
            var getDataProduct = await GetAjaxResult(url)
            getDataProduct = JSON.parse(getDataProduct)
            if (getDataProduct != null) {
                $.map(getDataProduct, (result) => {
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
                            "<small class='fw-bold'> Garantie:" + result.Discontinued + "</small>" +
                            "</div>" +
                            "<div class='btn-group'>" +
                            "<button type='button' class='btn btn-primary' data-toggle='modal' data-target='#myModal' onclick='GetProductbyID(" + result.ID + ")'>Edit</button>" +
                            "<a class='btn btn-danger' onclick='DeleteProduct(" + result.ID + ")'>Borrar</a>" +
                            "</div>"
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
        try {
            var getCategories = await GetAjaxResult(urlCategory)
            getCategories = JSON.parse(getCategories)
            if (getCategories != null) {
                $.map(getCategories, (result) => {
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
    async function CategoryHome() {
        var url = "/Category/List"
        try {
            var getDataCategories = await GetAjaxResult(url)
            getDataCategories = JSON.parse(getDataCategories)
            if (getDataCategories != null) {
                $.map(getDataCategories, (result) => {
                    $("#Card").append(
                        "<div class='CardContainer'>" +
                        "<h3>" + result.CategoryName + "</h3>" +
                        "<div class='d-flex justify-content-between'>" +
                        "<p class='card-text'>" + result.CategoryDescription + "</p>" +
                        "<small class='fw-bold'></small>" +
                        "</div>" +
                        "<div class='d-flex justify-content-between'>" +
                        "<small class='fw-bold'>" + result.IsActive + "</small>" +
                        "<small class='fw-bold'>" + result.ID + "</small>" +
                        "<div class='btn-group'>" +
                        "<button type='button' class='btn btn-primary' data-toggle='modal' data-target='#myModal' onclick='GetCategorybyID(" + result.ID + ")'>Edit</button>" +
                        "<a class='btn btn-danger' onclick='DeleteCategory(" + result.ID + ")'>Borrar</a>" +
                        "</div>"
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
function DeleteUser(ID) {
    var userModel = {
        "ID": ID
    }
    PostAjaxRequest('/User/Delete', userModel)

}
async function GetUserbyID(ID) {
        var url= "/User/GetID"
        var model = {
            "ID": ID
        }
    try {
        var getDataUser = await GetAjaxResultWithParameter(url, model)
        getDataUser = JSON.parse(getDataUser)
            $('#ID').val(getDataUser.ID);
            $('#FirstName').val(getDataUser.FirstName);
            $('#LastName').val(getDataUser.LastName);
            $('#PhoneNumber').val(getDataUser.PhoneNumber);
            $('#Email').val(getDataUser.Email);
            $('#Address').val(getDataUser.Address);
            $('#UserName').val(getDataUser.UserName);
            $('#UserPassword').val(getDataUser.UserPassword);
            $('#IsActive').val(getDataUser.IsActive);
            $('#TypeUser').val(getDataUser.TypeUser);
    }
    catch (error) {
        console.error(error)
    }
}

function UpdateUser() {
    var userModel = {
        "ID": $('#ID').val(),
        "FirstName": $('#FirstName').val(),
        "LastName": $('#LastName').val(),
        "PhoneNumber": $('#PhoneNumber').val(),
        "Email": $('#Email').val(),
        "Address": $('#Address').val(),
        "UserName": $('#UserName').val(),
        "UserPassword": $('#UserPassword').val(),
        "IsActive": $('#IsActive').val(),
        "TypeUser": $('#TypeUser').val()
    }

    PostAjaxRequest('/User/Update', userModel)
}


$("#formValidateLogin").validate({
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
$(document).on("submit", "#formValidateLogin", function (e) {
    e.preventDefault();
    var loginModel = {
        "UserName": $('#UserName').val(),
        "UserPassword": $('#Password').val()
    }
    PostAjaxRequest('/User/Login', loginModel)
})

$("#formValidateRegister").validate({
    rules: {
        Name: {
            required: true,
        },
        LastName: {
            required: true

        },
        PhoneNumber: {
            required: true

        },
        Email: {
            required: true
        },
        Address: {
            required: true

        },
        UserName: {
            required: true

        },
        Password: {
            required: true

        }
    },
    messages: {
        Name: {
            required: "Please enter your name",
        },
        LastName: {
            required: "Please enter your lastname"

        },
        PhoneNumber: {
            required: "Please enter your phonenumber"

        },
        Email: {
            required: "Please enter your email"
        },
        Address: {
            required: "Please enter your address"

        },
        UserName: {
            required: "Please enter your username"

        },
        Password: {
            required: "Please enter your password"
        }

    }
})
$(document).on("submit", "#formValidateRegister", function (e) {
    e.preventDefault();
    var userModel = {
        "FirstName": $('#FirstName').val(),
        "LastName": $('#LastName').val(),
        "PhoneNumber": $('#PhoneNumber').val(),
        "Email": $('#Email').val(),
        "Address": $('#Address').val(),
        "UserName": $('#UserName').val(),
        "UserPassword": $('#UserPassword').val(),
        "TypeUser": $('#TypeUser').val()
    }
    PostAjaxRequest('/User/Register', userModel)
})


//Products

function DeleteProduct(ID) {
    var productModel = {
        "ID": ID
    }
    PostAjaxRequest('/Product/Delete', productModel)
}
async function GetProductbyID(ID) {
        var url= "/Product/GetID"
        var model = {
            "ID": ID
        }
    try {
        var getDataProduct = await GetAjaxResultWithParameter(url, model)
        getDataProduct = JSON.parse(getDataProduct)
        $('#ID').val(getDataProduct.ID);
        $('#ProductName').val(getDataProduct.ProductName);
        $('#UnitPrice').val(getDataProduct.UnitPrice);
        $('#Garantie').val(getDataProduct.Garantie);
        $('#UnitInStock').val(getDataProduct.UnitInStock);
        $('#CategoryID').val(getDataProduct.CategoryID);
        $('#Discontinued').val(getDataProduct.Discontinued);

    }
    catch (error) {
        console.error(error)
    }
}

function UpdateProduct() {
    var productModel = {
        "ID": $('#ID').val(),
        "ProductName": $('#ProductName').val(),
        "UnitPrice": $('#UnitPrice').val(),
        "UnitInStock": $('#UnitInStock').val(),
        "Garantie": $('#Garantie').val(),
        "CategoryID": $('#Categories').val(),
        "Discontinued": $('#Discontinued').val()
    }
    PostAjaxRequest('/Product/Update', productModel)

}

$("#formValidateProducts").validate({
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
$(document).on("submit", "#formValidateProducts", function (e) {
    e.preventDefault();
    var productModel = {
        "ProductName": $('#ProductName').val(),
        "UnitPrice": $('#UnitPrice').val(),
        "UnitInStock": $('#UnitInStock').val(),
        "Garantie": $('#Garantie').val(),
        "CategoryID": $('#Categories').val()
    }
    PostAjaxRequest('/Product/Create', productModel)

})

//category

function DeleteCategory(ID) {
    var categoryModel = {
        "ID": ID
    }
    PostAjaxRequest('/Category/Delete', categoryModel)
}

async function GetCategorybyID(ID) {
    var url= "/Category/GetID"
    var model = {
        "ID": ID
    }
    try {
        var getDataCategory = await GetAjaxResultWithParameter(url, model)
        getDataCategory = JSON.parse(getDataCategory)
        $('#CategoryID').val(getDataCategory.ID);
        $('#CategoryName').val(getDataCategory.CategoryName);
        $('#CategoryDescription').val(getDataCategory.CategoryDescription);
        $('#IsActive').val(getDataCategory.IsActive);

    }
    catch (error) {
        console.error(error)
    }
}

function UpdateCategory() {
    var categoryModel = {
        "ID": $('#CategoryID').val(),
        "CategoryName": $('#CategoryName').val(),
        "CategoryDescription": $('#CategoryDescription').val(),
        "IsActive": $('#IsActive').val()
    }
    PostAjaxRequest('/Category/Update', categoryModel)
}

$("#formValidateCategory").validate({
    rules: {
        CategoryName: {
            required: true,
            minlength: 5
        },
        CategoryDescription: {
            required: true,
            minlength: 10

        }
    },
    messages: {
        CategoryName: {
            required: "Please enter the category name",
            minlength: "Name at least 5 character"
        },
        CategoryDescription: {
            required: "Please enter the description of the category",
            minlength: "Name at least 10 character"

        }
    }
})
$(document).on("submit", "#formValidateCategory", function (e) {
    e.preventDefault();
    var categoryModel = {
        "CategoryName": $('#CategoryName').val(),
        "CategoryDescription": $('#CategoryDescription').val()
    }

    PostAjaxRequest('/Category/Create', categoryModel)

})