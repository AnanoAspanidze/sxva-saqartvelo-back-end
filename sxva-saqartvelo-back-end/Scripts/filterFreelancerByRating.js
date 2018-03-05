$(document).ready(function () {
    $("#button1").click(function () {

        $("#loaderGif").show();
        var ratingLow = $("#rating_low").val();

        $.ajax({
            async: true,
            method: "Get",
            url: "/Freelancer/filterFreelancerByRating",
            traditional: true,
            data: { "ratingLow": ratingLow },
            success: function (data) {
                $("#loaderGif").hide();
                $("#filterFreelancersData").html(data);
            }
        });
    });

    $("#button2").on("click", function () {

        $("#loaderGif").show();

        var ratingHight = $("#rating_hight").val();

        $.ajax({
            async: true,
            method: "Get",
            url: "/Freelancer/filterFreelancerByRating",
            traditional: true,
            data: { "ratingHight": ratingHight },
            success: function (data) {
                $("#loaderGif").hide();
                $("#filterFreelancersData").html(data);
            }
        });
    });

});