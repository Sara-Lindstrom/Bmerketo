function validateOnSubmit() {
    var spanTags = document.getElementsByTagName("span");
    var isEmpty = true;

    for (var i = 0; i < spanTags.length; i++) {
        if (spanTags[i].textContent.trim() !== "") {
            isEmpty = false;
            break;
        }
    }

    if (!isEmpty) {
        return false;
    }

    return true;
}


function validateForm(event, errorMsgId, label) {
    var errorMsgElement = document.getElementById(errorMsgId);
    var element = event.target;
    errorMsgElement.innerText = "";

    if (element.value && element.required === "") {
        errorMsgElement.innerText = `Please enter a ${label}.`;
    }

    switch (label) {
        //add User cases
        case 'firstName':
            validateName(element, errorMsgElement, label);
            break;
        case 'lastName':
            validateName(element, errorMsgElement, label);
            break;
        case 'streetName':
            validateName(element, errorMsgElement, label);
            break;
        case 'postalCode':
            validatePostalCode(element, errorMsgElement, label);
            break;
        case 'city':
            validateName(element, errorMsgElement, label);
            break;
        case 'phoneNumber':
            validatePhoneNumber(element, errorMsgElement, label);
            break;
        case 'email':
            validateEmail(element, errorMsgElement, label);
            break;
        case 'password':
            validatePassword(element, errorMsgElement, label);
            break;
        case 'confirmedPassword':
            validateConfirmedPassword(element, errorMsgElement);
            break;
        case 'image':
            validateImage(element, errorMsgElement, label);
            break;
        //contact cases
        case 'cantactName':
            validateName(element, errorMsgElement, label);
            break;
        case 'contactEmail':
            validateEmail(element, errorMsgElement, label);
            break;
        case 'contactPhoneNumber':
            validatePhoneNumber(element, errorMsgElement, label);
            break;
        case 'contactMessage':
            validateFreeText(element, errorMsgElement, label);
            break;
        //register product cases
        case 'productTitle':
            validateFreeText(element, errorMsgElement, label);
            break;
        case 'productPrice':
            validatePrice(element, errorMsgElement, label);
            break;
        case 'productDiscountPrice':
            validateDiscountPrice(element, errorMsgElement, label);
            break;
        case 'productReview':
            validateReview(element, errorMsgElement, label);
            break;
        case 'productPrimairyImage':
            validateImage(element, errorMsgElement, label);
            break;
        case 'productImageOne':
            validateImage(element, errorMsgElement, label);
            break;
        case 'productImageTwo':
            validateImage(element, errorMsgElement, label);
            break;
        case 'productImageThree':
            validateImage(element, errorMsgElement, label);
            break;
        case 'productImageFour':
            validateImage(element, errorMsgElement);
            break;
        case 'productDescription':
            validateFreeText(element, errorMsgElement, label);
            break;

    }
}

