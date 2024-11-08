/// @description Insert description here
// You can write your code in this editor

// Inherit the parent event
event_inherited();

if (keyboard_check_pressed(vk_enter))
{
	scr_laser_movement(x + lengthdir_x(64, image_angle), y + lengthdir_y(64, image_angle), range, image_angle)
}