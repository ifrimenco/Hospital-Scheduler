var buttonFunction = function (url, confirmed) {
    var id = $('#IdContainer').attr('data-id')
    $.ajax({
        type: 'POST',
        url: url,
        cache: false,
        async: false,
        data: {
            appointmentId: $('#IdContainer').attr('data-id')
        },

        success: function (response) {
            if (confirmed == true) {
                window.location.reload();
            }

            else {
                window.location.href = "/Appointments/Medic";
                return false;
            }
        },

        error: function (error) {
            console.error(error);
        }

    });
}

$("#confirmBtn").click(function () {
    buttonFunction('/Appointments/ConfirmAppointment', true)
});


$("#denyBtn").click(function () {
    buttonFunction('/Appointments/DenyAppointment', false)
});