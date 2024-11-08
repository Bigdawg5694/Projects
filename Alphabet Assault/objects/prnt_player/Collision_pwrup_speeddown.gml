/// @description lowers move speed
// You can write your code in this editor

if (_speed_multiplier != .25)
{
	_speed_multiplier -= .25;
}
instance_destroy(other);
alarm[1] = 30 * game_get_speed(gamespeed_fps);
