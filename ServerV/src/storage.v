import db.sqlite

const storage_file = '../Server/records.json'
const keys_file = '../Server/keys.txt'

fn (mut s Server) write_record(r Record) ! {
	sql s.db {
		insert r into Record
	}!
}

fn (mut s Server) remove_record(rid string) ! {
	sql s.db {
		delete from Record where id == rid
	}!
}

fn (mut s Server) init() ! {
	s.db = sqlite.connect('data.db')!

	sql s.db {
		create table Record
		create table Key
	}!
}

fn (mut s Server) records() []Record {
	return sql s.db {
		select from Record
	} or { []Record{} }
}