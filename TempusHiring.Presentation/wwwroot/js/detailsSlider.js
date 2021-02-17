jQuery(document).ready(function ($) {
    var slideCount = $('#details-slider ul li').length;
    var slideWidth = $('#details-slider ul li').width();
    var slideHeight = $('#details-slider ul li').height();
    var sliderUlWidth = slideCount * slideWidth;

    $('#details-slider').css({ width: slideWidth, height: slideHeight });

    $('#details-slider ul').css({ width: sliderUlWidth, marginLeft: - slideWidth });

    $('#details-slider ul li:last-child').prependTo('#details-slider ul');

    function moveLeft() {
        $('#details-slider ul').animate({
            left: + slideWidth
        }, 200, function () {
            $('#details-slider ul li:last-child').prependTo('#details-slider ul');
            $('#details-slider ul').css('left', '');
        });
    };

    function moveRight() {
        $('#details-slider ul').animate({
            left: - slideWidth
        }, 200, function () {
            $('#details-slider ul li:first-child').appendTo('#details-slider ul');
            $('#details-slider ul').css('left', '');
        });
    };

    $('div.details-slider_control_prev').click(function () {
        moveLeft();
    });

    $('div.details-slider_control_next').click(function () {
        moveRight();
    });
});