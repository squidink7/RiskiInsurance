import os
import x.json2

const storage_file = '../Server/records.json'
const keys_file = '../Server/keys.txt'

fn (s Server) write_records() ! {
	os.write_file(storage_file, json2.encode_pretty(s.records))!
}

fn (mut s Server) load_all() ! {
	s.records = load_records()!
	s.keys = load_keys()!
}

fn load_records() ![]Record {
	return json2.decode[[]Record](os.read_file(storage_file)!)!
}

fn load_keys() ![]string {
	return os.read_lines(keys_file)!
}