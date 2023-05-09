function validateForm(event, errorMsgId, label) {
    var errorMsgElement = document.getElementById(errorMsgId);
    var element = event.target;
    errorMsgElement.innerText = "";

    if (element.value && element.required === "") {
        errorMsgElement.innerText = `Please enter a ${label}.`;
    }

    switch (label) {
        case 'name':
            const regExName = /^[a-öA-Ö]+(?:[ é'-][a-öA-Ö]+)*$/;

            if (element.value.length < 2) {
                errorMsgElement.innerText = `Your ${label} must contain at least 2 characters!`;

            }
            else if (!regExName.test(element.value)) {
                errorMsgElement.innerText = `Please enter a ${label}.`;

            }
            else {
                errorMsgElement.innerText = "";
            }
            break;

        case 'streetName':
            break;

        case 'postalCode':
            break;

        case 'city':
            break;

        case 'phoneNumber':
            break;

        case 'email':
            break;

        case 'password':
            break;

        case 'confirmedPassword':
            break;

        case 'image':
            break;
    }
}