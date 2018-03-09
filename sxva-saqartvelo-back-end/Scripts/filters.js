$(document).ready(function () {


    //For Search Input
    $("#searchInput").keypress(function (e) {
        if (e.which == "13") {
            getFiltersResult();
        }
    });


    $("#srch").click(function () {
        getFiltersResult();
    });
    //

    //For CheckBox
    $('.possibilities-section .possibilities input[type=checkbox]').change(function () {
        getFiltersResult();
    });
    //

    //For Range Slider Filter
    $("#button1").click(function () {
        getFiltersResult();
    });

    $("#button2").on("click", function () {
        getFiltersResult();
    });
    //

    $("#rating_low #rating_hight").keypress(function (e) {
        if (e.which == "13") {
            getFiltersResult();
        }
    });




    //$(".clear-search").click(function () {
    //    getFiltersResult();
    //});


    function getFiltersResult() {


        //For Search Input
        $("#srchImg").attr("src", "/img/searchSpin.svg");
        var searchInput = $("#searchInput").val();
        alert(searchInput);
        //


        //For CheckBox
        var checkedSkills = [];
        $('.possibilities-section .possibilities input[type=checkbox]').each(function () {
            var skillIds = $(this).attr("name");
            if ($(this).is(":checked")) {
                checkedSkills.push(skillIds);
            }
        });
        //

        ////For Range Slider Filter
        var ratingLow = $("#rating_low").val();
        var ratingHight = $("#rating_hight").val();
        var ratingLowInput = $("#rating_low").val();
        var ratingHightInput = $("#rating_hight").val();
        ////
        //alert(ratingLow);
        //alert(ratingHight);
        alert(ratingLowInput);
        alert(ratingHightInput);




        $.ajax({
            method: "Get",
            url: "/Freelancer/FilterFreelancerData",
            traditional: true,
            data: {
                SearchInput: searchInput,
                CheckedSkills: checkedSkills,
                RatingLow: ratingLow,
                RatingHight: ratingHight,
                RatingLowInput: ratingLowInput,
                RatingHightInput: ratingHightInput
            },
            success: function (data) {
                $("#srchImg").attr("src", "/img/search.svg").show();
                $("#filterFreelancersData").html(data);
                $("#countedFreelancers").html($("#foundFreelancers").val()).html();
            }
        });
    }
});










//$(document).ready(function () {

//    //For CheckBox
//    $('.possibilities-section .possibilities input[type=checkbox]').change(function () {
//        getFiltersResult();
//    });
//    //

//    //For Range Slider Filter
//    $("#button1").click(function () {
//        getFiltersResult();
//    });

//    $("#button2").on("click", function () {
//        getFiltersResult();
//    });
//    //


//    //For Search Input
//    $("#searchInput").keypress(function (e) {
//        if (e.which == "13") {
//            getFiltersResult();
//        }
//    });


//    $("#srch").click(function () {
//        getFiltersResult();
//    });
//    //

//    //$(".clear-search").click(function () {
//    //    getFiltersResult();
//    //});


//    function getFiltersResult() {

//        //For CheckBox
//        var checkedSkills = [];
//        $('.possibilities-section .possibilities input[type=checkbox]').each(function () {
//            var skillIds = $(this).attr("name");
//            if ($(this).is(":checked")) {
//                checkedSkills.push(skillIds);
//            }
//        });
//        //

//        ////For Range Slider Filter
//        var ratingLow = $("#rating_low").val();
//        var ratingHight = $("#rating_hight").val();
//        ////
//        //alert(ratingLow);
//        //alert(ratingHight);

//        //For Search Input
//        $("#srchImg").attr("src", "/img/searchSpin.svg");
//        var searchInput = $("#searchInput").val();
//        alert(searchInput);
//        //




//        $.ajax({
//            method: "Get",
//            url: "/Freelancer/FilterFreelancerData",
//            traditional: true,
//            data: { 
//                CheckedSkills: checkedSkills,
//                RatingLow: ratingLow,
//                RatingHight: ratingHight,
//                SearchInput: searchInput
//            },
//            success: function (data) {
//                $("#srchImg").attr("src", "/img/search.svg").show();
//                $("#filterFreelancersData").html(data);
//                $("#countedFreelancers").html($("#foundFreelancers").val()).html();
//            }
//        });
//    }
//});


















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

