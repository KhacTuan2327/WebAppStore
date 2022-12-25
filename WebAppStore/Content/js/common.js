﻿const common = {
    init: function () {
        common.registerEvent();
    },
    registerEvent: function () {
        $(".search").autocomplete({
            minLength: 0,
            source: function (request, response) {
                $.ajax({
                    url: "/Product/ListTitle",
                    dataType: "json",
                    data: {
                        q: request.term
                    },
                    success: function (data) {
                        response(data.data);
                    }
                });
            },
            focus: function (event, ui) {
                $(".search").val(ui.item.label);
                return false;
            },
            select: function (event, ui) {
                $(".search").val(ui.item.label);
                return false;
            }
        })
            .autocomplete("instance")._renderItem = function (ul, item) {
                return $("<li>")
                    .append("<a>" + item.label + "</a>")
                    .appendTo(ul);
            };
    },
}
common.init();
