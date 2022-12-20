function Validation02() {
    let a = document.getElementById("Name").value;
    let b = document.getElementById("Age").value;
    let c = document.getElementById("Email").value;
    let d = document.getElementById("fileobj").value;
    let e = document.getElementById("Course").value;
    let f = document.getElementById("CountryId").value;
    if (a == "" || b == "" || c == "" || d == "" || d == null || e == "" || f == "") {
        alert("All fields are required");
        //document.getElementById("Demo").innerHTML = "All the fields are required";
        return false;
    }
    else {
        return true;
    }
}

function Validation2() {
   let z = document.getElementById("Email").value;

    var re = /\S+@\S+\.\S+/;
    var r = re.test(z);
    if (r == true) {
        return true;
    }
    else {
        document.getElementById("Email1").innerHTML = "Invalid Email";
        return false;
    }
}