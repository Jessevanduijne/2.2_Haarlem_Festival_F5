var slideIndex = 0;
showSlides(slideIndex);

function plusSlides(n) {
    showSlides(slideIndex += n);
}

function currentSlide(n) {
    showSlides(slideIndex = n);
}

function showSlides(n) {
    var i;
    var slides = document.getElementsByClassName("Slide");
    var leftPane;
    var rightPane;

    if (n > slides.length - 1) { slideIndex = 0 }
    else if (n < 0) { slideIndex = slides.length - 1 }
    else { slideIndex = n }

    if (slideIndex - 1 < 0) { leftPane = slides.length - 1; }
    else { leftPane = slideIndex - 1; }

    if (slideIndex + 1 > slides.length - 1) { rightPane = 0; }
    else { rightPane = slideIndex + 1; }

    for (i = 0; i < slides.length; i++) {
        slides[i].className = "Slide";
    }
    slides[slideIndex].className = "Slide SlideCenter";
    slides[leftPane].className = "Slide SlideSides SlideLeft";
    slides[rightPane].className = "Slide SlideSides SlideRight";
}