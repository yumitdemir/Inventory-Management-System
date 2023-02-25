const viewDropDown = document.getElementById("viewDropDown");

var currentView = document.getElementById('currentView').value;
var currentIndexId = document.getElementById('currentIndexId').value;

//Auto select the view number on the dropdown
viewDropDown.value = currentView;





viewDropDown.addEventListener('change', () => {
    
    const selectedValue = viewDropDown.value;

    const newUrl = window.location.href.replace(/\/\d+\?showNum=\d+/, `/${1}?showNum=${selectedValue}`);


    //let link = `https://localhost:7196/Product/Index/1?showNum=${selectedValue}`;
    
    window.location.href = newUrl;
});