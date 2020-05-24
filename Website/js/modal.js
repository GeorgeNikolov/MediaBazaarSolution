var modal = document.getElementById("modal");

function openModal() {
    modal.open = true;
    modal.classList.add("fade-in");
}

function closeModal() {
    modal.open = false;
}

modal.addEventListener("animationend", function(){
    if(modal.classList.contains("fade-in")) {
        modal.classList.remove("fade-in");
    }

    if(modal.classList.contains("fade-out")) {
        modal.classList.remove("fade-out");
        closeModal();
    }
});