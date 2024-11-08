/// @description Insert description here
// You can write your code in this editor

instance_destroy(other);

if(_speed_multiplier != .25)
{
	_speed_multiplier -= .25;
}

alarm[0] = 10 * game_get_speed(gamespeed_fps);
