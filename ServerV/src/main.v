import vweb
import db.sqlite

const port = 6969
const use_keys = false

struct Server {
	vweb.Context
	middlewares map[string][]vweb.Middleware
mut:
	db sqlite.DB
}

// Create and run server
fn main() {	
	mut srv := &Server {}

	srv.init()!

	println('Server started on port ${port}!')

	vweb.run_at(srv, port: port, nr_workers: 1, show_startup_message: false) or {
		eprintln('Failed to start server: ${err.msg()}')
		exit(1)
	}

	srv.db.close()!
}

pub fn (mut s Server) before_request() {
	if use_keys && !s.is_authorised() {
		s.set_status(401, '')
		s.text('Not authorised')
	}
}