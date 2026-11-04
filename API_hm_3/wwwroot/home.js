const reg = async () => {
    const usermail = document.getElementById("mail").value;
    const userpassword = document.getElementById("password").value;
    const userfname = document.getElementById("fname").value;
    const userlname = document.getElementById("lname").value;
    const PostData = {
        mail: usermail, 
        password: userpassword,
        fname: userfname,
        lname: userlname
    }

    const ResponsePost = await fetch("api/Users", {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(PostData)
    });

    if (ResponsePost.ok)
        alert("נרשמת בהצלחה");
    else
        alert(ResponsePost.status)
}

const log = async () => {
    const loginpassword = document.getElementById("login_password").value;
    const mail = document.getElementById("userMail").value;
    const update = document.getElementById("Update");
    const PostData = {
        Email: mail,
        password: loginpassword,
    }

    const ResponsePost = await fetch("api/Users/login", {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(PostData)
    });
    const DataPost = await ResponsePost.json();
    if (ResponsePost.ok) {
        window.location.href = "Update.html"
        sessionStorage.setItem("CurrentUser", JSON.stringify(DataPost));
    }
    else
        alert(ResponsePost.status)
}

const checkpass = async () => {
    const password = document.getElementById("password").value;
    const progress = document.getElementById("progress");
    const ResponsePost = await fetch("api/password", {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(password)
    });
    progress.value = await ResponsePost.text();
}