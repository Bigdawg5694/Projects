/// @description Insert description here
// You can write your code in this editor

// Inherit the parent event
event_inherited();

if (keyboard_check_pressed(vk_space))
{
	scr_laser_movement(x + lengthdir_x(64, image_angle), y + lengthdir_y(64, image_angle), range, image_angle)
	scr_laser_movement(x + lengthdir_x(64, image_angle+150), y + lengthdir_y(64, image_angle+150), range, image_angle+150)
	scr_laser_movement(x + lengthdir_x(64, image_angle-150), y + lengthdir_y(64, image_angle-150), range, image_angle-150)
}