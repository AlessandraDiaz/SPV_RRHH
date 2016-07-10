$(function () {
    // Event
    $('form').bind("submit", function (event) {
        var nombre = $('#txtNombreBusqueda').val();
        var tipoConvocatoria = $('#cboTipoConvocatoria').val();
        var solicitud = $('#cboSolicitud').val();

        
        if (tipoConvocatoria == '') {
            alert("Debe seleccionar convocatoria");
            return false;
        }

        if (solicitud == '') {
            alert("Debe seleccionar solicitud");
            return false;
        }
    });
});