/*==============================
    zoom js
==============================*/
function zoom(e) {
  var zoomer = e.currentTarget;
  e.offsetX ? offsetX = e.offsetX : offsetX = e.touches[0].pageX
  e.offsetY ? offsetY = e.offsetY : offsetX = e.touches[0].pageX
  x = offsetX / zoomer.offsetWidth * 100
  y = offsetY / zoomer.offsetHeight * 100
  zoomer.style.backgroundPosition = x + '% ' + y + '%';
}

/*==============================
    popup js
==============================*/
$(window).on('load', function () {
  var popup = localStorage.getItem('popup_value');
  if (popup != 1) {
    $('#news-letter-modal').modal('show');
  }

  /*==============================
      pre-loader js
  ==============================*/

  $('.preloader').delay(100).fadeOut('fast');
});

(function ($) {
  "use strict";
  /*==============================
      sticky header js
  ==============================*/
  var lastScrollTop = 0;
  $(document).on("scroll", function () {
    var scroll = $(this).scrollTop();
    if (scroll > lastScrollTop) {
      $('.header-area').addClass('sticky-down');
      $('.header-area').removeClass('sticky-up');
    }
    else {
      if (lastScrollTop <= 100) {
        $('.header-area').removeClass('sticky');
        $('.header-area').removeClass('sticky-down');
        $('.header-area').removeClass('sticky-up');
      }
      else {
        $('.header-area').addClass('sticky');
        $('.header-area').removeClass('sticky-down');
        $('.header-area').addClass('sticky-up');
      }
    }
    lastScrollTop = scroll;
  });

  /*==============================
      menu js
  ==============================*/
  $('button.toggler-button').on('click', function () {
    $('#menu-toggle').addClass("active");
    $('.screen-bg').addClass("active");
  });
  $('button.close-menu').on('click', function () {
    $('#menu-toggle').removeClass("active");
    $('.screen-bg').removeClass("active");
  });

  /*==============================
      filter js
  ==============================*/
  $('button.filter-button').on('click', function () {
    $('.filter-sidebar').addClass("active");
    $('.screen-bg').addClass("active");
  });
  $('button.close-filter-sidebar').on('click', function () {
    $('.filter-sidebar').removeClass("active");
    $('.screen-bg').removeClass("active");
  });

  /*==============================
      cart js
  ==============================*/
  $('a.cart-count').on('click', function () {
    $('.mini-cart').addClass("active");
    $('body').addClass("hidden");
    $('.screen-bg').addClass("active");
  });
  $('button.cart-close').on('click', function () {
    $('.mini-cart').removeClass("active");
    $('body').removeClass("hidden");
    $('.screen-bg').removeClass("active");
  });
  $('.add-to-cart').on('click', function () {
    $('.mini-cart').addClass("active");
    $('.screen-bg').addClass("active");
  });

  /*==============================
      screen-bg js
  ==============================*/
  $('.screen-bg').on('click', function () {
    $('#menu-toggle').removeClass("active");
    $('.filter-sidebar').removeClass("active");
    $('.mini-cart').removeClass("active");
    $(this).removeClass("active");
    $('body').removeClass("hidden");
  });

  /*==============================
      read-agree js
  ==============================*/
  $('label.box-area, .read-agree').on('click', function () {
    if ($('.cust-checkbox, .create-checkbox').is(':checked')) {
      $('.checkout, .create').removeClass('disabled');
    }
    else {
      $('.checkout, .create').addClass('disabled');
    }
  });

  /*==============================
      home-slider js
  ==============================*/
  var menu = ['EARBUDS S9','VR BOX','HEADPHONES']
  var swiper = new Swiper('#home-slider', {
    slidesPerView: 1,
    loop: true,
    speed: 5000,
    observer: true,
    observeParents: true,
    watchSlidesProgress: true,
    navigation: {
      nextEl: '.swiper-next',
      prevEl: '.swiper-prev',
    },
    autoplay: true,
    autoplayTimeout: 5000,
    autoplayHoverPause: true,
    autoplaySpeed: 250,
  });

  /*==============================
      slider-category js
  ==============================*/
  $('#category-slider').owlCarousel({
      loop: false,
      margin: 30,
      nav: false,
      navText: ['<i class="ri-arrow-left-line"></i>','<i class="ri-arrow-right-line"></i>'],
      dots: false,
      autoplay: true,
      autoplayTimeout: 5000,
      autoplayHoverPause: true,
      responsive:{
        0: {
          items: 1,
          margin: 12
        },
        320: {
          items: 2,
          margin: 12
        },
        479: {
          items: 2,
          margin: 12
        },
        540: {
          items: 2,
          margin: 12
        },
        640: {
          items: 3,
          margin: 12
        },
        768: {
          items: 3
        },
        979: {
          items: 4
        },
        1199: {
          items: 4
        },
        1499: {
          items: 5
        }
      }
    });

  /*==============================
      special-category js
  ==============================*/
  var swiper = new Swiper('.swiper#special-category', {
    slidesPerView: 4,
    autoplay: true,
    autoplayTimeout: 5000,
    autoplayHoverPause: true,
    observer: true,
    observeParents: true,
    watchSlidesProgress: true,
    grid: {
      rows: 2,
      fill: 'row' | 'column'
    },
    navigation: {
      nextEl: '.swiper-next',
      prevEl: '.swiper-prev',
    },
    breakpoints: {
      0: {
        slidesPerView: 1,
        grid: {
          rows: 2,
          fill: 'row' | 'column'
        },
        spaceBetween: 12
      },
      320: {
        slidesPerView: 1,
        grid: {
          rows: 2,
          fill: 'row' | 'column'
        },
        spaceBetween: 12
      },
      360: {
        slidesPerView: 2,
        grid: {
          rows: 2,
          fill: 'row' | 'column'
        },
        spaceBetween: 12
      },
      540: {
        slidesPerView: 2,
        grid: {
          rows: 2,
          fill: 'row' | 'column'
        },
        spaceBetween: 12
      },
      640: {
        slidesPerView: 2,
        grid: {
          rows: 2,
          fill: 'row' | 'column'
        },
        spaceBetween: 12
      },
      768: {
        slidesPerView: 2,
        grid: {
          rows: 2,
          fill: 'row' | 'column'
        },
        spaceBetween: 30
      },
      1024: {
        slidesPerView: 3,
        grid: {
          rows: 2,
          fill: 'row' | 'column'
        },
        spaceBetween: 30
      },
      1199: {
        slidesPerView: 4,
        grid: {
          rows: 2,
          fill: 'row' | 'column'
        }
      }
    }
  });

  /*==============================
      testimonial js
  ==============================*/
    $('#testimonial-slider').owlCarousel({
      items: 1,
      margin: 30,
      nav: false,
      navText: ['<i class=" feather-arrow-left"></i>','<i class=" feather-arrow-right"></i>'],
      responsive: {
        0: {
          items: 1,
          margin: 12
        },
        479: {
          items: 1,
          margin: 12
        },
        768: {
          items: 1,
          margin: 12
        },
        979: {
          items: 1
        },
        1024: {
          items: 2
        },
        1199: {
          items: 2
        }
      }
    });


  /*========================================== 
      minus and plus btn js
  ==========================================*/
  $('.dec').on("click", function () {
    var $input = $(this).parent().find('input');
    var count = parseInt($input.val()) - 1;
    count = count < 1 ? 1 : count;
    $input.val(count);
    $input.change();
    return false;
  });

  $('.inc').on("click", function () {
    var $input = $(this).parent().find('input');
    $input.val(parseInt($input.val()) + 1);
    $input.change();
    return false;
  });

  /*===================================
      product-short js
  ===================================*/
  $('.product-short a.short-title-lg').on('click', function () {
    if ($('#select-wrap').hasClass('active')) {
      $('#select-wrap').removeClass('active');
      $(this).removeClass('active');
    }
    else {
      $('#select-wrap').addClass('active');
      $(this).addClass('active');
    }
  });

  /*============================== 
      quickview js
  ==============================*/
  var galleryThumbs = new Swiper(".gallery-thumbs", {
    spaceBetween: 15,
    slidesPerView: 3,
    thumbs: {
      swiper: galleryTop,
    },
  });
  var galleryTop = new Swiper(".gallery-top", {
    spaceBetween: 15,
    navigation: {
      nextEl: ".quick-next",
      prevEl: ".quick-prev",
    },
    thumbs: {
      swiper: galleryThumbs,
    },
  });

  /*==============================
     video popup js
  ==============================*/
  $('.play-button').magnificPopup({
    type: 'iframe',
    tClose: 'Close (Esc)',
    mainClass: 'mfp-fade',
    removalDelay: 160
  }); 

  /*==============================
      counter js
  ==============================*/
  $('.count-number').counterUp({
    delay: 10,
    time: 1000
  });

  /*==============================
      back-to-top js
  ==============================*/
  $(window).on("scroll", function () {
    if ($(this).scrollTop() > 600) {
      $('#top').addClass('show');
    }
    else {
      $('#top').removeClass('show');
    }
  });
  $('#top').on("click", function () {
    $("html, body").animate({ scrollTop: 0 }, 0);
    return false;
  });

})(jQuery);