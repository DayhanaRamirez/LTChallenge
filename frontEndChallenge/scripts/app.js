/* Section 3*/

let arrayCities = [];

function bringCity(city){
  fetch('https://api.openweathermap.org/data/2.5/weather?q='+city+'&appid=23e7bfdd9de307f099cde86dabfe8a88&units=metric')
    .then(response => response.json())
    .then(data => {
      console.log(data)
      let nameValue = data['name'];
      let tempValue = data['main']['temp'];
      let countryValue = data['sys']['country'];
      renderCity(nameValue, countryValue, tempValue);
    })
  .catch(err => alert("wrong city name"))
}

function renderCity(name, country, temp){
  const card = `<div class="card" id="${name}">
  <span class="close-card" id="${name}-span">x</span>
    <p class="title">${name}, ${country} </p>
    <div class="temp">
      <p class="num">${temp}°</p>
        <div class="butt-container">
          <button class="butt butt-c">C</button>
          <button class="butt butt-f">F</button>
          <button class="butt butt-k">K</button>
        </div>
    </div>
    <button class="update">Update</button>
  </div>`;
  document.getElementById("section3").innerHTML += card;
}

/* section 2*/

async function loadCities(){
  const respuesta = await fetch('./cities.json').then(response => 
      response.json())
      const ciudades = respuesta.cities.map(city => {
        const nombre = `<div class="option">
            <input type="radio" class="radio" id="${city.name}" name="category" value="${city.name}"/>
            <label for="${city.name}">${city.name}</label>
        </div>`;
        return nombre;
      });
      return ciudades;
}

async function selectCity(){
  const ciudades = await loadCities(); 
  console.log(ciudades);
  for(const ciudad of ciudades){
    console.log(ciudad);
    document.getElementById("op").innerHTML += ciudad;
  }

  const selected = document.querySelector(".selected");
  const optionsContainer = document.getElementById("op");
  const searchBox = document.querySelector(".search-box input");

  const optionsList = document.querySelectorAll(".option");

  selected.addEventListener("click", () => {
    optionsContainer.classList.toggle("active");

    searchBox.value = "";
    filterList("");

    if (optionsContainer.classList.contains("active")) {
      searchBox.focus();
    }
  });

  optionsList.forEach(o => {
    o.addEventListener("click", () => {
      selected.innerHTML = o.querySelector("label").innerHTML;
      console.log(selected.innerHTML = o.querySelector("label").innerHTML);
      if(!arrayCities.includes(o.querySelector("label").innerHTML)){
        arrayCities.push(o.querySelector("label").innerHTML);
        bringCity(o.querySelector("label").innerHTML);
      }

      optionsContainer.classList.remove("active");
    });
  });

  searchBox.addEventListener("keyup", function(e) {
    filterList(e.target.value);
  });

  const filterList = searchTerm => {
    searchTerm = searchTerm.toLowerCase();
    optionsList.forEach(option => {
      let label = option.firstElementChild.nextElementSibling.innerText.toLowerCase();
      if (label.indexOf(searchTerm) != -1) {
        option.style.display = "block";
      } else {
        option.style.display = "none";
      }
    });
  };

  window.addEventListener('click', (event)=> {
    const nodoObjetivo = event.target;
    if(nodoObjetivo.className === 'close-card'){
      deleteCard(nodoObjetivo);
    }
  });
}

window.addEventListener('load', function(){
  selectCity();
})

function deleteCard(target){
      if (target.parentNode) {
        const position = arrayCities.indexOf(target.parentNode);
        console.log(arrayCities);
        arrayCities.splice(position, 1);
        console.log(arrayCities);
        target.parentNode.parentNode.removeChild(target.parentNode);
      }
    
}

function getCelsius(event){
  if(event.target.className === 'c'){
  }

}

function getFahrenheit(event){
  if(event.target.className === 'f'){
   
  }

}

function getKelvin(event){
  if(event.target.className === 'k'){
   
  }

}

