function sendComment() {
        var comment = {
            "BlogID": parseInt($("").val()),
            "Comment": $("").val(),
            "Author": $("").val()
        };
        $.ajax({
            type: "POST",
            url: '/api/CommentApi/Post',
            data: JSON.stringify(comment),
            contentType: "application/json;charset=utf-8",
            processData: true,
            success: function (resultdata, status) {
                alert("Meddelandet har skickats");
            },
            error: function (resultdata, status) {
                alert("Meddelandet kunde ej skickas");
            }
        });
}