fn (mut s Server) is_authorised() bool {
	key := s.get_header('key')
	if key in s.keys {
		return true
	}
	return false
}