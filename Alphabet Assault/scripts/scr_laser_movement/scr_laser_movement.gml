// shoots a laser from a player with a set range and direction depending on the player
function scr_laser_movement(position_x, position_y, range, dir){
	// creates the bullet
	laser = instance_create_depth(position_x, position_y, 0, obj_laser)
	
	// spawns the laser in the set direction and sets the timer for laser life
	with(laser)
	{
		image_angle = dir // makes sure the laser sprite is facing the direction it is shot
		image_xscale += range // length of the laser is based on player range
		alarm_set(0, 10) // time laser exists is NOT based on player range
	}

}