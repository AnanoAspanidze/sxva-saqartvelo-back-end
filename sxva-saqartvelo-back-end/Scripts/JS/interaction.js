/*--- candidat hover ---*/

$(".candidat").hover(function () {
    $(this).find('.img-candidat').toggleClass("hvr-yellow-back");
});

/*--- filter ---*/
if (!isTouchDevice()) {
    $('[data-toggle*="tooltip"]').tooltip();
  }
  
  // utility
  
  function isTouchDevice() {
      return !!('ontouchstart' in window || navigator.msMaxTouchPoints);
  }