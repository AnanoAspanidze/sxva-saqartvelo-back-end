$(document).ready(function(){
    $("#searchInput").keydown(function () {
        $("#loaderGif").show();
        var searchResult = $(this).val();
        debugger

        $.ajax({
            type: "Post",
            url: "/Freelancer/GetSearchRecord?SearchResult=" + searchResult,
            contentType: "html",
            success: function (response) {
                $("#loaderGif").hide();
                $("#filterFreelancersData").html(response);
            }
        })
    });
});




//$("#filterFreelancersData .candidat").filter(function(){
//    $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
//});
