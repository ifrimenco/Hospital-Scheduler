
$("button[name=admin]").click(function () {
    let url1 = '/Admin/RemoveAdmin'
    let url2 = '/Admin/AddAdmin'
    let isAdmin = $(this).hasClass("btn-success");
    let userId = $(this).attr("value");
    let thisButton = "button[name=admin][value=" + userId + "]";
    $.ajax({
        type: 'POST',
        url: isAdmin ? url1 : url2,
        data: {
            userId: userId
        },
        success: function (response) {
            if (isAdmin) {
                $(thisButton).removeClass("btn-success");
            }
            else {
                $(thisButton).addClass("btn-success");
            }
            location.reload();
        },
        error: function (error) {

        }

    });

})

$("button[name=medic]").click(function () {
    let url1 = '/Admin/RemoveMedic'
    let url2 = '/Admin/AddMedic'
    let isMedic = $(this).hasClass("btn-success");
    let userId = $(this).attr("value");
    let thisButton = "button[name=medic][value=" + userId + "]";
    $.ajax({
        type: 'POST',
        url: isMedic ? url1 : url2,
        data: {
            userId: userId
        },
        success: function (response) {
            if (isMedic) {
                $(thisButton).removeClass("btn-success");
            }
            else {
                $(thisButton).addClass("btn-success");
            }
            location.reload();
        },
        error: function (error) {

        }
    });

});

function showSpecializations(element) {
    $(element).empty();
    $.ajax({
        type: 'GET',
        url: 'Admin/GetAllSpecializations',
        success: function (response) {
            var elements = $.map(response.result, function (item) {
                return `<option value=${item.Id} id=opt-${item.Id}>${item.Name}</option>`
            });
            $(element).append(elements);
        }
    });
}

function showRooms(element) {
    $(element).empty();
    $.ajax({
        type: 'GET',
        url: 'Admin/GetAllRooms',
        success: function (response) {
            var elements = $.map(response.result, function (item) {
                return `<option value=${item.Id} id=opt-${item.Id}>${item.Name}</option>`
            });
            $(element).append(elements);
        },
        error: function (error) {
            console.error(error);
        }
    });
}

var addSpec = function () {
    var name = $("#specializationInput").val();
    $("#specializationInput").val('');
    $.ajax({
        type: 'POST',
        url: 'Admin/AddSpecialization',
        data: {
            name: name
        },
        success: function (response) {
            if (response.success == true) {
                showSpecializations("#delSpec");
                $("#addSpecializationWrapper").append(`<p style="color: green" id="specializationResponse">Specialization added successfully!</p>`);
            }
            else {
                $("#addSpecializationWrapper").append(`<p style="color: red" id="specializationResponse">Specialization already exists!</p>`);
            }
            setTimeout(function () { $("#specializationResponse").remove() }, 2500);
        },
        error: function (error) {
            console.error(error)
        }
    });
}

// configure specialization button clicks and enter keypress for adding specialization
$("#specializationInput").keypress(function (e) {
    var code = (e.keyCode ? e.keyCode : e.which);
    if (code == 13) {
        addSpec();
    }
});

$("#addSpecBtn").click(addSpec);

$("#delSpecBtn").click(function () {
    var id = ($("#delSpec").val());
    $.ajax({
        type: 'POST',
        url: 'Admin/RemoveSpecialization',
        data: {
            id: id
        },
        success: function (response) {
            showSpecializations("#delSpec");
            $("#delSpecializationWrapper").append(`<p style="color: green" id="delResponse">Specialization deleted successfully!</p>`);

        },
        error: function (error) {

        }
    });
    setTimeout(function () { $("#delResponse").remove() }, 2500);
});

// configure room buttons and enter keypress for adding room
var addRoom = function () {
    var name = $("#roomInput").val();
    $("#roomInput").val('');
    $.ajax({
        type: 'POST',
        url: 'Admin/AddRoom',
        data: {
            name: name
        },
        success: function (response) {
            if (response.success == true) {
                showRooms("#delRoom");
                $("#addRoomWrapper").append(`<p style="color: green" id="roomResponse">Room added successfully!</p>`);
            }
            else {
                $("#addRoomWrapper").append(`<p style="color: red" id="roomResponse">Room already exists!</p>`);
            }
            setTimeout(function () { $("#roomResponse").remove() }, 2500);
        },
        error: function (error) {
            console.error(error)
        }
    });
}

$("#roomInput").keypress(function (e) {
    var code = (e.keyCode ? e.keyCode : e.which);
    if (code == 13) {
        addRoom();
    }
});

$("#addRoomBtn").click(addRoom);

$("#delRoomBtn").click(function () {
    var id = ($("#delRoom").val());
    $.ajax({
        type: 'POST',
        url: 'Admin/RemoveRoom',
        data: {
            id: id
        },
        success: function (response) {
            showRooms("#delRoom");
            $("#delRoomWrapper").append(`<p style="color: green" id="delResponse">Room deleted successfully!</p>`);

        },
        error: function (error) {

        }
    });
    setTimeout(function () { $("#delResponse").remove() }, 2500);
});

window.onload = function () {
    showSpecializations("#delSpec");
    showRooms("#delRoom");
}