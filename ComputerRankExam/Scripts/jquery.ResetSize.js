function resetSize() {
	var windowWidth = $(window).width();

	if (windowWidth <= 1226) {
		$(".footer").css("width", "1226px");
		$(".header").css("width", "1226px");
		$(".content").css("width", "1226px");
	}
	else {
		$(".footer").css("width", "100%");
		$(".header").css("width", "100%");
		$(".content").css("width", "1226px");
	}
}

$(window).resize(resetSize);
$(document).ready(resetSize);