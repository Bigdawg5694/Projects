/// @description Insert description here
// You can write your code in this editor

// Inherit the parent event
event_inherited();

if (keyboard_check_pressed(vk_enter))
{
	scr_bullet_movement(x + lengthdir_x(48, image_angle), y + lengthdir_y(48, image_angle), range, (image_angle-30))
	scr_bullet_movement(x + lengthdir_x(48, image_angle), y + lengthdir_y(48, image_angle), range, image_angle)
	scr_bullet_movement(x + lengthdir_x(48, image_angle), y + lengthdir_y(48, image_angle), range, (image_angle+30))
}