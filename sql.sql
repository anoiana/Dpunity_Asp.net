use demo;

CREATE TABLE Customers (
    customer_id INT AUTO_INCREMENT PRIMARY KEY,
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50) NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE,
    city VARCHAR(50)
) ENGINE=InnoDB;

CREATE TABLE Products (
    product_id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    category VARCHAR(50),
    price DECIMAL(10, 2) NOT NULL CHECK (price > 0)
) ENGINE=InnoDB;

CREATE TABLE Orders (
    order_id INT AUTO_INCREMENT PRIMARY KEY,
    customer_id INT,
    order_date DATE NOT NULL,
    status VARCHAR(20) DEFAULT 'Pending',
    FOREIGN KEY (customer_id) REFERENCES Customers(customer_id)
) ENGINE=InnoDB;

CREATE TABLE Order_Items (
    order_item_id INT AUTO_INCREMENT PRIMARY KEY,
    order_id INT,
    product_id INT,
    quantity INT NOT NULL CHECK (quantity > 0),
    price_per_item DECIMAL(10, 2) NOT NULL, -- Giá tại thời điểm mua
    FOREIGN KEY (order_id) REFERENCES Orders(order_id),
    FOREIGN KEY (product_id) REFERENCES Products(product_id)
) ENGINE=InnoDB;

INSERT INTO Customers (first_name, last_name, email, city) VALUES
('An', 'Nguyen', 'an.nguyen@email.com', 'Hanoi'),
('Binh', 'Le', 'binh.le@email.com', 'Da Nang'),
('Chi', 'Tran', 'chi.tran@email.com', 'Hanoi'),
('Dung', 'Pham', 'dung.pham@email.com', 'TP. HCM'),
('Em', 'Vo', 'em.vo@email.com', 'TP. HCM');

INSERT INTO Products (name, category, price) VALUES
('Laptop Pro', 'Electronics', 1200.00),
('Smartphone X', 'Electronics', 800.00),
('Wireless Mouse', 'Accessories', 25.50),
('SQL for Beginners', 'Books', 45.00),
('Web Development', 'Books', 55.00);

INSERT INTO Orders (customer_id, order_date, status) VALUES
(1, '2023-10-01', 'Completed'), 
(3, '2023-10-05', 'Completed'), 
(1, '2023-10-15', 'Shipped'), 
(2, '2023-10-20', 'Pending'),   
(4, '2023-10-25', 'Completed'), 
(NULL, '2023-10-28', 'Pending');  

INSERT INTO Order_Items (order_id, product_id, quantity, price_per_item) VALUES
(1, 1, 1, 1200.00),
(1, 3, 2, 25.00),
(2, 4, 1, 45.00),
(2, 5, 1, 55.00),
(3, 2, 1, 790.00),
(4, 3, 1, 25.50),
(5, 1, 1, 1150.00),
(5, 4, 2, 45.00);

-- -------------------------------------------------------------------------------- 
-- Cấp độ 1: Truy vấn cơ bản (SELECT, WHERE, ORDER BY, LIMIT)
-- Lấy tất cả thông tin của các khách hàng (Customers).
-- Lấy tên (name) và giá (price) của tất cả sản phẩm.
-- Lấy tên và giá của các sản phẩm có giá dưới 100.
-- Lấy thông tin các khách hàng sống ở 'Hanoi'.
-- Tìm các sản phẩm thuộc danh mục 'Electronics'.
-- Lấy danh sách sản phẩm, sắp xếp theo giá từ cao xuống thấp.
-- Lấy thông tin của 3 sản phẩm đắt nhất.
-- Tìm các đơn hàng được đặt sau ngày '2023-10-10'.
-- --------------------------------------------------------------------------------------------------------------------------------------------------------------- 
select * from Customers;
select name, price from products;
select name, price from products where price < 100;
select * from customers where city = "Hanoi";
select * from products where category = "Electronics";
select * from products order by price desc;
select * from products order by price desc limit 3;
select * from orders where order_date > '2023-10-10';

