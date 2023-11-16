(function ($) {
    $.fn.registerInputAmount = function () {
        var $this = $(this);
        $this.find('.input-amount').toArray().forEach(function (field) {
            new Cleave(field, {
                numeral: true,
                numericOnly: true,
                numeralPositiveOnly: true, // So duong
                numeralDecimalMark: ',',
                delimiter: '.',
                numeralThousandGroupStyle: 'thousand',
            });
            field.value = field.value;
        });
    };
})(jQuery);