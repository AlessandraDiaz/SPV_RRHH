//EXPRESIONES REGULARES
var RE_ALAFANUMERICO = /^[\w\d áéíóúAÉÍÓÚÑñüÜ_.,/ \\ \-]+$/i;
var RE_ALAFANUMERICONOESP = /^[\w\dáéíóúAÉÍÓÚÑñ]+$/i;
var RE_SOLONRO = /^\d+$/i;
var RE_EMAIL = /\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/i;
var RE_WEB = /\w+([-+.']\w+)*\w+([-.]\w+)*\.\w+([-.]\w+)*/i;
var RE_COLORWEB = /^#?([a-f]|[A-F]|[0-9]){3}(([a-f]|[A-F]|[0-9]){3})?$/i;
var RE_PATH = /([A-Z]:\\[^/:\*\?<>\|]+\.\w{2,6})|(\\{2}[^/:\*\?<>\|]+\.\w{2,6})/i;
var RE_IP = /^(?:25[0-5]|2[0-4]\d|1\d\d|[1-9]\d|\d)(?:[.](?:25[0-5]|2[0-4]\d|1\d\d|[1-9]\d|\d)){3}$/i;
var RE_PRECIO = /^(-)?\d+(\.\d?\d?)?$/i;
var RE_NRO_DECIMAL = /^[\ \d ,.]+$/i;///^[\- \d ,.]+$/i;
var MASCARA_FECHA = '__/__/____';
var RE_CUENTA_CORRIENTE = /^[\d \- /]*$/i;
var RE_NUMERO_TELEFONO = /^[\d () \- /]*$/i;
var RE_PLACA = /^[\w\d\ñÑ\-]*$/i;
var RE_CODIGO = /^[\w\d\-_.]*$/i;
var RE_NRO_VERSION = /^[\d.]+$/i;
var RE_NRO_DECIMAL_ESP = /^(\d*)\.{1}*\d{1,6}$/i;
/******************************************************
Descripción :    Permite validar numero decimales con un PUNTO(decimal) y enteros y 3 decimales, tbn acepta solo enteros (positivos) - RE_NRO_DECIMALM
Autor 		:    Remy Yactayo Hinostroza
Fecha/hora	:    20/04/2010
******************************************************/
var RE_NRO_DECIMALM = /^(\d*)\.{1}*\d{1,3}$/i;
