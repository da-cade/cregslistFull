CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';

CREATE TABLE IF NOT EXISTS cars(
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  color VARCHAR(255),
  make VARCHAR(255),
  model VARCHAR(255),
  imgUrl VARCHAR(255),
  price INT,
  year INT,
  creatorId VARCHAR(255) NOT NULL
  -- FOREIGN KEY (creatorId)
  --   REFERENCES accounts(id)
  --   ON DELETE CASCADE

) default charset utf8 ;

CREATE TABLE IF NOT EXISTS houses(
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  bedrooms INT,
  bathrooms INT,
  levels INT,
  year INT,
  price INT,
  imgUrl VARCHAR(255),
  description VARCHAR(255),
  creatorId VARCHAR(255) NOT NULL
) default charset utf8 ;

CREATE TABLE IF NOT EXISTS jobs(
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  title VARCHAR (255),
  company VARCHAR (255),
  description VARCHAR (255),
  startsAt VARCHAR (255),
  location VARCHAR(255),
  creatorId VARCHAR(255) NOT NULL
) default charset utf8 ;