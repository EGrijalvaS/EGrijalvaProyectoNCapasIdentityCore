
    // VALIDAR DEL LADO DEL CLIENTE

const form = document.getElementById('Form');
const inputs = document.querySelector('#formulario input');

const expresiones = {
	Rfc: /^[a-zA-Z0-9\_\-]{4,16}$/, // Letras, numeros, guion y guion_bajo
	Nombre: /^[a-zA-ZÀ-ÿ\s]{1,40}$/, // Letras y espacios, pueden llevar acentos.
	APaterno: /^[a-zA-ZÀ-ÿ\s]{1,40}$/,
	AMaterno: /^[a-zA-ZÀ-ÿ\s]{1,40}$/,
	Nss: /^.{4,12}$/, // 4 a 12 digitos
	Telefono: /^\d{7,14}$/ // 7 a 14 numeros.
}

const campos = {
	Rfc: false,
	Nombre: false,
	APaterno: false,
	AMaterno: false,
	Nss: false,
	Telefono: false
}

const validarform = (e) => {
	switch (e.target.name) {
		case "Rfc":
			validarCampo(expresiones.Rfc, e.target, 'Rfc');
			break;
		case "Nombre":
			validarCampo(expresiones.Nombre, e.target, 'Nombre');
			break;
		case "APaterno":
			validarCampo(expresiones.APaterno, e.target, 'APaterno');
			break;
		case "AMaterno":
			validarCampo(expresiones.AMaterno, e.target, 'AMaterno');
			break;
		case "Telefono":
			validarCampo(expresiones.Telefono, e.target, 'Telefono');
			break;
	}
}



