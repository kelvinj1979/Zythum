/*============================================================ 
BANNER
============================================================*/

$(".fade-slider").jdSlider({

	isSliding: false,
	isAuto: true,
	isLoop: true,
	isDrag: false,
	interval:5000,
	isCursor: false,
	speed:3000

});

var sliderheight = $(".fade-slider").height();
$(".static-banner").css({"height":sliderheight+"px"})

/*============================================================ 
SCROLL ANIMATION
============================================================*/
$(window).scroll(function(){

    var posY =window.pageYOffset;

    if (posY > sliderheight){

        $("header").css({"background":"rgba(226, 190, 75,.5)"})

    }else{

        $("header").css({"background":"rgba(226, 190, 75, 255)"})

    }
})

/*============================================================ 
    MENU
============================================================*/
$(".fa-bars").click(function(){

    $(".menu").fadeIn("fast");

})

$(".btnClose").click(function(){

    $(".menu").fadeOut("fast");

})


/*============================================================ 
    POST DETAIL
============================================================*/
// Rating Initialization
$(document).ready(function() {
    $('#rateMe1').mdbRate();
  });


/*============================================================ 
    PAGINATION
============================================================*/
$(".pagination").twbsPagination({
    totalPages: 10,
    visiblePages: 4,
    prev: '<i class="fa fa-angle-left"></i>', 
    next: '<i class="fa fa-angle-right"></i>'
});

/*============================================================ 
    PAGINATION
============================================================*/

var controller = $.superscrollorama();

controller.addTween(".contain_init .container", TweenMax.from(

    $(".contain_init .container"), .5, {css:{opacity: 0}}
))

/*=============================================
SCROLL UP
=============================================*/

$.scrollUp({
	scrollText:"",
	scrollSpeed: 2000,
	easingType: "easeOutQuint"
})