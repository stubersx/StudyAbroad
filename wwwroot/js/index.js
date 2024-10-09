$(document).ready(function () {

    // display first message on the index page
    let $i = 0;
    let $speed = 300;
    let $message = ["", "Make", "your", "study", "abroad", "experience", "a success", "a success!"];
    let $txt = "";

    firstMsg();

    function firstMsg() {
        if ($i < $message.length) {
            $txt = $message[$i];
            $("#msg").text($txt);
            $i++;
            setTimeout(firstMsg, $speed);
        }
        else {
            $("#cover").fadeOut(3000);
            cssChange();
        }
    }

    // display index page contents
    function cssChange() {
        $("#wrapper").animate({ marginTop: "0" }, 2000);
        $("body").css("overflow-y", "scroll");
    }

    /* fix a bug when reload -- delete cache setting?
        $(window).on("load", function () {
            $("#brand").trigger("click");
        });
    */
});
