document.addEventListener("DOMContentLoaded", () => {
    document.querySelectorAll('.checkboxInput')
        .forEach(elem => elem.addEventListener("click", OnChangeCheckbox));
});

const getWatchPrice = watchId => {
    return $.get("/ShoppingCart/GetWatchPrice", { watchId: watchId });
}

const getWatchesCount = watchId => {
    return $.get("/ShoppingCart/GetWatchCountInStock", { watchId: watchId });
}

const setWatchesCount = (watchId, count) => {
    return $.post("/ShoppingCart/ChangeCount", { watchId: watchId, count: count });
}

const getElementByXpath = (path) => {
    return document.evaluate(path, document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue;
}

const getOrderSummary = () => {
    return $.get("/ShoppingCart/GetOrderSummary");
}

const setValuesToOrderSummary = async () => {
    let data = await getOrderSummary();
    document.querySelector(".order__span__subtotal").innerHTML = `$${(+data.subTotal).toFixed(2).toString().replace(".", ",")}`;
    document.querySelector(".order__span__shipping").innerHTML = `$${(+data.shipping).toFixed(2).toString().replace(".", ",")}`;
    document.querySelector(".order__span__count").innerHTML = data.count;
    document.querySelector(".order__span__total").innerHTML = `$${(+data.total).toFixed(2).toString().replace(".", ",")}`;
}

const OnChangeCheckbox = async function (e) {
    e.target.checked = !!e.target.checked;

    await $.post("/ShoppingCart/ChangeSelection",
        {
            watchId: e.target.value,
            isChecked: e.target.checked
        });

    await setValuesToOrderSummary();
}

const setAdditionalPriceInfo = (unqiId, totalPrice, count) => {
    document.querySelector(`.cart__item-total-price-${unqiId}`).innerHTML = totalPrice;
    document.querySelector(`.price__details-count-${unqiId}`).innerHTML = count;
}

document.querySelectorAll(".cart-minus-btn").forEach(item => item.addEventListener("click", async e => {
    let watchId = e.target.parentNode.getAttribute("watchIdVal");
    let uniqBtnVal = e.target.getAttribute("uniqBtnVal");

    console.log(uniqBtnVal);

    let currentInput = e.target.nextElementSibling.childNodes[1];
    let currentVal = +currentInput.innerHTML - 1;

    if (currentVal >= 0) {
        currentInput.innerHTML = currentVal;
        await setWatchesCount(watchId, currentVal);
        await setValuesToOrderSummary();
        let watchPrice = await getWatchPrice(watchId);
        setAdditionalPriceInfo(uniqBtnVal, watchPrice * currentVal, currentVal);
    }
}));

document.querySelectorAll(".cart-plus-btn").forEach(item => item.addEventListener("click", async e => {
    let watchId = e.target.parentNode.getAttribute("watchIdVal");
    let watchCount = await getWatchesCount(watchId);
    let uniqBtnVal = e.target.getAttribute("uniqBtnVal");

    console.log(uniqBtnVal);
    
    let currentInput = e.target.previousElementSibling.childNodes[1];
    let currentVal = +currentInput.innerHTML + 1;

    if (currentVal <= watchCount) {
        currentInput.innerHTML = currentVal;
        await setWatchesCount(watchId, currentVal);
        await setValuesToOrderSummary();
        let watchPrice = await getWatchPrice(watchId);
        setAdditionalPriceInfo(uniqBtnVal, watchPrice * currentVal, currentVal);
    }
}));