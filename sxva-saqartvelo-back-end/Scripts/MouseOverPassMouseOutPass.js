function mouseoverPass(obj) {
    var obj = document.getElementById('Password');
    obj.type = "text";
}
function mouseoutPass(obj) {
    var obj = document.getElementById('Password');
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
    $('.showHidePd').hover(function () {
        $('.showHidePd').attr('src', '/img/logos/if_visibility_password.svg');
    },
    function () {
        $('.showHidePd').attr('src', '/img/logos/if_visibility-off.svg');
    })
});

$(function () {
    $('.showHideRePd').hover(function () {
        $('.showHideRePd').attr('src', '/img/logos/if_visibility_password.svg');
    },
    function () {
        $('.showHideRePd').attr('src', '/img/logos/if_visibility-off.svg');
    })
});