-- --------------------------------------------------------------------------------------------------------------------------------------------------------------- 
-- Cấp độ 2: Nối bảng (JOIN)
-- Lấy danh sách các đơn hàng, bao gồm order_id, order_date, và họ tên của khách hàng đã đặt hàng (first_name, last_name).
-- Sử dụng INNER JOIN, hiển thị tên sản phẩm (name) và số lượng (quantity) đã được bán trong mỗi mục của đơn hàng.
-- Sử dụng LEFT JOIN, hiển thị tất cả khách hàng và order_id của các đơn hàng họ đã đặt. Những khách hàng chưa đặt hàng bao giờ cũng phải xuất hiện.
-- Sử dụng RIGHT JOIN, hiển thị tất cả các đơn hàng và email của khách hàng. Những đơn hàng không có khách hàng (đơn của khách vãng lai) cũng phải xuất hiện.
-- Hiển thị thông tin chi tiết của đơn hàng số 1, bao gồm: order_id, order_date, tên khách hàng, tên sản phẩm, số lượng, và giá mỗi sản phẩm. (Yêu cầu JOIN 3 bảng).
select order_id, order_date, first_name, last_name
from orders o
join customers c on o.customer_id = c.customer_id;

select p.name, oi.quantity
from products p
inner join Order_Items oi on p.product_id = oi.product_id;

select c.first_name, c.last_name, o.order_id
from Customers c
left join Orders o on c.customer_id = o.customer_id;

select o.order_id, o.order_date, o.status, c.email
from Customers c 
right join Orders o ON c.customer_id = o.customer_id;

select o.order_id, o.order_date, c.first_name, c.last_name, p.name, oi.quantity, p.price
from orders o
join customers c on o.customer_id = c.customer_id
join Order_Items oi on oi.order_id = o.order_id
join products p on oi.product_id = p.product_id
where o.order_id = 1;

-- --------------------------------------------------------------------------------------------------------------------------------------------------------------- 
-- Cấp độ 3: Tổng hợp dữ liệu (GROUP BY, HAVING)
-- Đếm số lượng khách hàng ở mỗi thành phố (city).
-- Tính tổng số tiền cho mỗi đơn hàng. (Gợi ý: trong bảng Order_Items, bạn cần tính quantity * price_per_item cho mỗi dòng, sau đó SUM() và GROUP BY order_id).
-- Tìm danh mục sản phẩm (category) nào có nhiều hơn 1 sản phẩm.
-- Tìm khách hàng (customer_id) đã đặt nhiều hơn 1 đơn hàng.
-- Tính tổng doanh thu từ mỗi sản phẩm. (Gợi ý: tương tự bài 15 nhưng GROUP BY product_id).
-- Tìm những đơn hàng có tổng giá trị lớn hơn 1000. (Gợi ý: Kết hợp bài 15 và HAVING).
-- (Thử thách) Tìm tên của khách hàng đã chi tiêu nhiều tiền nhất.
select  city, count(*) as so_luong_khach_hang
from customers
group by city;

select order_id, sum(price_per_item * quantity) as tong_so_tien
from order_items
group by order_id;

select category, count(*) as so_luong_san_pham
from products
group by category
having so_luong_san_pham > 1;

select customer_id, count(*) as so_luong
from orders
group by customer_id
having so_luong > 1;

select oi.product_id, sum(quantity * price_per_item) as Tong_doanh_thu
from order_items oi
group by product_id;

select oi.order_id, sum(quantity * price_per_item) as tong_gia_tri_don_hang
from order_items oi
group by oi.order_id
having tong_gia_tri_don_hang > 1000
order by tong_gia_tri_don_hang desc;

select oi.order_id, sum(quantity * price_per_item) as tong_gia_tri_don_hang
from order_items oi
group by oi.order_id
having tong_gia_tri_don_hang > 1000;

select c.customer_id, c.first_name, c.last_name, sum(quantity * price_per_item) as tong_chi_tieu
from customers c
join orders o on c.customer_id = o.customer_id
join order_items oi on o.order_id = oi.order_id
group by c.customer_id, c.first_name, c.last_name
order by tong_chi_tieu desc
limit 1;












