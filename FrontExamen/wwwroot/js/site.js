
    $(document).ready(function () {
        $("#agregarExamenForm").submit(function (event) {
            event.preventDefault();

            var examenData = {
                idExamen: $("#idExamen").val(),
                nombre: $("#nombre").val(),
                descripcion: $("#descripcion").val()
            };

            $.post('@Url.Action("Agregar", "ExamenController")', examenData, function (data) {
                // Manejar la respuesta. Por ejemplo, cerrar el modal y actualizar la tabla
                $('#agregarExamenModal').modal('hide');
                // Puedes agregar código aquí para actualizar la tabla o mostrar un mensaje
            });
        });
    });

