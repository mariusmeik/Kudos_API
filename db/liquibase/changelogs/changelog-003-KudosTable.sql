CREATE TABLE public.kudos (
	id serial4 NOT NULL,
	receiver_id int,
    giver_id int,
	reason_id int,
    thanks_message varchar(50) NULL,
	is_claimed boolean,
   	created_date timestamp,
	CONSTRAINT kudos_pkey PRIMARY KEY (id),
    CONSTRAINT fk_receiver FOREIGN KEY(receiver_id) REFERENCES employe(id),
    CONSTRAINT fk_giver FOREIGN KEY(giver_id) REFERENCES employe(id),
	CONSTRAINT fk_reason FOREIGN KEY(reason_id) REFERENCES reason(id)
);