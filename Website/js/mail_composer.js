const inputTo = document.getElementsByClassName("input-to")[0];
const autocompleteList = document.getElementsByClassName("autocomplete-list")[0];


function openMailComposer() {
    const mailComposer = document.getElementById("mail-composer");
    mailComposer.style.transform = "scale(1)";
}

function closeMailComposer() {
    const mailComposer = document.getElementById("mail-composer");
    mailComposer.style.transform = "scale(0)";

    //Reset the fly away effect for send button
    //Wait 1s for the mail composer to fully closed then reset the fly away effect
    setTimeout(resetFlyAway, 1000);
    resetAllInputValues();
}

//This function will help autocomplete the available admins
function autoComplete() {
    //Check if the input value is empty or null
    if (!inputTo.value) {
        autocompleteList.style.display = "none";
        return false;
    }
    autocompleteList.innerText = "";
    //Clear the autocompleted item and show the list
    clearAutocompleteList();
    autocompleteList.style.display = "block";

    //this boolean value will help me toggle the autocomplete list
    var isMatching = false;
    //Traverse through the suggested admins to get matching results
    for(var i = 0; i < allAdmins.length; i++) {
        if(allAdmins[i].name.substr(0, inputTo.value.length).toUpperCase() == inputTo.value.toUpperCase()) {
            //Create an autocomplete item
            var autocompleteItem = document.createElement("div");
            autocompleteItem.classList.add("autocomplete-item");
            
            //Assign the employee_id and name to the autocomplete item 
            autocompleteItem.setAttribute("data-eid", allAdmins[i].employee_id);
            autocompleteItem.setAttribute("data-name", allAdmins[i].name);

            //Call the function to save admin employee id
            autocompleteItem.setAttribute("onclick", "saveAdminEmployeeID(this);");

            //Set the suggested name to the suggested item
            //Make the letters from the start of the string to the position equal the length of the value of the input - 1 bold
            autocompleteItem.innerHTML = "<strong>" + allAdmins[i].name.substr(0, inputTo.value.length) + "</strong>";

            //Fill the remaining letters in the matching result
            autocompleteItem.innerHTML += allAdmins[i].name.substr(inputTo.value.length)

            //Add the autocomplete item to the autocomplete list
            autocompleteList.append(autocompleteItem);

            //change the isMatching to true
            isMatching = true;
        }
    }

    //If there is no matching then hide the autocomplete list
    if(!isMatching) {
        autocompleteList.style.display = "none";
    }
    
}

function clearAutocompleteList() {
    //Loop through all the children of the autocomplete list and delete them
    while (autocompleteList.firstChild) {
        autocompleteList.removeChild(autocompleteList.lastChild);
    }
}

//Hide the autocomplete list when user clicks other elements apart from it
document.addEventListener("click", function(e){
    if (e.target != inputTo) {
        clearAutocompleteList();
        autocompleteList.style.display = "none";
    }
});

//Create a function to save the employee_id of the currently selected admins
function saveAdminEmployeeID(elem) {
    //Assign the employee_id of the selected admin to the selectedReceiver variable in the data.js file
    selectedReceiver = elem.dataset.eid;

    //Update the input value to the selected admin name
    inputTo.value = elem.dataset.name;
}

//Function to make the plane svg fly
function flyAway() {
    const sendBtn = document.getElementsByClassName("send-btn")[0];

    //Toggle the clicked class for the button
    sendBtn.classList.add("clicked");
    
    //Change the text to sent 
    document.getElementsByClassName("send-text")[0].innerText = "Sent !";
}

function resetFlyAway() {
    const sendBtn = document.getElementsByClassName("send-btn")[0];

    //Toggle the clicked class for the button
    sendBtn.classList.remove("clicked");
    
    //Change the text to sent 
    document.getElementsByClassName("send-text")[0].innerText = "Sent";
}

function sendMail() {
    const inputTo = document.getElementsByClassName("input-to")[0];
    const inputSubject = document.getElementsByClassName("input-subject")[0];
    const inputMessage = document.getElementsByClassName("input-message")[0];

    if (!inputTo.value) {
        alert("At least one receivers should be chosen!");
        inputTo.focus();
        return false;
    } else if (!inputSubject.value) {
        alert("Subject of the mail should not be empty!");
        inputSubject.focus();
        return false;
    } else if(!inputMessage.value) {
        alert("Mail content should not be blank!");
        inputMessage.focus();
        return false;
    }

    var isNameExist = false;
    for(var i = 0; i < allAdmins.length; i++) {
        if (allAdmins[i].name == inputTo.value) {
            isNameExist = true;
        }
    }

    if(!isNameExist) {
        alert("Unknow receiver!");
        return false;
    }

    // Ajax code to add the mail to the database
    var xmlhttp = new XMLHttpRequest();
    xmlhttp.onreadystatechange = function() {
      if (this.readyState == 4 && this.status == 200) {
        flyAway();
      }
    };
    xmlhttp.open("GET", "sendMail.php?receiver=" + selectedReceiver + "&subject=" + inputSubject.value + "&content=" + inputMessage.value, true);
    xmlhttp.send();
}

function resetAllInputValues() {
    const inputTo = document.getElementsByClassName("input-to")[0];
    const inputSubject = document.getElementsByClassName("input-subject")[0];
    const inputMessage = document.getElementsByClassName("input-message")[0];

    inputTo.value = "";
    inputSubject.value = "";
    inputMessage.value = "";
}