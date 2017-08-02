//主菜单的js

$(document).ready(function(e) {
	$('#but01').click(function(){//单击ID为#login的A标签
		$('.tanc').fadeIn();//名为#login_box的DIV显示,时间为1000毫秒=1秒
		//$('#mask').fadeIn();//名为#mask的DIV显示
		})
	$('.yiny').click(function(){
		$('.tanc').fadeOut();//名为#login_box的DIV隐藏
		//$('#mask').fadeOut();//名为#mask的DIV隐藏
		})
		$('#hh').click(function(){
		$('.tanc').fadeOut();//名为#login_box的DIV隐藏
		})
		$('.cha').click(function(){
		$('.tanc').fadeOut();//名为#login_box的DIV隐藏
		})
})
