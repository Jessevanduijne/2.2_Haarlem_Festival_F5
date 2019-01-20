$("#RestaurantModal").on("submit", "#ticketformid", function (e) {
    e.preventDefault();  // prevent standard form submission

    var form = $(this);
    $.ajax({
        url: form.attr("action"),
        method: form.attr("method"),
        data: form.serialize(),
        success: function (partialviewresult) {
            $("#modalBody").html(partialviewresult);
        }
    });
});

var BookRestaurant = function (restaurantId) {
    var url = "/Food/BookRestaurant?restaurantId=" + restaurantId;
    $("#modalBody").load(url, function () {
        $("#RestaurantModal").modal("show");
    })
};