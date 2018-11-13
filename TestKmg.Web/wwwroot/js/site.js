// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $('.btn-add-field').click(function () {
        $('.additional-fields').append('<div><input placeholder="Доп.поле" type="text" name="Fields"/></div>');
    });
});