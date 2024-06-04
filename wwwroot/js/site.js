// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function() {
    // Sepet sayacını güncelle
    function updateCartCount() {
        $.get("/Cart/GetCartCount", function(data) {
            $("#cart-count").text(data.count);
        });
    }

    // Sepete ekle butonuna tıklayınca sayacı güncelle
    $(".add-to-cart").click(function() {
        var mealId = $(this).data("meal-id");
        $.post("/Cart/AddToCart", { mealId: mealId }, function() {
            updateCartCount();
        });
    });

    // Sayfa yüklendiğinde sepet sayacını güncelle
    updateCartCount();
});
