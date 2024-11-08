/// @description Insert description here
// You can write your code in this editor

// Inherit the parent event
event_inherited();

if (keyboard_check_pressed(vk_enter))
{
	scr_laser_movement(x, y, range, image_angle)
	scr_laser_movement(x, y, range, image_angle+150)
	scr_laser_movement(x, y, range, image_angle-150)
}