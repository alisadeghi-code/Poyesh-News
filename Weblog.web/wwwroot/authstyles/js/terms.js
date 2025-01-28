
document.getElementById('register-form').addEventListener('submit', function(event) {
    var checkbox = document.getElementById('agree-term');
    if (!checkbox.checked) {
        event.preventDefault(); 
        alert("لطفاً قوانین سایت را بپذیرید.");
    }
});

