import vweb

['/addRecord'; post]
pub fn (mut s Server) add_record() vweb.Result {
	write_record(s.req.data) or {
		eprintln('Error adding record: ${err.msg()}')
		return s.server_error(500)
	}

	return s.ok('Record added!')
}