//Load Data in Table when documents is ready
$(document).ready(function () {
    loadTable();
});
//Load Data function
function loadTable() {
    var table = $('#DatoUsuarios').dataTable({
        destroy: true,
        "language": {
            "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json"
        },
        responsive: true,
        scrollY: "30em",
        scrollCollapse: true,
        ajax: {
            url: "/Usuario/CargarDatos",
            method: "GET",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            autoWidth: false,
            dataSrc: ""


        },
        columns: [
            { "data": "Empleado.Cedula" },
            { "data": "Password" },
            { "data": "Rol.Rol" },
            {
                "data": null,
                "render": function (data, type, row) {
                    return "<button type='button' class='btn btn-primary' onclick= getbyID(" + row.Empleado.Cedula + ")>" +
                        "<i class='	glyphicon glyphicon-pencil'> </i>" +
                        "</button > " +
                        "<button type='button' class='btn btn-danger'  onclick= Delete(" + row.Empleado.Cedula + ")>" +
                        "<i class='	glyphicon glyphicon-trash'> </i>" +
                        "</button > "
                }
            }

        ]
    });
}
//function loadData() {
//    $.ajax({
//        url: "/Usuario/CargarDatos",
//        type: "GET",
//        contentType: "application/json;charset=utf-8",
//        dataType: "json",
//        success: function (result) {
//            var html = '';
//            $.each(result, function (key, item) {
//                html += '<tr>';
//                html += '<td>' + item.Empleado.Cedula + '</td>';
//                html += '<td>' + item.Password + '</td>';
//                html += '<td>' + item.Rol.Rol + '</td>';
//                html += '<td><a href="#" onclick="return getbyID(' + item.IDUsuario + ')">Editar</a> | <a href="#" onclick="Delele(' + item.IDUsuario + ')">Eliminar</a></td>';
//                html += '</tr>';
//            });
//            $('.tbody').html(html);
//            $('#DatoUsuarios').dataTable().fnDestroy();
//            $('#DatoUsuarios').dataTable({ "ajax": result });
//            $('.dataTables_length').addClass('bs-select');
//        },
//        error: function (errormessage) {
//            alert(errormessage.responseText);
//        }
//    });
//}
//Add Data Function 
function Add() {
    var res = validate();
    if (res == false) {
        return false;
    }

    var usrObj = {
        Empleado: {
            Cedula: $('#Usuario').val()
        },
        Password: $('#Contraseña').val(),
        Rol: {
            ID_Rol: parseFloat($("#Rol option:selected").val())
        }
    };
    console.log(usrObj);
    try {
        $.ajax({
            url: "/Usuario/Agregar",
            data: JSON.stringify(usrObj),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                loadTable();
                $('#myModal').modal('hide');
                clearTextBox();
            },
            error: function (result) {
                alert('Revise los datos agregados, ya que no pueden haber campos vacios o cedulas repetidas');
            }
        });
    } catch (err) { alert('Revise los datos agregados, ya que no pueden haber campos vacios o cedulas repetidas'); }
}


//Function for getting the Data Based upon Employee ID
function getbyID(IDUsuario) {
    $.ajax({
        url: "/Usuario/consultar/" + IDUsuario,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            console.log(result.Rol.ID_Rol);
            $('#Usuario').val(result.Empleado.Cedula);
            $('#Contraseña').val(result.Password);
            $("#Rol option[value='" + result.Rol.ID_Rol + "']").attr("selected", true);
            $('#myModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
            $("#Usuario").prop("disabled", true);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}
//function for updating employee's record
function Update() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var usrObj = {
        Empleado: {
            Cedula: $('#Usuario').val()
        },
        Password: $('#Contraseña').val(),
        Rol: {
            ID_Rol: parseFloat($("#Rol option:selected").val())
        }
    };
    $.ajax({
        url: "/Usuario/Actualizar/",
        data: JSON.stringify(usrObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadTable();
            $('#myModal').modal('hide');

            clearTextBox();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//function for deleting employee's record
function Delete(ID) {
    console.log(ID);
    $.ajax({
        url: "/Usuario/Eliminar/" + ID + "",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            loadTable();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}
//Cargar agregar div
function cargarAgregar() {
    clearTextBox();
}

    //Function for clearing the textboxes
    function clearTextBox() {
        $('#Usuario').val("");
        $('#Contraseña').val("");
        $('#btnUpdate').hide();
        $('#btnAdd').show();
        $("#Usuario").prop("disabled", false);
        $('#Usuario').css('border-color', 'lightgrey');
        $('#Contraseña').css('border-color', 'lightgrey');
        $('#Rol').css('border-color', 'lightgrey');
    }


    // Validar datos
    function validate() {
        var isValid = true;
        if ($('#Usuario').val().trim() == "") {
            $('#Usuario').css('border-color', 'Red');
            isValid = false;
        }
        else {
            $('#Usuario').css('border-color', 'lightgrey');
        }
        if ($('#Contraseña').val().trim() == "") {
            $('#Contraseña').css('border-color', 'Red');
            isValid = false;
        }
        else {
            $('#Contraseña').css('border-color', 'lightgrey');
        }
        if ($('#Rol').val().trim() == "") {
            $('#Rol').css('border-color', 'Red');
            isValid = false;
        }
        else {
            $('#Rol').css('border-color', 'lightgrey');
        }
        return isValid;
    }
