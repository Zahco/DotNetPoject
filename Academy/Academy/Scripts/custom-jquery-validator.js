$(document).ready(function () {
    // JQuery validation styles, rules and messages.
    $('#form-add-update').validate({
        errorClass: 'help-block animation-slideDown',
        errorElement: 'div',
        errorPlacement: function (error, e) {
            e.parents('.form-group > div').append(error);
        },

        // Highlight elemment when submit is fired.
        highlight: function (e) {
            $(e).closest('.form-group').removeClass('has-success has-error').addClass('has-error');
            $(e).closest('.help-block').remove();
        },

        // Unhighlight element after user interaction.
        unhighlight: function (element) {
            $(element).closest('.form-group').removeClass('has-error');
        },

        // When submit is successful
        success: function (e) {
            e.closest('.form-group').removeClass('has-success has-error');
            e.closest('.help-block').remove();
        },

        // Rules 
        rules: {
            'Name': {
                required: true,
                minLength: 1,
                maxLength: 5,
            },          

            'Title': {
                required: true,
                maxLength: 50,
            },
        },

        // Messages to show when errors occured.
        messages: {
            'Name': {
                required: "Le champ Nom de l'académie est requis",
                minLength: "Le nom de l'académie doit contenir au moins 1 caractère",
                maxLength: "Le nom de l'académie doit contenir moins de 100 caractères",
            },

            'Title': {
                required: "Le titre de la salle est requis",
                maxLength: "Le titre de la classe doit être compris entre 1 et 50 caractères",
            }
        }
    });
}); 