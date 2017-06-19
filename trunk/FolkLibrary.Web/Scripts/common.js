(function ($) {
    $.fn.serializeJson = function () {
        var serializeObj = {};
        var array = this.serializeArray();
        var str = this.serialize();
        $(array).each(function () {
            if (serializeObj[this.name]) {
                if ($.isArray(serializeObj[this.name])) {
                    serializeObj[this.name].push(this.value);
                } else {
                    serializeObj[this.name] = [serializeObj[this.name], this.value];
                }
            } else {
                serializeObj[this.name] = this.value;
            }
        });
        return serializeObj;
    };
    $.extend({
        encodeHTML: function (strSource) {
            if (strSource === "" || strSource == null) {
                return "";
            }
            strSource = strSource
                .replace(/&/g, '&amp;')
                .replace(/</g, '&lt;')
                .replace(/>/g, '&gt;')
                .replace(/"/g, "&quot;")
                .replace(/'/g, "&#39;");
            return encodeURIComponent(strSource);
        },
        decodeHTML: function (strSource) {
            if (strSource === "" || strSource == null) {
                return "";
            }
            strSource = decodeURIComponent(strSource);
            strSource= strSource.replace(/&amp;/g, "&")
                .replace(/&lt;/g, "<")
                .replace(/&gt;/g, ">")
                .replace(/&quot;/g, "\"")
                .replace(/&#39;/g, "'");
          return strSource;
        }
    });
})(jQuery);