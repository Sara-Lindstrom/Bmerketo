
// Open hidden elements
function openElement(elementId) {
    resetCheckboxesAndButtons(elementId);

    const openThisElement = document.getElementById(elementId);
    openThisElement.classList.toggle("d-none");
}

// Button for changed checkboxes
// Global variable to store initial checkbox values
var initialCheckboxValues = []; 

// Populating initialCheckboxValues when the page is loaded
window.addEventListener('DOMContentLoaded', function () {

    //hämtar upp alla initiala status på alla checkboxar
    var checkboxes = document.querySelectorAll('input[type="checkbox"]');

    checkboxes.forEach(function (checkbox, idx) {
        initialCheckboxValues[idx] = { id: checkbox.getAttribute("userId"), role: checkbox.getAttribute("roleName"), checked: checkbox.checked };
    });

});

function checkboxChanged(checkbox, buttonId) {

    var userId = checkbox.getAttribute("userId");
    var initialValueForUser = initialCheckboxValues.filter(cb => cb.id === userId);


    if (hasChanged(initialValueForUser)) {
        showButton(buttonId);
    } else {
        hideButton(buttonId);
    }
}

function hasChanged(initialValueForUser) {

    //skapa ny array med klickade användarens nuvarande status
    var currentUserIndex = 0;
    var userCurrentValues = [];

    //hämtar upp alla nuvarande status på alla checkboxar
    var checkboxes = document.querySelectorAll('input[type="checkbox"]');
    for (var i = 0; i < checkboxes.length; i++)
    {
        var checkbox = checkboxes[i];

        //om musse == musse
        if (checkbox.getAttribute("userId") === initialValueForUser[0].id) {

            //lägger till musse med sin nya status in i userCurrentValues
            userCurrentValues[currentUserIndex++] = { id: checkbox.getAttribute("userId"), role: checkbox.getAttribute("roleName"), checked: checkbox.checked };
            console.log(checkbox.getAttribute("roleName"))
        }
    }

    //jämnför intiala och nuvarande status
    var anyHasChanged = [];
    for (var i = 0; i < userCurrentValues.length; i++) {
        anyHasChanged[i] = initialValueForUser.filter(initialVal => initialVal.role === userCurrentValues[i].role).map(initialVal => initialVal.checked !== userCurrentValues[i].checked)[0];
    }

    return anyHasChanged.includes(true);
}

function hideButton(buttonId) {
    var buttonElement = document.getElementById(buttonId);
    buttonElement.classList.add("d-none");
}

function showButton(buttonId) {
    var buttonElement = document.getElementById(buttonId);
    if (buttonElement.classList.contains("d-none")) {
        buttonElement.classList.remove("d-none");
    }
}

function resetCheckboxesAndButtons(elementId) {
    var menus = document.querySelectorAll('div[type="dropdownMenu"]');
    for (var i = 0; i < menus.length; i++) {
        var menuElement = menus[i];

        if (menuElement.id !== elementId) {
            if (menuElement.classList.contains("d-none") == false) {
                menuElement.classList.add("d-none");
            }
        }
    }
    
    var currentCheckboxValues = document.querySelectorAll('input[type="checkbox"]');
    for (var i = 0; i < currentCheckboxValues.length; i++) {
        currentCheckboxValues[i].checked = initialCheckboxValues[i].checked;
    }

    var buttons = document.querySelectorAll('button[buttontype="changeButton"]');
    for (var i = 0; i < buttons.length; i++) {
        var buttonElement = buttons[i];

        if (buttonElement.classList.contains("d-none") == false) {
            buttonElement.classList.add("d-none");
        }
    }
}