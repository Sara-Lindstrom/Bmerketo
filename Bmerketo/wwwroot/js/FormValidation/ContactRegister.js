function validateForm(element, errorMsg, label) {
    errorMsg.innerText = "";

    if (element.value === "") {
        errorMsg = "Please enter a ${label}."
    }

    switch (label) {
        case 'Name':
            break;

        case 'email':
            break;

        case 'phoneNumber':
            break;

        case 'message':
            break;
    }
}
