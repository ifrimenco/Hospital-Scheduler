function showSpecializations(element) {
    $.ajax({
        type: 'GET',
        url: '/Admin/GetAllSpecializations',
        success: function (response) {
            var elements = $.map(response.result, function (item) {
                return `<option value=${item.Id} id=opt-${item.Id}>${item.Name}</option>`
            });
            $(element).append(elements);
            var id = $("#spec-show").data("val");
            defaultSelect = `#opt-${id}`
            $(defaultSelect).attr('selected', 'selected')
            var x = $(defaultSelect);
        }
    });
}

function validateEmail(email) {
    return /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/.test(email)
}

function validateCNP(CNP) {
    if (CNP.length != 13) {
        return false;
    }
    let isnum = /^\d+$/.test(CNP);
    return isnum;
}

window.onload = function () {
    showSpecializations("#specSelect");
}

$("#submitSpec").click(function () {
    var email = $("#Email").val();
    var cnp = $("#CNP").val();
    isMedic = $("#isMedic").data("ismedic")
    var emailMessage, cnpMessage;
    var specializationId = null
    var specializationMessage = null

    if (!validateEmail(email)) {
        emailMessage = `<p style="color: red" id="emailMessage" class="message">Invalid E-mail</p>`;
        email = null;
    }

    else if (email === $("#email-show").text()) {
        emailMessage = `<p style="color: red" id="emailMessage" class="message">Same E-mail</p>`;
        email = null;
    }

    if (!validateCNP(cnp)) {
        cnpMessage = `<p style="color: red" id="cnpMessage" class="message">Invalid Personal Code</p>`;
        cnp = null;
    }

    else if (cnp === $("#CNP-show").text()) {
        cnpMessage = `<p style="color: red" id="cnpMessage" class="message">Same Personal Code</p>`;
        cnp = null;
    }


    if (isMedic == 'True') {
        var currSpecId = $("#spec-show").attr("data-val");
        var selectedSpecId = parseInt($("#specSelect option:selected").attr('value'));

        if (currSpecId == selectedSpecId) {
            specializationMessage = `<p style="color: red" id="specializationMessage" class="message">Same Specialization</p>`;
        }

        else {
            specializationId = selectedSpecId;
        }
    }

    $.ajax({
        type: 'POST',
        url: '/Admin/ModifyUser',
        data: {
            userId: $("#user-container").data("id"),
            cnp: cnp,
            email: email,
            specializationId: specializationId
        },

        // showing request responses
        success: function (response) {

            if (response.specializationChanged) {
                specializationMessage = `<p style="color: green" id="specializationMessage" class="message">Specialization Changed!</p>`;
                $("#spec-show").text($("#specSelect option:selected").text());
                $("#spec-show").attr("data-val", $("#specSelect option:selected").val())

            }

            if (response.cnpCode == 1) {
                cnpMessage = `<p style="color: green" id="cnpMessage" class="message">Unique Personal Code Changed!</p>`;
                $("#CNP-show").text($("#CNP").val());
            }

            else if (response.cnpCode == -1) {
                cnpMessage = `<p style="color: red" id="cnpMessage" class="message">Personal Code already exists</p>`;
            }

            if (response.emailCode == 1) {
                emailMessage = `<p style="color: green" id="emailMessage" class="message">Email Changed!</p>`;
                $("#email-show").text($("#Email").val());
            }

            else if (response.emailCode == -1) {
                emailMessage = `<p style="color: red" id="emailMessage" class="message">E-mail already exists</p>`;
            }

            if (!($(".message").length)) {
                $("#emailDiv").append(emailMessage);
                $("#cnpDiv").append(cnpMessage);
                if (isMedic === 'True') {
                    $("#specDiv").append(specializationMessage);
                }
                setTimeout(function () { $(".message").remove() }, 2500);
            }
        },

        error: function (error) {
            console.error(error);
        }
    });


});
