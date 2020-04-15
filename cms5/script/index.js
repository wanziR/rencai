

//回到顶部 最新最全最好的Bootstrap模板：http://www.bootstrapmb.com
$(document).ready(function(){	
	//gotop
	$(".gotop").hide();
	$(window).scroll(function(){
		if ($(window).scrollTop()>100){
			$(".gotop").fadeIn(500);
		}else{
			$(".gotop").fadeOut(500);
		}
	});
	//当点击跳转链接后，回到页面顶部位置
	$(".gotop").click(function(){
		$('body,html').animate({scrollTop:0},800);
		return false;
	});
});
$(function(){

	$(".nav_bbs h3").click(function(){
		var ul=$(".new");
		if(ul.css("display")=="none"){
			ul.slideDown();
		}else{
			ul.slideUp();
		}
	});
	
	$(".set").click(function(){
		var _name = $(this).attr("name");
		if( $("[name="+_name+"]").length > 1 ){
			$("[name="+_name+"]").removeClass("select1");
			$(this).addClass("select1");
		} else {
			if( $(this).hasClass("select1") ){
				$(this).removeClass("select1");
			} else {
				$(this).addClass("select1");
			}
		}
	});
	
	$(".nav_bbs li").click(function(){
		var li=$(this).text();
		$(".nav_bbs h3").html(li);
		$(".new").hide();
		/*$(".set").css({background:'none'});*/
		$("h3").removeClass("select1") ;   
	});
})

//伪类选择器
$(function(){
	$(".planServer ul li:last-child").css({'margin-right': '0'});
	
	$(".conL .conUl:last-child").css({'float': 'right',"margin-right":"3%"});
	$(".comUl li:nth-child(4n)").css({'margin-right': '0'});
	$(".colOl li:last-child").css({'margin-right': '0'});
	$(".contac ul li:last-child").css({'float': 'right'});
	$(".serMainUl li:last-child").css({'border-bottom': 'none'});
	$(".serMainUl li dl dd:last-child").css({'margin-right': '0'});
	$(".soluDl dd:last-child").css({'margin-right': '0'});
	$(".trainUl li:last-child").css({'margin-right': '0'});
	$("#honOl li:nth-child(n+15)").css({'border-bottom': 'none'});
	$(".imporNew ul li:last-child").css({'border-bottom': 'none'});
	$(".couseUl li:last-child").css({'border-bottom': 'none'});
});
$(function() {
	$(".topR .china").click(function(){
		$(this).addClass('cur').siblings().removeClass('cur');
	});
	
	$(".nav ul li").hover(function(){
		$(this).addClass('cur').siblings().removeClass('cur');
	});
	
	$(".directoryTM a").click(function(){
		$(this).addClass('cur').siblings().removeClass('cur');
	});
	
	$(".planTitle ul li").hover(function(){
		$(this).addClass('cur').siblings().removeClass('cur');
	});
	
	$(".paging .num").click(function(){
		$(this).addClass('cur').siblings().removeClass('cur');
	});
	var mark=1;
	$(".comNav h2").click(function(){
		if(mark==1){//把他展开
			$(this).addClass("navH2");
			$(this).siblings('#comNav').slideDown();
			mark=2;
		}else if(mark==2){//收缩
			$(this).removeClass("navH2");
			$(this).siblings('#comNav').slideUp();
			mark=1;
		}
	});
	$("#slide").click(function(){
		
		$('.nav').animate({"right":"0"},300);
		$("#TB_overlayBG").css({
			display:"block",height:$(document).height()
		});	
		$(".comNav h2").removeClass("navH2");
		$(".comNav h2").siblings('#comNav').slideUp();
		mark=1;
	});
	$("#TB_overlayBG").click(function(){
		$('.nav').animate({"right":"-240px"},300);
		$("#TB_overlayBG").css({
			display:"none",height:$(document).height()
		});
	});
});


