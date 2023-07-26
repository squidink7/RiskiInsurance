struct Key {
	data string
}

fn (mut s Server) is_authorised() bool {
	user_key := s.get_header('key')
	number_of_keys_in_table := sql s.db {
		select count from Key where data == user_key
	} or { 0 }
	return number_of_keys_in_table > 0
}