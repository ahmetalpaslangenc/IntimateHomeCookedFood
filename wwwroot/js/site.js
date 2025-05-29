$(document).ready(function () {
    $(".add-to-cart").click(function (e) {
        e.preventDefault();

        var mealId = $(this).data("id");

        $.ajax({
            url: '/Cart/AddToCart',
            type: 'POST',
            data: { mealId: mealId },
            success: function (result) {
                $("#cartCount").text(result.cartCount);
                alert("Ürün sepete eklendi.");
            }
        });
    });
});
