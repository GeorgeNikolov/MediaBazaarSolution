function dayClicked(elem) {
    //data.schedule_post.current_post_id = elem.dataset.uid;
    let schedule_details = document.getElementById("schedule-post-details");
    schedule_details.value = "";
    if (!havingScheduleOnTheDay(elem)) {
        schedule_details.value += "You don't have shifts on this day";
    } else {
        for(let i = 0; i < schedule_posts.length; ++i) {
            if (elem.dataset.uid == schedule_posts[i].id) {
                schedule_details.value += schedule_posts[i].note;
            }
        }
    }
    
    openModal();
}

function gotItButtonClicked() {
    document.getElementById("modal").classList.add("fade-out");
}

function havingScheduleOnTheDay(elem) {
    for(let i = 0; i < schedule_posts.length; ++i) {
        if (elem.dataset.uid == schedule_posts[i].id) {
            return true;
        }
    }
    return false;
}