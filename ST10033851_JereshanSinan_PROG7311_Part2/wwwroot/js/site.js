// const variables to store the body and the toggle button elements
const body = document.body;
const darkModeToggle = document.getElementById("darkModeToggle");

// Used local storage to get the local storage dark mode setting
let getMode = localStorage.getItem("mode");

// Function to toggle dark mode
function toggleDarkMode() {
    body.classList.toggle('dark');
}

// Check the stored mode and apply it to the web page
if (getMode) {
    if (getMode === "dark") {
        toggleDarkMode();
    }

    // Updates the checkbox state based on the mode
    darkModeToggle.checked = getMode === "dark";
}

//event listener to check if the toggle element is clicked
darkModeToggle.addEventListener("click", () => {
    toggleDarkMode();

    // Updates the mode in local storage 
    localStorage.setItem("mode", body.classList.contains("dark") ? "dark" : "light");
});








