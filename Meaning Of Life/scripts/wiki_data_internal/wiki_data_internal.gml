

function choose_random_title(){
	
	// List of Starters
	var _start = [
		"The Great",
		"The Amazing",
		"The Faraway",
		"The Slightly Underwhelming",
		"The Legend of the",
		"The God-Awful",
		"The Mediocre",
		"The Long Lost",
		"The Strange",
		"The Unusual",
		"The Shitty",
		"The Crappy",
		"The Bootleg",
		"The Completely",
		"The Average",
		"The Statue of the",
		"The Trivial",
		"The Failed",
		"The Sad",
		"The Depressed",
		"The Tragic Story of the",
		"The Lonely",
		"The Random",
		"The Weird",
		"The Politically Incorrect",
		"The Missing",
		"The Hidden",
		"The Buried",
		"The Overpowered",
	]
	
	// List of Adjectives
	var _mid = [
		"Digital",
		"Silly",
		"Sparkly",
		"Golden",
		"Overpriced",
		"Freshly Baked",
		"Undercooked",
		"Raw",
		"Annoying",
		"Haunted",
		"Sexy",
		"Unfunny",
		"Ugly",
		"Dimly Lit",
		"Stupid",
		"Stinky",
		"Cold",
		"Hot",
		"Paranormal",
		"Parody of the",
		"Rip-off",
		"Questionable",
		"Probably Illegal",
		"Oddly Shaped",
		"Broken",
	]
	
	// List of Nouns
	var _end = [
		"Cat",
		"Dog",
		"Calculator",
		"Keyboard",
		"Ice Cream",
		"Train",
		"Trail Mix",
		"Oreo",
		"2003 Honda Accord EX",
		"2008 Toyota Corolla",
		"2001 Cuisinart Toaster",
		"Demoman (Team Fortress 2)",
		"Joe Biden",
		"Parachute",
		"SoundCloud Mixtape",
		"Chris Pratt",
		"Elden Ring DLC",
		"Minecraft Update",
		"Super Mario 64 TAS Speedrun",
		"Advertisement",
		"RAID: Shadow Legends Sponsorship",
		"Mentorship",
		"Twitter Outrage",
		"Discord Moderator",
		"Anime Protagonist",
		"Phone Charger",
		"Samung Galaxy S22",
		"iPhone X",
		"Elon(gated) Musk(rat)",
		"Overwatch Loot Box",
		"Internet Search History",
		"Old Spice Odor-blocking Body Wash",
		"Walter White (Breaking Bad)",
		"Pornography Starring Your Mother",
		"Backpack",
		"Corsiar Gaming Mouse",
		"iPad Mini",
		"Mario Kart Track",
		"Hatsune Miku Song",
		"Minecraft Server",
		"Water Bottle",
		"Fanfiction",
		"Fanart",
		"Software Update",
		"Frying Pan"
		
	]

	return better_choose(_start) + " " + better_choose(_mid) + " " + better_choose(_end)
}

function choose_random_blurb(){
	// The template is the main meat of the paragraph. The placeholders are there for the random selection to be chosen.
	
	
	// all placeholders:
	// 0: videogame genre (adventure, first person shooter, open world, match-three, puzzle, idle clicker, sandbox)
	// 1: feature (obnoxious storyline, GPU-frying graphics, eye-frying graphics, endless quests, interative love scenes, unfair lootboxes, overpriced DLC)
	// 2: console (iOS devices, Android devices, all modern gaming consoles, PCs, Samsung Smart Refridgerators, the Nintendo 3DS specifically ...
	// ... Tamagotchis)
	// 3: price tag: Free, $29.99, $59.99, $129.99, $699.42, the price of the Golden Frying Pan from Team Fortress 2)
	// 4: age rating (E for everyone, E10+, T for Teens, M for Mature, AO for Adults Only, B for Banned in Multiple Countries)
	// 5: game rating (complete waste of time, memorable experience, buggy mess, rip off of a triple A game, greedy cash-grab, PowerPoint presentation because
	// ... of terribly optimized it is, tedious grind simulator, ad-infested hell, disgrace to humanity, blessing to humanity, piece of shit)
	
	var _blurb_template_videogame_vocab = {
		videogame_genres: ["adventure","first-person shooter", "open world", "match-three", "puzzle", "idle clicker", "sandbox", "romance visual novel"],
		feature: ["obnoxious storyline", "GPU-frying graphics", "eye-frying graphics", "endless quests", "interative love scenes", "unfair lootboxes", "overpriced DLC",
		"souls-like gameplay"],
		console: ["iOS devices", "Android devices", "all modern gaming consoles", "PCs", "Samsung Smart Refrigerators", "the Nintendo 3DS exclusively", "Tamogotchis"],
		pricetag: ["free", "$29.99", "$59.99", "$69.42", "$129.99", "the average cost of a home", "the price of the Golden Frying Pan from Team Fortress 2",
		"free if you tell the devs the last four of your social security number", "the monthly cost of your mother's onlyfans"],
		age_rating: ["E (everyone)", "E10+ (everyone aged 10 and up)", "T (teens)", "M (mature)", "AO (adults only)", "BiMC (banned in multiple countries)"],
		critic_rating: ["complete waste of time", "good game, but not as good as the original Crash Bandicoot", "educational experience", "buggy mess", "greedy cash grab",
		"PowerPoint presentation because of how terribly optimized it is", "tedious grind simulator", "ad-infested hell", "disgrace to humanity", "blessing to humanity",
		"piece of shit", "terrible introduction to video games", "poor bastard's sexual fantasy"]
	}
	
	var _blurb_template_videogame = string("is a {0} video game known for it's {1}. It is available for {2} for {3}, and it is rated {4}. Critics described this game as a {5}.",
	better_choose(_blurb_template_videogame_vocab.videogame_genres), better_choose(_blurb_template_videogame_vocab.feature),
	better_choose(_blurb_template_videogame_vocab.console), better_choose(_blurb_template_videogame_vocab.pricetag),
	better_choose(_blurb_template_videogame_vocab.age_rating), better_choose(_blurb_template_videogame_vocab.critic_rating))
	
	return _blurb_template_videogame
}
