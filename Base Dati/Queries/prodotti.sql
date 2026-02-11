use its2026;

/*select type1, count(type1) as quantity
from pokemon 
Group by type1
order by quantity desc;*/


create table products(
	product_id int primary key auto_increment,
    product_name varchar(30) not null,
    price decimal(6,2) not null default 0.00, -- 6 cifre di cui 2 dopo la virgola: 1234,56
    category_id int not null
);

create table category(
	category_id int primary key auto_increment,
    category_name varchar(30) not null
);

-- insert into products (product_name, price, category_id) values ("smartphone usato", 58, 1);
-- insert into products (product_name, price, category_id) values ("maglia blu", 8, 2);
-- insert into products (product_name, price, category_id) values ("pantalone verde usato", 58, 2);

-- insert into category (category_name) value("abbigliamento");

select * from products;
select * from category;

select products.product_name, products.price, category.category_name from products, category 
where products.category_id = category.category_id;

-- update category set category_name = 'fashion' where category_id = '2';

