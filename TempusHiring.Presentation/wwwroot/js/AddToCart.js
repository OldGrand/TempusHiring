var dataTypes = {
  Info: "info",
  Warn: "warn",
  Success: "success",
  Error: "error"
}

document.querySelectorAll(".sozdat-zapis").forEach(elem => elem.addEventListener("click", e => {
    $.ajax({
        type: "GET",
        url: e.target.getAttribute("way"),
        data: `watchId=${e.target.getAttribute("val")}`
    })
    .done(() => {
        note({
            callback: false,
            content: "Watch added to cart",
            type: dataTypes.Success,
            time: 3
        });
    })
    .fail(() => {
        note({
            callback: false,
            content: "You must be logged in to add to cart ",
            type: dataTypes.Error,
            time: 5
        });
    });
}));