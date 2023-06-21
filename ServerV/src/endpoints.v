import vweb
import x.json2

['/addrecord'; post]
pub fn (mut s Server) add_record() vweb.Result {
	s.records << json2.decode[Record](s.req.data) or {
		eprintln('Error decoding json: ${err.msg()}')
		return s.server_error(400)
	}
	
	s.write_records() or {
		eprintln('Error adding record: ${err.msg()}')
		return s.server_error(500)
	}

	return s.ok('Record added')
}

['/deleterecord/:id'; delete]
pub fn (mut s Server) delete_record(id string) vweb.Result {
	if id == '' {
		s.set_status(400, '')
		return s.text('No id provided')
	}
	
	mut deleted := false
	for i, r in s.records {
		if r.id == id {
			s.records.delete(i)
			deleted = true
		}
	}

	s.write_records() or {
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
	return s.json(json2.encode(s.records))
}