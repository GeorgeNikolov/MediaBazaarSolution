function checkSignIn() {
	const username = document.getElementById("username");
	const usernameError = document.getElementById("username-error");

	const password = document.getElementById("password");
	const passwordError = document.getElementById("password-error");

	var isValidUsername = true;
	var isValidPassword = true;

	if (username.value == "") {
		usernameError.innerText = "Please fill in your username";
		username.focus();
		return false;
	} else {
		usernameError.innerText = "";
	}

	if (password.value == "") {
		passwordError.innerText = "Please choose your password";
		password.focus();
		return false;
	} else {
		passwordError.innerText = "";
	}

	var http = new XMLHttpRequest();
	var url = "helpers/signin.helper.php";
	var params = "username=" + username.value+"&password=" + password.value;
	http.open("POST", url, false);

	http.setRequestHeader('Content-type', 'application/x-www-form-urlencoded');
	http.onreadystatechange = function() {
		if (this.readyState == 4 && this.status == 200) {
			if (this.responseText == "username") {
				usernameError.innerText = "This username has not been registered. Please sign up!";
				username.focus();
				isValidUsername = false;
			} else if (this.responseText == "password") {
				passwordError.innerText = "Password does not match";
				password.focus();
				isValidPassword = false;
			} else {
				usernameError.innerText = "";
			}
		}
	}
	http.send(params);

	if (!isValidPassword || !isValidUsername) {
		return false;
	}
}



function checkEmail() {
	const email = document.getElementById("email");
	const emailError = document.getElementById("email-error");

	var isValidEmail = true;

	if (email.value == "") {
		emailError.innerText = "Please fill in your email";
		email.focus();
		return false;
	}

	var http = new XMLHttpRequest();
	var url = "helpers/reset-request.helper.php";
	var params = "email=" + email.value;
	http.open("POST", url, false);

	http.setRequestHeader('Content-type', 'application/x-www-form-urlencoded');
	http.onreadystatechange = function() {
		if (this.readyState == 4 && this.status == 200) {
			if (this.responseText == "email") {
				emailError.innerText = "This username has not been registered. Please sign up!";
				email.focus();
				isValidEmail = false;
			} else {
				emailError.innerText = "";
			}
		}
	}
	http.send(params);

	if (!isValidEmail) {
		return false;
	}
}



function checkPassword() {
	const password = document.getElementById('password');
	const passwordError = document.getElementById('password-error');

	const password2 = document.getElementById('password2');
	const password2Error = document.getElementById('password2-error');

	if (password.value == "") {
		passwordError.innerText = "Please choose your password";
		password.focus();
		return false;
	} else {
		passwordError.innerText = "";
	}

	if (password2.value == "") {
		password2Error.innerText = "Please confirm your password";
		password2.focus();
		return false;
	} else {
		password2Error.innerText = "";
	}

	if (password2.value != password.value) {
		password2Error.innerText = "Passwords do not match!";
		password2.focus();
		return false;
	}
}

function checkUpdateInfo() {
	const username = document.getElementById('username');
	const first_name = document.getElementById('first-name');
	const last_name = document.getElementById('last-name');
	const phone = document.getElementById('phone');
	const email = document.getElementById('email');
	const address = document.getElementById('address');
	const success_message = document.getElementById('success-message');

	const username_error = document.getElementById('username-error')
	const first_name_error = document.getElementById('first-name-error');
	const last_name_error = document.getElementById('last-name-error');
	const phone_error = document.getElementById('phone-error');
	const email_error = document.getElementById('email-error');
	const address_error = document.getElementById('address-error');

	if (username.value == "") {
		username_error.innerText = "Username should not be blank";
		username.focus();
		return false;
	}

	if (first_name.value == "") {
		first_name_error.innerText = "First Name should not be blank";
		first_name.focus();
		return false;
	}

	if (last_name.value == "") {
		last_name_error.innerText = "Last Name should not be blank";
		last_name.focus();
		return false;
	}

	if (phone.value == "") {
		phone.innerText = "Username should not be blank";
		phone.focus();
		return false;
	}

	if (email.value == "") {
		email_error.innerText = "Username should not be blank";
		email.focus();
		return false;
	}

	if (address.value == "") {
		address_error.innerText = "Username should not be blank";
		address.focus();
		return false;
	}

}



