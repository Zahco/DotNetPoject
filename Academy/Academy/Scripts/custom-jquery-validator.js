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
                maxLength: 255,
            },          

            'Title': {
                required: true,
                maxLength: 50,
            },

            'Address': {
                required: true,
                maxLength: 255,
            },

            'Town': {
                required: true,
                maxLength: 50,
            },

            'PostCode': {
                required: true,
                maxLength: 50,
            },

            'FirstName': {
                required: true,
                maxLength: 50,
            },

            'LastName': {
                required: true,
                maxLength: 50,
            }
        },

        // Messages to show when errors occured.
        messages: {
            'Name': {
                required: "Le champ Nom est requis",
                maxLength: "Le nom doit être compris entre 1 et 255 caractères",
            },

            'Title': {
                required: "Le champ Titre est requis",
                maxLength: "Le titre de la classe doit être compris entre 1 et 50 caractères",
            },

            'Address': {
                required: "Le champ Adresse est requis",
                maxLength: "L'adresse doit être compris entre 1 et 255 caractères",
            },

            'Town': {
                required: "Le champ Ville est requis",
                maxLength: "La ville doit être compris entre 1 et 50 caractères",
            },

            'PostCode': {
                required: "Le champ Code Postal est requis",
                maxLength: "Le code postal doit être compris entre 1 et 50 caractères",
            },

            'FirstName': {
                required: "Le champ Prénom est requis",
                maxLength: "Le prénom doit être compris entre 1 et 50 caractères",
            },

            'LastName': {
                required: "Le champ Nom est requis",
                maxLength: "Le nom doit être compris entre 1 et 50 caractères",
            }
        }
    });
}); 