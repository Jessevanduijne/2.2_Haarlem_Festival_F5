thursday();

function reset() {
    document.getElementsByClassName("tableButton ButtonActive")[0].className = "tableButton ButtonInactive";
    document.getElementsByClassName("table tableActive")[0].className = "table tableInactive";
}

function thursday() {
    document.getElementsByClassName("tableButton")[0].className = "tableButton ButtonActive";
    document.getElementsByClassName("table")[0].className = "table tableActive";
}

function friday() {
    reset();

    document.getElementsByClassName("tableButton")[1].className = "tableButton ButtonActive";
    document.getElementsByClassName("table")[1].className = "table tableActive";
}

function saturday() {
    reset();

    document.getElementsByClassName("tableButton")[2].className = "tableButton ButtonActive";
    document.getElementsByClassName("table")[2].className = "table tableActive";
}

function sunday() {
    reset();

    document.getElementsByClassName("tableButton")[3].className = "tableButton ButtonActive";
    document.getElementsByClassName("table")[3].className = "table tableActive";
}

function PopUp(eventId, Name) {
    var x = document.getElementById("title");
    x.innerText = Name;
    var z = document.getElementsByName("EventId")[0];
    z.value = eventId;
    var y = document.getElementById("Popup");
    y.style.visibility = "visible";
    y.style.display = "block";
}

function Close() {
    var x = document.getElementById("Popup");
    x.style.visibility = "hidden";
    x.style.display = "none";
}