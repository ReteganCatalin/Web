function modifyShape() {
    // code to modify svg here, e.g.:
    for (var i=1; i <= 10; i++) {
        document.getElementById("" + i).setAttribute('d', "M 40, 20 a 30,20 0 1,0 1,0");
        document.getElementById("" + i).setAttribute('style', "fill:aqua; stroke:green;fill-opacity: 10");
    }
}