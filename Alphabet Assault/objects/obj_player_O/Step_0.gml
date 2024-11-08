/// @description Insert description here
// You can write your code in this editor

// Inherit the parent event
event_inherited();

if (keyboard_check_pressed(vk_space))
{
	scr_bullet_movement(x, y, range * _range_multiplier, image_angle, _size_multiplier)
	scr_bullet_movement(x, y, range * _range_multiplier, (image_angle+45), _size_multiplier)
	scr_bullet_movement(x, y, range * _range_multiplier, (image_angle+90), _size_multiplier)
	scr_bullet_movement(x, y, range * _range_multiplier, (image_angle+135), _size_multiplier)
	scr_bullet_movement(x, y, range * _range_multiplier, (image_angle+180), _size_multiplier)
	scr_bullet_movement(x, y, range * _range_multiplier, (image_angle+225), _size_multiplier)
	scr_bullet_movement(x, y, range * _range_multiplier, (image_angle+270), _size_multiplier)
	scr_bullet_movement(x, y, range * _range_multiplier, (image_angle+315), _size_multiplier)
}