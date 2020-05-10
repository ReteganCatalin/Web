$(document).ready(function(){
   $('#menu li').css("display","inline");
});

function clicker()
{
    $(this).on("click", function(e){
        //alert(e.target.getAttribute("id"))
        console.log('doc ready');
        $('#1ul,#2ul,#3ul,#4ul,#5ul').hide();
        console.log('element hidden');
        $("#"+e.target.getAttribute("id")+"ul").show();
        });
}
