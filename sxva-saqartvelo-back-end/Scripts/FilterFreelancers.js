$(function () {

    //$('.possibilities-section .possibilities input[type=checkbox]').prop("checked", true);

    $('.possibilities-section .possibilities input[type=checkbox]').change(function () {

        
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
            url: "/Freelancer/FilterFreelancerData",
            traditional: true,
            data: { 'skills': checkedSkills },
            success: function (data) {
                $("#filterFreelancersData").html(data);
            },
            error: function () {
                alert("error");
            }
        });
        //if ($('input[type=checkbox]').attr('checked', false)) {
        //    $("#filterFreelancersData").html('');
        //}
    });

});