//General
var mstrGrabar = "Se grabó exitosamente.";
var mstrErrorGrabar = "No se grabo correctamente.";
var mstrElimino = "Se eliminó exitosamente.";
var mstrActualizar = "Se actualizó exitosamente.";
var mstrNoElimino = "No se pudo realizar la acción, consultar con el administrador.";
var mstrNoEliminoRelacionado = "No se puede realizar la acción,\nel registro seleccionado se encuentra relacionado con otros registros del sistema.";
var mstrNoRegistros = "No se encontraron coincidencias.";
var mstrSeleccioneUno = "Debe seleccionar un registro.";
var mstrSeleccioneVarios = "Debe seleccionar al menos un registro.";
var mstrAsigneVarios = "Debe asignar al menos un registro.";

var mstrSeguroGrabar = "¿Está seguro de grabar?";
var mstrSeguroEliminarUno = "¿Está seguro de eliminar?";
var mstrSeguroExtraerExactus = "¿Está seguro de extraer los datos de EXACTUS? \neste proceso puede tardar algunos minutos.";

var mstrLongitudRUC = "- El campo RUC debe tener 11 caracteres.";
var mstrRUCInvalido = "- El campo RUC no es válido.";
var mstrRucDuplicado = "El campo RUC ya se encuentra registrado.";


//mensajes de validaciones.
var mstrPermitidos = " contiene caracteres no válidos, los permitidos son:";
var mstrDebeIngresar = "- Debe ingresar ";
var mstrDebeSeleccionar = "- Debe seleccionar ";
var mstrElCampo = "- El campo ";
var mstrReAlfanumerico = mstrPermitidos + " A-Z a-z áéíóú üÜ 0-9 Ññ /- _ , . .\n";
var mstrReSoloNro = mstrPermitidos + " 0-9 .\n";
var mstrCodigo = mstrPermitidos + " A-Z a-z 0-9 - _ .\n";
var mstrCorreo = mstrPermitidos + " A-Z a-z @ . _ .\n";
var mstrPlaca = mstrPermitidos + " A-Z a-z 0-9 Ññ - .\n";
var mstrTelefono = mstrPermitidos + " 0-9 - _ .\n";
var mstrDecimal = mstrPermitidos + " 0-9 , . .\n";
var mstrVersion = mstrPermitidos + "0-9 . .\n";
var mstrFormatoIncorrecto = " no tiene el formato correcto.\n";
var mstrFecha = " contiene caracteres no válidos, el formato es: DD/MM/AAAA.\n";
var mstrHora = " contiene caracteres no válidos.\n";
var mstrMayor = " debe ser mayor que ";
var mstrMayorIgual = " debe ser mayor o igual que ";
var mstrMenorIgual = " debe ser menor o igual que ";
var mstrMayorCero = " debe ser mayor a cero.\n";
var mstrRangoUnoCien = " debe contener un rango del [ 1-100 ].\n";
var mstrRangoCeroCien = " debe contener un rango del [ 0-100 ].\n";
var mstrTotalMenoroIgualCien = "- La suma total debe ser menor o igual a 100.\n";
var mstrFechaMala = " esta fuera del rango permitido.\n";
var mstrFechaFueraRango = mstrDebeIngresar + " un rango de fechas válidas.";
