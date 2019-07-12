var emailRegEx = new RegExp(/^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$/);

function validateForm(event) {
    //With custom js we will require each field

    //grabs all values from inputs
    var name = document.forms['main-contact-form']['name'].value;
    var email = document.forms['main-contact-form']['email'].value;
    var subject = document.forms['main-contact-form']['subject'].value;
    var message = document.forms['main-contact-form']['message'].value;

    //get error message <span>
    var nameVal = document.getElementById('nameVal');
    var emailVal = document.getElementById('emailVal');
    var subjectVal = document.getElementById('subjectVal');
    var messageVal = document.getElementById('messageVal');

    //test all conditions including checking for a valid email address
    if (name.length == 0 || email.length == 0 || subject.length == 0 || message.length == 0 || !emailRegEx.test(email)) {

        //error messages under each required field
        if (name.length == 0) {
            nameVal.textContent = "* Name is required.";
        } else {
            nameVal.textContent = "";
        }
        if (email.length == 0) {
            emailVal.textContent = "* Email is required.";
        } else {
            emailVal.textContent = "";
        }



        //error message if email is not valid
        if (!emailRegEx.test(email) && email.length > 0) {
            emailVal.textContent = "* Must be a valid Email address.";
        }
        if (emailRegEx.test(email) && email.length > 0) {
            emailVal.textContent = "";
        }



        if (subject.length == 0) {
            subjectVal.textContent = "* Subject is required.";
        } else {
            subjectVal.textContent = "";
        }
        if (message.length == 0) {
            messageVal.textContent = "* message is required.";
        } else {
            messageVal.textContent = "";
        }
        event.preventDefault();//prevents page refresh and allows error messages to be displayed
    }




}