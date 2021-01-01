
$(document).ready(function () {

  



    // Get the container element
    var LinkList = [];
    LinkList.push(document.getElementById("link-to-kancelaria"));
    LinkList.push(document.getElementById("link-to-kontakt"));
    LinkList.push(document.getElementById("link-to-oferta"));

    // Get all buttons with class="btn" inside the container


    // Loop through the buttons and add the active class to the current/clicked button
    for (var i = 0; i < LinkList.length; i++) {
        LinkList[i].addEventListener("click", function () {
            var current = document.getElementsByClassName("active");

            // If there's no active class
            if (current.length > 0) {
                current[0].className = current[0].className.replace(" active", "");
            }

            // Add the active class to the current/clicked button
            this.className += " active";
        });
    }
});