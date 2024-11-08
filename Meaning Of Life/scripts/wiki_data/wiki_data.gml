// fuck the wikipedia api

function get_wiki_data() {
/// @desc Creates a struct containing the wiki's title and the wiki's description. Basically a sloppy tie-together of the other functions. I'm so sorry.

var _tmp_title = choose_random_title()
var _tmp_blurb = _tmp_title + " " + choose_random_blurb()

		var wikidata = {
			title: _tmp_title,
			blurb: _tmp_blurb
		}
		
	return wikidata
}