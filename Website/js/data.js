var data = {
    current_date: {
        day: "",
        date: "",
        month: "",
        year: "",
    },
    calendar: {
        month: "",
        year: ""
    },
    
};

//Contains all the schedule table records
var schedule_posts = [];

//Containg the uid of the current selected cell
var currentUID;

//Contains all the mails user sent
var sentMails = [];

//Contains all the mails user received
var receivedMails = [];

//Cotains all deleted mails
var deletedMails = [];

var currentTab;