document.querySelectorAll('.sozdat-zapis').forEach(elem => elem.addEventListener('click', e => {
    $.ajax({
        type: "GET",
        url: e.target.getAttribute('way'),
        data: `watchId=${e.target.getAttribute('val')}`,
        success: function (response) {
            //window.location.href = response;
        }
    });
}));