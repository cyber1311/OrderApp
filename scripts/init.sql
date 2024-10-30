create table districts (
    id serial primary key not null,
    name varchar not null
);

create table orders (
    id uuid primary key not null,
    weight numeric not null,
    district_id bigint not null references districts (id),
    delivery_time timestamp not null
);

create table delivery_log (
    id uuid primary key not null,
    type varchar not null,
    message varchar not null,
    time timestamp not null
);

create table delivery_order (
    id uuid primary key not null,
    weight numeric not null,
    district varchar not null,
    delivery_time timestamp not null
);

insert into districts
values (1, 'Central'),
(2, 'South'),
(3, 'North'),
(4, 'East'),
(5, 'West');

insert into
    orders
values (
        gen_random_uuid (),
        1.4,
        1,
        '2024-01-01 12:34:47'
    ),
    (
        gen_random_uuid (),
        2.5,
        2,
        '2024-01-01 12:40:31'
    ),
    (
        gen_random_uuid (),
        5.2,
        1,
        '2024-01-01 12:43:07'
    ),
    (
        gen_random_uuid (),
        3.8,
        3,
        '2024-01-01 12:44:09'
    ),
    (
        gen_random_uuid (),
        0.2,
        1,
        '2024-01-01 12:49:22'
    ),
    (
        gen_random_uuid (),
        3.4,
        3,
        '2024-01-01 12:50:11'
    ),
    (
        gen_random_uuid (),
        1.5,
        1,
        '2024-01-01 12:55:14'
    ),
    (
        gen_random_uuid (),
        1.2,
        3,
        '2024-01-01 12:58:01'
    ),
    (
        gen_random_uuid (),
        3.6,
        4,
        '2024-01-01 13:00:04'
    ),
    (
        gen_random_uuid (),
        10.1,
        5,
        '2024-01-01 13:01:10'
    ),
    (
        gen_random_uuid (),
        8.0,
        2,
        '2024-01-01 13:05:42'
    ),
    (
        gen_random_uuid (),
        11.5,
        4,
        '2024-01-01 13:07:30'
    ),
    (
        gen_random_uuid (),
        0.7,
        5,
        '2024-01-01 13:07:56'
    ),
    (
        gen_random_uuid (),
        4.3,
        2,
        '2024-01-01 13:09:55'
    ),
    (
        gen_random_uuid (),
        0.2,
        3,
        '2024-01-01 13:10:31'
    ),
    (
        gen_random_uuid (),
        0.8,
        4,
        '2024-01-01 13:12:20'
    ),
    (
        gen_random_uuid (),
        5.9,
        5,
        '2024-01-01 13:14:40'
    ),
    (
        gen_random_uuid (),
        7.1,
        1,
        '2024-01-01 13:15:13'
    ),
    (
        gen_random_uuid (),
        7.3,
        3,
        '2024-01-01 13:16:26'
    ),
    (
        gen_random_uuid (),
        2.6,
        4,
        '2024-01-01 13:18:34'
    ),
    (
        gen_random_uuid (),
        0.8,
        5,
        '2024-01-01 13:19:56'
    ),
    (
        gen_random_uuid (),
        6.2,
        2,
        '2024-01-01 13:24:32'
    ),
    (
        gen_random_uuid (),
        2.9,
        3,
        '2024-01-01 13:29:45'
    ),
    (
        gen_random_uuid (),
        3.5,
        1,
        '2024-01-01 13:31:05'
    ),
    (
        gen_random_uuid (),
        0.1,
        5,
        '2024-01-01 13:35:37'
    ),
    (
        gen_random_uuid (),
        0.7,
        2,
        '2024-01-01 13:36:41'
    ),
    (
        gen_random_uuid (),
        9.0,
        3,
        '2024-01-01 13:36:43'
    ),
    (
        gen_random_uuid (),
        3.2,
        4,
        '2024-01-01 13:37:22'
    ),
    (
        gen_random_uuid (),
        5.4,
        5,
        '2024-01-01 13:39:56'
    ),
    (
        gen_random_uuid (),
        8.8,
        2,
        '2024-01-01 13:40:05'
    ),
    (
        gen_random_uuid (),
        0.4,
        3,
        '2024-01-01 13:44:02'
    ),
    (
        gen_random_uuid (),
        6.5,
        4,
        '2024-01-01 13:46:19'
    ),
    (
        gen_random_uuid (),
        7.9,
        5,
        '2024-01-01 13:50:07'
    ),
    (
        gen_random_uuid (),
        0.6,
        1,
        '2024-01-01 13:52:06'
    ),
    (
        gen_random_uuid (),
        2.2,
        3,
        '2024-01-01 13:54:00'
    ),
    (
        gen_random_uuid (),
        5.1,
        4,
        '2024-01-01 13:57:40'
    ),
    (
        gen_random_uuid (),
        9.5,
        1,
        '2024-01-01 13:59:27'
    ),
    (
        gen_random_uuid (),
        6.1,
        2,
        '2024-01-01 14:00:03'
    ),
    (
        gen_random_uuid (),
        8.9,
        3,
        '2024-01-01 14:02:34'
    ),
    (
        gen_random_uuid (),
        4.5,
        4,
        '2024-01-01 14:03:05'
    ),
    (
        gen_random_uuid (),
        5.6,
        5,
        '2024-01-01 14:05:10'
    ),
    (
        gen_random_uuid (),
        7.0,
        2,
        '2024-01-01 14:06:34'
    ),
    (
        gen_random_uuid (),
        11.9,
        3,
        '2024-01-01 14:09:10'
    ),
    (
        gen_random_uuid (),
        2.7,
        1,
        '2024-01-01 14:10:03'
    ),
    (
        gen_random_uuid (),
        9.1,
        5,
        '2024-01-01 14:10:41'
    ),
    (
        gen_random_uuid (),
        6.8,
        2,
        '2024-01-01 14:14:50'
    ),
    (
        gen_random_uuid (),
        3.7,
        3,
        '2024-01-01 14:15:30'
    ),
    (
        gen_random_uuid (),
        8.2,
        4,
        '2024-01-01 14:17:39'
    ),
    (
        gen_random_uuid (),
        1.5,
        5,
        '2024-01-01 14:19:50'
    ),
    (
        gen_random_uuid (),
        0.8,
        1,
        '2024-01-01 14:23:07'
    ),
    (
        gen_random_uuid (),
        1.6,
        3,
        '2024-01-01 14:27:08'
    ),
    (
        gen_random_uuid (),
        4.1,
        4,
        '2024-01-01 14:30:01'
    ),
    (
        gen_random_uuid (),
        1.4,
        1,
        '2024-01-01 14:31:17'
    );