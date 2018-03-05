$(function () {

    $('.possibilities-section .possibilities input[type=checkbox]').change(function () {
        $("#loaderGif").show();
        var checkedSkills = [];

        $('.possibilities-section .possibilities input[type=checkbox]').each(function () {

            var skillName = $(this).attr("name");
            if ($(this).is(":checked")) {
                checkedSkills.push(skillName);
                
            }
        })

        $.ajax({
            async: true,
            method: "Get",
            url: "/Freelancer/FilterFreelancerByCheckBox",
            traditional: true,
            data: { 'skills': checkedSkills },
            success: function (data) {
                $("#loaderGif").hide();
                $("#filterFreelancersData").html(data);
                $("#countedFreelancers").html($("#foundFreelancers").val()).html();
            },
            error: function () {
                alert("error");
            }
        });
    });

});