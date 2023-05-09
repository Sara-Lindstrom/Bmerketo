function validateForm(element, errorMsg, label) {
    errorMsg.innerText = "";

    if (element.value === "") {
        errorMsg = "Please enter a ${label}."
    }

    switch (label) {
        case 'title':
            break;

        case 'description':
            break;

        case 'price':
            break;

        case 'discountPrice':
            break;

        case 'image':
            break;
    }
}