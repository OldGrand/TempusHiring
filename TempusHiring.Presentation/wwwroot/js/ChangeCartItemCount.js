const getWatchesCount = watchId => {
    return $.get("/ShoppingCart/GetWatchCountInStock", { watchId: watchId }, (data) => {
        return data.count;
    });
}

document.querySelectorAll(".cart-minus-btn").forEach(item => item.addEventListener("click", async e => {
    let watchId = e.target.parentNode.getAttribute("watchIdVal");
    let watchCount = await getWatchesCount(watchId);

    let currentInput = e.target.nextElementSibling.childNodes[1];
    let currentVal = +currentInput.innerHTML - 1;

    if (currentVal >= 0) {
        currentInput.innerHTML = currentVal;
    }
}));

document.querySelectorAll(".cart-plus-btn").forEach(item => item.addEventListener("click", async e => {
    let watchId = e.target.parentNode.getAttribute("watchIdVal");
    let watchCount = await getWatchesCount(watchId);

    let currentInput = e.target.previousElementSibling.childNodes[1];
    let currentVal = +currentInput.innerHTML + 1;
    
    if (currentVal <= watchCount) {
        currentInput.innerHTML = currentVal;
    }
}));