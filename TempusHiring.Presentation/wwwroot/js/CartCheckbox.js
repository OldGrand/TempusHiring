document.addEventListener("DOMContentLoaded", () => {
    document.querySelectorAll('.checkboxInput')
            .forEach(elem => elem.addEventListener("click", OnChangeCheckbox));
});

const OnChangeCheckbox = e => {
    e.target.checked = !!e.target.checked;
    $.ajax({
        type: "POST",
        url: "/ShoppingCart/ChangeSelection",
        data: `watchId=${e.target.previousElementSibling.value}&isChecked=${e.target.checked}`,
        success: function (response) {
            //window.location.href = response;
        }
    });
}