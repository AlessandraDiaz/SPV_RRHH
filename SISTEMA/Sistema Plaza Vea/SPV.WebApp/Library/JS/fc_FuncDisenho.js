function setTabCabeceraOn(strIndiceTab) {
    try {
        objTableTab = document.getElementById("tblHeader" + strIndiceTab);
        if (objTableTab != null) {
            objImgIzq = objTableTab.rows[0].cells[0].firstChild;
            objTdCentro = objTableTab.rows[0].cells[1];
            objImgDer = objTableTab.rows[0].cells[2].firstChild;

            if (objTdCentro != null) objTdCentro.className = "TabCabeceraOn";
            /*if ( objImgIzq != null ) objImgIzq.src = "../Images/Tabs/tab-izq_on.gif"
            if ( objImgDer != null ) objImgDer.src = "../Images/Tabs/tab-der_on.gif"*/
        }
    }
    catch (e) {
        strMsg = e.message;
    }
}

var strClassNameOff = "";

function onTabCabeceraOver(strIndiceTab) {
    try {
        objTableTab = document.getElementById("tblHeader" + strIndiceTab);
        if (objTableTab != null) {
            objImgIzq = objTableTab.rows[0].cells[0].firstChild;
            objTdCentro = objTableTab.rows[0].cells[1];
            objImgDer = objTableTab.rows[0].cells[2].firstChild;

            strClassNameOff = objTdCentro.className;
            if (objTdCentro != null) objTdCentro.className = "TabCabeceraOn";
            /*if ( objImgIzq != null ) objImgIzq.src = "../Images/Tabs/tab-izq_on.gif"
            if ( objImgDer != null ) objImgDer.src = "../Images/Tabs/tab-der_on.gif"*/
        }
    }
    catch (e) {
        strMsg = e.message;
    }
}


function onTabCabeceraOut(strIndiceTab) {
    try {
        objTableTab = document.getElementById("tblHeader" + strIndiceTab);
        if (objTableTab != null) {
            objImgIzq = objTableTab.rows[0].cells[0].firstChild;
            objTdCentro = objTableTab.rows[0].cells[1];
            objImgDer = objTableTab.rows[0].cells[2].firstChild;

            if (objTdCentro != null) objTdCentro.className = strClassNameOff;
            /*if ( objImgIzq != null ) objImgIzq.src = "../Images/Tabs/tab-izq.gif"
            if ( objImgDer != null ) objImgDer.src = "../Images/Tabs/tab-der.gif"*/
        }
    }
    catch (e) {
        strMsg = e.message;
    }
}

/*Funciones para cabeceras de TAB's que no sean de mantenimientos*/
var strClassNameOffForm = "";
var strImgIzqOffForm = "";
var strImgDerOffForm = "";

function setTabCabeceraOffForm(strIndiceTab) {
    try {
        objTableTab = document.getElementById("tblHeader" + strIndiceTab);
        if (objTableTab != null) {
            objImgIzq = objTableTab.rows[0].cells[0].firstChild;
            objTdCentro = objTableTab.rows[0].cells[1];
            objImgDer = objTableTab.rows[0].cells[2].firstChild;

            if (objTdCentro != null) objTdCentro.className = "TabCabeceraOffForm";
            if (objImgIzq != null) objImgIzq.src = "../Images/Tabs/tab-izq_off_plom.gif"
            if (objImgDer != null) objImgDer.src = "../Images/Tabs/tab-der_off_plom.gif"
        }
    }
    catch (e) {
        strMsg = e.message;
    }
}

function setTabCabeceraOnForm(strIndiceTab) {
    try {
        objTableTab = document.getElementById("tblHeader" + strIndiceTab);
        if (objTableTab != null) {
            objImgIzq = objTableTab.rows[0].cells[0].firstChild;
            objTdCentro = objTableTab.rows[0].cells[1];
            objImgDer = objTableTab.rows[0].cells[2].firstChild;

            if (objTdCentro != null) objTdCentro.className = "TabCabeceraOnForm";
            if (objImgIzq != null) objImgIzq.src = "../Images/Tabs/tab-izq.gif"
            if (objImgDer != null) objImgDer.src = "../Images/Tabs/tab-der.gif"
        }
    }
    catch (e) {
        strMsg = e.message;
    }
}

function onTabCabeceraOverForm(strIndiceTab) {
    try {
        objTableTab = document.getElementById("tblHeader" + strIndiceTab);
        if (objTableTab != null) {
            objImgIzq = objTableTab.rows[0].cells[0].firstChild;
            objTdCentro = objTableTab.rows[0].cells[1];
            objImgDer = objTableTab.rows[0].cells[2].firstChild;

            strClassNameOffForm = objTdCentro.className;

            if (objImgIzq != null) strImgIzqOffForm = objImgIzq.src;
            if (objImgDer != null) strImgDerOffForm = objImgDer.src;

            if (objTdCentro != null) objTdCentro.className = "TabCabeceraOnForm";
            if (objImgIzq != null) objImgIzq.src = "../Images/Tabs/tab-izq.gif"
            if (objImgDer != null) objImgDer.src = "../Images/Tabs/tab-der.gif"
        }
    }
    catch (e) {
        strMsg = e.message;
    }
}


