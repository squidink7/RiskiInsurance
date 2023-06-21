import vweb

const port = 3000

struct Server {
	vweb.Context
mut:
	records []Record
}

// Create and run server
fn main() {	
	mut srv := &Server {}

	srv.load_records() or {
		eprintln('Failed loading records')
	}

	println('Server started on port ${port}!')

	vweb.run_at(srv, port: port, nr_workers: 1, show_startup_message: false) or {
		eprintln('Failed to start server: ${err.msg()}')
		exit(1)
	}
}