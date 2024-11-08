// shoots a bullet from a player with a set range and direction depending on the player
function scr_bullet_movement(position_x, position_y, range, dir, size){
	// creates the bullet
	bullet = instance_create_depth(position_x, position_y, 0, obj_bullet)
	
	// gets the bullet moving in the set direction and sets the timer for bullet life
	with(bullet)
	{
		image_xscale += (size - 1);
		image_yscale = image_xscale;
		
		motion_set(dir, 20) // moves in direction based on character
		alarm_set(0, range) // time bullet exists is based on player range
	}

}