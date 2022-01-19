// NAV 1 BG CHANGE LIST ITEM
function random(number) {
    return Math.floor(Math.random()*number);
}

function bgChange() {
    const randomColor = `rgb(${random(255)}, ${random(255)}, ${random(255)})`;
    return randomColor;
}

const nav_1 = document.querySelector('#nav_1');
nav_1.addEventListener('click', event => event.target.style.backgroundColor = bgChange());


// NAV 2 WELCOME MESSAGE
document.querySelector('#nav_2').onclick = function () {
    const welcome = document.querySelector('#welcome');
    const name = prompt('What is your name?');
    alert(`Hi, ${name}! Nice to meet you`);
    welcome.textContent = `Welcome ${name}`;

}


// NAV 3 HTML BG CHANGE
const nav_3 = document.querySelector('#nav_3');
nav_3.addEventListener('mouseenter', function(e) {
    document.body.style.background = bgChange();
})

// NAV 4
document.querySelector('#nav_4').onclick = function () {
    const subject = prompt('Type a word of a picture you want to see..');
    document.getElementById('image').src = 'https://source.unsplash.com/random/600x600/?' + subject;
    document.getElementById('image').alt = subject;
}
