//Update deleted mails
updateDeletedMails();


function fillDeletedMails(elem = null) {
    //Display default email content when user changes tab
    displayDefaultEmailContent();

    const emailList = document.getElementsByClassName("email-list")[0];
    emailList.innerText = "";

    updateDeletedMails();
    
    for(var i = 0; i < deletedMails.length; i++) {
        // Create email item
        var emailItem = document.createElement("div");
        emailItem.classList.add("email-item");
        emailItem.setAttribute("onclick", "getEmailItemContentDeleted(this);");
        emailItem.setAttribute("data-mid", deletedMails[i].mail_id);

        // Create subject div
        var emailItemSubject = document.createElement("div");
        emailItemSubject.classList.add("email-item-subject");
        emailItemSubject.classList.add("truncate");
        emailItemSubject.innerText = deletedMails[i].subject;

        //Create email item details 
        var emailItemDetails = document.createElement("div");
        emailItemDetails.classList.add("email-item-details");

        //Create email item from and email item time
        var emailItemFrom = document.createElement("span");
        var emailItemTime = document.createElement("span");

        emailItemFrom.classList.add("email-item-from");
        emailItemFrom.innerText = deletedMails[i].sender;

        emailItemTime.classList.add("email-item-time");
        emailItemTime.innerText = deletedMails[i].date;

        //Add two spans to the email item details 
        emailItemDetails.appendChild(emailItemTime);
        emailItemDetails.appendChild(emailItemFrom);

        //Add email item subject and details to email item
        emailItem.appendChild(emailItemSubject);
        emailItem.appendChild(emailItemDetails);

        //Add the create email item to the email list
        emailList.appendChild(emailItem);
    }

    if (elem != null) {
        indicateActiveTab(elem);
    }
}

function updateDeletedMails() {
    // Clear the deleted mails array
    deletedMails = [];
    //Put all the received mails that are deleted by the employee to the deleted emails array
    for(var i = 0; i < receivedMails.length; i++) {
        if (receivedMails[i].deletedFromEmployee == 1 && receivedMails[i].deletedFromEmployeeForever == 0) {
            deletedMails.push(receivedMails[i]);
        }
    }

    //Put all the sent mails that are deleted by the employee to the deleted emails array
    for(var i = 0; i < sentMails.length; i++) {
        if (sentMails[i].deletedFromEmployee == 1 && sentMails[i].deletedFromEmployeeForever == 0) {
            deletedMails.push(sentMails[i]);
        }
    }

    //Change the item count for trash
    document.getElementsByClassName("item-count-trash")[0].innerText = deletedMails.length;
}

function getEmailItemContentDeleted(elem) {
    var subject = "";
    var sender = "";
    var receiver = "";
    var date = "";
    var content = "";

    for(var i = 0; i < deletedMails.length; i++) {
        if(deletedMails[i].mail_id == elem.dataset.mid) {
            subject = deletedMails[i].subject;
            sender = deletedMails[i].sender;
            //Check if object contains the value receiver
            if (deletedMails[i].receiver != undefined) {
                receiver = deletedMails[i].receiver;
            }
            date = deletedMails[i].date;
            content = deletedMails[i].content;
        }
    }

    const emailContent = document.getElementsByClassName("email-content")[0];
    emailContent.innerText = "";

    //Create email content header
    var emailContentHeader = document.createElement("div");
    emailContentHeader.classList.add("email-content-header");

    //Create email content subject
    var emailContentSubject = document.createElement("h3");
    emailContentSubject.classList.add("email-content-subject");
    emailContentSubject.innerText = subject;

    //Create delete button
    var deleteBtn = document.createElement("span");
    deleteBtn.classList.add("delete-btn");
    var trashIcon = document.createElement("i");
    trashIcon.classList.add("fa");
    trashIcon.classList.add("fa-trash");
    deleteBtn.appendChild(trashIcon);
    deleteBtn.setAttribute("onclick", "removeTheMailForever(this);")
    deleteBtn.setAttribute("data-mid", elem.dataset.mid);

    //Create email content time
    var emailContentTime = document.createElement("div");
    emailContentTime.classList.add("email-content-time");
    emailContentTime.innerText = date;

    //Create email content from 
    var emailContentFrom = document.createElement("div");
    emailContentFrom.classList.add("email-content-from");
    emailContentFrom.innerText = sender;

    //Add these to the email content header
    emailContentHeader.appendChild(emailContentSubject);
    emailContentHeader.appendChild(deleteBtn);
    emailContentHeader.appendChild(emailContentTime);
    emailContentHeader.appendChild(emailContentFrom);


    //Create email content message 
    var emailContentMessage = document.createElement("div");
    emailContentMessage.classList.add("email-content-message");
    emailContentMessage.innerText = content;
    //Add receiver info
    //Only display receiver info on sent message
    if (receiver != "") {
        var receiverInfo = document.createElement("div");
        receiverInfo.classList.add("receiver-info");
        receiverInfo.innerText = "\n\n\nRECEIVER: " + receiver;
        emailContentMessage.appendChild(receiverInfo);
    }

    //Add the email content header and email content message to the email content 
    emailContent.appendChild(emailContentHeader);
    emailContent.appendChild(emailContentMessage);

    //Indicate selected mail item
    indicateSelectedEmailItem(elem);
}

function removeTheMailForever(elem) {
    var xmlhttp = new XMLHttpRequest();
    xmlhttp.onreadystatechange = function() {
      if (this.readyState == 4 && this.status == 200) {
        //Doing nothing
      }
    };
    xmlhttp.open("GET", "./updateDeletedFromEmployeeForever.php?mid=" + elem.dataset.mid, true);
    xmlhttp.send();

    for(var i = 0; i < deletedMails.length; i++) {
        if (deletedMails[i].mail_id == elem.dataset.mid) {
            deletedMails[i].deletedFromEmployeeForever = 1;
        }
    }

    updateDeletedMails();
    fillDeletedMails();
}