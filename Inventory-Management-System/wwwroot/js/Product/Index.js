const viewDropDown = document.getElementById("viewDropDown");


const urlParams = new URLSearchParams(window.location.search);
const currentView = urlParams.get('showNum'); 


//Auto select the view number on the dropdown
viewDropDown.value = currentView;


viewDropDown.addEventListener('change', () => {
    const newView = viewDropDown.value.toString();

    fetch('/api/Product/NewView', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(newView)
    })
        .then(response => response.text())
        .then(data => {
            window.location.href = data;
        });

})


    


 
