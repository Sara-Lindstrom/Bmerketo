function RedirectToDetailsPage(button) {
    const id = button.value;
    window.location.href = "/Products/Details?id=" + id;
}
