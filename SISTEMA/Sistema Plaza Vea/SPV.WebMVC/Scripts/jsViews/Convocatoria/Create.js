$(function () {
    $('#dpFechaInicio').datepicker({
        format: 'dd/mm/yyyy'
    });

    $('#dpFechaFin').datepicker({
        format: 'dd/mm/yyyy'
    });

    // Event
    $('form').bind("submit", function (event) {
        var nombre = $('#txtNombreBusqueda').val();
        var fechaInicio = $("#dpFechaInicio").data('datepicker').date;
        var fechaFin = $("#dpFechaFin").data('datepicker').date;
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

        if (fechaInicio != null && fechaFin != null)
        {
            if (fechaInicio > fechaFin) {
                alert("Fecha inicio no debe ser mayor que fecha fin");
                return false;
            }
        }
    });
});