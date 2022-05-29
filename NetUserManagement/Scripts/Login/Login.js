$(document).ready(function () {
    $('#login').click(function () {
        if ($("#Username").val() == "") {
            SendSwalMessage("Kullanıcı adınızı giriniz ");
            return;
        }
        if ($("#Password").val() == "") {
            SendSwalMessage("Şifrenizi giriniz ");
            return;
        }
        $('#login').prop('disabled', true);
        var data = {
            "Username": $("#Username").val(),
            "Password": $("#Password").val()
        };
        $.ajax({
            url: "/Login/UserLogin",
            type: "POST",
            data: JSON.stringify(data),
            dataType: "json",
            contentType: "application/json",
            success: function (response) {
                $('#login').prop('disabled', false);
                if (response.Success) {
                    window.location.href = "/User/Index/";
                }
                else {
                    SendSwalMessage(response.Error);
                }
            }
        });
    });
});

function SendSwalMessage(text) {
    Swal.fire({
        icon: 'error',
        title: text
    });
}