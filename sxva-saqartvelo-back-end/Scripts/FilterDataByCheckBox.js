//$(function () {
//    var skillName = $(this).attr("name");
//    $('.possibilities input[type=checkbox]').change(function () {

//        var checkedSkills = [];

//        $('.possibilities input[type=checkbox]').each(function () {

//            var skillName = $(this).attr("name");

//            if ($(this).is(":checked")) {
//                checkedSkills.push(skillName);

//            }
//        })

//        $.ajax({
//            async: true,
//            method: "Get",
//            url: "/Freelancer/FilterSkills",
//            traditional: true,
//            data: { 'skills': checkedSkills },
//            succes: function (data) {
//                $("#can").html(data);
//            },
//            error: function () {
//                alert("error");
//            }
//        })
//    });

//});