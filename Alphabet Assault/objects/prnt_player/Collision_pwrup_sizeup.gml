/// @description increases bullet size
// You can write your code in this editor

_size_multiplier += .25;
instance_destroy(other);
alarm[2] = 30 * game_get_speed(gamespeed_fps);
