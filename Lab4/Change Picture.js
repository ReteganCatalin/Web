function changeBackground(){
    var body = document.getElementsByTagName('body')[0];
    if(body.style.backgroundImage === "" || body.style.backgroundImage === "url(\"1.jpg\")" ) {
        body.style.backgroundImage = "url(2.jpg)";
    }
    else if(body.style.backgroundImage === "url(\"2.jpg\")") {
        body.style.backgroundImage = "url(3.jpg)";
    }
    else if(body.style.backgroundImage === "url(\"3.jpg\")") {
        body.style.backgroundImage = "url(4.jpg)";
    }
    else if(body.style.backgroundImage === 'url(\"4.jpg\")') {
        body.style.backgroundImage = "url(5.jpg)";
    }
    else if(body.style.backgroundImage === "url(\"5.jpg\")") {
        body.style.backgroundImage = "url(1.jpg)";
    }
}