/// @description lowers bullet size
// You can write your code in this editor

if (_size_multiplier != .25)
{
	_size_multiplier -= .25;
}
instance_destroy(other);
alarm[3] = 30 * game_get_speed(gamespeed_fps);
