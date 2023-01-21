// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const form =  document.getElementById("Form")
const PhoneNumber = document.getElementById("PhoneNumber");
const PhoneNumberRegex = /\+?(\(?d{2}\s?\))?((\(?\d{2}\)?)?\s?(\d{5})\s?-?\s?(\d{4}))/g;
const Email = document.getElementById("Email");
const EmailRegex = /^[a-z0-9.]+@[a-z0-9]+\.[a-z]+\.([a-z]+)?$/i;
const ReqFields = document.querySelectorAll(".reqField")

console.log(Email);

form.addEventListener("submit", (event) => {

    event.preventDefault();
    validateFields();
    form.submit();
});
function validateFields() {

    ReqFields.forEach(element => {
        if (element.value === "")
            console.log("Deu boa")
    })
}

//Já consigo mapear quais campos estão vazios. Agora é validar!