let searchBar = document.getElementById("searchInput");
let searchButton = document.getElementById("searchButton");

searchBar.addEventListener("change", () => {

    if (searchBar.value == null) {
        searchButton.setAttribute("href", `Supplier?id=1&showNum=50`)
    }
    searchButton.setAttribute("href", `Supplier?id=1&showNum=50&searchInput=${searchBar.value}`)


})

const viewDropDown = document.getElementById("viewDropDown");

const urlParams = new URLSearchParams(window.location.search);
const currentView = urlParams.get('showNum');


//Auto select the view number on the dropdown
viewDropDown.value = currentView;


viewDropDown.addEventListener('change', () => {
    const newView = viewDropDown.value.toString();
    const currentSearch = urlParams.get('searchInput');
    const requestBody = { newView: newView, currentSearch: currentSearch };
    fetch('/api/Supplier/NewView', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(requestBody)
    })
        .then(response => response.text())
        .then(data => {
            window.location.href = data;
        });

})





