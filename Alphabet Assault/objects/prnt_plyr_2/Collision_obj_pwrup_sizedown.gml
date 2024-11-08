/// @description Insert description here
// You can write your code in this editor

instance_destroy(other);

if(_size_multiplier != .25)
{
	_size_multiplier -= .25;
}

alarm[1] = 10 * game_get_speed(gamespeed_fps);
