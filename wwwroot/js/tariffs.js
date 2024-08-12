window.updateSelectedUser = function(user) {
    // Update the UI with the selected user information
    document.getElementById("selectedUser").textContent = `Selected User: ${user.UserName}`;
}

window.updateSelectedTariff = function(tariff) {
    // Update the UI with the selected tariff information
    document.getElementById("selectedTariff").textContent = `Selected Tariff: ${tariff.Name} - ${tariff.Price}`;
}