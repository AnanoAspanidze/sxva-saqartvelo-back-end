$(document).ready(function () {
    //For Search Input
    $("#searchInput").keypress(function (e) {
        if (e.which == "13") {
            getFiltersResult();
        }
    });
    //

    //For CheckBox
    $('.possibilities-section .possibilities input[type=checkbox]').change(function () {
        getFiltersResult();
    });
    //

    //For Range Slider Filter
    $("button1").click(function () {
        getFiltersResult();
    });

    $("button2").on("click", function () {
        getFiltersResult();
    });
    //




    function getFiltersResult() {

        //For Search Input
        $("#srchImg").attr("src", "/img/searchSpin.svg");
        var searchInput = $("#searchInput").val();
        //

        //For CheckBox
        var checkedSkills = [];
        $('.possibilities-section .possibilities input[type=checkbox]').each(function () {
            var skillName = $(this).attr("name");
            if ($(this).is(":checked")) {
                checkedSkills.push(skillName);
            }
        });
        //

        //For Range Slider Filter
        var ratingLow = $("#rating_low").val();
        var ratingHight = $("#rating_hight").val();
        //
        alert(ratingLow);
        alert(ratingHight);

        $.ajax({
            method: "Get",
            url: "/Freelancer/FilterFreelancerData",
            traditional: true,
            data: {
                SearchInput: searchInput,
                CheckedSkills: checkedSkills,
                RatingLow: ratingLow,
                RatingHight: ratingHight
            },
            success: function (data) {
                $("#srchImg").attr("src", "/img/search.svg").show();
                $("#filterFreelancersData").html(data);
            }
        });
    }
});


































//$(document).ready(function () {

//    $("#searchInput").keypress(function (e) {
//        if (e.which == "13") {
//            getFiltersResult();
//        }
//    });

//    function getFiltersResult() {
        
//        var searchInput = $("#searchInput").val();

//        $.ajax({
//            method: "Get",
//            url: "/Freelancer/FilterFreelancerData",
//            traditional: true,
//            data: {
//                SearchInput: searchInput
//            },
//        })
//        .done(function (msg) {
//            $("#filterFreelancersData").html(msg);
//        });
//    }


//});

