function toggleEye() {
    var x = document.getElementById("myInput");
    var eyeIcon = document.getElementById("eyeIcon");
    if (x.type === "password") {
        x.type = "text";
        eyeIcon.classList.remove("eye-open");
        eyeIcon.classList.add("eye-closed");
    } else {
        x.type = "password";
        eyeIcon.classList.remove("eye-closed");
        eyeIcon.classList.add("eye-open");
    }
}