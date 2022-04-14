CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';
INSERT INTO
  accounts (id, name)
VALUES
  ("1243de", "Hannah");
SELECT
  *
FROM
  accounts;
CREATE TABLE IF NOT EXISTS follows(
    id INT AUTO_INCREMENT PRIMARY KEY,
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    followingId VARCHAR(255) NOT NULL,
    followerId VARCHAR(255) NOT NULL,
    FOREIGN KEY (followingId) REFERENCES accounts(id) ON DELETE CASCADE,
    FOREIGN KEY (followerId) REFERENCES accounts(id) ON DELETE CASCADE
  ) default charset utf8 COMMENT '';