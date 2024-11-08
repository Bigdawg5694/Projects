/// @description Insert description here
// You can write your code in this editor

// Inherit the parent event
event_inherited();

if (keyboard_check_pressed(vk_space))
{
<<<<<<< Updated upstream:objects/obj_player_I/Step_0.gml
	scr_laser_movement(x, y, range * _range_multiplier, image_angle)
=======
	scr_bullet_movement(x + lengthdir_x(48, image_angle), y + lengthdir_y(48, image_angle), range, image_angle);
>>>>>>> Stashed changes:objects/obj_player_A_1/Step_0.gml
}