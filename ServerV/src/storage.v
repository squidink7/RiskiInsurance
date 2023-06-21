import os
import x.json2

const storage_file = '../Server/records.json'

fn (s Server) write_records() ! {
	os.write_file(storage_file, json2.encode_pretty(s.records))!
}

fn (mut s Server) load_records() ! {
	s.records = json2.decode[[]Record](os.read_file(storage_file)!)!
}