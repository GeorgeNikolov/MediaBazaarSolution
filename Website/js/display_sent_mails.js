function fillSentMails(elem = null) {
    //Display default email content when user changes tab
    displayDefaultEmailContent();

    const emailList = document.getElementsByClassName("email-list")[0];
    emailList.innerText = "";

    for(var i = 0; i < sentMails.length; i++) {
        if (sentMails[i].deletedFromEmployee == 0) {
            // Create email item
            var emailItem = document.createElement("div");
            emailItem.classList.add("email-item");
            emailItem.setAttribute("onclick", "getEmailItemContentSent(this);");
            emailItem.setAttribute("data-mid", sentMails[i].mail_id);

            // Create subject div
            var emailItemSubject = document.createElement("div");
            emailItemSubject.classList.add("email-item-subject");
            emailItemSubject.classList.add("truncate");
            emailItemSubject.innerText = sentMails[i].subject;

            //Create email item details 
            var emailItemDetails = document.createElement("div");
            emailItemDetails.classList.add("email-item-details");

            //Create email item from and email item time
            var emailItemFrom = document.createElement("span");
            var emailItemTime = document.createElement("span");

            emailItemFrom.classList.add("email-item-from");
            emailItemFrom.innerText = sentMails[i].sender;

            emailItemTime.classList.add("email-item-time");
            emailItemTime.innerText = sentMails[i].date;

            //Add two spans to the email item details 
            emailItemDetails.appendChild(emailItemTime);
            emailItemDetails.appendChild(emailItemFrom);

            //Add email item subject and details to email item
            emailItem.appendChild(emailItemSubject);
            emailItem.appendChild(emailItemDetails);

            //Add the create email item to the email list
            emailList.appendChild(emailItem);
        }
        
    }

    if (elem != null) {
        indicateActiveTab(elem);
    }

    
}

function getEmailItemContentSent(elem) {
    var subject = "";
    var sender = "";
    var receiver = "";
    var date = "";
    var content = "";

    for(var i = 0; i < sentMails.length; i++) {
        if(sentMails[i].mail_id == elem.dataset.mid) {
            subject = sentMails[i].subject;
            sender = sentMails[i].sender;
            receiver = sentMails[i].receiver;
            date = sentMails[i].date;
            content = sentMails[i].content;
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
    deleteBtn.setAttribute("onclick", "removeTheSelectedItemFromEmployeeSent(this);");
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
    var receiverInfo = document.createElement("div");
    receiverInfo.classList.add("receiver-info");
    receiverInfo.innerText = "\n\n\nRECEIVER: " + receiver;
    emailContentMessage.appendChild(receiverInfo);

    //Add the email content header and email content message to the email content 
    emailContent.appendChild(emailContentHeader);
    emailContent.appendChild(emailContentMessage);

    //Indicate selected mail item
    indicateSelectedEmailItem();

}

function removeTheSelectedItemFromEmployeeSent(elem) {
    for(var i = 0; i < sentMails.length; i++) {
        if(sentMails[i].mail_id == elem.dataset.mid) {
            sentMails[i].deletedFromEmployee = 1;
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

    //Update the email list in place
    fillSentMails();
    
    //Update deleted mails item count
    updateDeletedMails();
}