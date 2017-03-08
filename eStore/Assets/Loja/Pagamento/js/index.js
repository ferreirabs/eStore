/* Card.js plugin by Jesse Pollak. https://github.com/jessepollak/card */

$('form').card({
    container: '.card-wrapper',
    width: 280,

    formSelectors: {
        nameInput: 'input[name="primeiro-nome"], input[name="ultimo-nome"]'
    }
});