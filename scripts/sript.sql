create table __EFMigrationsHistory
(
    MigrationId    varchar(150) not null
        primary key,
    ProductVersion varchar(32)  not null
);

create table addresses
(
    id          int auto_increment
        primary key,
    country     varchar(64)  not null,
    city        varchar(128) not null,
    street      varchar(128) not null,
    street2     varchar(128) null,
    postal_code varchar(10)  null
);

create table branches
(
    id      int auto_increment
        primary key,
    address int null,
    constraint branches_ibfk_1
        foreign key (address) references addresses (id)
);

create index address
    on branches (address);

create table destinations
(
    id          int auto_increment
        primary key,
    name        varchar(128) not null,
    address     int          not null,
    description text         null,
    availible   tinyint(1)   not null,
    rating      int          null,
    constraint destinations_ibfk_1
        foreign key (address) references addresses (id)
);

create index address1
    on destinations (address);

create table photos
(
    id    int  not null
        primary key,
    photo blob not null,
    constraint photos_ibfk_1
        foreign key (id) references destinations (id)
);

create table destinations_photos
(
    destinations_id int not null,
    photos_id       int not null,
    primary key (destinations_id, photos_id),
    constraint destinations_photos_ibfk_1
        foreign key (destinations_id) references destinations (id),
    constraint destinations_photos_ibfk_2
        foreign key (photos_id) references photos (id)
);

create index photos_id
    on destinations_photos (photos_id);

create table rooms
(
    id               int auto_increment
        primary key,
    destination      int                  not null,
    description      text                 null,
    beds             json                 not null,
    availible        tinyint(1) default 1 not null,
    amount_availible int                  null,
    cost_per_night   decimal(15, 2)       not null,
    constraint rooms_ibfk_1
        foreign key (destination) references destinations (id)
);

create index destination
    on rooms (destination);

create table rooms_photos
(
    rooms_id  int not null,
    photos_id int not null,
    primary key (rooms_id, photos_id),
    constraint rooms_photos_ibfk_1
        foreign key (rooms_id) references rooms (id),
    constraint rooms_photos_ibfk_2
        foreign key (photos_id) references photos (id)
);

create index photos_id1
    on rooms_photos (photos_id);

create table tags
(
    id         int auto_increment
        primary key,
    name       varchar(64) not null,
    decription text        null
);

create table tags_destinations
(
    tags_id         int not null,
    destinations_id int not null,
    primary key (tags_id, destinations_id),
    constraint tags_destinations_ibfk_1
        foreign key (tags_id) references tags (id),
    constraint tags_destinations_ibfk_2
        foreign key (destinations_id) references destinations (id)
);

create index destinations_id
    on tags_destinations (destinations_id);

create table tags_rooms
(
    tags_id  int not null,
    rooms_id int not null,
    primary key (tags_id, rooms_id),
    constraint tags_rooms_ibfk_1
        foreign key (tags_id) references tags (id),
    constraint tags_rooms_ibfk_2
        foreign key (rooms_id) references rooms (id)
);

create index rooms_id
    on tags_rooms (rooms_id);

create table users
(
    id         int auto_increment
        primary key,
    email      varchar(256)                        not null,
    password   varchar(64)                         not null,
    name       varchar(255)                        not null,
    surname    varchar(255)                        not null,
    phone_num  varchar(255)                        null,
    addresses  int                                 null,
    created_at timestamp default CURRENT_TIMESTAMP not null,
    constraint users_ibfk_1
        foreign key (addresses) references addresses (id)
);

create table employees
(
    id     int not null
        primary key,
    branch int null,
    constraint employees_ibfk_1
        foreign key (id) references users (id),
    constraint employees_ibfk_2
        foreign key (branch) references branches (id)
);

create table admin
(
    id         int        not null
        primary key,
    can_edit   tinyint(1) not null,
    can_delete tinyint(1) not null,
    constraint admin_ibfk_1
        foreign key (id) references employees (id)
);

create index branch
    on employees (branch);

create table packages
(
    id              int auto_increment
        primary key,
    room            int                                  not null,
    availible       tinyint(1) default 1                 not null,
    created_by      int                                  not null,
    created_at      timestamp  default CURRENT_TIMESTAMP not null,
    deleted_at      timestamp                            null,
    root_package_id int                                  null,
    constraint packages_ibfk_1
        foreign key (room) references rooms (id),
    constraint packages_ibfk_2
        foreign key (created_by) references admin (id),
    constraint packages_ibfk_3
        foreign key (root_package_id) references packages (id)
);

create table orders
(
    package_schedules int        not null,
    userId            int        not null,
    has_been_paid     tinyint(1) not null,
    primary key (package_schedules, userId),
    constraint orders_ibfk_1
        foreign key (package_schedules) references packages (id),
    constraint orders_ibfk_2
        foreign key (userId) references users (id)
);

create index userId
    on orders (userId);

create table package_schedules
(
    id         int auto_increment
        primary key,
    package_id int      not null,
    date_start date     not null,
    days       smallint not null,
    constraint package_schedules_ibfk_1
        foreign key (package_id) references packages (id)
);

create index package_id
    on package_schedules (package_id);

create index created_by
    on packages (created_by);

create index room
    on packages (room);

create index root_package_id
    on packages (root_package_id);

create table tags_packages
(
    tags_id     int not null,
    packages_id int not null,
    primary key (tags_id, packages_id),
    constraint tags_packages_ibfk_1
        foreign key (tags_id) references tags (id),
    constraint tags_packages_ibfk_2
        foreign key (packages_id) references packages (id)
);

create index packages_id
    on tags_packages (packages_id);

create index addresses
    on users (addresses);

create index users_index_0
    on users (email);

