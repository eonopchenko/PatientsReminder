$(document).ready(function () {
    $(".send").click(function () {
        const id = $(this).attr("id").slice("send-button-".length);
        const phone = document.getElementById("phone-" + id).value;
        const notification = document.getElementById("notification-"+id).value;

        $.ajax({
            url: "Patients/SendSms?phone=" + encodeURIComponent(phone) + "&notification=" + encodeURIComponent(notification),
            success: function (data) {
            }
        });
	});
});
