//By default when the user go to the mail inbox, they will see all the mails received
//By default the user will be in the inbox tab
const inboxTab = document.getElementById("sidebar-inboxes").getElementsByTagName("li")[0].childNodes[0];

fillReceivedMails(inboxTab);

//Update unread mails
updateUnreadMails();


function fillReceivedMails(elem = null) {
    //Display default email content when user changes tab
    displayDefaultEmailContent();

    const emailList = document.getElementsByClassName("email-list")[0];
    emailList.innerText = "";

    for(var i = 0; i < receivedMails.length; i++) {
        if (receivedMails[i].deletedFromEmployee == 0) {
            // Create email item
            var emailItem = document.createElement("div");
            emailItem.classList.add("email-item");
            emailItem.setAttribute("onclick", "getEmailItemContentInbox(this);");
            emailItem.setAttribute("data-mid", receivedMails[i].mail_id);

            // Create unread dot
            var emailItemUnreadDot = document.createElement("div");
            emailItemUnreadDot.classList.add("email-item-unread-dot");

            if (receivedMails[i].status == 0) {
                emailItemUnreadDot.setAttribute("data-read", "false");
            } else {
                emailItemUnreadDot.setAttribute("data-read", "true");
            }

            // Create subject div
            var emailItemSubject = document.createElement("div");
            emailItemSubject.classList.add("email-item-subject");
            emailItemSubject.classList.add("truncate");
            emailItemSubject.innerText = receivedMails[i].subject;

            //Create email item details 
            var emailItemDetails = document.createElement("div");
            emailItemDetails.classList.add("email-item-details");

            //Create email item from and email item time
            var emailItemFrom = document.createElement("span");
            var emailItemTime = document.createElement("span");

            emailItemFrom.classList.add("email-item-from");
            emailItemFrom.innerText = receivedMails[i].sender;

            emailItemTime.classList.add("email-item-time");
            emailItemTime.innerText = receivedMails[i].date;

            //Add two spans to the email item details 
            emailItemDetails.appendChild(emailItemTime);
            emailItemDetails.appendChild(emailItemFrom);

            //Add email item subject, unread dot and details to email item
            emailItem.appendChild(emailItemUnreadDot);
            emailItem.appendChild(emailItemSubject);
            emailItem.appendChild(emailItemDetails);

            //Add the create email item to the email list
            emailList.appendChild(emailItem);
        }
        
    }

    //Indidcate currently active tab
    if (elem != null) {
        indicateActiveTab(elem);
    }
}


function getEmailItemContentInbox(elem) {
    var subject = "";
    var sender = "";
    var date = "";
    var content = "";

    for(var i = 0; i < receivedMails.length; i++) {
        if(receivedMails[i].mail_id == elem.dataset.mid) {
            subject = receivedMails[i].subject;
            sender = receivedMails[i].sender;
            date = receivedMails[i].date;
            content = receivedMails[i].content;
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
    deleteBtn.setAttribute("onclick", "removeTheSelectedItemFromEmployeeInbox(this);");
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

    //Add the email content header and email content message to the email content 
    emailContent.appendChild(emailContentHeader);
    emailContent.appendChild(emailContentMessage);

    // Change email status to read instad of unread
    elem.childNodes[0].dataset.read = "true";

    //Using ajax to update the status of the corresponsing mail
    var xmlhttp = new XMLHttpRequest();
    xmlhttp.onreadystatechange = function() {
      if (this.readyState == 4 && this.status == 200) {
        //Doing nothing
      }
    };
    xmlhttp.open("GET", "./updateStatusMail.php?mid=" + elem.dataset.mid, true);
    xmlhttp.send();

    //Update Unread Mails
    for(var i = 0; i < receivedMails.length; i++) {
        if(receivedMails[i].mail_id == elem.dataset.mid) {
            receivedMails[i].status = 1;
        }
    }
    updateUnreadMails();

    //Indicate selected mail item
    indicateSelectedEmailItem(elem);
}

function updateUnreadMails() {
    var counter = 0;
    for(var i = 0; i < receivedMails.length; i++) {
        if (receivedMails[i].status == 0) {
            counter++;
        }
    }

    if (counter == 0) {
        document.getElementsByClassName("item-count-inbox")[0].innerText = "";
    } else {
        document.getElementsByClassName("item-count-inbox")[0].innerText = counter;
    }
}

function displayDefaultEmailContent() {
    const emailContent = document.getElementsByClassName("email-content")[0];
    emailContent.innerText = "";

    var tempImg = document.createElement("img");
    tempImg.setAttribute("src", "img/logo.png");

    var tempH2 = document.createElement("h2");
    tempH2.innerText = "Chances to communicate with your administrators!";

    var tempP = document.createElement("p");
    tempP.innerText = "Here at LogiK, we developed an internal mailing system where you can exchange information with your administrators straight from the website you are accessing.";

    emailContent.appendChild(tempImg);
    emailContent.appendChild(tempH2);
    emailContent.appendChild(tempP);
}

function indicateSelectedEmailItem(elem) {
    const emailList = document.getElementsByClassName("email-list")[0];

    resetAllSelectedEmailItem();

    for(var i = 0; i < emailList.childNodes.length; i++) {
        if (emailList.childNodes[i] == elem) {
            emailList.childNodes[i].classList.add("selected");
        }
    }
}

function resetAllSelectedEmailItem() {
    const emailList = document.getElementsByClassName("email-list")[0];

    for(var i = 0; i < emailList.childNodes.length; i++) {
        if (emailList.childNodes[i].classList.contains("selected")) {
            emailList.childNodes[i].classList.remove("selected");
        }
    }
}

function removeTheSelectedItemFromEmployeeInbox(elem) {
    for(var i = 0; i < receivedMails.length; i++) {
        if(receivedMails[i].mail_id == elem.dataset.mid) {
            receivedMails[i].deletedFromEmployee = 1;
        }
    }

    //Make ajax request to update the corresponsing mail in the DB for deletedFromEmployee to 1 (deleted)
    var xmlhttp = new XMLHttpRequest();
    xmlhttp.onreadystatechange = function() {
      if (this.readyState == 4 && this.status == 200) {
        //Doing nothing
      }
    };
    xmlhttp.open("GET", "./updateDeletedFromEmployee.php?mid=" + elem.dataset.mid, true);
    xmlhttp.send();

    //Update the deleted mail item count
    updateDeletedMails();

    //Update the email list in place
    fillReceivedMails();
    
}

function indicateActiveTab(elem) {
    resetAllTabs();

    document.getElementById("sidebar-inboxes").classList.remove("currently-active");
    elem.parentNode.classList.add("currently-active");
}

function resetAllTabs() {
    const sidebarInboxes = document.getElementById("sidebar-inboxes").getElementsByTagName("li");

    for(var i = 0; i < sidebarInboxes.length; i++) {
        if (sidebarInboxes[i].classList.contains("currently-active")) {
            sidebarInboxes[i].classList.remove("currently-active");
        }
    }
}