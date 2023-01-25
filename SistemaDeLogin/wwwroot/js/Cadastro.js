const botao = document.getElementById("Confirmar")
const ReqFields = document.querySelectorAll(".validateField")
const PhoneNumber = document.getElementById("PhoneNumber");
const Email = document.getElementById("Email");
const spanEmailVal = document.querySelector(".validateEmail")
const spanPhoneVal = document.querySelector(".validatePhoneNumber")
const PhoneNumberRegex = /\+?(\(?d{2}\s?\))?((\(?\d{2}\)?)?\s?(\d{5})\s?-?\s?(\d{4}))/g;
const EmailRegex = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$/ig;

botao.addEventListener("click", (event) => {

    validateFields();
    form.submit();
});

function validateFields() {

    ReqFields.forEach(element => {
        if (element.id === "PhoneNumber" && !element.value.match(PhoneNumberRegex)) {

            spanPhoneVal.textContent = `Please, insert a valid phone number.'61957160436'`
            event.preventDefault();
        }

        if (element.id === "Email" && !element.value.match(EmailRegex)) {

            spanEmailVal.textContent = `Please,insert a valid email. 'exampleemail@exemple.com'`
            event.preventDefault();
        }

        if (element.id === "PhoneNumber" && element.value.match(PhoneNumberRegex)) spanPhoneVal.textContent = ``

        if (element.id === "Email" && element.value.match(EmailRegex))  spanEmailVal.textContent = ``
    })
}