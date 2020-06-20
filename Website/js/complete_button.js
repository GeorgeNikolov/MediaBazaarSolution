function completeTodo(element) {
    //Toggle the class completed
    var todoDetails = element.parentElement.childNodes[1];
    todoDetails.classList.toggle("completed");

    //Fade out effect
    //This fade out effect replicating the fadeOut() function in Jquery but written in vanilla javascript (pure javascript)
    var listItem = element.parentElement;
    var fadeEffect = setInterval(function () {
        //Check if listItem opacity value != ""
        if (!listItem.style.opacity) {
            listItem.style.opacity = 1;
        }
        if (listItem.style.opacity > 0) {
            listItem.style.opacity -= 0.1;
        } else {
            clearInterval(fadeEffect);
        }
    }, 60);

    //change the status of the corresponding schedule post
    for(var i = 0; i < schedule_posts.length; i++) {
        if (schedule_posts[i].schedule_id == element.dataset.sid) {
            schedule_posts[i].status = 1;
        }
    }    

    //Write Ajax code to change the status of the corresponding schedule item to 1 (completed)
    var xmlhttp = new XMLHttpRequest();
    xmlhttp.onreadystatechange = function() {
        if (this.readyState == 4 && this.status == 200) {
            if(this.responseText == "Yes") {
                updateNumCounter();
                updateNumUndoneCounter();
            }
        }
    };
    xmlhttp.open("GET", "./completeTodo.php?sid=" + element.dataset.sid, true);
    xmlhttp.send();
}

//This function receive schedule post id or uid
function updateNumCounter() {
    // var targetNum = document.getElementsByClassName("numCompletedTasks");
    var counter = 0;
    for (var i = 0; i < schedule_posts.length; i++) {
        if (schedule_posts[i].id == currentUID && schedule_posts[i].status == 1) {
            counter++;
        }
    }
    //For span selector, using textContent is valid compared with innerText
    document.getElementById("numCompletedTasks").innerText = counter.toString();
}

function updateNumUndoneCounter() {
    var counter = 0;
    for (var i = 0; i < schedule_posts.length; i++) {
        if (schedule_posts[i].id == currentUID && schedule_posts[i].status == 0) {
            counter++;
        }
    }

    document.getElementById("numUndoneTasks").innerText = counter.toString();
}
