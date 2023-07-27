import db.sqlite

fn (mut s Server) write_record(r Record) ! {
	sql s.db {
		delete from Record where id == r.id
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