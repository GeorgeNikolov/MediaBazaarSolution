function fillInCalendar() {
    updateCalendarDates();

    var monthToFIllIn = data.calendar.month;
    var yearToFillIn = data.calendar.year;

    var previousMonth = (monthToFIllIn - 1)<0?11:monthToFIllIn-1;
    var previousMonthYear = (monthToFIllIn -1)<0?yearToFillIn-1:yearToFillIn;

    var amountDaysPreviousMonth = daysInMonth(monthToFIllIn, yearToFillIn)
    var amountDaysCurrentMonth = daysInMonth(monthToFIllIn + 1, yearToFillIn);

    var firstDayOfMonthToFillIn = firstDayOfMonth(monthToFIllIn, yearToFillIn);


    let days = document.getElementsByClassName("td");
    let currentMonthCount = 1;
    let previousMonthCount = amountDaysPreviousMonth - firstDayOfMonthToFillIn + 1;
    let nextMonthCount = 1;
    let uid;
    cleanCells(days);

    for(let i = 0; i < days.length; i++) {
        //Filling current month
        if(firstDayOfMonthToFillIn <= i && currentMonthCount <= amountDaysCurrentMonth) {
            days[i].innerHTML = currentMonthCount;
            uid = getUID(monthToFIllIn, yearToFillIn, currentMonthCount);
            days[i].setAttribute("data-uid", uid);
            appendSpriteToCellAndTooltip(uid, days[i]);

            if (currentMonthCount == data.current_date.date && calendarIsCurrentMonth()) {
                days[i].setAttribute("id", "current-day");
            }
            currentMonthCount++;
        //Filling previous month
        } else if(currentMonthCount <= amountDaysCurrentMonth) {
            days[i].classList.add("color");
            days[i].innerHTML = previousMonthCount;
            uid = getUID(previousMonth, previousMonthYear, previousMonthCount);
            days[i].setAttribute("data-uid", uid);
            appendSpriteToCellAndTooltip(uid, days[i]);

            if(previousMonthCount == amountDaysPreviousMonth) {
                days[i].classList.add("prev-month-last-day");
            }
            previousMonthCount++;
        //Filling next month
        } else {
            days[i].classList.add("color");
            days[i].innerHTML = nextMonthCount;
            uid = getUID(monthToFIllIn + 1, yearToFillIn, nextMonthCount);
            days[i].setAttribute("data-uid", uid);
            appendSpriteToCellAndTooltip(uid, days[i]);

            nextMonthCount++;
        }
    }
}

//For the Javascript Date function, the second argument is month, starting with 0. The third argument is day, starting with 1. When you pass a 0 to the third argument instead, it uses the last day of the previous month. If you were to pass -1 as the third argument, it would be the second to last day of the previous month (it's decrementing). 

//When you add the month to argument, remember to add 1 to the month before passing it to the function because month is zero-based. For example, 0 is January, 1 is February.Therefore, if you want to get the number of days in March. Passed 3 to the function instead.
function daysInMonth(month, year) {
    return new Date(year, month, 0).getDate();
}

function firstDayOfMonth(month, year) {
    return new Date(year, month, 1).getDay();
}

function removeCurrentDay() {
    if(document.getElementById("current-day")) {
        document.getElementById("current-day").removeAttribute("id");
    }
}

function cleanCells(cells) {
    removeCurrentDay();

    for(let i = 0; i < cells.length; i++) {
        if(cells[i].classList.contains("color")) {
            cells[i].classList.remove("color");
        }

        if(cells[i].classList.contains("prev-month-last-day")) {
            cells[i].classList.remove("prev-month-last-day");
        }
    }
}

function calendarIsCurrentMonth() {
    if(data.current_date.year == data.calendar.year && data.current_date.month == data.calendar.month) {
        return true;
    } else {
        return false;
    }
}

function nextMonth() {
    if(data.calendar.month <= 11) {
        data.calendar.month++;
    }

    if(data.calendar.month == 12) {
        data.calendar.month = 0;
        data.calendar.year++;
    }
    updateCalendarDates();
    fillInCalendar();
}

function previousMonth() {
    if (data.calendar.month >= 0) {
        data.calendar.month--;
    }

    if(data.calendar.month == 0) {
        data.calendar.month = 11;
        data.calendar.year--;
    }
    updateCalendarDates();
    fillInCalendar();
}

document.onkeydown = function(e) {
    switch(e.keyCode) {
        case 37: previousMonth();
            break;
        case 39: nextMonth();
            break;
    }
}

function getUID(month, year, day) {
    if(month == 12) {
        month = 0;
        year++;
    }
    
    var dayStr = day.toString().length == 1?"0"+day.toString():day.toString();

    var monthStr = (month+1).toString().length == 1?"0"+(month+1).toString():(month+1).toString();

    return dayStr + "/" + monthStr + "/" + year.toString();
}

function appendSpriteToCellAndTooltip(uid, elem) {
    var imageAlreadyAdded = false;
    for(let i = 0; i < schedule_posts.length; i++) { 
        if(uid == schedule_posts[i].id && schedule_posts[i].status == 0) {
            if(!imageAlreadyAdded) {
                elem.innerHTML += `<img src='img/note${schedule_posts[i].note_num}.png'>`;
                imageAlreadyAdded = true;
            }
            elem.classList.add("tooltip");
            elem.innerHTML +=  `<span>${schedule_posts[i].note}</span>`;
        }
    }
}