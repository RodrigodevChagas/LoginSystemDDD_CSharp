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
            console.log("Da proxima vez que pegar no projeto, validar RegEx e pintar bordas de campos defeituosos de vermelho!")
    })
}

//Já consigo mapear quais campos estão vazios. Agora é validar!