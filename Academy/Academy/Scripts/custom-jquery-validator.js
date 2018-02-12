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

        // Rules about each fields present on forms.
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
            },

            'Tel': {
                required: true,
                maxLength: 50,
            },

            'Mail': {
                required: true,
                email: true,
                maxLength: 50,
            },

            'Comment': {
                maxLength: 1000,
            },
        },
    });
}); 