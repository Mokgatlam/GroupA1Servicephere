
const preloader =document.querySelector("[data-preloader]");

window.addEventListener("load", ()=>{
    preloader.classList.add("remove");

})

///
/// * add event on multiple elements
 ///

 const addEventOnElements= function(elements, eventType,callback){

    ///loop
    for (let i=0,len = elements.length; i<len; i++){
        elements[i].addEventListener(eventType,callback);}

 }

 /**
  * navigator toggler for mobile
  */
 const navbar=document.querySelector("[data-navbar]");
 const navTogglers= document.querySelectorAll("[data-nav-toggler]");
 const overlay = document.querySelector("[data-overlay]");

 const toggleNav = function(){
    navbar.classList.toggle("active");
    overlay.classList.toggle("active");
    document.body.classList.toggle("nav-active");
 }

 addEventOnElements(navTogglers,"click",toggleNav);

 /**
  * Header
  */

 
 const header =document.querySelector("[data-header]");
 window.addEventListener("scroll",function(){
    header.classList[window.scrollY > 100 ? "add" : "remove"]("active");
 });


 // Select all input elements and add event listeners
Array.from(document.getElementsByTagName('input')).forEach((e, i) => {
   const inputField = e; // Get the current input element
   const icon = document.getElementById('iconSearch'); // Make sure the icon ID matches the actual element

   let typingTimer; // Timer identifier
   const doneTypingInterval = 500; // 0.5 seconds after typing

   // Event listener for keydown (user typing)
   inputField.addEventListener('keydown', () => {
       icon.classList.add('animate-icon'); // Add animation class when there's input
       clearTimeout(typingTimer); // Clear any previously set timers
   });

   // Start a timer to stop spinning after the user stops typing
   inputField.addEventListener('keyup', () => {
       clearTimeout(typingTimer); // Clear any previously set timers
       typingTimer = setTimeout(() => {
           icon.classList.remove('animate-icon'); // Stop spinning after typing stops
       }, doneTypingInterval);
   });
});

/**
 * Categories scrollable 
 */

function scrollLeft() {
    document.querySelector('.category-row').scrollBy({ left: -200, behavior: 'smooth' });
}

function scrollRight() {
    document.querySelector('.category-row').scrollBy({ left: 200, behavior: 'smooth' });
}

function navigateToCategory(category) {
    // Logic to navigate to category page
    alert('Navigating to ' + category);
}