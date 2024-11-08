/// @description Insert description here
// You can write your code in this editor

instance_destroy(other);

if(_range_multiplier != .25)
{
	_range_multiplier -= .25;
}

alarm[2] = 10 * game_get_speed(gamespeed_fps);
