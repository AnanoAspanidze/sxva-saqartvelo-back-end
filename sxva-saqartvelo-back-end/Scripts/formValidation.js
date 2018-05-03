//function validateForm() {

//    //Validate Login
//    if ($("#Email").val() == "" || $("#Password").val() == "") {

//        $("#Email").css("border-color", "#e80c4d");
//        $("#Password").css("border-color", "#e80c4d");
//    }

//    if ($("#Email").val() != null || $("#Password").val() != null) {
//        $("#Email, #Password").keyup(function () {
//            var $this = $(this);
//            var insertedVal = $this.val();
//            if (insertedVal != null) {
//                $this.css("border-color", "");
//            }
//        });
//    }
//    //


//    //Validate Registration
//    if ($("#Name").val() == ""
//         || $("#Surname").val() == ""
//          || $("#Field").val() == ""
//           || $("Email").val() == ""
//            || $("#Password").val() == ""
//             || $("#RepeatPassword").val() == ""
//              || $("#Mobile").val() == "") {

//        $("#Name").css("border-color", "#e80c4d");
//        $("#Surname").css("border-color", "#e80c4d");
//        $("#Field").css("border-color", "#e80c4d");
//        $("#Email").css("border-color", "#e80c4d");
//        $("#Password").css("border-color", "#e80c4d");
//        $("#RepeatPassword").css("border-color", "#e80c4d");
//        $("#Mobile").css("border-color", "#e80c4d");
//    }

//    if ($("#Name").val() != null ||
//        $("#Surname").val() != null ||
//         $("#Field").val() != null ||
//           $("#Email").val() != null ||
//            $("#Password").val() != null ||
//             $("#RepeatPassword").val() != null ||
//              $("#Mobile").val() != null) {

//        $("input").keyup(function () {
//            var $this = $(this);
//            var insertedVal = $this.val();
//            if (insertedVal != null) {
//                $this.css("border-color", "");
//            }
//        });
//    }
//    //
//}


////if (e.keyCode == 8) {
////    $("input").keyup(function () {
////        var $this = $(this);
////        var insertedVal = $this.val();
////        if (insertedVal == null) {
////            $this.css("border-color", "#e80c4d");
////        }
////    });
////}