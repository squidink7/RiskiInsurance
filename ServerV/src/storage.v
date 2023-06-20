import os
import x.json2

fn write_record(json string) ! {
	mut records := json2.raw_decode(os.read_file('../Server/records.json')!)!.arr()
	records << json2.raw_decode(json)!
	os.write_file('../Server/records.json', json2.encode(records))!
}