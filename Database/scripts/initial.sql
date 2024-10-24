-- Insert sample categories
INSERT INTO "Categories" ("Name", "Description")
VALUES ('Electronics', 'Devices and gadgets'),
       ('Books', 'Printed and digital books'),
       ('Entertainment', 'Entertainment'),
       ('Clothing', 'Apparel and accessorie,s');

-- Insert sample products
INSERT INTO "Products" ("Name", "Description", "Price", "CategoryId")
VALUES ('Smartphone', 'A high-end smartphone with a large display', 699.90, 1),
       ('Laptop', 'A powerful laptop suitable for gaming and work', 199.90, 1),
       ('Novel', 'A best-selling fiction novel', 49.90, 2),
       ('T-Shirt', 'A comfortable cotton t-shirt', 24.99, 3),
       ('Jeans', 'Stylish denim jeans', 35.90, 3);

-- Insert sample ShippingAddress
INSERT INTO "ShippingAddresses" ("Street", "City", "State", "ZipCode", "Country")
VALUES
('123 Maple St', 'New York', 'NY', '10001', 'USA'),
('456 Oak Ave', 'Los Angeles', 'CA', '90001', 'USA'),
('789 Pine Rd', 'Chicago', 'IL', '60601', 'USA'),
('101 Birch Dr', 'Houston', 'TX', '77001', 'USA'),
('202 Cedar Blvd', 'Miami', 'FL', '33101', 'USA'),
('303 Walnut St', 'San Francisco', 'CA', '94101', 'USA'),
('404 Elm St', 'Seattle', 'WA', '98101', 'USA'),
('505 Ash Ct', 'Boston', 'MA', '02101', 'USA'),
('606 Willow Way', 'Austin', 'TX', '73301', 'USA'),
('707 Fir Ln', 'Denver', 'CO', '80201', 'USA');

-- Insert sample Orders
INSERT INTO "Orders" ("EmailAddress", "TotalAmount", "Status", "CreatedAt", "UpdatedAt", "ShippingAddressId")
VALUES
('john.doe@example.com', 150.75, 'Pending', '2024-10-01 12:35:00', '2024-10-01 12:35:00', 1),
('john.doe@example.com', 220.50, 'Pending', '2024-10-22 10:30:00', '2024-10-22 10:30:00', 1),
('jane.smith@example.com', 85.50, 'Shipped', '2024-09-15 14:22:30', '2024-09-16 10:11:00', 2),
('mike.johnson@example.com', 230.00, 'Delivered', '2024-09-05 09:18:00', '2024-09-08 13:45:20', 3),
('emily.davis@example.com', 420.99, 'Pending', '2024-10-10 08:00:00', '2024-10-10 08:00:00', 4),
('chris.brown@example.com', 99.99, 'Processing', '2024-09-25 16:12:45', '2024-09-26 11:30:00', 5),
('sarah.white@example.com', 75.25, 'Shipped', '2024-08-30 12:45:10', '2024-09-01 09:00:00', 6),
('alex.green@example.com', 180.60, 'Delivered', '2024-09-20 07:35:22', '2024-09-22 14:40:00', 7),
('laura.james@example.com', 135.80, 'Pending', '2024-10-05 18:22:30', '2024-10-05 18:22:30', 8),
('daniel.martin@example.com', 250.10, 'Processing', '2024-09-28 11:45:00', '2024-09-29 10:30:00', 9),
('olivia.walker@example.com', 300.00, 'Shipped', '2024-10-03 15:20:55', '2024-10-04 09:10:00', 10);

--Insert sample OrderItems
INSERT INTO "OrderItems" ("ProductId", "Quantity", "OrderId")
VALUES
(1, 2, 1),
(2, 1, 1),
(3, 4, 2),
(4, 1, 2),
(5, 3, 3),
(5, 2, 3),
(4, 5, 4),
(3, 1, 5),
(2, 3, 6),
(1, 2, 7);


