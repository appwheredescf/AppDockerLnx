// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function modalAddPerson(id, name, apPat, apMat) {
    
    if (id == "" || id == null) {
        $("#ICVEPERSONA").prop("readonly", false);
        $("#divID").addClass("hidden");
        $("#modalTitle").text("Agregar persona");
        $("#ICVEOPERACION").val("1");
        $("#ICVEPERSONA").val("0");
        $("#CNOMBRE").val("");
        $("#CAPPATERNO").val("");
        $("#CAPMATERNO").val("");

    } else {
        $("#divID").removeClass("hidden");
        $("#modalTitle").text("Editar persona");
        $("#ICVEPERSONA").prop("readonly", true);
        $("#ICVEPERSONA").val(id);
        $("#CNOMBRE").val(name);
        $("#CAPPATERNO").val(apPat);
        $("#CAPMATERNO").val(apMat);
        $("#ICVEOPERACION").val("2");
    }
    $("#modalAddEdit").modal("show");
}