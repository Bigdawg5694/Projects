/// @description create hint array based on crab or lobster
// You can write your code in this editor
var _crab_end = random_range(0,1);

if (_crab_end == 1)
{
	_hints = ["covered with a thick exoskeleton", "six walking legs and two swimming legs",
	"breathes through gills on its underside", "typically walk sideways",
	"feed on algae", "Cancer"];
}
else
{
	_hints = ["one of the most profitable commodities in coastal areas", "invertebrates with a protective exoskeleton",
	"two main body parts: the cephalothorax and the abdomen", "dark colored, either bluish-green or greenish-brown",
	"live up to 45-50 years in the wild", "grow throughout life"];
}
 
 sprite_array = [spr_WWII, spr_algonquin, spr_bees, spr_bibliotherapy, spr_crab_hyp, spr_ceti, spr_cryptozoology, spr_einstein, spr_gatsby, spr_inception, spr_liquid_death, spr_lobster_hyp, spr_lockheed, spr_minecraft, spr_morality, spr_numismatics, spr_pigs, spr_quantum, spr_queen];
 scr_hyperlink_sprite(sprite_array);
 draw_sprite(sprite_index, 0, 0, 0);
