function toggleMenu(){
    try {
        const toggleBtn = document.querySelector('[data-option="toggle"]')
        toggleBtn.addEventListener('click', function () {
            const element = document.querySelector(toggleBtn.getAttribute('data-target'))

            if (!element.classList.contains('open-menu')) {
                element.classList.add('open-menu')
            }

            else {
                element.classList.remove('open-menu')
            }
        })
    } catch { }
}
toggleMenu()


function footerPosition(scrollHeight, InnerHeight) {
    try {
        const footer = document.querySelector('#footer')
        const isTallerThanScreen = scrollHeight >= innerHeight

        footer.classList.toggle('position-fixed-bottom', !isTallerThanScreen)
        footer.classList.toggle('postition-static', isTallerThanScreen)
    } catch { }
}
footerPosition(document.body.scrollHeight, window.innerHeight)


