/// @description increases move speed
// You can write your code in this editor

_speed_multiplier += .25;
instance_destroy(other);
alarm[0] = 30 * game_get_speed(gamespeed_fps);
