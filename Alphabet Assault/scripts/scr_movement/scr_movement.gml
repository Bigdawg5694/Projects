// Script assets have changed for v2.3.0 see
// https://help.yoyogames.com/hc/en-us/articles/360005277377 for more information
function scr_movement(up, down, left, right, _multiplier){
	var spd = 0;
	if (up)
	{
		spd = 1.5;
	}
	else if (down)
	{
		spd = -0.7;
	}
	
	spd *= _multiplier;
	
	image_angle += (left + (-right)) * 2;

	var hspd = lengthdir_x(spd, image_angle);
	var vspd = lengthdir_y(spd, image_angle);
	
	if (place_meeting(x + hspd, y + vspd, prnt_player)) 
	{
		hspd = 0;
		vspd = 0;
	}
	
	x += hspd;
	y += vspd;
}