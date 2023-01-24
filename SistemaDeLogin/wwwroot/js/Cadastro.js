const botao = document.getElementById("Confirmar")
const PhoneNumber = document.getElementById("PhoneNumber");
const PhoneNumberRegex = /\+?(\(?d{2}\s?\))?((\(?\d{2}\)?)?\s?(\d{5})\s?-?\s?(\d{4}))/g;
const Email = document.getElementById("Email");
const EmailRegex = /^[a-z0-9.]+@[a-z0-9]+\.[a-z]+\.([a-z]+)?$/i;
const ReqFields = document.querySelectorAll(".validateField")

console.log(Email);

botao.addEventListener("click", (event) => {

    event.preventDefault();
    validateFields();
    form.submit();
});

function validateFields() {

    ReqFields.forEach(element => {
        if (element.id === "PhoneNumber" && element.value.match(PhoneNumberRegex)) {

            console.log("coloca span")
        }
    })
}

//Já consigo mapear quais campos estão vazios. Agora é validar!
//