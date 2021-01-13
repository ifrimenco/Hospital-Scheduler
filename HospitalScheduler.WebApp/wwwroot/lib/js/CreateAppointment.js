function showRooms(element) {

    if ($("#main-container").attr("data-ismedic") == 'False') {
        return;
    }

    $(element).empty();

    $.ajax({
        type: 'GET',
        url: '/Appointments/GetAllRooms',
        success: function (response) {
            var elements = $.map(response.result, function (item) {
                return `<option asp-for="RoomId" value=${item.Id} id=opt-${item.Id}>${item.Name}</option>`
            });

            $(element).append(elements);
        },
        error: function (error) {
            console.error(error);
        }
    });
}

function showUsers(currentElement, isMedic) {

    if (isMedic == true && $("#main-container").attr("data-ismedic") == 'False') {
        return;
    }

    var name = $(currentElement).val();
    $("#userresults").empty();
    $("#inputId").attr("value", 0);
    url = (isMedic == true) ? '/Appointments/GetUsersByName' : '/Appointments/GetMedicsByName';
    $.ajax({
        type: 'GET',

        url: url,

        data: {
            name: name
        },

        success: function (response) {

            if (response.isEmpty == true) {
                $("#userresults").empty();
                $("#userresults").hide();
            }

            else {
                if (isMedic == true) {
                    var elements = $.map(response.result, function (item) {
                        return `<option class="unselectable optionUser" value="${item.Id}">${item.FirstName} ${item.LastName}</option>`
                    });

                } else {
                    var elements = $.map(response.result, function (item) {
                        return `<option class="unselectable optionUser" value="${item.Id}">[${item.Specialization}]${item.FirstName} ${item.LastName}</option>`
                    });
                }

                $("#userresults").append(elements);
                $("#userresults").show();
            }
        },

        error: function (error) {
            console.error(error);
        }
    });
}

$("#userInput").keyup(function () {
    if ($("#main-container").attr("data-ismedic") == 'True') {
        showUsers(this, true);
    }
    else {
        showUsers(this, false);
    }
});

$("#userresults").on("click", ".optionUser", function () {
    $("#userInput").val($(this).text());
    $("#inputId").val($(this).val());
    $("#userresults").empty();
    $("#userresults").hide();
});

window.onload = function () {
    $("#userresults").hide();
    $("#userresults").empty();
    showRooms("#roomSelect");
}
