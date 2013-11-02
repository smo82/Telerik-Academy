

/* Custom jQuery accordion for Telerik Academy exam */

(function ($) {
    $.fn.accordion = function () {
        var self = this;
        $(self).find("ul").hide();
        $(self).find("#activegames-list").show("slow");

        $(self).on("click", "h4", function () {
            $(self).find("ul").hide('slow');
            $(this).next("ul").toggle('slow');
        });

        return $(this);
    }
}(jQuery));