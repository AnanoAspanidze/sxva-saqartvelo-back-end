function mouseoverPassOldPsw(obj) {
    var obj = document.getElementById('Password');
    obj.type = "text";
}
function mouseoutPassOldPsw(obj) {
    var obj = document.getElementById('Password');
    obj.type = "password";
}

function mouseoverPass(obj) {
    var obj = document.getElementById('NewPassword');
    obj.type = "text";
}
function mouseoutPass(obj) {
    var obj = document.getElementById('NewPassword');
    obj.type = "password";
}

function mouseoverHover(obj) {
    var obj = document.getElementById('RepeatPassword');
    obj.type = "text";
}
function mouseoutHover(obj) {
    var obj = document.getElementById('RepeatPassword');
    obj.type = "password";
}


//show hide icon
$(function () {
    $('.showHidePassword').hover(function () {
        $('.showHidePassword').attr('src', '/img/logos/if_visibility_password.svg');
    },
    function () {
        $('.showHidePassword').attr('src', '/img/logos/if_visibility-off.svg');
    })
});

$(function () {
    $('.showHideNewPassword').hover(function () {
        $('.showHideNewPassword').attr('src', '/img/logos/if_visibility_password.svg');
    },
    function () {
        $('.showHideNewPassword').attr('src', '/img/logos/if_visibility-off.svg');
    })
});

$(function () {
    $('.showHideRepeatPassword').hover(function () {
        $('.showHideRepeatPassword').attr('src', '/img/logos/if_visibility_password.svg');
    },
    function () {
        $('.showHideRepeatPassword').attr('src', '/img/logos/if_visibility-off.svg');
    })
});