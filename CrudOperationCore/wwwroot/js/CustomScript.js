$(document).ready(function () {

    $("#UserInputBtn").click(function () {
        var str = $("#UserInput").val();
        console.log(str);
    });

    $("#GetProvinces").click(function () {
        $.post('/Jquery/GetProvince', function (Provinces) {
            console.log(Provinces);
            debugger;

            $('#showprovince').empty();
            var list = $('<ul/>').appendTo('#showprovince');
            $.each(Provinces, function (index, pro) {
                list.append($('<li/>').text("Province Name : " +  pro.provinceName + " , " + "Province ID : " +  pro.provinceId));
            });
        

        });
    });
});
    
