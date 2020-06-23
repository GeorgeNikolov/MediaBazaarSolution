function dayClicked(elem) {
    currentUID = elem.dataset.uid;
    buildTodoList();
    updateNumCounter();
    updateNumUndoneCounter();
    
    //Change the header of the current selected date
    document.getElementById("current-selected-date").innerText = elem.dataset.uid;

    openModal();
}

function gotItButtonClicked() {
    document.getElementById("modal").classList.add("fade-out");
    //Hide undone todos button

    setTimeout(function(){
        document.getElementById("completed-todos-button").style.display = "inline";
    
        //Show the completed todos button
        document.getElementById("undone-todos-button").style.display = "none";
    }, 1000);
    
}

function havingScheduleOnTheDay(elem) {
    for(let i = 0; i < schedule_posts.length; ++i) {
        if (elem.dataset.uid == schedule_posts[i].id) {
            return true;
        }
    }
    return false;
}

function buildTodoList() {
    //List of todo's 
    const todoList = document.getElementById("todo-list");
    todoList.innerText = "";

    //List of coworkers
    const coWorkersList = document.getElementById("co-workers");
    coWorkersList.innerText = "";
    
    for(let i = 0; i < schedule_posts.length; i++) {
        if (schedule_posts[i].id == currentUID && schedule_posts[i].status == 0) {
            //Create LI with class todo-item
            var todoItem = document.createElement("li");
            todoItem.classList.add("todo-item");

            //Create span with class complete-btn containing complete button icon
            var completeBtn = document.createElement("span");
            completeBtn.classList.add("complete-btn");
            var btnIcon = document.createElement("i");
            btnIcon.classList.add("fa");
            btnIcon.classList.add("fa-check-circle");
            completeBtn.appendChild(btnIcon);
            completeBtn.setAttribute("onclick", "completeTodo(this)");
            completeBtn.setAttribute("data-sid", schedule_posts[i].schedule_id);

            //Create a new span containing the todo details
            var todoDetails = document.createElement("span");
            todoDetails.classList.add("todo-details");

            //Add Todo details to the todo details span
            todoDetails.innerText = schedule_posts[i].note;

            //Add two newly created span to the LI 
            todoItem.appendChild(completeBtn);
            todoItem.appendChild(todoDetails);

            // Add the LI to the UL (todo-list)
            todoList.appendChild(todoItem);
        }
    }

    for (var i = 0; i < coWorkers.length; i++) {
        if (coWorkers[i].date == currentUID) {
            //Create a new LI element
            var coWorkerItem = document.createElement("li");
            
            //Assign the name of each coworker to the LI element
            coWorkerItem.innerText = coWorkers[i].first_name + " " + coWorkers[i].last_name;

            //Add the LI element to the co-workers list
            coWorkersList.appendChild(coWorkerItem);
        }
    }
}

function completedTodosButtonClicked() {
    const todoList = document.getElementById("todo-list");
    todoList.innerText = "";

    for(let i = 0; i < schedule_posts.length; i++) {
        if (schedule_posts[i].id == currentUID && schedule_posts[i].status == 1) {
            //Create LI with class todo-item
            var todoItem = document.createElement("li");
            todoItem.classList.add("todo-item");

            //Create a new span containing the todo details
            var todoDetails = document.createElement("span");
            todoDetails.classList.add("todo-details");

            //Add Todo details to the todo details span
            todoDetails.innerText = schedule_posts[i].note;

            //Add two newly created span to the LI 
            todoItem.appendChild(todoDetails);

            // Add the LI to the UL (todo-list)
            todoList.appendChild(todoItem);
        }
    }

    //Hide the completed todo button
    document.getElementById("completed-todos-button").style.display = "none";

    //Show the undone todo button
    document.getElementById("undone-todos-button").style.display = "inline";
}

function undoneTodosButtonClicked() {
    buildTodoList();

    //Hide undone todos button
    document.getElementById("completed-todos-button").style.display = "inline";
    
    //Show the completed todos button
    document.getElementById("undone-todos-button").style.display = "none";
}