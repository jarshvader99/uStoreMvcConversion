//capture info from user
//capture element info will be printed
//create string
//print string to element

function createMadLib() {
    var country = document.getElementById('tbCountry').value;

    var adjective = document.getElementById('tbAdjective').value;

    var animal = document.getElementById('tbAnimal').value;

    var verb = document.getElementById('tbVerb').value;

    var place = document.getElementById('tbPlace').value;

    var liquid = document.getElementById('tbLiquid').value;

    var results = document.getElementById('madLibResults');

    var madLib = "If you are traveling in the " + country +
        " and find yourself having to cross a piranha-filled river," + 
        " here’s how to do it safely. Piranhas are more " + adjective +
        " during the day, so cross the river at night. Avoid areas with netted "
        + animal + " traps – piranhas may be waiting there looking to "
        + verb + " them! Piranhas are attracted to fresh " + 
        liquid + " and will migrate to it as often as possible. Whatever you do, "
        + " if you have an open wound, try to find another way to get back " 
        + " to the " + place + ".";

    results.textContent = madLib;
    var form = document.getElementById('madLib').reset(); 
}

var madLibSubmit = document.getElementById('madLibSubmit');
madLibSubmit.addEventListener('click', function () { createMadLib(); }, false);

function calcMultiples() {
    var results = document.getElementById('multiplesResults');

    for (var i = 7; i < 30; i+= 7) {
        results.innerHTML += i + '<br/>'; 
    }
}

function convertToFahrenheit() {
    var temp = document.getElementById('tbCelsius').value;

    var convertedTemp = (temp * 9) / 5 + 32;

    document.getElementById('tempResults').innerHTML = 'That is ' + convertedTemp + '&deg; in Fahrenheit.'; 
}

var tempSubmit = document.getElementById('celsiusBtn');
tempSubmit.addEventListener('click', function () { convertToFahrenheit() }, false);

function calcSquare() {
    var height = document.getElementById('tbSquareHeight').value;
    var width = document.getElementById('tbSquareWidth').value;

    var squareArea = height * width;

    document.getElementById('squareResults').textContent = squareArea; 
}

function calcTriangle() {
    var height = document.getElementById('tbTriangleHeight').value;
    var width = document.getElementById('tbTriangleWidth').value;

    var triangleArea = (height * width) / 2;

    document.getElementById('triangleResults').textContent = triangleArea;
}

function calcCircle() {
    var radius = document.getElementById('tbCircleRadius').value;

    var circleArea = 3.14 * radius * radius; 

    document.getElementById('circleResults').textContent = circleArea;
}

function calcRingArea() {
    var outer = document.getElementById('tbOuterRadius').value;
    var inner = document.getElementById('tbInnerRadius').value;


        var outerArea = 3.14 * outer * outer;
        var innerArea = 3.14 * inner * inner;

        var ringArea = outerArea - innerArea;

        document.getElementById('ringResults').textContent = ringArea;

}

var ringSubmit = document.getElementById('ringAreaBtn');
ringSubmit.addEventListener('click', function () { calcRingArea() }, false);

/*
Below is an advanced version of the Ring Calculator that checks to make sure the inner ring radius is smaller than the outer ring radius. This must be 
combined with an onsubmit attribute on the form tag that is equal to calcRingArea(event)

function calcRingArea(event) {
    var outer = Number(document.getElementById('tbOuterRadius').value);
    var inner = Number(document.getElementById('tbInnerRadius').value);

    if (outer > inner) {
        var outerArea = 3.14 * outer * outer;
        var innerArea = 3.14 * inner * inner;

        var ringArea = outerArea - innerArea;

        document.getElementById('ringResults').textContent = ringArea;
    } else {
        document.getElementById('ringResults').textContent = 'The radius of the inner ring cannot be larger than the radius of the outer ring. '
        event.preventDefault();
    }
}
*/

function calcChange() {
    var money = document.getElementById('tbChange').value;
    console.log(money); 
    var quarters = Math.floor(money / .25);

    var dimes = Math.floor((money % .25) / .10);

    var nickels = Math.floor(((money % .25) % .10) / .05);

    var pennies = Math.round((((money % .25) % .10) % .05) / .01);

    document.getElementById('changeResults').innerHTML = 'You have the following amount in change:<br/>' + quarters + " quarters<br/>" +
        dimes + " dimes<br/>" + nickels + " nickels<br/>" + pennies + " pennies"; 
}

var changeSubmit = document.getElementById('changeBtn');
changeSubmit.addEventListener('click', function () { calcChange() }, false);


/*******Basic Calculator Functions********/
function basicAdd() {
    var numOne = Number(document.getElementById('tbNumOne').value);
    var numTwo = Number(document.getElementById('tbNumTwo').value);

    document.getElementById('basicCalcResults').textContent = numOne + numTwo;
}

function basicSub() {
    var numOne = Number(document.getElementById('tbNumOne').value);
    var numTwo = Number(document.getElementById('tbNumTwo').value);

    document.getElementById('basicCalcResults').textContent = numOne - numTwo;
}

function basicMult() {
    var numOne = Number(document.getElementById('tbNumOne').value);
    var numTwo = Number(document.getElementById('tbNumTwo').value);

    document.getElementById('basicCalcResults').textContent = numOne * numTwo;
}

function basicDiv() {
    var numOne = Number(document.getElementById('tbNumOne').value);
    var numTwo = Number(document.getElementById('tbNumTwo').value);

    document.getElementById('basicCalcResults').textContent = numOne / numTwo;
}

/*
The below is an alternate option to the basic calculator using only one function. It would need to be used in combination with the below HTML code for a select
form control. 

---HTML Code---
Opening form tag would look like this: 
<form action="#" method="get" id="basicCalcForm" onsubmit="basicCalculator(event)">

Select form control work look like this: 
<div>
    <label for="operation">Select an Operation:</label>
    <select id="operation" name="operation">
        <option value="-1">[..Select One..]</option>
        <option value="add">Add</option>
        <option value="subtract">Subtract</option>
        <option value="multiply">Multiply</option>
        <option value="divide">Divide</option>
    </select>
</div>

Form submit button would look like this: 
<div>
    <input type="submit" value="Calculate" id="basicCalcBtn" />
</div>

---JS Code---
function basicCalculator(event) {
    var numOne = Number(document.getElementById('tbNumOne').value);
    var numTwo = Number(document.getElementById('tbNumTwo').value);

    var operation = document.getElementById('operation').value;

    var result = "";

    switch (operation) {
        case 'add':
            result = numOne + numTwo;
            break;
        case 'subtract':
            result = numOne - numTwo;
            break;
        case 'multiply':
            result = numOne * numTwo;
            break;
        case 'divide':
            result = numOne / numTwo;
            break;
        default:
            result = 'Not a valid operation'
            break;
    }

    document.getElementById('basicCalcResults').textContent = result;
    event.preventDefault(); 
}
*/


/******Advanced Calculator********/
function advancedCalc(operation) {
    var numOne = Number(document.getElementById('tbNumOne').value);
    var numTwo = Number(document.getElementById('tbNumTwo').value);

    var results = ""; 

    if (operation == 'add') {
        results = numOne + numTwo; 
    } else if (operation == 'subtract') {
        results = numOne - numTwo; 
    } else if (operation == 'multiply') {
        results = numOne * numTwo; 
    } else if (operation == 'divide') {
        results = numOne / numTwo
    } else {
        results = 'Not a valid operation.'
    }

    document.getElementById('advancedCalcResults').textContent = results;
}