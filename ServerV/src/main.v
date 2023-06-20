import os
import vweb
import x.json2

const port = 3000

struct Server {
	vweb.Context
}

// Create and run server
fn main() {
	srv := &Server {}
	println('Server started on port ${port}!')

	vweb.run_at(srv, port: port, nr_workers: 1, show_startup_message: false) or {
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
	mut records := json2.raw_decode(os.read_file('../Server/records.json')!)!.arr()
	records << json2.raw_decode(json)!
	os.write_file('../Server/records.json', json2.encode(records))!
}