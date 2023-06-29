import vweb
import x.json2

const port = 3000
const use_keys = false

struct Server {
	vweb.Context
	middlewares map[string][]vweb.Middleware
mut:
	keys []string
	records []Record
}

// Create and run server
fn main() {	
	mut srv := &Server {}

	srv.load_all() or {
		eprintln('Failed loading records')
	}

	println(json2.decode[[]string]('["hi", "hello", "test"]')!)

	println('Server started on port ${port}!')

	vweb.run_at(srv, port: port, nr_workers: 1, show_startup_message: false) or {
		eprintln('Failed to start server: ${err.msg()}')
		exit(1)
	}
}

pub fn (mut s Server) before_request() {
	if use_keys && !s.is_authorised() {
		s.set_status(401, '')
		s.text('Not authorised')
	}
}