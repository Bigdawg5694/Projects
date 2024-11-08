/// @description Insert description here
// You can write your code in this editor

// Inherit the parent event
event_inherited();

if (keyboard_check_pressed(vk_enter))
{
	scr_bullet_movement(x + lengthdir_x(48, image_angle), y + lengthdir_y(48, image_angle), range, image_angle);
	scr_bullet_movement(x + lengthdir_x(48, image_angle+45), y + lengthdir_y(48, image_angle+45), range, (image_angle+45));
	scr_bullet_movement(x + lengthdir_x(48, image_angle+90), y + lengthdir_y(48, image_angle+90), range, (image_angle+90));
	scr_bullet_movement(x + lengthdir_x(48, image_angle+135), y + lengthdir_y(48, image_angle+135), range, (image_angle+135));
	scr_bullet_movement(x + lengthdir_x(48, image_angle+180), y + lengthdir_y(48, image_angle+180), range, (image_angle+180));
	scr_bullet_movement(x + lengthdir_x(48, image_angle+225), y + lengthdir_y(48, image_angle+225), range, (image_angle+225));
	scr_bullet_movement(x + lengthdir_x(48, image_angle+270), y + lengthdir_y(48, image_angle+270), range, (image_angle+270));
	scr_bullet_movement(x + lengthdir_x(48, image_angle+315), y + lengthdir_y(48, image_angle+315), range, (image_angle+315));
}