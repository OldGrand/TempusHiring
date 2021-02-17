document.querySelectorAll('.sozdat-zapis').forEach(elem => elem.addEventListener('click', e => {
    $.ajax({
        type: "GET",
        url: e.target.getAttribute('way'),
        data: `watchId=${e.target.getAttribute('val')}`,
        success: function (response) {
            alert("Watches successfully added to shopping cart");
        },
        failed: function(response) {
            alert("You must be registered to add to cart");
        }
    });
}));