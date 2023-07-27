import vweb
import x.json2

['/addRecord'; post]
pub fn (mut s Server) add_record() vweb.Result {
	record := json2.decode[Record](s.req.data) or {
		eprintln('Error decoding json: ${err.msg()}')
		return s.server_error(400)
	}
	
	s.write_record(record) or {
		eprintln('Error adding record: ${err.msg()}')
		return s.server_error(500)
	}

	return s.ok('Record added')
}

['/deleteRecord'; delete]
pub fn (mut s Server) delete_record() vweb.Result {
	id := s.query['ID']
	if id == '' {
		s.set_status(400, '')
		return s.text('No id provided')
	}
	
	mut deleted := false
	for _, r in s.records() {
		if r.id == id {
			deleted = true
		}
	}

	s.remove_record(id) or {
		eprintln('Error removing record: ${err.msg()}')
		return s.server_error(500)
	}

	if deleted {
		return s.ok('Record deleted')
	} else {
		return s.ok('No record to delete')
	}
}

['/records'; get]
pub fn (mut s Server) get_records() vweb.Result {
	return s.text(json2.encode(s.records()))
}

['/testConnection'; get]
pub fn (mut s Server) test_connection() vweb.Result {
	return s.ok('')
}