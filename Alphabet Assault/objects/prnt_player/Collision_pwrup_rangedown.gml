/// @description lowers the range
// You can write your code in this editor

if (_range_multiplier != .25)
{
	_range_multiplier -= .25;
}
instance_destroy(other);
alarm[5] = 30 * game_get_speed(gamespeed_fps);