//导航
$(function(){

	var time = null;
	var list = $("#navlist");
	var box = $("#navbox");
	var lista = list.find("a");
	
	for(var i=0,j=lista.length;i<j;i++){
		if(lista[i].className == "now"){
			var olda = i;
		}
	}
	
	var box_show = function(hei){
		box.stop().animate({
			height:hei,
			opacity:1
		},400);
	}
	
	var box_hide = function(){
		box.stop().animate({
			height:0,
			opacity:0
		},400);
	}
	
	lista.hover(function(){
		clearTimeout(time);
		var index = list.find("a").index($(this));
		box.find(".cont").hide().eq(index).show();
		var _height = box.find(".cont").eq(index).height();
		box_show(_height)
	},function(){
		time = setTimeout(function(){	
			box.find(".cont").hide();
			box_hide();
		},50);
	});
	
	box.find(".cont").hover(function(){
		var _index = box.find(".cont").index($(this));
		clearTimeout(time);
		$(this).show();
		var _height = $(this).height();
		box_show(_height);
	},function(){
		time = setTimeout(function(){		
			$(this).hide();
			box_hide();
		},50);
	});

});
//按行业筛选
$(function(){
	$("#indestry").bind("mouseover", function() {
		$(this).children("h2").addClass("indeH2");
	    $(this).children(".indeLayer").addClass("indeLayer1");
	}).bind("mouseout", function() {
		$(this).children("h2").removeClass("indeH2");
	    $(this).children(".indeLayer").removeClass("indeLayer1");	
	});
});

var result = false;
window.onload = function() {
	if($(window).width()<750){

		var mySwiper1 = new Swiper('#tab',{
	        nextButton: '.swiper-button-next',
	        prevButton: '.swiper-button-prev',
	        slidesPerView: 'auto',
		    speed:500,
	        paginationClickable: true,
			freeMode : true,
			slidesPerView : 'auto'
		});
		var mySwiper1 = new Swiper('#tab1',{
	        nextButton: '.swiper-button-next',
	        prevButton: '.swiper-button-prev',
	        slidesPerView: 'auto',
		    speed:500,
	        paginationClickable: true,
			freeMode : true,
			slidesPerView : 'auto'
		});
	}
	$(document).ready(function(){
		var $tab_li = $('#tab .tab_div');
		$tab_li.hover(function(){	   
			$(this).addClass('selectedl').siblings().removeClass('selectedl');
			var index = $tab_li.index(this);
			$('div.tab_box').eq($(".tabs .active").index()).find('> div').eq(index).show().siblings().hide();
		   
		});	
	});
	
}
$(document).ready(function(){
	var $tab_li = $('#tabDown ul li');
	$tab_li.hover(function(){
		$(this).addClass('selected').siblings().removeClass('selected');
		var index = $tab_li.index(this);
		$('div.tab_boxD > div').eq(index).show().siblings().hide();
	});	
});
	

$(function(){
	var width1 = $(window).width();
	var a = 749;
	if(width1>=a){
    	$(".list ul li:last-child").css({'display': 'none'});
	};
});
//微信弹出
$(function(){
	var width2 = $(window).width();
	var b = 667;
	if(width2<=b){
		var mark=1;
    	$("#web").bind("click", function(){
			if(mark==1){//把他展开
				$(this).siblings('.webLayer').fadeIn();
				mark=2;
			}else if(mark==2){//收缩
				$(this).siblings('.webLayer').fadeOut();
				mark=1;
			}
		});
		
		var mark=1;
		$("#QQ").bind("click", function(){
			if(mark==1){//把他展开
				$(this).siblings('.QQlayer').fadeIn();
				mark=2;
			}else if(mark==2){//收缩
				$(this).siblings('.QQlayer').fadeOut();
				mark=1;
			}
		});
	};
});

$(function(){
	var widtha = $(window).width();
	var z = 432;
	if(widtha>=z){
		$(".directory ul li:nth-child(4n)").css({'margin-right': '0',"float":"right"});
	};
});


