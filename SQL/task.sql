CREATE TABLE status_types (
    id INT PRIMARY KEY,
    status_name VARCHAR(20)
);

INSERT INTO status_types (id, status_name) VALUES
(1, 'standby'),
(2, 'ready'),
(3, 'preparing'),
(4, 'completed'),
(5, 'stopped');

CREATE TABLE tasks (
    id INT PRIMARY KEY,
    status_id INT,
    FOREIGN KEY (status_id) REFERENCES status_types(id)
);
