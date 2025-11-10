function validacioForm() {
    'use strict'

    const forms = document.querySelectorAll('.needs-validation')

    Array.from(forms).forEach(form => {
        form.addEventListener('submit', event => {
            // Verificar si el formulario es válido
            if (!form.checkValidity()) {
                event.preventDefault()
                event.stopPropagation()
            }

            
            form.classList.add('was-validated')
        }, false)
    })
}

document.addEventListener('DOMContentLoaded', function () {
    validacioForm();
});