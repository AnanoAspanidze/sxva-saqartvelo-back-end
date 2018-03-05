//$(document).ready(function(){
//    $("#searchInput").keydown(function () {
//        $("#loaderGif").show();
//        var searchResult = $(this).val();
//        debugger

//        $.ajax({
//            type: "Post",
//            url: "/Freelancer/GetSearchRecord?SearchResult=" + searchResult,
//            contentType: "html",
//            success: function (response) {
//                $("#loaderGif").hide();
//                $("#filterFreelancersData").html(response);
//            }
//        })
//    });
//});

//$(document).ready(function(){
//    $("#searchInput").keydown(function () {
//        $("#loaderGif").show();
//        var SearchResult = $(this).val();
//        debugger

//        $.ajax({
//            async: true,
//            method: "Post",
//            url: "/Freelancer/GetSearchRecord",
//            traditional: true,
//            data: { "SearchResult": SearchResult },
//            success: function (data) {
//                $("#loaderGif").hide();
//                $("#filterFreelancersData").html(data);
//            }


//        });
//    });
//});

$(document).ready(function () {
    $("#srch").click(function () {
        
        $("#loaderGif").show();
        var SearchResult = $("#searchInput").val();

        if (SearchResult == '') {
            alert("ჩაწერეთ საძიებო სიტყვა");
            $("#loaderGif").hide();
            return false;
        }
        
        $.ajax({
            async: true,
            method: "Post",
            url: "/Freelancer/GetSearchRecord",
            traditional: true,
            data: { "SearchResult": SearchResult },
            success: function (data) {
                $("#loaderGif").hide();
                $("#filterFreelancersData").html(data);
                $("#countedFreelancers").html($("#foundFreelancers").val()).html(); //არსებული ფრილანსერების რაოდენობის, ნაპოვნი ფრილანსერების რაოდენობით ჩანაცვლება.
            }
        });
    });
});




//$("#filterFreelancersData .candidat").filter(function(){
//    $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
//});
