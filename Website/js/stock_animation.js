//Create event handlers 
var searchInput = document.getElementById("search-input");
searchInput.addEventListener("input", updateDepotItemTable);
var depotItemList = document.getElementById("depot-item-list");
var filterInput = document.getElementsByClassName("filter-input")[0];


//This function will help filling in the input value depending on the value the user chose
function fillFilterInput(elem) {
    var filterInput = document.getElementsByClassName("filter-input")[0];
    if (elem.innerText == "ID") {
        filterInput.innerText = "ID";
    } else if (elem.innerText == "Name") {
        filterInput.innerText = "Name";
    }
}

function updateDepotItemTable() {
    if(filterInput.innerText == "ID") {
        searchByID();
    } else if (filterInput.innerText == "Name") {
        searchByName();
    }
}

function searchByID() {
    var filter = searchInput.value.toUpperCase();
    var tr = document.getElementsByClassName("depot-item-row");
    
    clearEliminatedClass();
    for (var i = 0; i < tr.length; i++) {
        var td = tr[i].getElementsByTagName("td")[0];
        if (td) {
          var txtValue = td.textContent || td.innerText;
          if (txtValue.toUpperCase().indexOf(filter) > -1) {
            tr[i].style.transform = "translate(0)";
            tr[i].style.opacity = 1;
            tr[i].style.display = "";
          } else {
            tr[i].style.transform = "translateX(-200px)";
            tr[i].classList.add("eliminated");
            tr[i].style.opacity = 0;
          }
        }
    }
    setTimeout(removeRowHavingEliminatedClass, 300);
}

function searchByName() {
    var filter = searchInput.value.toUpperCase();
    var tr = document.getElementsByClassName("depot-item-row");

    clearEliminatedClass();

    for (var i = 0; i < tr.length; i++) {
        var td = tr[i].getElementsByTagName("td")[1];
        if (td) {
          var txtValue = td.textContent || td.innerText;
          if (txtValue.toUpperCase().indexOf(filter) > -1) {
            tr[i].style.transform = "translate(0)";
            tr[i].style.opacity = 1;
            tr[i].style.display = "";
          } else {
            tr[i].style.transform = "translateX(-200px)";
            tr[i].classList.add("eliminated");
            tr[i].style.opacity = 0;
          }
        }
    }
    setTimeout(removeRowHavingEliminatedClass, 300);
}

function clearEliminatedClass() {
    var rowList = document.getElementsByClassName("depot-item-row");
    for (var i = 0; i < rowList.length; i++) {
        if (rowList[i].classList.contains("eliminated")) {
            rowList[i].classList.remove("eliminated");
        }
    }
}

function removeRowHavingEliminatedClass() {
    var rowList = document.getElementsByClassName("depot-item-row");
    for (var i = 0; i < rowList.length; i++) {
        if (rowList[i].classList.contains("eliminated")) {
            rowList[i].style.display = "none";
        }
    }
}