//Modules
function validateName(element, errorMsgElement, label) {
    const NameRegEx = /^[a-öA-Ö]+(?:[ é'-][a-öA-Ö]+)*$/;

    if (element.value.length < 2) {
        errorMsgElement.innerText = `Your ${label} must contain at least 2 characters!`;

    }
    else if (!NameRegEx.test(element.value)) {
        errorMsgElement.innerText = `Please enter a valid ${label}.`;

    }
    else {
        errorMsgElement.innerText = "";
    }
}

function validatePostalCode(element, errorMsgElement, label) {
    const postalCodeRegEx = /^(?!0)\d{3}(?:\s?\d{2})?$/;

    if (!postalCodeRegEx.test(element.value)) {
        errorMsgElement.innerText = `Please enter a valid ${label}. (ex: 123 45)`;

    }
    else {
        errorMsgElement.innerText = "";
    }
}

function validatePhoneNumber(element, errorMsgElement, label) {
    const phoneNumberRegEx = /^(?:\+?[1-9]\d{1,2}(?:\s|-)?\d{3}(?:\s|-)?\d{2}(?:\s|-)?\d{2}|0\d{2}(?:\s|-)?\d{3}(?:\s|-)?\d{2}(?:\s|-)?\d{2})$/;

    if (!phoneNumberRegEx.test(element.value)) {
        errorMsgElement.innerText = `Please enter a valid ${label}. (ex: 012 3456789)`;

    }
    else {
        errorMsgElement.innerText = "";
    }
}

function validateEmail(element, errorMsgElement, label) {
    const emailRegEx = /^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$/;

    if (!emailRegEx.test(element.value)) {
        errorMsgElement.innerText = `Please enter a valid ${label}. (ex: test@domain.se)`;

    }
    else {
        errorMsgElement.innerText = "";
    }
}

function validatePassword(element, errorMsgElement, label) {
    const passwordRegEx = /^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$/;
    const passwordExclusionRegex = /^(?!Passw0rd!$)/;

    if (element.value.length < 8) {
        errorMsgElement.innerText = `Your ${label} is too short!`;

    }
    else if (!passwordRegEx.test(element.value)) {
        errorMsgElement.innerText = `Please enter a valid ${label}. (ex: Passw0rd!)`;

    }
    else if (!passwordExclusionRegex.test(element.value)) {
        errorMsgElement.innerText = `You can't have the example as your ${label}.'`;

    }
    else {
        errorMsgElement.innerText = "";
    }
}

function validateConfirmedPassword(element, errorMsgElement) {
    var passwordCheckTest = document.getElementById('password').value;

    if (element.value !== passwordCheckTest) {
        errorMsgElement.innerText = `This does not match your password.`;
    }
    else {
        errorMsgElement.innerText = "";
    }
}

function validateImage(element, errorMsgElement, label) {
    var allowedFormats = [".jpeg", ".jpg", ".png", ".gif", ".bmp", ".tiff", ".webp", ".svg"];
    var fileExtension = element.value.substring(element.value.lastIndexOf('.')).toLowerCase();
    console.log(fileExtension)

    if (element.value) {
        if (!allowedFormats.includes(fileExtension)) {
            errorMsgElement.innerText = "Invalid file format. Please choose a file with one of the following formats: JPEG, JPG, PNG, GIF, BMP, TIFF, WebP, SVG";
        }
        else {
            errorMsgElement.innerText = "";
        }
    }
    else {
        errorMsgElement.innerText = "";
    }
}

function validateFreeText(element, errorMsgElement, label) {
    if (element.value.length < 2) {
        errorMsgElement.innerText = `Your ${label} must contain at least 2 characters!`;

    }
    else {
        errorMsgElement.innerText = "";
    }
}

function validatePrice(element, errorMsgElement, label) {
    var priceRegEx = /^\d{1,3}(?:\s?\d{3})*(?:([.,])\d{1,2})?$/;

    var DisscountedPriceError = document.getElementById('productDiscountPriceError');
    var DisscountedPrice = document.getElementById('productDiscountPrice');

    if (DisscountedPriceError.textContent.length > 0) {
        validateDiscountPrice(DisscountedPrice, DisscountedPriceError);
    }

    if (!priceRegEx.test(element.value)) {
        errorMsgElement.innerText = `The ${label} is not valid. (ex: 1 - 99 999.99)`;
    }
    else if (element.value <= 0) {
        errorMsgElement.innerText = `The ${label} need to be more than 0. (ex: 1 - 99999.99)`;

    }
    else {
        errorMsgElement.innerText = "";
    }
}

function validateDiscountPrice(element, errorMsgElement) {

    var priceCheck = document.getElementById('productPrice').value;

    if (element.value >= priceCheck) {
        errorMsgElement.innerText = `The Discounted price needs to be lower than the original price`;
    }
    else if (element.value <= 0) {
        errorMsgElement.innerText = `The Discounted price need to be more than 0. (ex: 1 - ${priceCheck})`;

    }
    else {
        errorMsgElement.innerText = "";
    }
}

function validateReview(element, errorMsgElement, label) {
    var reviewRegEx = /^[1-5]$/;
    if (!reviewRegEx.test(element.value)) {
        errorMsgElement.innerText = `The review can only be 1-5.`;
    }
    else {
        errorMsgElement.innerText = "";
    }
}