function onTabCabeceraOutForm(strIndiceTab) {
    try {
        objTableTab = document.getElementById("tblHeader" + strIndiceTab);

        if (objTableTab != null) {
            objImgIzq = objTableTab.rows[0].cells[0].firstChild;
            objTdCentro = objTableTab.rows[0].cells[1];
            objImgDer = objTableTab.rows[0].cells[2].firstChild;

            if (objTdCentro != null && strClassNameOffForm != "") objTdCentro.className = strClassNameOffForm;
            if (objImgIzq != null && strImgIzqOffForm != "") objImgIzq.src = strImgIzqOffForm;
            if (objImgDer != null && strImgDerOffForm != "") objImgDer.src = strImgDerOffForm;
        }
    }
    catch (e) {
        strMsg = e.message;
    }
}


/*Funciones para cabeceras de TAB de TAB's*/
var strClassNameOffTabToTab = "";
var strImgIzqOffTabToTab = "";
var strImgDerOffTabToTab = "";

function setTabCabeceraOffTabToTab(strIndiceTab) {
    try {
        objTableTab = document.getElementById("tblHeader" + strIndiceTab);
        if (objTableTab != null) {
            objImgIzq = objTableTab.rows[0].cells[0].firstChild;
            objTdCentro = objTableTab.rows[0].cells[1];
            objImgDer = objTableTab.rows[0].cells[2].firstChild;

            if (objTdCentro != null) objTdCentro.className = "TabCabeceraOffTabToTab";
            if (objImgIzq != null) objImgIzq.src = "../Images/Tabs/taboff2-izq_vf.gif"
            if (objImgDer != null) objImgDer.src = "../Images/Tabs/taboff2-der_vf.gif"
        }
    }
    catch (e) {
        strMsg = e.message;
    }
}

function setTabCabeceraOnTabToTab(strIndiceTab) {
    try {
        objTableTab = document.getElementById("tblHeader" + strIndiceTab);
        if (objTableTab != null) {
            objImgIzq = objTableTab.rows[0].cells[0].firstChild;
            objTdCentro = objTableTab.rows[0].cells[1];
            objImgDer = objTableTab.rows[0].cells[2].firstChild;

            if (objTdCentro != null) objTdCentro.className = "TabCabeceraOnTabToTab";
            if (objImgIzq != null) objImgIzq.src = "../Images/Tabs/tabon2-izq_vf.gif"
            if (objImgDer != null) objImgDer.src = "../Images/Tabs/tabon2-der_vf.gif"
        }
    }
    catch (e) {
        strMsg = e.message;
    }
}

function onTabCabeceraOverTabToTab(strIndiceTab) {
    try {
        objTableTab = document.getElementById("tblHeader" + strIndiceTab);
        if (objTableTab != null) {
            objImgIzq = objTableTab.rows[0].cells[0].firstChild;
            objTdCentro = objTableTab.rows[0].cells[1];
            objImgDer = objTableTab.rows[0].cells[2].firstChild;

            strClassNameOffTabToTab = objTdCentro.className;

            if (objImgIzq != null) strImgIzqOffTabToTab = objImgIzq.src;
            if (objImgDer != null) strImgDerOffTabToTab = objImgDer.src;

            if (objTdCentro != null) objTdCentro.className = "TabCabeceraOnTabToTab";
            if (objImgIzq != null) objImgIzq.src = "../Images/Tabs/tabon2-izq_vf.gif"
            if (objImgDer != null) objImgDer.src = "../Images/Tabs/tabon2-der_vf.gif"
        }
    }
    catch (e) {
        strMsg = e.message;
    }
}


function onTabCabeceraOutTabToTab(strIndiceTab) {
    try {
        objTableTab = document.getElementById("tblHeader" + strIndiceTab);

        if (objTableTab != null) {
            objImgIzq = objTableTab.rows[0].cells[0].firstChild;
            objTdCentro = objTableTab.rows[0].cells[1];
            objImgDer = objTableTab.rows[0].cells[2].firstChild;

            if (objTdCentro != null && strClassNameOffTabToTab != "") objTdCentro.className = strClassNameOffTabToTab;
            if (objImgIzq != null && strImgIzqOffTabToTab != "") objImgIzq.src = strImgIzqOffTabToTab;
            if (objImgDer != null && strImgDerOffTabToTab != "") objImgDer.src = strImgDerOffTabToTab;
        }
    }
    catch (e) {
        strMsg = e.message;
    }
}