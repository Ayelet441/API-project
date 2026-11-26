const title = document.getElementById("title");
const email = document.getElementById("email");
const password = document.getElementById("password");
const fname = document.getElementById("fname");
const lname = document.getElementById("lname");
let curUser = JSON.parse(sessionStorage.getItem("CurrentUser"))
title.textContent = `hello ${curUser.firstName}`
email.textContent = `mail: ${curUser.email}`
password.value = curUser.password
fname.value = curUser.firstName
lname.value = curUser.lastName
const Update = async () => {
    const updateData = {
        Email: curUser.email,
        Password: password.value,
        FirstName: fname.value,
        LastName: lname.value,
        UserId: curUser.userId
    }
    const responsePut = await fetch(`api/Users/${curUser.userId}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(updateData)
    })
    if (responsePut.ok) {
        alert("עדכון הפרטים בוצע בהצלחה")
    }
    else
        alert(responsePut.status)

}