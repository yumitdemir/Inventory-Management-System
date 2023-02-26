let searchable = [
    'Elastic',
    'PHP',
    'Something about CSS',
    'How to code',
    'JavaScript',
    'Coding',
    'Some other item',
];
const searchWrapper = document.querySelector('.wrapper');
const resultsWrapper = document.querySelector('.results');
const searchInput = document.querySelector("#supplierSearchInput");
const hiddenSupplierInput = document.querySelector("#hiddenSupplierInput");

let clicked = false;
searchInput.addEventListener('keyup', () => {
    

    if (clicked) {
        searchInput.value = "";
        hiddenSupplierInput.value = searchInput.value;

    }

    clicked = false;
    
    
    let input = searchInput.value;
    console.log(input);
    controller = new AbortController();
    const data = {
        dataString: input,
    };

    fetch('/api/CreateProduct/Suppliers', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    })
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            return response.json();
        })
        .then(data => {

            console.log(data)
         
            
            resultsWrapper.innerHTML = "";
            renderResults(data);
            
        })
        .catch(error => {
            console.error('There was a problem with the fetch operation:', error);
           
        });

    
   
});


function renderResults(results) {
    if (!results.length) {
        return searchWrapper.classList.remove('show');
    }
   
    var parentUl = document.createElement('ul');
    resultsWrapper.appendChild(parentUl);
       
    const content = results
        .map((item) => {
            const liElement = document.createElement('li');
            liElement.textContent = `${item.name} - ID:${item.supplierId}`;
            liElement.addEventListener('click', (event) => {

                searchWrapper.classList.remove('show');
                clicked = true;
                searchInput.value = item.name;
                hiddenSupplierInput.value = item.supplierId;
                
            });
            parentUl.appendChild(liElement);
        })
        
    searchWrapper.classList.add('show');
   
    
}


   
