// Script assets have changed for v2.3.0 see
// https://help.yoyogames.com/hc/en-us/articles/360005277377 for more information
function scr_hyperlink_sprite(sprite_array){
	randomize();
	spr_use = irandom_range(0, 5);
	sprite_index = sprite_array[spr_use];
}