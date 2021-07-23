    $(document).ready(function () {
        $("#btnSubmit").click(function () {

            var myformdata = $("#myForm").serialize();

            $.ajax({
                type: "POST",
                url: "/Staff/Create",
                data: myformdata,
                dataType: 'json',
                //success: function () {
                //    $("#myModal").modal("hide");
                    
                //}
            })
        })

        
    });


