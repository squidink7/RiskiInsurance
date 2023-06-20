module main

import os
import vweb
import x.json2

struct Server {
	vweb.Context
}

// Create and run server
fn main() {
	srv := &Server {}

	vweb.run_at(srv, port: 3000, nr_workers: 1) or {
		eprintln('Failed to start server: ${err.msg()}')
		exit(1)
	}
}

// Add record
['/addRecord'; post]
pub fn (mut s Server) add_record() vweb.Result {
	write_record(s.req.data) or { return s.server_error(500) }

	return s.ok('Record added!')
}

fn write_record(json string) ! {
	records_data := os.read_file('../Server/records.json')!
	mut records := (json2.raw_decode(records_data)!).arr()
	records << json2.raw_decode(json)!
	os.write_file('../Server/records.json', json2.encode(records))!
}