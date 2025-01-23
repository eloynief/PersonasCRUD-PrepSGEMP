
class Persona {
    // Atributos
    /**
     * Atributos de la entidad Persona
     */
    constructor(id = 0, nombre = '', apellido = '', fechaNac = new Date(), direccion = '', foto = '', telefono = '', idDepartamento = 0) {
        this._id = id;
        this._nombre = nombre;
        this._apellido = apellido;
        this._fechaNac = fechaNac;
        this._direccion = direccion;
        this._foto = foto;
        this._telefono = telefono;
        this._idDepartamento = idDepartamento;
    }

    // Propiedades (Getters y Setters)
    /**
     * Propiedades de la entidad Persona
     */
    get id() {
        return this._id;
    }

    set id(value) {
        this._id = value;
    }

    get nombre() {
        return this._nombre;
    }

    set nombre(value) {
        this._nombre = value;
    }

    get apellido() {
        return this._apellido;
    }

    set apellido(value) {
        this._apellido = value;
    }

    get fechaNac() {
        return this._fechaNac;
    }

    set fechaNac(value) {
        this._fechaNac = value;
    }

    get direccion() {
        return this._direccion;
    }

    set direccion(value) {
        this._direccion = value;
    }

    get foto() {
        return this._foto;
    }

    set foto(value) {
        this._foto = value;
    }

    get telefono() {
        return this._telefono;
    }

    set telefono(value) {
        this._telefono = value;
    }

    get idDepartamento() {
        return this._idDepartamento;
    }

    set idDepartamento(value) {
        this._idDepartamento = value;
    }

    // Métodos adicionales
    /**
     * Métodos adicionales si son necesarios
     */

    toString() {
        return `Persona: ${this.nombre} ${this.apellido}, ID: ${this.id}`;
    }
}




const apiUrl = "https://eloynervionasp.azurewebsites.net/api/personas";


function CargaPersonas() {
    var miLlamada = new XMLHttpRequest();

    // Configurar la llamada a la API
    miLlamada.open("GET", apiUrl);

    // Definición de estados
    miLlamada.onreadystatechange = function () {
        if (miLlamada.readyState < 4) {
            alert("Kagando");
            // Mostrar mensaje de carga
            document.getElementById("persona").innerHTML = `<img src="https://i.pinimg.com/originals/87/e0/53/87e05309319f35ff3fd7d3522d9fd256.gif"/>`;
        } else if (miLlamada.readyState === 4 && miLlamada.status === 200) {
            // Parsear la respuesta JSON y llamar a obtencion
            var arrayPersonas = JSON.parse(miLlamada.responseText);
            obtencion(arrayPersonas);
        }
    };

    // Enviar la solicitud
    miLlamada.send();
}

function obtencion(arrayPersonas) {
    // Inicializar una cadena para mostrar los datos
    let mostrador = "<ul>";

    // Iterar sobre las personas y construir elementos HTML
    arrayPersonas.forEach(persona => {
        mostrador += `
            <li>
                <strong>Nombre:</strong> ${persona.nombre}<br>
                <strong>Apellido:</strong> ${persona.apellido}<br>
                <strong>Dirección:</strong> ${persona.direccion}<br>
                <strong>Fecha de Nacimiento:</strong> ${persona.fechaNac}<br>
                <img src="${persona.foto}"/><br>

                <button >Editar</button>
                <button >Borrar</button>


            </li>
        `;
    });

    mostrador += "</ul>";

    alert("Listota gorda de personas");

    // Mostrar los datos en el elemento con ID "persona"
    document.getElementById("persona").innerHTML = mostrador;
}

//////////////////////////////////////////////////////////////////////////////


















// Guardar persona (Crear o Actualizar)
function guardarPersona() {
    const id = document.getElementById("idPersona").value;
    const nombre = document.getElementById("nombre").value;
    const apellido = document.getElementById("apellido").value;
    const direccion = document.getElementById("direccion").value;
    const fechaNac = document.getElementById("fechaNac").value;
    const foto = document.getElementById("foto").value;

    const persona = {
        nombre,
        apellido,
        direccion,
        fechaNac,
        foto
    };

    const miLlamada = new XMLHttpRequest();
    if (id) {
        // Actualizar persona
        miLlamada.open("PUT", `${apiUrl}/${id}`);
    } else {
        // Crear nueva persona
        miLlamada.open("POST", apiUrl);
    }

    miLlamada.setRequestHeader("Content-Type", "application/json");

    miLlamada.onreadystatechange = function () {
        if (miLlamada.readyState === 4 && miLlamada.status === 200) {
            CargaPersonas(); // Recargar la lista
            resetForm();
        }
    };

    miLlamada.send(JSON.stringify(persona));
}

// Editar persona
function editarPersona(id) {
    const miLlamada = new XMLHttpRequest();
    miLlamada.open("GET", `${apiUrl}/${id}`);

    miLlamada.onreadystatechange = function () {
        if (miLlamada.readyState === 4 && miLlamada.status === 200) {
            const persona = JSON.parse(miLlamada.responseText);

            // Llenar el formulario con los datos de la persona
            document.getElementById("idPersona").value = persona.id;
            document.getElementById("nombre").value = persona.nombre;
            document.getElementById("apellido").value = persona.apellido;
            document.getElementById("direccion").value = persona.direccion;
            document.getElementById("fechaNac").value = persona.fechaNac.split("T")[0];
            document.getElementById("foto").value = persona.foto;

            document.getElementById("formTitle").textContent = "Editar Persona";
        }
    };

    miLlamada.send();
}

// Borrar persona
function borrarPersona(id) {
    const miLlamada = new XMLHttpRequest();
    miLlamada.open("DELETE", `${apiUrl}/${id}`);

    miLlamada.onreadystatechange = function () {
        if (miLlamada.readyState === 4 && miLlamada.status === 200) {
            CargaPersonas(); // Recargar la lista
        }
    };

    miLlamada.send();
}

// Resetear formulario
function resetForm() {
    document.getElementById("idPersona").value = "";
    document.getElementById("nombre").value = "";
    document.getElementById("apellido").value = "";
    document.getElementById("direccion").value = "";
    document.getElementById("fechaNac").value = "";
    document.getElementById("foto").value = "";
    document.getElementById("formTitle").textContent = "Agregar Persona";
}


