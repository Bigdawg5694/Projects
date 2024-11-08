
function better_choose(list, return_index = false){
	/// @desc													select and return a random element from an array. 
	/// @function												better_choose(array)
	/// @param {Id.DsList, Array} list				a list or array to choose random elements from.
	/// @param {Bool} return_index				If true, will return the index of the array as an int instead of the object in the array. Defaults to false.

	randomize()
	
	
	var _list_len
	if is_array(list) {
		_list_len = array_length(list)
	} else {
		_list_len = ds_list_size(list)
	}
	
	if not return_index {
		var _tmp_int = irandom(_list_len)
		if _tmp_int == _list_len {
			_tmp_int -= 1
		}
		return list[_tmp_int]
	} else {
		var _tmp_int = irandom(_list_len)
		if _tmp_int == _list_len {
			_tmp_int -= 1
		}
		return _tmp_int
	}
}
