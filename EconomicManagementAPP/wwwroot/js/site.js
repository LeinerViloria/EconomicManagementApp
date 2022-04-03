// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
//Script para el toast en Create Account Types
window.onload = (event) => {
    let myAlert = document.querySelector('#accountTypeToast');
    let bsAlert = new bootstrap.Toast(myAlert);
    bsAlert.show();
}